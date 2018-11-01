//タップしたキューブが指定された種類のオブジェクトを生成するスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

	public GameObject Cube,triangle,ACT_Y;
    //public GameObject CenterMane;
    public Vector2 point;
    public CubeManager CM;
    public AudioClip createSE;
    public AudioClip breakSE;

    //private ObjManager OM;
    private Color mycolor;
    private AudioSource AD;

	void Start () {
        CM = this.gameObject.transform.parent.gameObject.GetComponent<CubeManager>();
        mycolor = this.gameObject.GetComponent<Renderer>().material.color;
        AD = GetComponent<AudioSource>();
        //OM = GetComponent<ObjManager>();
	}

	void Update(){
	}

	void setobjects(){
        if (GameManager.Notwall == true)
        {
            if (GameManager.setobj != true)
            {
                return;
            }
            else
            {
                Debug.Log(GameManager.issetobj);
                switch (GameManager.issetobj)
                {
                    case Responce.Createobj.Cube:
                        CUBE();
                        break;
                    case Responce.Createobj.RightTriangle:
                        RT_triangle();
                        break;
                    case Responce.Createobj.LeftTriangle:
                        LF_triangle();
                        break;
                    case Responce.Createobj.Active_Y:
                        Active_Y();
                        break;
                    default:
                        break;
                }
            }
        }
	}

	void CUBE(){
        //GameObject obj = OM.CreateObj(a);
        GameObject obj = CreateObj(Cube);
        CM.BegingCube((int)point.y,(int)point.x,obj);
        CM.Set_Nowobj(obj);
	}

	void RT_triangle(){
        //GameObject obj = OM.CreateObj(b);
        GameObject obj = CreateObj(triangle,-90);
        CM.BegingCube((int)point.y, (int)point.x, obj);
        CM.Set_Nowobj(obj);
	}

	void LF_triangle(){
        //GameObject obj = OM.CreateObj(c);
        GameObject obj = CreateObj(triangle,90);
        CM.BegingCube((int)point.y, (int)point.x, obj);
        CM.Set_Nowobj(obj);
	}

    void Active_Y(){
        GameObject obj = CreateObj(ACT_Y,90);
        CM.BegingCube((int)point.y, (int)point.x, obj);
        CM.Set_Nowobj(obj);
    }

	void serectthis(){
		this.gameObject.GetComponent<Renderer> ().material.color = new Color (250.0f / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f,0.5f);
	}

	void nomalcolor(){
        //Debug.Log("yappari");
        this.gameObject.GetComponent<Renderer>().material.color = mycolor;
	}

    public void serectpoint(int y,int x){
        point.y = y;
        point.x = x;
    }

    public GameObject CreateObj(GameObject obj, int y = 0)
    {
        if (this.gameObject.transform.childCount > 0)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
        }
        Vector3 mypos = this.gameObject.transform.position;
        mypos.z += 1;
        GameObject newchild = Instantiate(obj,mypos, Quaternion.Euler(0, y, 0));
        AD.PlayOneShot(createSE);
        newchild.transform.SetParent(this.transform);
        return newchild;
    }

    public void Breakobj()
    {
        if (this.gameObject.transform.childCount > 0)
        {
            AD.PlayOneShot(breakSE);
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
        }
    }
}
