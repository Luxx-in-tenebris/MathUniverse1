using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public int Mod_Of_The_Game;//0-турнир, 1-тренировка
	public GameObject[] answers; //варианты ответа
    public GameObject question;
    public Vector3 spawnValues; //для вариантов ответа
	public int answerCount;
	public float startWait;
    public float waitQuestion;
    public float waveWait;

    public GameObject explosion;
    public GameObject playerExplosion;
    int[] left_multiplier = new int[3];
    int[] right_multiplier = new int[3];
    int[] otvet = new int[3];
    public Text scoreText;
    private int SUMscore=0;
    public Text scoreText1;
    public Text SpeedText;
    private float SUMspeed=17f;
    public Text SpeedText1;
    public GameObject Game_Over;

    private string[] all_multipliers = new string[3];// оба слагаемых(множителя) будут записаны в строку
    private bool gameOver;
	private int score;

    //ПАРАМЕТРЫ ИЗ ГЛАВНОГО МЕНЮ
    private float speed = -1.35f; //начальная скорость метеоритов
    private float Stars_speed = 1;
    public ParticleSystem stars;
    public Done_Mover[]Mover_Scripts;
    //для суммирования
    private int Up_limit_SUM=99;
    private int Down_limit_SUM=15;
    //для вычитания
    private int TheHighestNumber_SUB=99;
    private int down_limit_SUB=10;
    //для умножения

    private int down_limit_MUL=15;
    private int Up_limit_MUL = 99;
    //для деления
    private int TheHighestNumber_DIV=99;
    private int TheSmallestNumber_DIV=10;


    //скрипты генераторов
    private Divide_generator Div_gen;
    private Multiplication_generator Mul_gen;
    private Summation_generator Sum_gen;
    private Subtraction_generator Sub_gen;
    //private bool PlayerCrossedRightAsteroid=true;//если  игрок пересек правильный астероид 



    void Start ()
	{

        SpeedText.text = "Cкорость: " + SUMspeed + " км/с";
        SpeedText1.text = "Cкорость: " + SUMspeed + " км/с";
        //найдем скрипты генераторов
        Div_gen = this.GetComponent<Divide_generator>();
        Mul_gen = this.GetComponent<Multiplication_generator>();
        Sum_gen = this.GetComponent<Summation_generator>();
        Sub_gen = this.GetComponent<Subtraction_generator>();
        set_atributes();

        gameOver = false;
        Game_Over.SetActive(false);
		score = 0;
		UpdateScore ();
        for (int i = 0; i < answers.Length; i++)
        {
            Transform Text1 = answers[i].transform.Find("Text");
            TextMesh text_of_right_answer = Text1.GetComponent<TextMesh>();
            text_of_right_answer.text = "0";
        }
        StartCoroutine(SpawnAsteroids());
    }

    private void Update()
    {
        if(!Player)
        {
            GameOver();
        }
    }
    //для доступа к функции извне, а очнее при столкновении метеорита с кораблем игрока
    public void Access_to_SpawnAsteroids()
    {
        StartCoroutine(SpawnAsteroids());
        return;
    }

    private IEnumerator SpawnAsteroids()
	{
        question.SetActive(false);
        yield return new WaitForSeconds (startWait);

        //маску выставляяем одну для всех астероидов, чтобы потом выделить отдельную маску правильному варианту ответа
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].tag = "WrongAsteroid";
        }


        //генерируем варианты ответа и сам ответ
        generation();

        //раздлеяем строку и ввытаскиваем из нее правильный ответ и левый и правый множители 
        string[] str = all_multipliers[0].Split(new[] { ' ' });



        //выводим вопрос(он же правильный ответ)
        TextMesh text_of_question = question.GetComponent<TextMesh>();
        text_of_question.text = str[1];

        question.SetActive(true);
        yield return new WaitForSeconds(waitQuestion);

        //генерируем индекс метеорита, в котором будет правильный ответ
        int index_of_right_asteroid = Random.Range(0, answers.Length);

        //выводим на метеорит получившиеся множители
        Transform Text1 = answers[index_of_right_asteroid].transform.Find("Text");
        TextMesh text_of_right_answer = Text1.GetComponent<TextMesh>();
        text_of_right_answer.text = str[0];

        answers[index_of_right_asteroid].tag = "RightAsteroid";

        int j = 0;//для того чтобы корректно прилипить неправильные варианты к астероидам
        for (int i = 0; i < answers.Length; i++)
        {
            if(i!= index_of_right_asteroid)
            {
                j++;
                Transform Text = answers[i].transform.Find("Text");
                TextMesh text_of_ = Text.GetComponent<TextMesh>();
                text_of_.text = all_multipliers[j];
            }
        }

            Vector3 spawnPosition;
        float increase_x = -spawnValues.x;
        float delta = 0;//правильный ответ будет слегка позади неправильных ответов, чтобы не возникало проблемы с вызывом OnCollisionEnter

        for (int i = 0; i < answers.Length; i++)
		{
            if (i== index_of_right_asteroid)
                delta = 0.06f;
            else
                delta = 0;
            spawnPosition = new Vector3(increase_x, 0, spawnValues.z+delta);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (answers[i], spawnPosition, spawnRotation);
            increase_x += spawnValues.x*2/ answers.Length+0.85f;
        }
        updateSpeedAndDifficulty();
    }
    //===========================================================================================================================================================================================	
    //===========================================================================================================================================================================================
    //===========================================================================================================================================================================================
    public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
        UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Счёт: " + score;
        scoreText1.text = "Счёт: " + score;
        SUMscore += score;

    }
	
	public void GameOver ()
	{
        Time.timeScale = 0.1f;
        if(Mod_Of_The_Game==0)
        {
            //если увеличение чисел
            if (PlayerPrefs.HasKey("Difficulty"))
            {
                if (PlayerPrefs.GetInt("Difficulty") == 1 && (PlayerPrefs.GetInt("Speed")) == 0)
                {
                    PlayerPrefs.SetString("Score_Difficulty", "" + SUMscore);
                    PlayerPrefs.Save();
                }
            }
            //если скорость
            if (PlayerPrefs.HasKey("Speed"))
            {
                if (PlayerPrefs.GetInt("Speed") == 1 && PlayerPrefs.GetInt("Difficulty") == 0)
                {
                    PlayerPrefs.SetString("Score_Speed", "" + SUMscore);
                    PlayerPrefs.SetString("Speed_Speed", "" + SUMspeed);
                    PlayerPrefs.Save();
                }
            }

            //если все сразу
            if (PlayerPrefs.HasKey("Speed") && (PlayerPrefs.HasKey("Difficulty")))
            {
                if (PlayerPrefs.GetInt("Speed") == 1 && PlayerPrefs.GetInt("Difficulty") == 1)
                {
                    PlayerPrefs.SetString("Score_ALL", "" + SUMscore);
                    PlayerPrefs.SetString("Speed_ALL", "" + SUMspeed);
                    PlayerPrefs.Save();
                }
            }
        }
        
        Game_Over.SetActive(true);	
		gameOver = true;
	}


    void generation()
    {

        if(Mod_Of_The_Game==0)//если турнир
        {
            //случайно получаем следующее действие и варианты ответа
            int random_action = Random.Range(1, 5);

            if (random_action == 1)//деление
                all_multipliers = Div_gen.Get_multipliers_Divide();
            if (random_action == 2)//умножение
                all_multipliers = Mul_gen.Get_multipliers_Multiplication();
            if (random_action == 3)//суммирование
                all_multipliers = Sum_gen.Get_multipliers_Summation();
            if (random_action == 4)//вычитание
                all_multipliers = Sub_gen.Get_multipliers_Subtraction();

            Debug.Log(all_multipliers[0]);
        }

        if (Mod_Of_The_Game == 1)//если тренировка - умножение
        {
            all_multipliers = Mul_gen.Get_multipliers_Multiplication();
        }
        if (Mod_Of_The_Game == 2)//если тренировка - деление
        {
            all_multipliers = Div_gen.Get_multipliers_Divide();
        }  
        if (Mod_Of_The_Game == 3)//если тренировка - сложение
        {           
            all_multipliers = Sum_gen.Get_multipliers_Summation();
        }
        if (Mod_Of_The_Game == 4)//если тренировка - вычитание
        {
            all_multipliers = Sub_gen.Get_multipliers_Subtraction();
        }

    }
    //===========================================================================================================================================================================================
    private void set_atributes()
    {
        if (PlayerPrefs.HasKey("Game_Mod"))
        {
            Debug.Log(PlayerPrefs.GetInt("Game_Mod"));
        }
        Mod_Of_The_Game = PlayerPrefs.GetInt("Game_Mod");

        //скорость метеоритов
        for (int i = 0; i < Mover_Scripts.Length; i++)
        {
            Mover_Scripts[i].set_speed(speed);
        }

        //скорость звезд
        stars.playbackSpeed = Stars_speed;

        if (PlayerPrefs.HasKey("Difficulty"))
        {
            //если включено увеличение чисел, то надо сделать начальные значения меньше
            if (PlayerPrefs.GetInt("Difficulty") == 1)
            {
                Up_limit_SUM = 30;
                Down_limit_SUM = 15;
                //для вычитания
                TheHighestNumber_SUB = 30;
                down_limit_SUB = 10;
                //для умножения
                down_limit_MUL = 15;
                Up_limit_MUL = 30;
                //для деления
                TheHighestNumber_DIV = 30;
                TheSmallestNumber_DIV = 10;
            }
            
        }
        Div_gen.set_Div_params(TheHighestNumber_DIV, TheSmallestNumber_DIV);
        Mul_gen.set_Mul_params(down_limit_MUL, Up_limit_MUL);
        Sum_gen.set_SUM_params(Down_limit_SUM, Up_limit_SUM);
        Sub_gen.set_SUB_params(TheHighestNumber_SUB, down_limit_SUB);
    }
    //===========================================================================================================================================================================================
    private void updateSpeedAndDifficulty()
    {
        //увеличиваем скорость звезды и метеоритов
        if (PlayerPrefs.HasKey("Speed"))
        {
            if (PlayerPrefs.GetInt("Speed") == 1)
            {
                speed -= 0.054f;
                Stars_speed += 0.054f;
                for (int i = 0; i < Mover_Scripts.Length; i++)
                {
                    Mover_Scripts[i].set_speed(speed);
                }
                //скорость звезд
                stars.playbackSpeed = Stars_speed;
                SUMspeed*= Stars_speed;
                SUMspeed = Mathf.RoundToInt(SUMspeed);
            }
        }
        SpeedText.text = "Cкорость: " + SUMspeed+" км/с";
        SpeedText1.text = "Cкорость: " + SUMspeed + " км/с";
        //увеличиваем числа
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            //если включено увеличение чисел, то надо сделать начальные значения меньше
            if (PlayerPrefs.GetInt("Difficulty") == 1 && Mod_Of_The_Game != 0)
            {
                //для суммирования
                if (Up_limit_SUM <= 99)
                    Up_limit_SUM += 2;
                if (Down_limit_SUM <= 40)
                    Down_limit_SUM += 1;
                //для вычитания
                if (TheHighestNumber_SUB <= 99)
                    TheHighestNumber_SUB += 2;
                if (down_limit_SUB <= 30)
                    down_limit_SUB += 2;
                //для умножения
                if (down_limit_MUL <= 45)
                    down_limit_MUL += 1;
                if (Up_limit_MUL <= 99)
                    Up_limit_MUL += 2;
                //для деления
                if (TheHighestNumber_DIV <= 99)
                    TheHighestNumber_DIV += 2;
                if (TheSmallestNumber_DIV <= 40)
                    TheSmallestNumber_DIV += 1;
            }
            if (PlayerPrefs.GetInt("Difficulty") == 1 && Mod_Of_The_Game == 0)
            {
                //для суммирования
                if (Up_limit_SUM <= 99)
                    Up_limit_SUM += 3;
                if (Down_limit_SUM <= 40)
                    Down_limit_SUM += 1;
                //для вычитания
                if (TheHighestNumber_SUB <= 99)
                    TheHighestNumber_SUB += 3;
                if (down_limit_SUB <= 30)
                    down_limit_SUB += 2;
                //для умножения
                if (down_limit_MUL <= 45)
                    down_limit_MUL += 1;
                if (Up_limit_MUL <= 99)
                    Up_limit_MUL += 3;
                //для деления
                if (TheHighestNumber_DIV <= 99)
                    TheHighestNumber_DIV += 3;
                if (TheSmallestNumber_DIV <= 40)
                    TheSmallestNumber_DIV += 1;
            }
            Div_gen.set_Div_params(TheHighestNumber_DIV, TheSmallestNumber_DIV);
            Mul_gen.set_Mul_params(down_limit_MUL, Up_limit_MUL);
            Sum_gen.set_SUM_params(Down_limit_SUM, Up_limit_SUM);
            Sub_gen.set_SUB_params(TheHighestNumber_SUB, down_limit_SUB);
        }
    }
}
