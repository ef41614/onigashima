using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{

    public GameObject PanelCheck;
    public GameObject PanelCheck_numberOfPersons;
    public Image CharaFace;
    public GameObject CharaNameText;
    public GameObject PanelNextToScene;

    public GameObject Cover_01;
    public GameObject Cover_02;
    public GameObject Cover_03;
    public GameObject Cover_04;
    public GameObject Cover_05;
    public GameObject Cover_06;

    public GameObject Cover_07;
    public GameObject Cover_08;
    public GameObject Cover_09;
    public GameObject Cover_10;
    public GameObject Cover_11;
    public GameObject Cover_12;

    public Sprite VTuber_icon1;
    public Sprite VTuber_icon2;
    public Sprite VTuber_icon3;
    public Sprite VTuber_icon4;
    public Sprite VTuber_icon5;
    public Sprite VTuber_icon6;
    public Sprite VTuber_icon7;
    public Sprite VTuber_icon8;
    public Sprite VTuber_icon9;
    public Sprite VTuber_icon10;
    public Sprite VTuber_icon11;
    public Sprite VTuber_icon12;

    public static int siteA = 0;
    public static int siteB = 0;
    public static int siteC = 0;
    public static int siteD = 0;
    public static int siteE = 0;
    public static int siteF = 0;
    public static int siteG = 0;
    public static int siteH = 0;

    int charaNum = 0;
//    Image image;

    public static int hito_num = 1;
    public int robo_num = 0;
    public GameObject hito_numText;
    public GameObject robo_numText;
    int HandOfTime = 0;    // 「つぎの人に渡してね」のメッセージを表示させる
    public GameObject ImageHandToNext;

    public GameObject robo_01;
    public GameObject robo_02;
    public GameObject robo_03;
    public GameObject robo_04;
    public GameObject robo_05;
    public GameObject robo_06;
    public GameObject robo_07;
    public GameObject robo_08;

    int rndNum = 0;
    bool InputOKFlg = false;  // 各サイトにキャラ番号情報（数値）を入力できるフラグ
    public int[] charaN = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }; //VTuberのキャラネーム

    public static int OniStrong = 2;  // 鬼チームの強さ： 2（デフォルト）が「ふつう」

    bool SelectedFlgOni01 = false;  // よわい
    bool SelectedFlgOni02 = false;  // ふつう
    bool SelectedFlgOni03 = false;  // つよい
    bool SelectedFlgOni04 = false;  // ちょつよ

    public GameObject ImageOniStr01;
    public GameObject ImageOniStr02;
    public GameObject ImageOniStr03;
    public GameObject ImageOniStr04;

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
 //       CloseWindow();
 //       CloseWindow2();
        KesuCover_01();
        KesuCover_02();
        KesuCover_03();
        KesuCover_04();
        KesuCover_05();
        KesuCover_06();

        KesuCover_07();
        KesuCover_08();
        KesuCover_09();
        KesuCover_10();
        KesuCover_11();
        KesuCover_12();

