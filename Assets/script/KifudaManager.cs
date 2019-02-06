using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class KifudaManager : MonoBehaviour {

    public Sprite FudaIconOni;
    public Sprite FudaIconOniMomo;
    public Sprite FudaIconMomo;

    public GameObject SiteManager;
    SiteManager SiteMSC;
    public GameObject SEManager;
    SEManager SEMSC;

//    Image image;

    //public Sprite SiteA_turn;
    //    public GameObject SiteA_turn;
    public Image SiteA_FudaIcon;
    public Image SiteB_FudaIcon;
    public Image SiteC_FudaIcon;
    public Image SiteD_FudaIcon;
    public Image SiteE_FudaIcon;
    public Image SiteF_FudaIcon;
    public Image SiteG_FudaIcon;
    public Image SiteH_FudaIcon;

    public int kifuda_A = 0;
    public int kifuda_B = 0;
    public int kifuda_C = 0;
    public int kifuda_D = 0;
    public int kifuda_E = 0;
    public int kifuda_F = 0;
    public int kifuda_G = 0;
    public int kifuda_H = 0;

    public bool askedQuestionA = false;
    public bool askedQuestionB = false;
    public bool askedQuestionC = false;
    public bool askedQuestionD = false;
    public bool askedQuestionE = false;
    public bool askedQuestionF = false;
    public bool askedQuestionG = false;
    public bool askedQuestionH = false;

    public GameObject SiteA_Kifuda;
    public GameObject SiteB_Kifuda;
    public GameObject SiteC_Kifuda;
    public GameObject SiteD_Kifuda;
    public GameObject SiteE_Kifuda;
    public GameObject SiteF_Kifuda;
    public GameObject SiteG_Kifuda;
    public GameObject SiteH_Kifuda;

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        SEMSC = SEManager.GetComponent<SEManager>();
//        image = this.GetComponent<Image>();

        FudaIconSet();
        CloseKifuda();

    //this.gameObject.GetComponent<Image>().sprite = Turn_num_icon1;
    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void FudaIconSet()
    {
        FudaIconSet(SiteA_FudaIcon, 1, kifuda_A);
        FudaIconSet(SiteB_FudaIcon, 2, kifuda_B);
        FudaIconSet(SiteC_FudaIcon, 3, kifuda_C);
        FudaIconSet(SiteD_FudaIcon, 4, kifuda_D);
        FudaIconSet(SiteE_FudaIcon, 5, kifuda_E);
        FudaIconSet(SiteF_FudaIcon, 6, kifuda_F);
        FudaIconSet(SiteG_FudaIcon, 7, kifuda_G);
        FudaIconSet(SiteH_FudaIcon, 8, kifuda_H);
    }

    public void FudaIconSet(Image FudaIcon, int x, int y)
    {
        switch (SiteMSC.rollF[x])
        {
            case 1: // ももたろう
                FudaIcon.sprite = FudaIconMomo;
                y = 3;
                break;
            case 2:
                FudaIcon.sprite = FudaIconOniMomo;
                y = 2;
                break;
            case 3:
                FudaIcon.sprite = FudaIconOniMomo;
                y = 2;
                break;
            case 4:
                FudaIcon.sprite = FudaIconOniMomo;
                y = 2;
                break;
            case 5: // おにのおやぶん
                FudaIcon.sprite = FudaIconOni;
                y = 1;
                break;
            case 6:
                FudaIcon.sprite = FudaIconOniMomo;
                y = 2;
                break;
            case 7:
                FudaIcon.sprite = FudaIconOniMomo;
                y = 2;
                break;
            case 8:
                FudaIcon.sprite = FudaIconOniMomo;
                y = 2;
                break;
            default:
                // 処理３
                break;
        }
    }

    public void AppearKifudaWait()
    {
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.5f, () => AppearKifuda());
    }

    public void AppearKifuda()
    {
        if (askedQuestionA)
        {
            SiteA_Kifuda.SetActive(true);
            SiteMSC.StatusSiteA = 2;  // ステータス木札ON
        }

        if (askedQuestionB)
        {
            SiteB_Kifuda.SetActive(true);
            SiteMSC.StatusSiteB = 2;  // ステータス木札ON
        }

        if (askedQuestionC)
        {
            SiteC_Kifuda.SetActive(true);
            SiteMSC.StatusSiteC = 2;  // ステータス木札ON
        }

        if (askedQuestionD)
        {
            SiteD_Kifuda.SetActive(true);
            SiteMSC.StatusSiteD = 2;  // ステータス木札ON
        }

        if (askedQuestionE)
        {
            SiteE_Kifuda.SetActive(true);
            SiteMSC.StatusSiteE = 2;  // ステータス木札ON
        }

        if (askedQuestionF)
        {
            SiteF_Kifuda.SetActive(true);
            SiteMSC.StatusSiteF = 2;  // ステータス木札ON
        }

        if (askedQuestionG)
        {
            SiteG_Kifuda.SetActive(true);
            SiteMSC.StatusSiteG = 2;  // ステータス木札ON
        }

        if (askedQuestionH)
        {
            SiteH_Kifuda.SetActive(true);
            SiteMSC.StatusSiteH = 2;  // ステータス木札ON
        }
        SEMSC.WoodPut_SE();
    }

    public void askedQuestionSite_active()
    {
        switch (SiteMSC.TargetSiteNum)
        {
            case 1:
                askedQuestionA = true;
                break;
            case 2:
                askedQuestionB = true;
                break;
            case 3:
                askedQuestionC = true;
                break;
            case 4:
                askedQuestionD = true;
                break;
            case 5:
                askedQuestionE = true;
                break;
            case 6:
                askedQuestionF = true;
                break;
            case 7:
                askedQuestionG = true;
                break;
            case 8:
                askedQuestionH = true;
                break;
            default:
                // 処理３
                break;
        }
    }

    public void CloseKifuda()
    {
        Debug.Log("木札を隠します");
        SiteA_Kifuda.SetActive(false);
        SiteB_Kifuda.SetActive(false);
        SiteC_Kifuda.SetActive(false);
        SiteD_Kifuda.SetActive(false);
        SiteE_Kifuda.SetActive(false);
        SiteF_Kifuda.SetActive(false);
        SiteG_Kifuda.SetActive(false);
        SiteH_Kifuda.SetActive(false);
    }
    //#################################################################################

}
// End