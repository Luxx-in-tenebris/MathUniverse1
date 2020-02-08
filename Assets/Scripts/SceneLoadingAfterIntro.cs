using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoadingAfterIntro : MonoBehaviour {

    public new AudioSource audio;

    void Awake ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
	if(!audio.isPlaying)
        {
            SceneManager.LoadScene("NewMenu_without_scripts");
        }
	}
}
