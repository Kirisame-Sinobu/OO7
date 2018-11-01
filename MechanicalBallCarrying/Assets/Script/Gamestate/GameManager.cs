using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static bool setobj=true;                        //置くオブジェクトが選択されているか否か（予定）
    public static Responce.Createobj issetobj = Responce.Createobj.Cube;              //置くオブジェの種類
    public static bool Notwall = true;
    public static bool GameClear = false;
    public static bool Not_Touch = false;
    public static bool GameOver = false;


	// Update is called once per frame
	void Update () {
        //if(issetobj > Responce.Createobj.BreakCube){
        //    Notwall = false;
        //}else {
        //    Notwall = true;
        //}
	}
}
