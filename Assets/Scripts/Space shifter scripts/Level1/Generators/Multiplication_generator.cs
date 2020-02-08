using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication_generator : MonoBehaviour
{

    private int TheHighestNumber=15;
    private int TheSmallestNumber=2;
    private int down_limit;
    private int up_limit;

    int[] left_multiplier = new int[3];
    int[] right_multiplier = new int[3];
    string[] all_multipliers = new string[3];// оба слагаемых(множителя) будут записаны в строку
    int[] otvet = new int[3];

    // Use this for initialization
    void Start()
    {
        //generator();

    }


    void generator()
    {

        //генерируем правильный ответ
        while (true)
        {
            left_multiplier[0] = Random.Range(TheSmallestNumber, TheHighestNumber);
            right_multiplier[0] = Random.Range(TheSmallestNumber, TheHighestNumber);

            if (left_multiplier[0] * right_multiplier[0] >= down_limit &&left_multiplier[0] * right_multiplier[0]<= up_limit)
            {
                break;
            }
        }

       // Debug.Log("0 " + left_multiplier[0] + " * " + right_multiplier[0] + " = " + left_multiplier[0] * right_multiplier[0]);
        otvet[0] = left_multiplier[0] * right_multiplier[0];

        generator_for_other_asteroids();
    }

    private void generator_for_other_asteroids()
    {

        //первый астероид
        while (true)
        {
            left_multiplier[1] = Random.Range(TheSmallestNumber, TheHighestNumber+1);
            right_multiplier[1] = Random.Range(TheSmallestNumber, TheHighestNumber + 1);

            if (left_multiplier[1] * right_multiplier[1] > otvet[0] - 5 && left_multiplier[1] * right_multiplier[1] < otvet[0] + 5)
            {
                if (left_multiplier[1] * right_multiplier[1] != otvet[0])
                {          
                    break;
                }
            }

        }
       // Debug.Log("1 " + left_multiplier[1] + " * " + right_multiplier[1] + " = " + left_multiplier[1] * right_multiplier[1]);

        otvet[1] = left_multiplier[1] * right_multiplier[1];

        //второй астероид

        while (true)
        {
            left_multiplier[2] = Random.Range(TheSmallestNumber, TheHighestNumber + 1);
            right_multiplier[2] = Random.Range(TheSmallestNumber, TheHighestNumber + 1);

            if (left_multiplier[2] * right_multiplier[2] > otvet[0] - 12 && left_multiplier[2] * right_multiplier[2] < otvet[0] + 12)
            {
                if (left_multiplier[2] * right_multiplier[2] != otvet[1] && left_multiplier[2] * right_multiplier[2] != otvet[0])
                {           
                    break;
                }
            }
        }
        //Debug.Log("2 " + left_multiplier[2] + " * " + right_multiplier[2] + " = " + left_multiplier[2] * right_multiplier[2]);
        otvet[2] = left_multiplier[2] * right_multiplier[2];

        for (int i = 0; i < 3; i++)
        {
            all_multipliers[i] = "" + left_multiplier[i] + "x" + right_multiplier[i];
            //Debug.Log(all_multipliers[i]);
        }
        all_multipliers[0] += " " + otvet[0];
    }
    public string[] Get_multipliers_Multiplication()
    {
        generator();
        return all_multipliers;
    }

    public void set_Mul_params(int downLimit, int upLimit)
    {
        down_limit = downLimit;
        up_limit=upLimit;
}
}
