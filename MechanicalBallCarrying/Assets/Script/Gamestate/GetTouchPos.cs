// タッチしたキューブの座標とる

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTouchPos : MonoBehaviour {

	private Vector2 touchpos;
    private GameObject afterobj = null;
    private bool puttouch = true;                  //そのタッチがオブジェクトを置くために触られたのかを検知します

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Not_Touch == false)
        {
            if (GameManager.Notwall)
            {
                touchCube();
            }
            else
            {
                TouchCL();
            }
        }
//		if(OnTouchDown()){
//			Debug.Log("kore");
//		}
	}

	void touchCube(){
		if (Input.touchCount > 0) {
            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)
                {
                    if (t.position.y <= 200)
                    {
                        puttouch = false;
                    }
                }
                if (puttouch == true)
                {
                    touchpos = t.position;
                    RaycastHit hit = new RaycastHit();
                    Ray ray = Camera.main.ScreenPointToRay(touchpos);
                    if (Physics.Raycast(ray, out hit, 50.0f))
                    {
                        if (afterobj != hit.collider.gameObject)
                        {
                            if (afterobj != null)
                            {
                                afterobj.SendMessage("nomalcolor");
                            }
                        }
                    }

                    if (Physics.Raycast(ray, out hit, 50.0f))
                    {
                        if (hit.collider.gameObject.tag == "Cube")
                        {
                            afterobj = hit.collider.gameObject;
                            hit.collider.gameObject.SendMessage("serectthis");
                        }
                    }


                    //hit.transform.gameObject.SendMessage ("serectthis");
                    if (t.phase == TouchPhase.Ended)
                    {
                        //Debug.Log(hit.collider.gameObject.name);
                        if (hit.collider != null && hit.collider.gameObject.tag == "Cube")
                        {
                            hit.collider.gameObject.SendMessage("nomalcolor");
                            if (Responce.Createobj.BreakCube == GameManager.issetobj)
                            {
                                Debug.Log(GameManager.issetobj);
                                //  Debug.Log("break");
                                hit.collider.gameObject.SendMessage("Breakobj");
                            }
                            else
                            {
                                //  Debug.Log("create");
                                hit.collider.gameObject.SendMessage("setobjects");
                            }
                            if (afterobj != null)
                            {
                                afterobj.gameObject.SendMessage("nomalcolor");
                            }
                        }
                        else if (hit.collider != null && hit.collider.gameObject.tag == "port")
                        {
                            Debug.Log("toch!");
                            hit.collider.gameObject.SendMessage("Game_Start");
                        }
                    }
                }else {
                    if(t.phase == TouchPhase.Ended){
                        puttouch = true;
                    }
                }
            }
		}
	}

    void TouchCL(){
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)
                {
                    if (t.position.y <= 200)
                    {
                        puttouch = false;
                    }
                }
                if (puttouch == true)
                {
                    touchpos = t.position;
                    RaycastHit hit = new RaycastHit();
                    Ray ray = Camera.main.ScreenPointToRay(touchpos);
                    if (Physics.Raycast(ray, out hit, 50.0f))
                    {
                        if (afterobj != hit.collider.gameObject)
                        {
                            if (afterobj != null)
                            {
                                afterobj.SendMessage("nomalcolor");
                            }
                        }
                    }

                    if (Physics.Raycast(ray, out hit, 50.0f))
                    {
                        if (hit.collider.gameObject.tag == "LongClearrance" || hit.collider.gameObject.tag == "HightClearrance")
                        {
                            afterobj = hit.collider.gameObject;
                            hit.collider.gameObject.SendMessage("serectthis");
                        }
                    }


                    //hit.transform.gameObject.SendMessage ("serectthis");
                    if (t.phase == TouchPhase.Ended)
                    {

                        if (hit.collider != null && (hit.collider.gameObject.tag == "LongClearrance" || hit.collider.gameObject.tag == "HightClearrance"))
                        {
                            hit.collider.gameObject.SendMessage("nomalcolor");
                            if (Responce.Createobj.BreakClearance == GameManager.issetobj)
                            {
                                //Debug.Log(GameManager.issetobj);
                                //  Debug.Log("break");
                                hit.collider.gameObject.SendMessage("Breakobj");
                            }
                            else
                            {
                                //Debug.Log("create");
                                hit.collider.gameObject.SendMessage("setobjects");
                            }
                            if (afterobj != null)
                            {
                                afterobj.gameObject.SendMessage("nomalcolor");
                            }
                        }else if(hit.collider != null && hit.collider.gameObject.tag == "port"){
                            hit.collider.gameObject.SendMessage("Game_Start");
                        }
                    }
                }else {
                    if(t.phase == TouchPhase.Ended){
                        puttouch = true;
                    }
                }
            }
        }
    }
}
