using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_color : MonoBehaviour {

    public enum Local_Office
    {
        none = 0,
        head_office,
        information,
        fund
    }

    private Local_Office now_state = Local_Office.none;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Change_Color(Local_Office change_state){

        if (now_state != change_state)
        {
            Image new_color = this.gameObject.GetComponent<Image>();
            if (change_state == Local_Office.none)
            {
                new_color.color = new Color(0.7f, 0.7f, 0.7f, 1);
            }
            else if (change_state == Local_Office.head_office)
            {
                new_color.color = new Color(1.0f, 0.3f, 0.3f, 1);
            }
            else if (change_state == Local_Office.information)
            {
                new_color.color = new Color(0.3f, 0.3f, 1.0f, 1);
            }
        }
    }


}
