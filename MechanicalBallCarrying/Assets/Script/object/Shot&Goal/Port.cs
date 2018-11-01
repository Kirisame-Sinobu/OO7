using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour {

    public GameObject[] Ball = new GameObject[3];

    private Color nullcolor;
    private bool gamestart = false;
    private float Injectiontime = 3.0f;
    private int Shotballnumber = 5;
    private float Balltime = 0;
    private int ShotedBall = 0;
	// Use this for initialization
	void Start () {
        nullcolor = new Color(0f, 0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (gamestart == true)
        {
            Balltime += Time.deltaTime;
            if (Balltime >= Injectiontime)
            {
                int i = Random.Range(0, 3);
                Instantiate(Ball[i], this.gameObject.transform.position, Quaternion.identity);
                //Debug.Log(Balltime);
                Balltime = 0.0f;
                i++;
                Debug.Log(i);
                ShotedBall++;
                if(ShotedBall == Shotballnumber){
                    gamestart = false;
                }

            }
        }
	}

    void Game_Start(){
        GameObject parent = GameObject.FindGameObjectWithTag("Canvas").gameObject;
        GameObject restart = parent.transform.Find("ReStart").gameObject;
        GameObject UPDown = parent.transform.Find("UPDOWN").gameObject;
        ShotedBall = 0;
        restart.SetActive(true);
        UPDown.SetActive(false);
        GameManager.Not_Touch = true;
        GameManager.GameOver = false;
        gamestart = true;
        Crearcolor();
    }

    void Crearcolor(){
        foreach(GameObject c in CubeManager.Basecube){
            //Debug.Log(c);
            c.gameObject.GetComponent<Renderer>().material.color = nullcolor;
        }

        foreach(GameObject c in CubeManager.Base_longCL){
            //Debug.Log(c == null);
            c.gameObject.GetComponent<Renderer>().material.color = nullcolor;
        }

        foreach(GameObject c in CubeManager.Base_heightCL){
            c.gameObject.GetComponent<Renderer>().material.color = nullcolor;
        }

        //CubeManager.Nowobj.GetComponent<Renderer>().material.color = nullcolor;
    }

    public void Stop_Game(){
        gamestart = false;
        Balltime = 0;
        ShotedBall = 0;
    }

    public int Rertn_shotballnumber(){
        return Shotballnumber;
    }
}
