using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour {

    public Button pause_b;
    public Button resume_b;
    public Button resume_menu_b;
    public Button restart;
    public Button quit;
    public GameObject pause_menu;

    // Use this for initialization
    void Start ()
    {
        pause_menu.SetActive(false);
        resume_b.gameObject.SetActive(false);

        pause_b.onClick.AddListener(delegate { pause_function(); });

        resume_b.onClick.AddListener(delegate { resume_function(); });

        resume_menu_b.onClick.AddListener(delegate { resume_function(); });

        restart.onClick.AddListener(delegate { resume_function(); });

        quit.onClick.AddListener(delegate { resume_function(); });
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void pause_function()
    {
        pause_b.gameObject.SetActive(false);
        resume_b.gameObject.SetActive(true);
        pause_menu.SetActive(true);
        Time.timeScale = 0;
    }

    void resume_function()
    {
        Time.timeScale = 1;
        pause_menu.SetActive(false);
        pause_b.gameObject.SetActive(true);
        resume_b.gameObject.SetActive(false);
    }
}
