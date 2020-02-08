// #######################################
// ---------------------------------------
// ---------------------------------------
// PFC - prefrontal cortex
// ---------------------------------------
// Full Android Sensor Access for Unity3D
// ---------------------------------------
// Contact:
// 		contact.prefrontalcortex@gmail.com
// ---------------------------------------
// #######################################


using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class MoveByLinearAcc : MonoBehaviour {

    public Rigidbody rigidbody;
    public float Force= 10;
    // Use this for initialization
    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //GUI.Button(new Rect(10, 30, 180, 30), "Гиро:" + Input.gyro.userAcceleration);
        Input.gyro.enabled = true;
        //Sensor.Activate(Sensor.Type.LinearAcceleration);
    }

    // Update is called once per frame 
    void FixedUpdate() {
        Vector3 linearAcc = FilterMax(Input.acceleration / 20 * 10);
        rigidbody.AddForce((new Vector3(-linearAcc.x*Force, rigidbody.position.y, linearAcc.z * Force)));
    }

    void OnGUI()
    {
        GUI.Button(new Rect(10, 30, 180, 50), "Acc: " + Input.acceleration);
        GUI.Button(new Rect(10, 100, 180, 50), "Positon: " + rigidbody.position);
        if (GUI.Button(new Rect(10, 200, 180, 50), "Exit"))
        {
            Application.Quit();
        }
    }
    // Decay filter - goes instantly up to higher values, but slowly down back to zero
    // (LinearAcceleration sensor returns one peak and goes immediately back down to zero - this filter preserves the peak)

    Vector3 holder = Vector3.zero;
    Vector3 max = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    Vector3 FilterMax(Vector3 input)
    {
        if (input.magnitude > max.magnitude) max = input;

        holder = Vector3.SmoothDamp(holder, max, ref velocity, 0.1f);
        if (Vector3.Distance(holder, max) < 0.4f) max = Vector3.zero;   
        if (holder.z<0)
        {
            holder.z = 0;
        }
        return holder;         
    }

}        