using UnityEngine;
using System.Collections;

public class Control_With_Ray : MonoBehaviour
{


    private GameObject FocusObj = null;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Debug.Log("внутри");
                FocusObj = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // if(hit.transform.gameObject.layer == 10)
                //{
                Debug.Log("Нашелся");
                FocusObj = hit.transform.gameObject;
                // }
            }

            }
            if (FocusObj && Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                FocusObj.transform.position += new Vector3(Input.GetTouch(i).deltaPosition.x / 500f, 0, Input.GetTouch(i).deltaPosition.y / 500f);
            }
            if (FocusObj && Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                FocusObj = null;
            }
        }    
        
    }
}
//if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
//            {
//                Debug.Log("внутри");
//                FocusObj = null;

//                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
//RaycastHit hit;

//            if (Physics.Raycast(ray, out hit, 1000))
//            {
//                // if(hit.transform.gameObject.layer == 10)
//                //{
//                Debug.Log("Нашелся");
//                FocusObj = hit.transform.gameObject;
//                // }
//            }

//            }
//            if (FocusObj && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
//            {
//                FocusObj.transform.position += new Vector3(Input.GetTouch(0).deltaPosition.x / 500f, 0, Input.GetTouch(0).deltaPosition.y / 500f);
//            }
//            if (FocusObj && Input.touchCount > 0 & Input.GetTouch(0).phase == TouchPhase.Ended)
//            {
//                FocusObj = null;
//            }