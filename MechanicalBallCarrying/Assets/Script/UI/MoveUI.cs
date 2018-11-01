using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour {

    Vector2 aftertouch;
    Vector3 UPpos;
    Vector3 movepos;
    Vector3 startpos;
    bool move = false;
    float movespeed = 1.0f;
    GameObject Root;

	// Use this for initialization
	void Start () {
        Root = this.gameObject.transform.parent.gameObject;
        UPpos = Root.transform.position;
        UPpos.y += 110;
        startpos = this.gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(this.gameObject.transform.position.x); -120
        if (Root.transform.position == UPpos)
        {
            if (Input.touchCount >= 1)
            {
                //Debug.Log(Input.touches[0].position.y);
                foreach (Touch t in Input.touches)
                {
                    if (t.phase == TouchPhase.Began)
                    {
                        if (t.position.y <= 180)
                        {
                            aftertouch = t.position;
                            move = true;
                        }
                    }
                    if (move == true)
                    {
                        if (t.phase == TouchPhase.Moved)
                        {
                            if (Mathf.Abs(t.position.y - aftertouch.y) < Mathf.Abs(t.position.x - aftertouch.x))
                            {
                                movepos = this.transform.position;
                                movepos.x = Mathf.Clamp((t.position.x - aftertouch.x) * movespeed + movepos.x,-120,startpos.x);
                                this.gameObject.transform.position = movepos;
                                aftertouch = t.position;
                            }
                        }
                        if(t.phase == TouchPhase.Ended){
                            move = false;
                        }
                    }
                }
            }
        }
	}
}
