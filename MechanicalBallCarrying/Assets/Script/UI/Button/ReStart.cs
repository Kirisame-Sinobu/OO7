using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour {

    public GameObject Goal;

    private Port PT;
    private GoalCompare GC;


	// Use this for initialization
	void Start () {
        PT = GameObject.FindGameObjectWithTag("port").gameObject.GetComponent<Port>();
        GC = Goal.GetComponent<GoalCompare>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restart(){
        GameObject parent = this.gameObject.transform.parent.gameObject;
        GameObject UPDown = parent.transform.Find("UPDOWN").gameObject;
        UPDown.SetActive(true);
        GameManager.Not_Touch = false;
        GameManager.GameOver = true;
        Setcolor();
        PT.Stop_Game();
        GC.ResetDestroyball();
        this.gameObject.SetActive(false);
    }

    void Setcolor(){
        foreach (GameObject c in CubeManager.Basecube)
        {
            c.gameObject.SendMessage("nomalcolor");
        }

        foreach (GameObject c in CubeManager.Base_longCL)
        {
            c.gameObject.SendMessage("nomalcolor");
        }

        foreach (GameObject c in CubeManager.Base_heightCL)
        {
            c.gameObject.SendMessage("nomalcolor");
        }
    }
}
