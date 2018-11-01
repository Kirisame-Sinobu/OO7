//いろいろテストしてるやつ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Responce : MonoBehaviour {

    private List<GameObject> Buttom = new List<GameObject>();
    private Color serectcolor;

    // Use this for initialization
    public enum Createobj
    {
        Cube,
        RightTriangle,
        LeftTriangle,
        Active_Y,
        Clearance,
        BreakClearance,
        BreakCube
    };
	void Start () {
        //Debug.Log(Createobj.Cube > Createobj.LeftTriangle);
        foreach(Transform child in this.gameObject.GetComponentInChildren<Transform>()){
            //Debug.Log(child.gameObject.name);
            Buttom.Add(child.gameObject);
            serectcolor = new Color(125f / 255f, 255f / 255f, 20f / 255f, 1);
            Buttom[(int)Createobj.Cube].GetComponent<Image>().color = serectcolor;
        }
	}

    public void Cube(){
        GameManager.issetobj = Createobj.Cube;
        ChangeColor();
        Buttom[(int)Createobj.Cube].GetComponent<Image>().color = serectcolor;
        GameManager.Notwall = true;
    }
	
	public void RightTriangle(){
        GameManager.issetobj = Createobj.RightTriangle;
        ChangeColor();
        Buttom[(int)Createobj.RightTriangle].GetComponent<Image>().color = serectcolor;
        GameManager.Notwall = true;
	}

	public void LeftTriangle(){
        GameManager.issetobj = Createobj.LeftTriangle;
        ChangeColor();
        Buttom[(int)Createobj.LeftTriangle].GetComponent<Image>().color = serectcolor;
        GameManager.Notwall = true;
	}

    public void Active_Y(){
        GameManager.issetobj = Createobj.Active_Y;
        ChangeColor();
        Buttom[(int)Createobj.Active_Y].GetComponent<Image>().color = serectcolor;
        GameManager.Notwall = true;
    }

	public void Clearance(){
        GameManager.issetobj = Createobj.Clearance;
        ChangeColor();
        Buttom[(int)Createobj.Clearance].GetComponent<Image>().color = serectcolor;
        GameManager.Notwall = false;
	}

    public void BreakClearance(){
        GameManager.issetobj = Createobj.BreakClearance;
        ChangeColor();
        Buttom[(int)Createobj.BreakClearance].GetComponent<Image>().color = serectcolor;
        GameManager.Notwall = false;
    }

    public void BreakCube()
    {
        GameManager.issetobj = Createobj.BreakCube;
        ChangeColor();
        Buttom[(int)Createobj.BreakCube].GetComponent<Image>().color = serectcolor;
        GameManager.Notwall = true;
    }

    private void ChangeColor(){
        foreach(GameObject var in Buttom){
                var.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            GameManager.Notwall = true;
        }
    }
}
