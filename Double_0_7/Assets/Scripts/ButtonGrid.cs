using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGrid : MonoBehaviour {

    public GameObject Button;

    public GameObject[,] grit = new GameObject[9, 9];

	// Use this for initialization
	void Start () {
        for (int y = 0; y < 9;y++){
            for (int x = 0; x < 9;x++){
                GameObject temp = Instantiate(Button,new Vector3(x-4,y-4,0), Quaternion.identity);
                grit[x, y] = temp;
                //Instantiate(Button, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
