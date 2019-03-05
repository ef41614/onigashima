using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeControlForCamera : MonoBehaviour
{
    //最初に作った画面のwidth
    public float defaultWidth = 9.0f;

    //最初に作った画面のheight
    public float defaultHeight = 16.0f;

    void Start()
    {
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen  height: " + Screen.height);
        Debug.Log("◎ Screen currentResolution : " + Screen.currentResolution);

        //camera.mainを変数に格納
        Camera mainCamera = Camera.main;

        Debug.Log("◎ mainCamera.orthographicSize : " + mainCamera.orthographicSize);


        //最初に作った画面のアスペクト比 
        float defaultAspect = defaultWidth / defaultHeight;

        //実際の画面のアスペクト比
        float actualAspect = (float)Screen.width / (float)Screen.height;

        //実機とunity画面の比率
        float ratio = actualAspect / defaultAspect;

        //サイズ調整
        mainCamera.orthographicSize /= ratio *0.5f;

        Debug.Log("■ Screen currentResolution : " + Screen.currentResolution);
        Debug.Log("■ Screen ratio : " + ratio);
        Debug.Log("■ mainCamera.orthographicSize : " + mainCamera.orthographicSize);

    }
}