﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class YakuManager : MonoBehaviour {

    public Sprite Yaku_icon1;
    public Sprite Yaku_icon2;
    public Sprite Yaku_icon3;
    public Sprite Yaku_icon4;
    public Sprite Yaku_icon5;
    public Sprite Yaku_icon6;
    public Sprite Yaku_icon7;
    public Sprite Yaku_icon8;

    public GameObject SiteManager;
    SiteManager SiteMSC;

    Image image;

    //public Sprite SiteA_turn;
    //    public GameObject SiteA_turn;
    public Image SiteA_rollF;
    public Image SiteB_rollF;
    public Image SiteC_rollF;
    public Image SiteD_rollF;
    public Image SiteE_rollF;
    public Image SiteF_rollF;
    public Image SiteG_rollF;
    public Image SiteH_rollF;
    public Image SiteTrash_rollF;

    string SiteA_roleNametext;
    string SiteB_roleNametext;
    string SiteC_roleNametext;
    string SiteD_roleNametext;
    string SiteE_roleNametext;
    string SiteF_roleNametext;
    string SiteG_roleNametext;
    string SiteH_roleNametext;

    public Image PreventRollFace;
    public GameObject RollNameText;
    public int countX = 1;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        image = this.GetComponent<Image>();

        SiteA_roleNametext = RollFaceSet(SiteA_rollF, 1, SiteA_roleNametext);
        SiteB_roleNametext = RollFaceSet(SiteB_rollF, 2, SiteB_roleNametext);
        SiteC_roleNametext = RollFaceSet(SiteC_rollF, 3, SiteC_roleNametext);
        SiteD_roleNametext = RollFaceSet(SiteD_rollF, 4, SiteD_roleNametext);
        SiteE_roleNametext = RollFaceSet(SiteE_rollF, 5, SiteE_roleNametext);
        SiteF_roleNametext = RollFaceSet(SiteF_rollF, 6, SiteF_roleNametext);
        SiteG_roleNametext = RollFaceSet(SiteG_rollF, 7, SiteG_roleNametext);
        SiteH_roleNametext = RollFaceSet(SiteH_rollF, 8, SiteH_roleNametext);

        //        RollFaceSet(SiteTrash_rollF, 8);


        //this.gameObject.GetComponent<Image>().sprite = Yaku_icon1;
        AppearPreventRoll(); //【初回時】巻物に現在手番の役職を表示させる（やくわりチェック）

    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public String RollFaceSet(Image RollFace, int x, string RoleName)
    {
        switch (SiteMSC.rollF[x])
        {
            case 1:
                RollFace.sprite = Yaku_icon1;
                RoleName = "ももたろう";
                break;
            case 2:
                RollFace.sprite = Yaku_icon2;
                RoleName = "いぬ";
                break;
            case 3:
                RollFace.sprite = Yaku_icon3;
                RoleName = "さる";
                break;
            case 4:
                RollFace.sprite = Yaku_icon4;
                RoleName = "きじ";
                break;
            case 5:
                RollFace.sprite = Yaku_icon5;
                RoleName = "オニのおやぶん";
                break;
            case 6:
                RollFace.sprite = Yaku_icon6;
                RoleName = "こオニ";
                break;
            case 7:
                RollFace.sprite = Yaku_icon7;
                RoleName = "こオニ";
                break;
            case 8:
                RollFace.sprite = Yaku_icon8;
                RoleName = "こオニ";
                break;
            default:
                // 処理３
                break;
        }
        return RoleName;
        image = RollFace;
        image.SetNativeSize();
    }

    public void AppearPreventRoll() //【初回時】巻物に現在手番の役職を表示させる（やくわりチェック）
    {
        if (countX <= SiteMSC.human_num)
        {
            switch (SiteMSC.rollF[countX])
            {
                case 1:
                    PreventRollFace.sprite = Yaku_icon1;
                    RollNameText.GetComponent<Text>().text = "ももたろう";
                    break;
                case 2:
                    PreventRollFace.sprite = Yaku_icon2;
                    RollNameText.GetComponent<Text>().text = "いぬ";
                    break;
                case 3:
                    PreventRollFace.sprite = Yaku_icon3;
                    RollNameText.GetComponent<Text>().text = "さる";
                    break;
                case 4:
                    PreventRollFace.sprite = Yaku_icon4;
                    RollNameText.GetComponent<Text>().text = "きじ";
                    break;
                case 5:
                    PreventRollFace.sprite = Yaku_icon5;
                    RollNameText.GetComponent<Text>().text = "オニのおやぶん";
                    break;
                case 6:
                    PreventRollFace.sprite = Yaku_icon6;
                    RollNameText.GetComponent<Text>().text = "こオニ";
                    break;
                case 7:
                    PreventRollFace.sprite = Yaku_icon7;
                    RollNameText.GetComponent<Text>().text = "こオニ";
                    break;
                case 8:
                    PreventRollFace.sprite = Yaku_icon8;
                    RollNameText.GetComponent<Text>().text = "こオニ";
                    break;
                default:
                    // 処理３
                    break;
            }
        }
        countX++;
        image = PreventRollFace;
        image.SetNativeSize();

        //       PreventRollFace = Site_rollF1;
        //      image = PreventRollFace;

    }


    public void CheckPreventRole() // 【ゲーム開始後】巻物に現在手番の役職を表示させる（やくわりチェック）
    {
        switch (SiteMSC.NowActiveSiteN)
        {
            case 1:
                PreventRollFace.sprite = SiteA_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteA_roleNametext;
                break;
            case 2:
                PreventRollFace.sprite = SiteB_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteB_roleNametext;
                break;
            case 3:
                PreventRollFace.sprite = SiteC_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteC_roleNametext;
                break;
            case 4:
                PreventRollFace.sprite = SiteD_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteD_roleNametext;
                break;
            case 5:
                PreventRollFace.sprite = SiteE_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteE_roleNametext;
                break;
            case 6:
                PreventRollFace.sprite = SiteF_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteF_roleNametext;
                break;
            case 7:
                PreventRollFace.sprite = SiteG_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteG_roleNametext;
                break;
            case 8:
                PreventRollFace.sprite = SiteH_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteH_roleNametext;
                break;
            default:
                // 処理３
                break;
        }
        image = PreventRollFace;
        image.SetNativeSize();
    }


    //#################################################################################

}
// End