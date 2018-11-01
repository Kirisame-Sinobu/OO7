using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACT_serect_color : MonoBehaviour {

    private string Serectcolor;
    private CubeManager CM;
    private ACT_Y AY;
    private bool serect = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Start_setup(){
        GameManager.Not_Touch = true;
        CM = GameObject.FindGameObjectWithTag("CenterManager").GetComponent<CubeManager>();
        AY = CM.Return_Nowobj().GetComponent<ACT_Y>();
    }

    public void Redcolor(){
        Serectcolor = "RedBall";
        serect = true;
    }

    public void Bluecolor(){
        Serectcolor = "BlueBall";
        serect = true;
    }

    public void Greencolor(){
        Serectcolor = "GreenBall";
        serect = true;
    }

    public void End_serect(){
        if (serect == true)
        {
            AY.SetMycolor(Serectcolor);
            //Debug.Log("kore");
            Invoke("change_touch", 2.0f);
            this.gameObject.SetActive(false);
        }
    }

    private void change_touch(){
        //Debug.Log("yatt!!");
        GameManager.Not_Touch = false;
    }
}
