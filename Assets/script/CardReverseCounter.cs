﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class CardReverseCounter : MonoBehaviour {

    public CanvasGroup ReversedFace_CanvasGroup;
    public GameObject YakuCard;
    public GameObject ImageCardOyabun;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {


    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################


    public void ImageReset()
    {
        YakuCard.SetActive(false);
        ImageCardOyabun.SetActive(false);
    }

    public void ImageResetOyabun()
    {
        ImageCardOyabun.SetActive(false);
    }

    public void ImageSet()
    {
        YakuCard.SetActive(true);
        ImageCardOyabun.SetActive(true);
    }

    public void ImageSetOyabun()
    {
        ImageCardOyabun.SetActive(true);
    }

    public void StartCardOpen()
    {
        StartCoroutine(CardOpen());
    }

    //カードのGameObjectにアタッチしたScriptに記述
    //右回転用
    public IEnumerator CardOpen()
    {
        //カードを予め-180度回転させ裏面用の画像を表示する
        //裏面表示はコルーチン外で行っても良い
        //CanvasGroupでなくspriteのalpha値を操作しても良い
        transform.eulerAngles = new Vector3(0, 180, 0);
        ReversedFace_CanvasGroup.alpha = 1f;

        float angle = -180f;
        float Speed = 100f*2;

        //-90度を超えるまで回転
        while (angle < -90f)
        {
            angle += Speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, angle, 0);
            yield return null;
        }

        //裏面用の画像を非表示(表面が表示される)
        ReversedFace_CanvasGroup.alpha = 0f;

        //0度まで回転
        while (angle < 0f)
        {
            angle += Speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, angle, 0);
            yield return null;
        }

        //綺麗に0度にならないことがあるため、補正
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    //#################################################################################

}
// End