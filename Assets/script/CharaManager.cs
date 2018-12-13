﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class CharaManager : MonoBehaviour {

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

    public GameObject SiteManager;
    SiteManager SiteMSC;

    Image image;
    String str;
//    public Sprite SiteA_charaF;
//    public GameObject SiteA_charaF;
    public Image SiteA_charaF;
    public Image SiteB_charaF;
    public Image SiteC_charaF;
    public Image SiteD_charaF;
    public Image SiteE_charaF;
    public Image SiteF_charaF;
    public Image SiteG_charaF;
    public Image SiteH_charaF;

    string SiteA_charaNametext;
    string SiteB_charaNametext;
    string SiteC_charaNametext;
    string SiteD_charaNametext;
    string SiteE_charaNametext;
    string SiteF_charaNametext;
    string SiteG_charaNametext;
    string SiteH_charaNametext;

    public Image PreventCharaFace;
    public GameObject CharaNameText;
    public int countX = 1;

    public Image NowActiveCharaFace;
    public GameObject NowActiveCharaNameText;
//    public GameObject NowActiveCharaNameText;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        //countX = SiteMSC.human_num;
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        image = this.GetComponent<Image>();
        //str = this.GetComponent<string>();

        SiteA_charaNametext = CharaFaceSet(SiteA_charaF, 1, SiteA_charaNametext);
        SiteB_charaNametext = CharaFaceSet(SiteB_charaF, 2, SiteB_charaNametext);
        SiteC_charaNametext = CharaFaceSet(SiteC_charaF, 3, SiteC_charaNametext);
        SiteD_charaNametext = CharaFaceSet(SiteD_charaF, 4, SiteD_charaNametext);
        SiteE_charaNametext = CharaFaceSet(SiteE_charaF, 5, SiteE_charaNametext);
        SiteF_charaNametext = CharaFaceSet(SiteF_charaF, 6, SiteF_charaNametext);
        SiteG_charaNametext = CharaFaceSet(SiteG_charaF, 7, SiteG_charaNametext);
        SiteH_charaNametext = CharaFaceSet(SiteH_charaF, 8, SiteH_charaNametext);


        //        image.SetNativeSize();

        //this.gameObject.GetComponent<Image>().sprite = VTuber_icon1;
        AppearPreventChara();  // 【初回時】巻物に現在手番のキャラを表示させる（やくわりチェック）
        AppearNowActiveSite(); // 下のスクロール欄に現在手番のキャラを表示させる
    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public String CharaFaceSet(Image charaFace, int x, string CharaName)
    {
        switch (SiteMSC.charaN[x])
        {
            case 1:
                charaFace.sprite = VTuber_icon1;
                CharaName = "アイ";
                break;
            case 2:
                charaFace.sprite = VTuber_icon2;
                CharaName = "アカリ";
                break;
            case 3:
                charaFace.sprite = VTuber_icon3;
                CharaName = "あおい";
                break;
            case 4:
                charaFace.sprite = VTuber_icon4;
                CharaName = "ひなた";
                break;
            case 5:
                charaFace.sprite = VTuber_icon5;
                CharaName = "かえで";
                break;
            case 6:
                charaFace.sprite = VTuber_icon6;
                CharaName = "ルナ";
                break;
            case 7:
                charaFace.sprite = VTuber_icon7;
                CharaName = "みと";
                break;
            case 8:
                charaFace.sprite = VTuber_icon8;
                CharaName = "ねこます";
                break;
            case 9:
                charaFace.sprite = VTuber_icon9;
                CharaName = "のら";
                break;
            case 10:
                charaFace.sprite = VTuber_icon10;
                CharaName = "りん";
                break;
            case 11:
                charaFace.sprite = VTuber_icon11;
                CharaName = "シロ";
                break;
            case 12:
                charaFace.sprite = VTuber_icon12;
                CharaName = "そら";
                break;
            default:
                // 処理３
                break;
        }
        return CharaName;
//        image = charaFace;
//        str = CharaName;
        Debug.Log("★CharaName: "+ CharaName);
        Debug.Log("★SiteA_charaNametext はじめの: " + SiteA_charaNametext);
        //        PreventCharaFace = image;
    }

    public void AppearPreventChara() // 【初回時】巻物に現在手番のキャラを表示させる（やくわりチェック）
    {
        if (countX <= SiteMSC.human_num)
        {
            switch (SiteMSC.charaN[countX])
            {
                case 1:
                    PreventCharaFace.sprite = VTuber_icon1;
                    CharaNameText.GetComponent<Text>().text = "アイ";
                    break;
                case 2:
                    PreventCharaFace.sprite = VTuber_icon2;
                    CharaNameText.GetComponent<Text>().text = "アカリ";
                    break;
                case 3:
                    PreventCharaFace.sprite = VTuber_icon3;
                    CharaNameText.GetComponent<Text>().text = "あおい";
                    break;
                case 4:
                    PreventCharaFace.sprite = VTuber_icon4;
                    CharaNameText.GetComponent<Text>().text = "ひなた";
                    break;
                case 5:
                    PreventCharaFace.sprite = VTuber_icon5;
                    CharaNameText.GetComponent<Text>().text = "かえで";
                    break;
                case 6:
                    PreventCharaFace.sprite = VTuber_icon6;
                    CharaNameText.GetComponent<Text>().text = "ルナ";
                    break;
                case 7:
                    PreventCharaFace.sprite = VTuber_icon7;
                    CharaNameText.GetComponent<Text>().text = "みと";
                    break;
                case 8:
                    PreventCharaFace.sprite = VTuber_icon8;
                    CharaNameText.GetComponent<Text>().text = "ねこます";
                    break;
                case 9:
                    PreventCharaFace.sprite = VTuber_icon9;
                    CharaNameText.GetComponent<Text>().text = "のら";
                    break;
                case 10:
                    PreventCharaFace.sprite = VTuber_icon10;
                    CharaNameText.GetComponent<Text>().text = "りん";
                    break;
                case 11:
                    PreventCharaFace.sprite = VTuber_icon11;
                    CharaNameText.GetComponent<Text>().text = "シロ";
                    break;
                case 12:
                    PreventCharaFace.sprite = VTuber_icon12;
                    CharaNameText.GetComponent<Text>().text = "そら";
                    break;
                default:
                    // 処理３
                    break;
            }
        }
        countX++;
        image = PreventCharaFace;

 //       PreventCharaFace.sprite = VTuber_icon1;
 //      image = PreventCharaFace;

    }

    public void AppearNowActiveSite() // 下のスクロール欄に現在手番のキャラを表示させる
    {
        Debug.Log("◎●SiteMSC.NowActiveSiteN: " + SiteMSC.NowActiveSiteN);
        switch (SiteMSC.NowActiveSiteN)
        {
            case 1:
                NowActiveCharaFace.sprite = SiteA_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteA_charaNametext;
                break;
            case 2:
                NowActiveCharaFace.sprite = SiteB_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteB_charaNametext;
                break;
            case 3:
                NowActiveCharaFace.sprite = SiteC_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteC_charaNametext;
                break;
            case 4:
                NowActiveCharaFace.sprite = SiteD_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteD_charaNametext;
                break;
            case 5:
                NowActiveCharaFace.sprite = SiteE_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteE_charaNametext;
                break;
            case 6:
                NowActiveCharaFace.sprite = SiteF_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteF_charaNametext;
                break;
            case 7:
                NowActiveCharaFace.sprite = SiteG_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteG_charaNametext;
                break;
            case 8:
                NowActiveCharaFace.sprite = SiteH_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteH_charaNametext;
                break;
            default:
                // 処理３
                break;
        }
        image = NowActiveCharaFace;
        Debug.Log("◎●SiteA_charaNametext: " + SiteA_charaNametext);
//        Debug.Log("◎●NowActiveCharaNameText: " + NowActiveCharaNameText);

    }


    public void CheckPreventChara() // 【ゲーム開始後】巻物に現在手番のキャラを表示させる（やくわりチェック）
    {
        switch (SiteMSC.NowActiveSiteN)
        {
            case 1:
                PreventCharaFace.sprite = SiteA_charaF.sprite;
                CharaNameText.GetComponent<Text>().text = SiteA_charaNametext;
                break;
            case 2:
                PreventCharaFace.sprite = SiteB_charaF.sprite;
                CharaNameText.GetComponent<Text>().text = SiteB_charaNametext;
                break;
            case 3:
                PreventCharaFace.sprite = SiteC_charaF.sprite;
                CharaNameText.GetComponent<Text>().text = SiteC_charaNametext;
                break;
            case 4:
                PreventCharaFace.sprite = SiteD_charaF.sprite;
                CharaNameText.GetComponent<Text>().text = SiteD_charaNametext;
                break;
            case 5:
                PreventCharaFace.sprite = SiteE_charaF.sprite;
                CharaNameText.GetComponent<Text>().text = SiteE_charaNametext;
                break;
            case 6:
                PreventCharaFace.sprite = SiteF_charaF.sprite;
                CharaNameText.GetComponent<Text>().text = SiteF_charaNametext;
                break;
            case 7:
                PreventCharaFace.sprite = SiteG_charaF.sprite;
                CharaNameText.GetComponent<Text>().text = SiteG_charaNametext;
                break;
            case 8:
                PreventCharaFace.sprite = SiteH_charaF.sprite;
                CharaNameText.GetComponent<Text>().text = SiteH_charaNametext;
                break;
            default:
                // 処理３
                break;
        }
    }

    //#################################################################################

}
// End