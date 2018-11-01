using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retrumselect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void To_Select(){
        GameManager.GameOver = false;
        GameManager.Not_Touch = false;
        SceneManager.LoadScene("SerectScene");
    }
}
