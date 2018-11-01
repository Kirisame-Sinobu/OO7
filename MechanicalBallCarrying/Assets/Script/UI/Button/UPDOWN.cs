using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPDOWN : MonoBehaviour {
    private Vector3 Uppos;
    private Vector3 Downpos;
    private Vector3 Movepos;
    private Vector2 afterpos;
    private bool Movetouch = false;
    private float Upspeed = 1.0f;
    private float Downspeed = 2.0f;

	// Use this for initialization
	void Start () {
        Uppos = this.gameObject.transform.position;
        Uppos.y += 110;
        Downpos = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0){
            foreach(Touch t in Input.touches){
                if(t.phase == TouchPhase.Began){
                    if(t.position.y <= 200){
                        afterpos = t.position;
                        Movetouch = true;
                    }
                }
                if (Movetouch == true)
                {
                    if (t.phase == TouchPhase.Moved)
                    {
                        if (Mathf.Abs(t.position.y - afterpos.y) > Mathf.Abs(t.position.x - afterpos.x))
                        {
                            Movepos = this.gameObject.transform.position;
                            if (t.position.y - afterpos.y >= 0)
                            {
                                Movepos.y = Mathf.Clamp((t.position.y - afterpos.y) * Upspeed + Movepos.y, Downpos.y, Uppos.y);
                            }
                            else
                            {
                                Movepos.y = Mathf.Clamp((t.position.y - afterpos.y) * Downspeed + Movepos.y, Downpos.y, Uppos.y);
                            }
                            this.gameObject.transform.position = Movepos;
                            afterpos = t.position;
                        }
                    }
                    if(t.phase == TouchPhase.Ended){
                        Movetouch = false;
                        if(this.gameObject.transform.position == Uppos){
                            this.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "↓";
                        }else if(this.gameObject.transform.position == Downpos){
                            this.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "↑";
                        }
                    }
                }
            }
        }
	}
}
