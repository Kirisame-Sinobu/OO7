using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private GameObject GameOver_Image;
    private Rigidbody RD;
    private float firsttime = 2.5f;
    private float time = 0f;
    private float breaktime  = 0f;
    private float Bantime = 4f;

	// Use this for initialization
	void Start () {
        RD = this.gameObject.GetComponent<Rigidbody>();
        GameOver_Image = GameObject.FindGameObjectWithTag("Canvas").transform.Find("GameOver").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        //Debug.Log(GameManager.GameOver);
        if(GameManager.GameOver == true){
            Destroy(this.gameObject);
        }
        //Debug.Log(RD.velocity.magnitude);
        if (time >= firsttime)
        {
            if (RD.velocity.magnitude <= 1)
            {
                breaktime += Time.deltaTime;
                if (breaktime >= Bantime)
                {
                    Game_Over();
                    Destroy(this.gameObject);
                }
            }else {
                breaktime = 0;
            }
            if(RD.velocity.magnitude >= 30){
                Game_Over();
                Destroy(this.gameObject);
            }
        }
	}

    private void Game_Over(){
        Debug.Log("desutroy");
        GameManager.GameOver = true;
        GameOver_Image.SetActive(true);
    }

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag != this.gameObject.tag){
            if (collision.gameObject.tag == "RedBall")
            {
                Game_Over();
                Destroy(this.gameObject);
            }
            else if (collision.gameObject.tag == "BlueBall"){
                Game_Over();
                Destroy(this.gameObject);
            }else if(collision.gameObject.tag == "GreenBall"){
                Game_Over();
                Destroy(this.gameObject);
            }
        }
	}
}
