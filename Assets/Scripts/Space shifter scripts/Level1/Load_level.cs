using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Load_level : MonoBehaviour {

    public GameObject trident;
    public GameObject Omega;
    public GameObject Quadra;

    public void load()
    {
        if(trident.active==true)
        {
            SceneManager.LoadScene("Loading level_trident");
        }
        if (Omega.active == true)
        {
            SceneManager.LoadScene("Loading level_Omega");
        }
        if (Quadra.active == true)
        {
            SceneManager.LoadScene("Loading level_Quadra");
        }
    }
}
