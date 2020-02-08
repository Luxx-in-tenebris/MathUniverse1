using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {
	
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}


}
