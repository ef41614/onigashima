using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class SelectManager : MonoBehaviour
{

    public GameObject PanelCheck;
    public Image CharaFace;
    public GameObject CharaNameText;

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

    int siteA = 0;
    int siteB = 0;
    int siteC = 0;
    int siteD = 0;
    int siteE = 0;
    int siteF = 0;
    int siteG = 0;
    int siteH = 0;

    int charaNum = 0;
    Image image;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        CloseWindow();
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

        image = this.GetComponent<Image>();
    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void CloseWindow()
    {
        PanelCheck.SetActive(false);
    }

    public void OpenWindow()
    {
        PanelCheck.SetActive(true);
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
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "アイ";
    }

    public void chooseAkari()
    {
        charaNum = 2;
        CharaFace.sprite = VTuber_icon2;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "アカリ";
    }

    public void chooseAoi()
    {
        charaNum = 3;
        CharaFace.sprite = VTuber_icon3;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "あおい";
    }

    public void chooseHinata()
    {
        charaNum = 4;
        CharaFace.sprite = VTuber_icon4;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "ひなた";
    }

    public void chooseKaede()
    {
        charaNum = 5;
        CharaFace.sprite = VTuber_icon5;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "かえで";
    }

    public void chooseLuna()
    {
        charaNum = 6;
        CharaFace.sprite = VTuber_icon6;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "ルナ";
    }

    public void chooseMito()
    {
        charaNum = 7;
        CharaFace.sprite = VTuber_icon7;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "みと";
    }

    public void chooseNoja()
    {
        charaNum = 8;
        CharaFace.sprite = VTuber_icon8;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "ねこます";
    }

    public void chooseNora()
    {
        charaNum = 9;
        CharaFace.sprite = VTuber_icon9;
        image = CharaFace;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "のら";
    }

    public void chooseRin()
    {
        charaNum = 10;
        CharaFace.sprite = VTuber_icon10;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "りん";
    }

    public void chooseShiro()
    {
        charaNum = 11;
        CharaFace.sprite = VTuber_icon11;
        image = CharaFace;
        CharaNameText.GetComponent<Text>().text = "シロ";
    }

    public void chooseSora()
    {
        charaNum = 12;
        CharaFace.sprite = VTuber_icon12;
        image = CharaFace;
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

    //#################################################################################

}
// End