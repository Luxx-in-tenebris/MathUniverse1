using UnityEngine;
using System.Collections;

public class Resoltion : MonoBehaviour
{
    public int Level;
    void Start()
    {
        if(Level==0)
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        if(Level ==1)
            Screen.orientation = ScreenOrientation.Portrait;
    }
}