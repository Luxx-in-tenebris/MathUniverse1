using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoadScene : MonoBehaviour {

    public Slider slider;
    public string SceneName;


    private AsyncOperation async;




    void Start ()
    {
        StartCoroutine("launchLevel");
	}
	
	IEnumerator launchLevel()
    {

		async = Application.LoadLevelAsync(SceneName);
        while(!async.isDone)
        {
            slider.value = async.progress;
            yield return true;
        }
        //async.allowSceneActivation = false;   
            
        //loadingIsReady = true;
        
        
        
        Debug.Log(async.progress);       
        
	}
	
	void Update ()
    {
        //if(loadingIsReady == true)
        ////{
        //    slider.animator.SetTrigger("EndLoad");
        //    Text.SetTrigger("PlayNow");
        //    if((Input.GetButtonDown("Fire1"))||(Input.touchCount>0))
        //    {
        //        Debug.Log("тут");
        //        async.allowSceneActivation = true; 
        //    }
        //}
	}
}
