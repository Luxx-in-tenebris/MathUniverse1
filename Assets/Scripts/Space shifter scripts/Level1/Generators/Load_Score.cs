using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_Score : MonoBehaviour {

    public Text scoreTextDif;
    public Text scoreTextSp;
    public Text speedTextSp;
    public Text scoreTextALL;
    public Text speedTextALL;

    // Use this for initialization
    private void Awake()
    {
        {
            if (PlayerPrefs.HasKey("Score_Difficulty"))
            {
                scoreTextDif.text = "Cчёт = "+PlayerPrefs.GetString("Score_Difficulty");
            }
            else
            {
                scoreTextDif.text = "Счёт = 0";
            }

            if (PlayerPrefs.HasKey("Score_Speed")&&PlayerPrefs.HasKey("Speed_Speed"))
            {
                scoreTextSp.text = "Cчёт = " + PlayerPrefs.GetString("Score_Speed");
                speedTextSp.text = "Скорость = " + PlayerPrefs.GetString("Speed_Speed") +" км/с";
            }
            else
            {
                scoreTextSp.text = "Cчёт = 0";
                speedTextSp.text = "Скорость = 0 км/с";
            }
            if (PlayerPrefs.HasKey("Score_ALL") && PlayerPrefs.HasKey("Speed_ALL"))
            {
                scoreTextALL.text = "Cчёт = " + PlayerPrefs.GetString("Score_ALL");
                speedTextALL.text = "Скорость = " + PlayerPrefs.GetString("Speed_ALL") + " км/с";
            }
            else
            {
                scoreTextALL.text = "Cчёт = 0";
                speedTextALL.text = "Скорость = 0 км/с";
            }
        }
    }
}
        ////если увеличение чисел
        //if(PlayerPrefs.HasKey("Difficulty")&&!(PlayerPrefs.HasKey("Speed")))
        //{
        //    if (PlayerPrefs.GetInt("Difficulty") == 1)
        //    {
        //        PlayerPrefs.SetString("Score_Difficulty", "" + SUMscore);
        //        PlayerPrefs.Save();
        //    }
        //}
        ////если скорость
        //if (PlayerPrefs.HasKey("Speed")&&!(PlayerPrefs.HasKey("Difficulty")))
        //{
        //    if (PlayerPrefs.GetInt("Speed") == 1)
        //    {
        //        PlayerPrefs.SetString("Score_Speed", "" + SUMscore);
        //        PlayerPrefs.SetString("Speed_Speed", "" + SUMspeed);
        //        PlayerPrefs.Save();
        //    }
        //}

        ////если все сразу
        //if (PlayerPrefs.HasKey("Speed") && (PlayerPrefs.HasKey("Difficulty")))
        //{
        //    if (PlayerPrefs.GetInt("Speed") == 1 && PlayerPrefs.GetInt("Difficulty") == 1)
        //    {
        //        PlayerPrefs.SetString("Score_ALL", "" + SUMscore);
        //        PlayerPrefs.SetString("Speed_ALL", "" + SUMspeed);
        //        PlayerPrefs.Save();
        //    }