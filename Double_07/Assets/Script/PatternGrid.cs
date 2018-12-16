using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternGrid : MonoBehaviour {


    private const int x_max = 9;
    private const int y_max = 1;

    #region なんか上のやつをシリアライズしたかったかもしれない
    //[Tooltip("パターンを横方向にいくつ並べるか")]
    //[SerializeField]
    //private int xMax;

    //[Tooltip("パターンを上方向にいくつ並べるか")]
    //[SerializeField]
    //private int yMax;

    #endregion


    [Tooltip("パターンの上方向の大きさ")]
    [SerializeField]
    private int pattern_size_x;

    [Tooltip("パターンの横方向の大きさ")]
    [SerializeField]
    private int pattern_size_y;

    #region
    //private const int rightUpCornerPattern = 1;
    //[Tooltip("空前絶後の右上")]
    //[SerializeField]
    //private GameObject[] rightUpCorner = new GameObject[rightUpCornerPattern];

    //private const int leftUpCornerPattern = 1;
    //[Tooltip("左上の素材")]
    //[SerializeField]
    //private GameObject[] leftUpCorner = new GameObject[leftUpCornerPattern];

    //private const int rightDownCornerPattern = 1;
    //[Tooltip("右下の素材")]
    //[SerializeField]
    //private GameObject[] rightDownCorner = new GameObject[rightDownCornerPattern];

    //private const int leftDownCornerPattern = 1;
    //[Tooltip("左下の素材")]
    //[SerializeField]
    //private GameObject[] leftDownCorner = new GameObject[leftDownCornerPattern];

    //private const int upPattern = 1;
    //[Tooltip("上の素材")]
    //[SerializeField]
    //private GameObject[] up = new GameObject [upPattern];

    //private const int leftPattern = 1;
    //[Tooltip("左の素材")]
    //[SerializeField]
    //private GameObject[] left = new GameObject[leftPattern];

    //private const int rightPattern = 1;
    //[Tooltip("右の素材")]
    //[SerializeField]
    //private GameObject[] right = new GameObject[rightPattern];

    //private const int floorPattern = 1;
    //[Tooltip("床の素材")]
    //[SerializeField]
    //private GameObject[] floor = new GameObject[floorPattern];
    #endregion

    private const int image_button_pattern = 1;
    [Tooltip("ボタンの素材")]
    [SerializeField]
    private GameObject[] image_button = new GameObject[image_button_pattern];

    private GameObject[,] grid = new GameObject[x_max, y_max];

	// Use this for initialization
    void Start () {
        for (int i = 0; i < x_max; i += 1){
            for (int j = 0; j < y_max; j += 1){
                StageGrid(i, j);
            }
        }
	}

    private void StageGrid(int x, int y){

        #region 大量のメモ書き
        //if(x == 0){
        //    if(y == 0){
        //        grid[x,y] = Instantiate(corner[Random.Range(0,cornerPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //        return;
        //    }
        //    if(y == yMax - 1){
        //        grid[x, y] = Instantiate(corner[Random.Range(0, cornerPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //        return;
        //    }
        //    grid[x,y] = Instantiate(left[Random.Range(0, leftPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(y == 0){
        //    if(x == xMax - 1){
        //        grid[x,y] = Instantiate(corner[Random.Range(0, cornerPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //        return;
        //    }
        //    grid[x, y] = Instantiate(floor[Random.Range(0, floorPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(x == xMax - 1){
        //    if(y == yMax - 1){
        //        grid[x, y] = Instantiate(corner[Random.Range(0, cornerPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //        return;
        //    }
        //    grid[x, y] = Instantiate(right[Random.Range(0, rightPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(y == yMax - 1){
        //    grid[x, y] = Instantiate(up[Random.Range(0, upPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if((x == 0 && (y == 0 || y == yMax - 1)) || (x == xMax - 1 && (y == 0 || y == yMax - 1))){
        //    grid[x, y] = Instantiate(corner[Random.Range(0, cornerPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    Debug.Log(new Vector2(x,y));
        //    return;
        //}

        #endregion

        #region
        //if (x == 0 && y == 0){
        //    grid[x, y] = Instantiate(leftDownCorner[Random.Range(0, leftDownCornerPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(x == 0 && y == yMax - 1){
        //    grid[x, y] = Instantiate(leftUpCorner[Random.Range(0, leftUpCornerPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(x == xMax - 1 && y == 0){
        //    grid[x, y] = Instantiate(rightDownCorner[Random.Range(0, rightDownCornerPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(x == xMax - 1 && y == yMax - 1){
        //    grid[x, y] = Instantiate(rightUpCorner[Random.Range(0, rightUpCornerPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(x == 0){
        //    grid[x, y] = Instantiate(left[Random.Range(0, leftPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(y == 0){
        //    grid[x, y] = Instantiate(floor[Random.Range(0, floorPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(x == xMax - 1){
        //    grid[x, y] = Instantiate(right[Random.Range(0, rightPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        //if(y == yMax - 1){
        //    grid[x, y] = Instantiate(up[Random.Range(0, upPattern)], new Vector3(x * patternSizeX, y * patternSizeY, 0.0f), Quaternion.identity);
        //    return;
        //}

        #endregion

        grid[x, y] = Instantiate(image_button[Random.Range(0, image_button_pattern)], new Vector3(x * pattern_size_x, y * pattern_size_y, 0.0f), Quaternion.identity);
    }

}
