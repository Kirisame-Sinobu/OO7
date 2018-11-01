using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgin : MonoBehaviour
{

    public GameObject Goal;

    private Port PT;
    private GoalCompare GC;
    private Text Trytext;
    private int looptime = 1;
    private float time = 0;
    private bool nowcolor = true;
    private Color mycolor;

    // Use this for initialization
    void Start()
    {
        PT = GameObject.FindGameObjectWithTag("port").gameObject.GetComponent<Port>();
        GC = Goal.GetComponent<GoalCompare>();
        Trytext = this.gameObject.GetComponentInChildren<Text>();
        mycolor = Trytext.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        float temp;
        //Debug.Log(Trytext.color);
        if (nowcolor == true)
        {
            temp = (looptime - time) / looptime;
        }
        else
        {
            temp = time / looptime;
        }
        mycolor.a = temp;
        Trytext.color = mycolor;
        if (time >= looptime)
        {
            time = 0;
            nowcolor = !nowcolor;
        }
    }

    public void Restart()
    {
        GameObject parent = this.gameObject.transform.root.gameObject;
        GameObject UPDown = parent.transform.Find("UPDOWN").gameObject;
        GameObject restart = parent.transform.Find("ReStart").gameObject;

        UPDown.SetActive(true);
        restart.SetActive(false);
        Invoke("Touch", 0.5f);
        Setcolor();
        PT.Stop_Game();
        GC.ResetDestroyball();
        GameManager.GameOver = false;
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }

    void Setcolor()
    {
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

    void Touch(){
        GameManager.Not_Touch = false;
    }
}
