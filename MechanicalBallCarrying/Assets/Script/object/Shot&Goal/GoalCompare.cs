using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCompare : MonoBehaviour {

    private static bool Gamecrear;
    private static int DestroyBall = 0;
    private string mytag;
    private Port PT;
    private int Ballnumber;


	void Start () {
        mytag = this.gameObject.tag;
        PT =GameObject.FindGameObjectWithTag("port").gameObject.GetComponent<Port>();
        Ballnumber = PT.Rertn_shotballnumber();
	}
	

	void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == mytag) {
			Destroy (col.gameObject);
            DestroyBall++;
            if(DestroyBall == Ballnumber){
                Invoke("GameCrear", 2.0f);
            }
		}
		
	}

    private void GameCrear(){
        SceneManager.LoadScene("Crear");
    }

    public void ResetDestroyball(){
        DestroyBall = 0;
    }
}
