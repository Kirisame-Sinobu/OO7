using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    /// <summary>
    /// xに数値を代入して色を変えます。x=０が赤色でx＝２が青、x＝３が黄色で、x＝４が緑です。
    /// </summary>
    /// <returns>The change.</returns>
    /// <param name="x">The x coordinate.</param>
    void Change(int x)
    {
        if (x == 0){
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }else if (x == 1)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }else if(x == 2){
            this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }else if(x == 3){
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
