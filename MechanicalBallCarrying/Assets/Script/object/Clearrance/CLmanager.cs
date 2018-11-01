using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CLmanager : MonoBehaviour {

    public GameObject HightCL;
    public GameObject LongCL;
    public Vector2 point;
    public AudioClip createSE;
    public AudioClip breakSE;
    public CubeManager CM;

    private Color mycolor;
    private AudioSource AD;
	// Use this for initialization
	void Start () {
        mycolor = this.GetComponent<Renderer>().material.color;
        CM = this.gameObject.transform.parent.gameObject.GetComponent<CubeManager>();
        AD = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void serectthis()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color(250.0f / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 0.5f);
    }

    void nomalcolor()
    {
        this.gameObject.GetComponent<Renderer>().material.color = mycolor;
    }

    void setobjects()
    {
        if (this.gameObject.transform.childCount == 0)
        {
            Vector3 mypos = this.gameObject.transform.position;
            mypos.z += 1;
            if (this.gameObject.tag == "HightClearrance")
            {
                GameObject newchild = Instantiate(HightCL,mypos, Quaternion.identity);
                AD.PlayOneShot(createSE);
                CM.BegingHeightWall((int)point.y, (int)point.x, newchild);
                newchild.transform.SetParent(this.transform);
            }
            if (this.gameObject.tag == "LongClearrance")
            {
                GameObject newchild = Instantiate(LongCL, mypos, Quaternion.identity);
                AD.PlayOneShot(createSE);
                CM.BegingLongWall((int)point.y, (int)point.x, newchild);
                newchild.transform.SetParent(this.transform);
            }
        }
    }

    public void serectpoint(int y,int x){
        point.y = y;
        point.x = x;
    }

    public void Breakobj()
    {
        //Debug.Log("state1");
        if (this.gameObject.transform.childCount > 0)
        {
            //Debug.Log("stage2");
            AD.PlayOneShot(breakSE);
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
        }
    }
}
