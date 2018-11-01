using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACT_Y : MonoBehaviour {

    private  float speed = 70;
    private int count = 0;
    private int state = 0;
    private float angle;
    private bool RT;
    private bool move = false;
    private string mycolor;

	// Use this for initialization
	void Start () {
        GameObject serecter = GameObject.FindGameObjectWithTag("Canvas").gameObject.transform.Find("ACT_Serecter").gameObject;
        serecter.SetActive(true);
        serecter.GetComponent<ACT_serect_color>().Start_setup();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(state == 1){
            angle = Mathf.LerpAngle(0, 180, count/speed);
            transform.eulerAngles = new Vector3(angle,90,0);
            //Debug.Log(this.transform.eulerAngles.x);
            count++;
            //Debug.Log("pules");
            if(count == (int)speed){
                //Debug.Log("step1 finish");
                count = 0;
                state = 3;
                RT = true;
            }
        }else if(state == 2){
            angle = Mathf.LerpAngle(0, 180, count/speed);
            transform.eulerAngles = new Vector3(-angle, 90, 0);
            count++;
            if(count ==(int)speed){
                count = 0;
                state = 3;
                RT = false;
            }
        }else if(state == 3){
            angle = Mathf.LerpAngle(180,0 ,count/speed);
            if(RT == true){
                angle *= -1;
            }
            //Debug.Log(angle);
            transform.eulerAngles =new Vector3(angle, 90, 0);
            count++;
            if(count == (int)speed){
                Debug.Log("step2 finish");
                transform.eulerAngles = new Vector3(0, 90, 0);
                count = 0;
                state = 0;
                move = false;
            }
        }
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (move == false)
        {
            if (collision.gameObject.tag == mycolor)
            {
                state = 1;
                move = true;
                Debug.Log(state);
            }
            else
            {
                state = 2;
                move = true;
                Debug.Log(state);
            }
        }
	}

    public void SetMycolor(string color){
        mycolor = color;
        ColorChange();
    }

    private void ColorChange(){
        if(mycolor == "RedBall"){
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1f,0f,0f);
        }else if(mycolor == "BlueBall"){
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0f,0f,1f);
        }else if(mycolor == "GreenBall"){
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0f,1f,0f);
        }
    }
}
