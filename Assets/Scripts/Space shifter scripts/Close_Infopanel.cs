using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Close_Infopanel : MonoBehaviour
{

    public GameObject[] AirCrafts;
    public Transform InfoPanel;
    public Transform InfoPanel_copy;
    public Animator InfoPanel_anim;
    public Animator InfoPanel_anim_copy;
    public GameObject Render_image;
    public GameObject Render_image_copy;
    public Button[] Buttons;

    private int i = 0;
    private bool opened=true;

    // Use this for initialization
    void Start ()
    {
	for(i=0;i< Buttons.Length;i++)
        {
            Buttons[i].onClick.AddListener( delegate { Check_and_close(EventSystem.current.currentSelectedGameObject.name); });

        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    //проверяем что открыто и закрываем
    void Check_and_close(string name)
    {
        int j = 0;
        
        //если еще никакой самолет не выбран, т.е. обе панели наверху
        if(((InfoPanel.position.y > 50))&& ((InfoPanel_copy.position.y > 50)))
        {
            InfoPanel_anim.SetTrigger("Open");
        }      

        //если открыта первая панель, то закрываем её и открываем копию
        if (InfoPanel.position.y<23)
        {
            Render_image.SetActive(false);
            InfoPanel_anim.SetTrigger("Close");
            Render_image_copy.SetActive(true);
            InfoPanel_anim_copy.SetTrigger("Open");
        }

        //если открыта вторая панель (копия), то закрываем её и открываем первую
        if (InfoPanel_copy.position.y <23)
        {
            Render_image_copy.SetActive(false);
            InfoPanel_anim_copy.SetTrigger("Close");
            Render_image.SetActive(true);
            InfoPanel_anim.SetTrigger("Open");
        }

        if (((InfoPanel.position.y<23)) && ((InfoPanel_copy.position.y < 23)))
        {
            InfoPanel_anim_copy.SetTrigger("Close");
        }

        for(j=0;j<AirCrafts.Length;j++)
        {
            if (name == AirCrafts[j].name)
            {
                AirCrafts[j].SetActive(true);

            }
            else
            {
                AirCrafts[j].SetActive(false);
            }
        }

    }

    void close_panel(Animator InfoPanel_anim, GameObject Render_image)
    {
        InfoPanel_anim.SetTrigger("Close");
        Render_image.SetActive(false);

    }
    public void close_panels()
    {
        if (InfoPanel_copy.position.y < 23)
        {
            InfoPanel_anim_copy.SetTrigger("Close");
        }
        if (InfoPanel.position.y < 23)
        {
            InfoPanel_anim.SetTrigger("Close");
        }
        for (int j = 0; j < AirCrafts.Length; j++)
        {
            AirCrafts[j].SetActive(false);
        }
    }
}