//        image = this.GetComponent<Image>();
        Check_numberOfPersons();
        ResetSelectOniStrong();  // おにチームの強さを一旦リセットする
        SelectOnistr02();   // 初期設定「ふつう」にする
        CheckSelectedOniStr();  // 選択されている強さをアピールする（黄色背景点滅）

    }


    //####################################  Update  ###################################

    void Update()
    {
        Debug.Log("OniStrong == " + OniStrong);

    }

    //####################################  other  ####################################

    public void CloseWindow()
    {
        PanelCheck.SetActive(false);
        Debug.Log("HandOfTime == " + HandOfTime);

        if (HandOfTime > 0)
        {
            var sequence = DOTween.Sequence();
            sequence.InsertCallback(0.2f, () => OpenImageHandToNext());
            sequence.InsertCallback(2.0f, () => CloseImageHandToNext());
            recordChara();
            HandOfTime--;
        }
        else if (HandOfTime <= 0)
        {
            recordChara();
            Debug.Log("InputEmptySite ：空のサイトに数字をランダムに入れる");
            var sequence = DOTween.Sequence();
            sequence.InsertCallback(0.3f, () => InputEmptySite());
            sequence.InsertCallback(0.5f, () => OpenWindow3());
        }
        Debug.Log("siteA == " + siteA);
        Debug.Log("siteB == " + siteB);
        Debug.Log("siteC == " + siteC);
        Debug.Log("siteD == " + siteD);

        Debug.Log("siteE == " + siteE);
        Debug.Log("siteF == " + siteF);
        Debug.Log("siteG == " + siteG);
        Debug.Log("siteH == " + siteH);
        Debug.Log("-----------------");
    }

    public void CloseWindowOnly()
    {
        PanelCheck.SetActive(false);
    }

    public void OpenWindow()
    {
        PanelCheck.SetActive(true);
    }

    public void CloseWindow2()
    {
        PanelCheck_numberOfPersons.SetActive(false);
        Debug.Log("hito_num == " + hito_num);
        Debug.Log("HandOfTime == " + HandOfTime);
    }

    public void OpenWindow2()
    {
        PanelCheck_numberOfPersons.SetActive(true);
    }

    public void CloseWindow3()
    {
        PanelNextToScene.SetActive(false);
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.5f, () => StartGameScene());
    }

    public void StartGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenWindow3()
    {
        PanelNextToScene.SetActive(true);
    }

    public void OpenImageHandToNext()
    {
        ImageHandToNext.SetActive(true);
    }

    public void CloseImageHandToNext()
    {
        ImageHandToNext.SetActive(false);
    }

    #region recordChara
    public void recordChara()
    {
        if (siteA == 0)
        {
            siteA = charaNum;
        }
        else if (siteB == 0)
        {
            siteB = charaNum;
        }
        else if (siteC == 0)
        {
            siteC = charaNum;
        }
        else if (siteD == 0)
        {
            siteD = charaNum;
        }
        else if (siteE == 0)
        {
            siteE = charaNum;
        }
        else if (siteF == 0)
        {
            siteF = charaNum;
        }
        else if (siteG == 0)
        {
            siteG = charaNum;
        }
        else if (siteH == 0)
        {
            siteH = charaNum;
        }
    }
    #endregion

    #region chooseVTuber
    public void chooseAi()
    {
        charaNum = 1;
        CharaFace.sprite = VTuber_icon1;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "アイ";
    }

    public void chooseAkari()
    {
        charaNum = 2;
        CharaFace.sprite = VTuber_icon2;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "アカリ";
    }

    public void chooseAoi()
    {
        charaNum = 3;
        CharaFace.sprite = VTuber_icon3;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "あおい";
    }

    public void chooseHinata()
    {
        charaNum = 4;
        CharaFace.sprite = VTuber_icon4;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "ひなた";
    }

    public void chooseKaede()
    {
        charaNum = 5;
        CharaFace.sprite = VTuber_icon5;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "かえで";
    }

    public void chooseLuna()
    {
        charaNum = 6;
        CharaFace.sprite = VTuber_icon6;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "ルナ";
    }

    public void chooseMito()
    {
        charaNum = 7;
        CharaFace.sprite = VTuber_icon7;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "みと";
    }

    public void chooseNoja()
    {
        charaNum = 8;
        CharaFace.sprite = VTuber_icon8;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "ねこます";
    }

    public void chooseNora()
    {
        charaNum = 9;
        CharaFace.sprite = VTuber_icon9;
//        image = CharaFace;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "のら";
    }

    public void chooseRin()
    {
        charaNum = 10;
        CharaFace.sprite = VTuber_icon10;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "りん";
    }

    public void chooseShiro()
    {
        charaNum = 11;
        CharaFace.sprite = VTuber_icon11;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "シロ";
    }

    public void chooseSora()
    {
        charaNum = 12;
        CharaFace.sprite = VTuber_icon12;
//        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "そら";
    }
    

    #endregion

    #region KesuCover
    public void KesuCover_01()
    {
       Cover_01.SetActive(false);
    }

    public void KesuCover_02()
    {
        Cover_02.SetActive(false);
    }

    public void KesuCover_03()
    {
        Cover_03.SetActive(false);
    }

    public void KesuCover_04()
    {
        Cover_04.SetActive(false);
    }

    public void KesuCover_05()
    {
        Cover_05.SetActive(false);
    }

    public void KesuCover_06()
    {
        Cover_06.SetActive(false);
    }

    public void KesuCover_07()
    {
        Cover_07.SetActive(false);
    }

    public void KesuCover_08()
    {
        Cover_08.SetActive(false);
    }

    public void KesuCover_09()
    {
        Cover_09.SetActive(false);
    }

    public void KesuCover_10()
    {
        Cover_10.SetActive(false);
    }

    public void KesuCover_11()
    {
        Cover_11.SetActive(false);
    }

    public void KesuCover_12()
    {
        Cover_12.SetActive(false);
    }
    #endregion

    #region SetCover
    public void SetCover_01()
    {
        Cover_01.SetActive(true);
    }

    public void SetCover_02()
    {
        Cover_02.SetActive(true);
    }

    public void SetCover_03()
    {
        Cover_03.SetActive(true);
    }

    public void SetCover_04()
    {
        Cover_04.SetActive(true);
    }

    public void SetCover_05()
    {
        Cover_05.SetActive(true);
    }

    public void SetCover_06()
    {
        Cover_06.SetActive(true);
    }

    public void SetCover_07()
    {
        Cover_07.SetActive(true);
    }

    public void SetCover_08()
    {
        Cover_08.SetActive(true);
    }

    public void SetCover_09()
    {
        Cover_09.SetActive(true);
    }

    public void SetCover_10()
    {
        Cover_10.SetActive(true);
    }

    public void SetCover_11()
    {
        Cover_11.SetActive(true);
    }

    public void SetCover_12()
    {
        Cover_12.SetActive(true);
    }
    #endregion

    public void SetCover()
    {
        BranchSetCover(charaNum);
    }

    public void BranchSetCover(int x)
    {
        switch (x)
        {
            case 1:
                SetCover_01();
                break;
            case 2:
                SetCover_02();
                break;
            case 3:
                SetCover_03();
                break;
            case 4:
                SetCover_04();
                break;
            case 5:
                SetCover_05();
                break;
            case 6:
                SetCover_06();
                break;
            case 7:
                SetCover_07();
                break;
            case 8:
                SetCover_08();
                break;
            case 9:
                SetCover_09();
                break;
            case 10:
                SetCover_10();
                break;
            case 11:
                SetCover_11();
                break;
            case 12:
                SetCover_12();
                break;
            default:
                // 処理３
                break;
        }
    }

    public void Check_numberOfPersons()
    {
        robo_num = 8 - hito_num;
        HandOfTime = hito_num - 1;
        hito_numText.GetComponent<Text>().text = hito_num+"";
        robo_numText.GetComponent<Text>().text = robo_num + "";
        OnRoboImgage();
        OffRoboImgage();
    }

    public void hitoNumPlus()
    {
        if(hito_num < 8)
        {
            hito_num++;
            Check_numberOfPersons();
        }
    }

    public void hitoNumMinus()
    {
        if (hito_num > 1)
        {
            hito_num--;
            Check_numberOfPersons();
        }
    }

    public void OnRoboImgage()
    {
        if (hito_num < 2)
        {
            robo_02.SetActive(true);
        }
        if (hito_num < 3)
        {
            robo_03.SetActive(true);
        }
        if (hito_num < 4)
        {
            robo_04.SetActive(true);
        }
        if (hito_num < 5)
        {
            robo_05.SetActive(true);
        }
        if (hito_num < 6)
        {
            robo_06.SetActive(true);
        }
        if (hito_num < 7)
        {
            robo_07.SetActive(true);
        }
        if (hito_num < 8)
        {
            robo_08.SetActive(true);
        }
    }

    public void OffRoboImgage()
    {
        if (hito_num >= 2)
        {
            robo_02.SetActive(false);
        }
        if (hito_num >= 3)
        {
            robo_03.SetActive(false);
        }
        if (hito_num >= 4)
        {
            robo_04.SetActive(false);
        }
        if (hito_num >= 5)
        {
            robo_05.SetActive(false);
        }
        if (hito_num >= 6)
        {
            robo_06.SetActive(false);
        }
        if (hito_num >= 7)
        {
            robo_07.SetActive(false);
        }
        if (hito_num >= 8)
        {
            robo_08.SetActive(false);
        }
    }

    public static int getHito_num()
    {
        return hito_num;
    }


    public void InputEmptySite()
    {
        var ary = Enumerable.Range(1, 12).OrderBy(n => Guid.NewGuid()).Take(8).ToArray();

        for (int s = 0; s < ary.Length; s++)
        {
            charaN[s + 1] = ary[s];
            Debug.Log(ary[s]);
            Debug.Log("charaN[" + (s + 1) + "]" + charaN[(s + 1)]);
        }

        for (int s = 0; s < 8; s++)
        {
            rndNum = charaN[s + 1];
            if (siteA == 0)
            {
                checkDouble();
                if (InputOKFlg)
                {
                    siteA = rndNum;
                }
            }
            else if (siteB == 0)
            {
                checkDouble();
                if (InputOKFlg)
                {
                    siteB = rndNum;
                }
            }
            else if (siteC == 0)
            {
                checkDouble();
                if (InputOKFlg)
                {
                    siteC = rndNum;
                }
            }
            else if (siteD == 0)
            {
                checkDouble();
                if (InputOKFlg)
                {
                    siteD = rndNum;
                }
            }
            else if (siteE == 0)
            {
                checkDouble();
                if (InputOKFlg)
                {
                    siteE = rndNum;
                }
            }
            else if (siteF == 0)
            {
                checkDouble();
                if (InputOKFlg)
                {
                    siteF = rndNum;
                }
            }
            else if (siteG == 0)
            {
                checkDouble();
                if (InputOKFlg)
                {
                    siteG = rndNum;
                }
            }
            else if (siteH == 0)
            {
                checkDouble();
                if (InputOKFlg)
                {
                    siteH = rndNum;
                }
            }
        }
        Debug.Log("siteA == " + siteA);
        Debug.Log("siteB == " + siteB);
        Debug.Log("siteC == " + siteC);
        Debug.Log("siteD == " + siteD);

        Debug.Log("siteE == " + siteE);
        Debug.Log("siteF == " + siteF);
        Debug.Log("siteG == " + siteG);
        Debug.Log("siteH == " + siteH);
    }



    public void checkDouble()
    {
        int PassTotal = 0;
        InputOKFlg = false;
        if (siteA != rndNum)
        {
            PassTotal++;
        }
        if (siteB != rndNum)
        {
            PassTotal++;
        }
        if (siteC != rndNum)
        {
            PassTotal++;
        }
        if (siteD != rndNum)
        {
            PassTotal++;
        }
        if (siteE != rndNum)
        {
            PassTotal++;
        }
        if (siteF != rndNum)
        {
            PassTotal++;
        }
        if (siteG != rndNum)
        {
            PassTotal++;
        }
        if (siteH != rndNum)
        {
            PassTotal++;
        }
        if (PassTotal >= 8)
        {
            InputOKFlg = true;
        }
    }

    #region getSiteInfo
    public static int getSiteAInfo()
    {
        return siteA;
    }

    public static int getSiteBInfo()
    {
        return siteB;
    }

    public static int getSiteCInfo()
    {
        return siteC;
    }

    public static int getSiteDInfo()
    {
        return siteD;
    }

    public static int getSiteEInfo()
    {
        return siteE;
    }

    public static int getSiteFInfo()
    {
        return siteF;
    }

    public static int getSiteGInfo()
    {
        return siteG;
    }

    public static int getSiteHInfo()
    {
        return siteH;
    }

    public static int getHito_numInfo()
    {
        return hito_num;
    }
    #endregion

    public void ResetSelectOniStrong()  // フラグをすべてfalseにする（あくまでフラグのみ。これだけでは非表示にならない）
    {
        SelectedFlgOni01 = false;
        SelectedFlgOni02 = false;
        SelectedFlgOni03 = false;
        SelectedFlgOni04 = false;
    }

    public void SelectOnistr01()
    {
        SelectedFlgOni01 = true;
    }

    public void SelectOnistr02()
    {
        SelectedFlgOni02 = true;
    }

    public void SelectOnistr03()
    {
        SelectedFlgOni03 = true;
    }

    public void SelectOnistr04()
    {
        SelectedFlgOni04 = true;
    }

    public void CheckSelectedOniStr()
    {
        CloseSelectedOniStr();  // まず、全部消す
        AppearSelectedOniStr();  // 次に、条件にあった物のみ表示させる
    }

    public void AppearSelectedOniStr()
    {
        if (SelectedFlgOni01)
        {
            ImageOniStr01.SetActive(true);
            OniStrong = 1;
        }
        if (SelectedFlgOni02)
        {
            ImageOniStr02.SetActive(true);
            OniStrong = 2;
        }
        if (SelectedFlgOni03)
        {
            ImageOniStr03.SetActive(true);
            OniStrong = 3;
        }
        if (SelectedFlgOni04)
        {
            ImageOniStr04.SetActive(true);
            OniStrong = 4;
        }
    }

    public void CloseSelectedOniStr()
    {
        ImageOniStr01.SetActive(false);
        ImageOniStr02.SetActive(false);
        ImageOniStr03.SetActive(false);
        ImageOniStr04.SetActive(false);
    }

    public static int getOniStrong()  // ゲッターの関数
    { 
        return OniStrong;
    }

    //#################################################################################

}
// End