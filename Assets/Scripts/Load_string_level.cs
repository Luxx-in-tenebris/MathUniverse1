using UnityEngine;
using System.Collections;

public class Load_string_level : MonoBehaviour {

	// Use this for initialization

    public void load(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}
