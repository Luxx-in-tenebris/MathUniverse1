using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class back_to_main_menu : MonoBehaviour {

    public void back()
    {
        SceneManager.LoadScene("NewMenu_without_scripts");
    }
}
