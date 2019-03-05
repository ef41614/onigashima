﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableAspect : MonoBehaviour
{
    private Camera cam;

    // 固定したい表示サイズ
    private float width = 1080f;
    private float height = 1920f;

    // 画像のPixel Per Unit
    private float pixelPerUnit = 200f;

    //カメラのSize設定が height / 2 / picelParUnit である必要がある
    //picelParUnitが 200 で height が 1920 なら カメラのサイズは 4.8になる。

//    public GameObject Canvas_01;
    public float matchWidthOrHeight;

    public int GamenSize = 0;  // 0：「16:9」、1：XR（たて型）
    public float OriginalMakuSpeed = 2.0f;


    void Awake()
    {
        float aspect = (float)Screen.height / (float)Screen.width; //表示画面のアスペクト比
        float bgAcpect = height / width; //理想とするアスペクト比

        // カメラコンポーネントを取得します
        cam = GetComponent<Camera>();

        // カメラのorthographicSizeを設定
        cam.orthographicSize = (height / 2f / pixelPerUnit);

        if (bgAcpect >= aspect)
        {
            //画面が横に広いとき (9:16 はこちら)
            // 倍率
            float bgScale = height / Screen.height;
            // viewport rectの幅
            float camWidth = width / (Screen.width * bgScale);
            // viewportRectを設定
            cam.rect = new Rect((1.0f - camWidth) / 2f, 0f, camWidth, 1f);
            Debug.Log("画面が横に広い bgAcpect" + bgAcpect);
            Debug.Log("画面が横に広い aspect " + aspect);
            GamenSize = 0; // 0：「16:9」
            OriginalMakuSpeed = 2.0f;
        }
        else
        {
            //画面が縦に長い （XR はこちらになる）
            //想定しているアスペクト比とどれだけ差があるかを出す
            float bgScale = aspect / bgAcpect;

            // カメラのorthographicSizeを縦の長さに合わせて設定しなおす
            cam.orthographicSize *= bgScale;

            // viewportRectを設定
            cam.rect = new Rect(0f, 0f, 1f, 1f);
            Debug.Log("画面が たて に広い bgAcpect" + bgAcpect);
            Debug.Log("画面が たて に広い aspect " + aspect);
            GamenSize = 1;  // 1：XR（たて型）
            OriginalMakuSpeed = 15.0f;
        }
    }
}