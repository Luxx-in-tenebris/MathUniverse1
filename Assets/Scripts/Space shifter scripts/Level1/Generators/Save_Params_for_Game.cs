using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save_Params_for_Game : MonoBehaviour {
    //для тренировки
    public Dropdown dropdown;
    public Toggle difficulty;
    public Toggle speed;
    //для турнира
    public Toggle difficulty1;
    public Toggle speed1;

    public GameObject AttentionTournament;
    public GameObject AttentionTraining;

    private void Awake()
    {
        PlayerPrefs.DeleteKey("Game_Mod");
        PlayerPrefs.DeleteKey("Difficulty");
        PlayerPrefs.DeleteKey("Speed");
        PlayerPrefs.Save();
    }

    public void set_params_Training(string Scene_name)
    {
        if(!(difficulty.isOn)&&!(speed.isOn))
        {
            AttentionTraining.SetActive(true);
            return;
        }
        else
        {
            AttentionTraining.SetActive(false);
        }
        set_GameMod(dropdown.value);
        set_Difficulty(difficulty.isOn);
        set_Speed(speed.isOn);
        load(Scene_name);
    }

    public void set_params_Tournament(string Scene_name)
    {
        if(!(difficulty1.isOn)&&!(speed1.isOn))
        {
            AttentionTournament.SetActive(true);
            return;
        }
        else
        {
            AttentionTournament.SetActive(false);
        }
        set_GameMod(-1);
        set_Difficulty(difficulty1.isOn);
        set_Speed(speed1.isOn);
        load(Scene_name);
    }

    //режим игры
    void set_GameMod(int number)
    {
        PlayerPrefs.SetInt("Game_Mod", number+1);
        PlayerPrefs.Save();
    }
    //сложность
     void set_Difficulty(bool yes)
    {
        if(yes)
        {
            PlayerPrefs.SetInt("Difficulty", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Difficulty", 0);
        }
        
        PlayerPrefs.Save();
    }
    //скорость
     void set_Speed(bool yes)
    {
        if (yes)
        {
            PlayerPrefs.SetInt("Speed", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Speed", 0);
        }

        PlayerPrefs.Save();
    }
    private void load(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}
