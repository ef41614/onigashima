using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class MainFlow : MonoBehaviour {

    //******* 定数  *******
    int TURN_MAX = 5; //最大ターン数

    //******* 変数  *******
    bool turnLoopFlg = true; //ターンループフラグ

    int nowTurnNum = 0; //現在ターン番号



    //☆################☆################  Start  ################☆################☆

    void Start()
    {


    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void LoadGameScene()
    {
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.5f, () => LoadGameScene2());  // 数秒後、ロード開始

    }

    public void LoadGameScene2()
    {
        SceneManager.LoadScene("GameScene");
    }


    //#################################################################################

}
// End
