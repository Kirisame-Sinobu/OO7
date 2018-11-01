using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBall : MonoBehaviour {

    public GameObject[] port = new GameObject[3]; //発射口のことです
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
        if(Input.GetKeyDown(KeyCode.Space)){
            int i = Random.Range(0, 3);
            Instantiate(port[i], this.gameObject.transform.position, Quaternion.identity);
        }
	}
}
