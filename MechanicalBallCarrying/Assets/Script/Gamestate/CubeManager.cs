/*今回の根幹をなすプログラム
 * 全てのキューブの管理から様々なことを司る*/
//だれも俺に気がつくことはない
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//おれだおれだおれだおれだ

public class CubeManager : MonoBehaviour {

    public static int Cubehight = 10;
    public static int Cubelong = 6;
    public static GameObject[,] Basecube = new GameObject[Cubehight, Cubelong + 1];
    public static GameObject[,] Base_heightCL = new GameObject[Cubehight, Cubelong + 2];
    public static GameObject[,] Base_longCL = new GameObject[Cubehight + 1, Cubelong + 1];
    public static GameObject Nowobj;

    private GameObject[,] cube = new GameObject[Cubehight, Cubelong+1];
    private GameObject[,] heightCL = new GameObject[Cubehight, Cubelong + 2];
    private GameObject[,] longCL = new GameObject[Cubehight + 1, Cubelong + 1];


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BegingCube(int y,int x,GameObject temp){
        cube[y,x] = temp;
    }

    public void BegingHeightWall(int y,int x,GameObject temp){
        heightCL[y, x] = temp;
    }

    public void BegingLongWall(int y,int x,GameObject temp){
        longCL[y, x] = temp;
    }

    public void Set_Nowobj(GameObject temp){
        Nowobj = temp;
    }

    public GameObject Return_Nowobj(){
        return Nowobj;
    }

    public void Set_Basecube(int y, int x, GameObject temp){
        Basecube[y, x] = temp;
    }

    public void Set_BaseheightCL(int y ,int x ,GameObject temp){
        Base_heightCL[y, x] = temp;
    }

    public void Set_BaselongCL(int y,int x,GameObject temp){
        Base_longCL[y, x] = temp;
    }

}
