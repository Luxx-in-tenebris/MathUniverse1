using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divide_generator : MonoBehaviour {

    private int TheHighestNumber;
    private int TheSmallestNumber;

    private int Second_TheHighestNumber = 15;
    private int Second_TheSmallestNumber=2;


    int[] left_multiplier = new int[3];
    int[] right_multiplier = new int[3];
    string[] all_multipliers = new string[3];// оба слагаемых(множителя) будут записаны в строку
    int[] otvet = new int[3];

    // Use this for initialization
    void Start () {
       // generator();

    }
	

    void generator()
    {

        //генерируем правильный ответ
        while (true)
        {
            left_multiplier[0] = Random.Range(TheSmallestNumber, TheHighestNumber);
            right_multiplier[0] = Random.Range(Second_TheSmallestNumber, Second_TheHighestNumber+1);
            

            if (left_multiplier[0] % right_multiplier[0] == 0 )
            {
                if((left_multiplier[0] / right_multiplier[0]) <=TheHighestNumber/5)
                {
                    break;
                }          
            }
        }
       // Debug.Log("0 "+ left_multiplier[0] + " : "+ right_multiplier[0] + " = "+ left_multiplier[0] / right_multiplier[0]);
        otvet[0] = left_multiplier[0] / right_multiplier[0];

        generator_for_other_asteroids();
    }

    private void generator_for_other_asteroids()
    {

        //первый неправильынй вариант ответа
        while (true)
        {
            left_multiplier[1] = Random.Range(TheSmallestNumber, TheHighestNumber);
            right_multiplier[1] = Random.Range(Second_TheSmallestNumber, Second_TheHighestNumber + 1);


            if (left_multiplier[1] % right_multiplier[1] == 0)
            {
                if ((left_multiplier[1] / right_multiplier[1]) <= TheHighestNumber / 5)
                {
                  //  Debug.Log("1 " + left_multiplier[1] + " : " + right_multiplier[1] + " = " + left_multiplier[1] / right_multiplier[1]);
                    if (left_multiplier[1] / right_multiplier[1] > otvet[0] - 5 && left_multiplier[1] / right_multiplier[1] < otvet[0] + 5)
                    {
                        if (left_multiplier[1] / right_multiplier[1] != otvet[0])
                        {
                            break;
                        }
                    }   
                }
            }
        }
        otvet[1] = left_multiplier[1] / right_multiplier[1];

       // Debug.Log("1 " + left_multiplier[1] + " : " + right_multiplier[1] + " = " + left_multiplier[1] / right_multiplier[1]);


        //второй неправильынй вариант ответа

        while (true)
        {
            left_multiplier[2] = Random.Range(TheSmallestNumber, TheHighestNumber);
            right_multiplier[2] = Random.Range(Second_TheSmallestNumber, Second_TheHighestNumber + 1);


            if (left_multiplier[2] % right_multiplier[2] == 0)
            {
                if ((left_multiplier[2] / right_multiplier[2]) <= TheHighestNumber / 5)
                {
                    if (left_multiplier[2] / right_multiplier[2] > otvet[1] - 10 && left_multiplier[2] / right_multiplier[2] < otvet[1] + 10)
                    {
                        if (left_multiplier[2] / right_multiplier[2] != otvet[0])
                        {
                            if (left_multiplier[2] / right_multiplier[2] != otvet[1])
                            {
                                break;
                            }                   
                        }
                    }
                }
            }
        }
        otvet[2] = left_multiplier[2] / right_multiplier[2];
       // Debug.Log("2 " + left_multiplier[2] + " : " + right_multiplier[2] + " = " + left_multiplier[2] / right_multiplier[2]);

        for (int i = 0; i < 3; i++)
        {
            all_multipliers[i] = "" + left_multiplier[i] + ":" + right_multiplier[i];
            //Debug.Log(all_multipliers[i]);
        }
        all_multipliers[0] += " " + otvet[0];

    }

    public string[] Get_multipliers_Divide()
    {
        generator();
        return all_multipliers;
    }

    public void set_Div_params(int theHighestNumber,int theSmallestNumber)
    {
        TheHighestNumber = theHighestNumber;
        TheSmallestNumber = theSmallestNumber;
    }

}
