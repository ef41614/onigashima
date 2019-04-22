using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class MainFlow : MonoBehaviour {

    public static int preventShiaiNum = 1;  // 現在、第〇試合目 のナンバー
//    public GameObject ShiaiNumUe;    // 現在、第〇試合目かを画面上に表示する
    public GameObject ShiaiNumCenter;    // 現在、第〇試合目かを画面中央に表示する
    public GameObject ShiaiNumMekuri;    // 現在、第〇試合目かを めくり に表示する
    public GameObject CanvasShiaiNum;
    public GameObject ShiaiNumSeiseki;    // 現在、第〇試合目かを 総合成績 に表示する

    public int GenShiaiNum = 1;


    //####################################  Awake  ###################################

    void Awake()
    {
        Debug.Log("MainFlow Awake");
        GenShiaiNum = preventShiaiNum;
        Debug.Log("GenShiaiNum :"+ GenShiaiNum);
        Debug.Log("preventShiaiNum :" + preventShiaiNum);
    }

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
  //      SetShiaiNumUe();  //ターン開始時に画面上部に「現在、第〇試合目か」 を表示させる 
        SetShiaiNumCenter();
        SetShiaiNumMekuri();
        AppearCanvasShiaiNum();
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

    public void SetShiaiNumSeiseki_end()  // 現在、第〇試合目かを 総合成績 に表示する_しあい しゅうりょう
    {
        ShiaiNumSeiseki.GetComponent<Text>().text = "だい" + preventShiaiNum.ToString() + "しあい しゅうりょう";
    }

    public void SetShiaiNumSeiseki_during()  // 現在、第〇試合目かを 総合成績 に表示する_しあい中
    {
        ShiaiNumSeiseki.GetComponent<Text>().text = "だい" + preventShiaiNum.ToString() + "しあい ちゅう";
    }

    public void SetShiaiNumCenter()  //ターン開始時に画面中央に「現在、第〇試合目か」 を表示させる 
    {
        ShiaiNumCenter.GetComponent<Text>().text = "だ\nい\n"+ preventShiaiNum.ToString() + "\nし\nあ\nい";
    }

    public void SetShiaiNumMekuri()  //ターン開始時に画面中央に「現在、第〇試合目か」 を表示させる 
    {
        ShiaiNumMekuri.GetComponent<Text>().text = "だ\nい\n" + preventShiaiNum.ToString() + "\nし\nあ\nい";
    }

    

    public void AddShiaiNum()  // 試合ナンバーをプラス1する
    {
        preventShiaiNum++;
    }

    public void ResetShiaiNum()  // 試合ナンバーをリセットし、1に戻す
    {
        preventShiaiNum = 1;
    }

    public void AppearCanvasShiaiNum()
    {
        CanvasShiaiNum.SetActive(true);
    }

    public void CloseCanvasShiaiNum()
    {
        CanvasShiaiNum.SetActive(false);
    }

    public void LoadStartScene()
    {
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.5f, () => LoadStartScene2());  // 数秒後、ロード開始
    }

    public void LoadStartScene2()
    {
        SceneManager.LoadScene("StartScene");
    }

    //#################################################################################

}
// End
