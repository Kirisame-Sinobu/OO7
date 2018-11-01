/*マスに使う予定のブロックを作るためのスクリプト
 * 使うためにはからのゲームオブジェクトにつける
 * ブロックの大きさは１、１、１で固定とする
   使うとそのオブジェクトが中心にくる*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriateSquares : MonoBehaviour {

    private int Verticalcube = CubeManager.Cubehight;				//縦に並ぶブロックの数	今１０
    private int SideCule = CubeManager.Cubelong;					//横に並ぶブロックの数　※ただし、プラス１　今６だから７
	private float Clearance = 0.2f;				//使うかわからないけどブロックとブロックの隙間
	public GameObject Cube;						//生成するブロック
    public GameObject HightClearrance,LongClearrance;            //隙間ブロック

    private Vector3 Cubepos;
	private float tempX;
    private CubeManager CM;

	// Use this for initialization
	void Start () {
        CM = GetComponent<CubeManager>();
        CreateSquares();
        Create_LongClearrances();
        Create_HightClearrances();
	}

    void CreateSquares(){
        Cubepos = this.gameObject.transform.position;
        Cubepos.y += Verticalcube / 2 + (Verticalcube / 2) * Clearance;
        Cubepos.x -= SideCule / 2 + SideCule / 2 * Clearance;
        tempX = Cubepos.x;
        for (int y = 0; y < Verticalcube; y++)
        {
            for (int x = 0; x <= SideCule; x++)
            {
                GameObject obj = Instantiate(Cube, Cubepos, Quaternion.identity);
                obj.GetComponent<CreateObject>().serectpoint(y, x);
                obj.transform.SetParent(this.gameObject.transform);
                CM.Set_Basecube(y, x, obj);
                obj.name = "cubu[" + y + "," + x + "]";
                Cubepos.x += 1 + Clearance;
            }
            Cubepos.y -= 1 + Clearance;
            Cubepos.x = tempX;
        }
    }

    void Create_LongClearrances(){
        Cubepos = this.gameObject.transform.position;
        Cubepos.y += Verticalcube / 2 + ((Verticalcube + 6) / 2) * Clearance;
        Cubepos.x -= SideCule / 2 + SideCule / 2 * Clearance;
        tempX = Cubepos.x;
        for (int y = 0; y <= Verticalcube; y++)
        {
            for (int x = 0; x <= SideCule; x++)
            {
                GameObject obj = Instantiate(LongClearrance, Cubepos, Quaternion.identity);
                obj.GetComponent<CLmanager>().serectpoint(y, x);
                obj.transform.SetParent(this.gameObject.transform);
                CM.Set_BaselongCL(y, x, obj);
                obj.name = "LoClear[" + y + "," + x + "]";
                Cubepos.x += 1 + Clearance;
            }
            Cubepos.y -= 1 + Clearance;
            Cubepos.x = tempX;
        }
    }

    void Create_HightClearrances(){
        Cubepos = this.gameObject.transform.position;
        Cubepos.y += Verticalcube / 2 + (Verticalcube / 2) * Clearance;
        Cubepos.x -= SideCule / 2 + (SideCule + 6) / 2 * Clearance;
        tempX = Cubepos.x;
        for (int y = 0; y < Verticalcube; y++)
        {
            for (int x = 0; x <= SideCule + 1; x++)
            {
                GameObject obj = Instantiate(HightClearrance, Cubepos, Quaternion.identity);
                obj.GetComponent<CLmanager>().serectpoint(y, x);
                obj.transform.SetParent(this.gameObject.transform);
                CM.Set_BaseheightCL(y, x, obj);
                obj.name = "HiClear[" + y + "," + x + "]";
                Cubepos.x += 1 + Clearance;
            }
            Cubepos.y -= 1 + Clearance;
            Cubepos.x = tempX;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
