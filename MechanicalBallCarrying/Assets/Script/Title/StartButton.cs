using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    private Text Starttext;
    private int looptime = 1;
    private float time = 0;
    private bool nowcolor = true;
    private AudioSource startBGM;

	// Use this for initialization
	void Start () {
        Starttext = this.transform.Find("Starttext").gameObject.GetComponent<Text>();
        startBGM = GetComponent<AudioSource>();
        // Numata-Foo
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        time += Time.deltaTime;
        Debug.Log(time + "koko");
        float temp;
        if (nowcolor == true)
        {
            temp = (looptime - time) / looptime;
        }
        else
        {
            temp = time / looptime;
        }
        Starttext.color = new Color(0, 0, 0, temp);
        if(time >= looptime){
            time = 0;
            nowcolor = !nowcolor;
        }
	}

    public void Startgame(){
        startBGM.PlayOneShot(startBGM.clip);
        Invoke("Loadscene", 0.3f);
    }

    private void Loadscene(){
        SceneManager.LoadScene("SerectScene");
    }
}
