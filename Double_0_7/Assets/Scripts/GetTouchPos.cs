// タッチしたキューブの座標とる

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTouchPos : MonoBehaviour {

	//bool t=true;
	private Vector2 touchpos;


	void Start () {
		
	}
	

	void Update () {
		touch ();
	}

    /// <summary>
    /// タッチ！！！！！
    /// </summary>
    //なんだお前
	void touch(){
		if (Input.touchCount <= 0) {
			return;
		} else {
			foreach (Touch t in Input.touches) {
				if (t.phase == TouchPhase.Began) {
					touchpos = t.position;
					RaycastHit hit = new RaycastHit ();
					Ray ray = Camera.main.ScreenPointToRay(touchpos);
					if (Physics.Raycast (ray,out hit)) {
                        Debug.Log(hit.collider.name);
					}
				}
			}
		}
	}
}
