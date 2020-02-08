using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MobileMoviePlayer : MonoBehaviour
{
	public string movieFileName;
	public Color backgroundColor = Color.black;

	#if UNITY_ANDROID || UNITY_IPHONE
	public FullScreenMovieControlMode controlMod = FullScreenMovieControlMode.Hidden;
	public FullScreenMovieScalingMode scalingMod = FullScreenMovieScalingMode.Fill;
	#endif

	public bool playOnStart = true;

    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    IEnumerator Start ()
	{
	    Debug.Log (Application.streamingAssetsPath + "/" + movieFileName);
		if (playOnStart) {
				Play ();
		}
                
        yield return 0;
        //SceneManager.LoadScene("NewMenu");
	}
    void Update()
    {
            
    }


	public void Play ()
	{
			if (string.IsNullOrEmpty (movieFileName)) {
					Debug.Log("movieFileName is undefined");
					return;
			}
			#if UNITY_ANDROID || UNITY_IPHONE
				//Play full screen only
				Handheld.PlayFullScreenMovie (movieFileName,  backgroundColor, controlMod,scalingMod);
			#endif
	}
}