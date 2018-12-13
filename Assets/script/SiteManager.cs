using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class SiteManager : MonoBehaviour
{
    public GameObject CharaManager;
    CharaManager CharaMSC;
    public GameObject SEManager;
    SEManager SEMSC;

    public GameObject PanelHandToNext;
    public GameObject RollInfo;
    public GameObject PanelCheckEnd;
    public GameObject CanvasRollCheck;
    public GameObject CanvasPlayPlace;

    public int TotalSurvivalSiteN = 8;
    public int NowActiveSiteN = 1;
    public int siteN = 0;   //サイト
    public int charaF = 0;  //キャラ顔
//    public int charaN = 0;  //キャラname
    public int huda = 0;    //キャラ判別木札
    public int rollC = 0;   //役わりカード
    public int HP = 0;      //体力
    public int ATK = 0;     //攻撃力
    public int[] turnM = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };    //順番マーク
    public int[] charaN = { 0, 1, 2, 3, 4, 5, 6, 7, 8,9,10,11,12};    //VTuberのキャラネーム
    public int[] rollF = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };    //役わり顔
    public int human_num = 1;
    int HandOfTime = 0;    // 「つぎの人に渡してね」のメッセージを表示させる
    int preventTurnNum = 1;
    int TargetSiteNum = 0;

    public bool aliveSiteA;
    public bool aliveSiteB;
    public bool aliveSiteC;
    public bool aliveSiteD;
    public bool aliveSiteE;
    public bool aliveSiteF;
    public bool aliveSiteG;
    public bool aliveSiteH;

    public int TurnChip_A = 0;
    public int TurnChip_B = 0;
    public int TurnChip_C = 0;
    public int TurnChip_D = 0;
    public int TurnChip_E = 0;
    public int TurnChip_F = 0;
    public int TurnChip_G = 0;
    public int TurnChip_H = 0;

    public bool selectTimeActive = false;
    public GameObject selevtBottonA;
    public GameObject selevtBottonB;
    public GameObject selevtBottonC;
    public GameObject selevtBottonD;
    public GameObject selevtBottonE;
    public GameObject selevtBottonF;
    public GameObject selevtBottonG;
    public GameObject selevtBottonH;

    public bool FirstTimeCheck;


    private void Awake()
    {
        shakeTurnMark();
        //       shakeCharaN();
        convertSiteInfo();
        shakeRollFace();
    }

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        HandOfTime = human_num - 1;
        AppearCanvasRollCheck();
        CloseCanvasPlayPlace();
        CharaMSC = CharaManager.GetComponent<CharaManager>();
        SEMSC = SEManager.GetComponent<SEManager>();
    }


    //####################################  Update  ###################################

    void Update()
    {
        if(selectTimeActive)
        {
            selevtBottonA.SetActive(true);
            selevtBottonB.SetActive(true);
            selevtBottonC.SetActive(true);
            selevtBottonD.SetActive(true);
            selevtBottonE.SetActive(true);
            selevtBottonF.SetActive(true);
            selevtBottonG.SetActive(true);
            selevtBottonH.SetActive(true);
        }
        else if (selectTimeActive == false)
        {
            selevtBottonA.SetActive(false);
            selevtBottonB.SetActive(false);
            selevtBottonC.SetActive(false);
            selevtBottonD.SetActive(false);
            selevtBottonE.SetActive(false);
            selevtBottonF.SetActive(false);
            selevtBottonG.SetActive(false);
            selevtBottonH.SetActive(false);
        }

    }

    //####################################  other  ####################################

    public void shakeCharaN()
    {
        var ary = Enumerable.Range(1, 12).OrderBy(n => Guid.NewGuid()).Take(8).ToArray();

        for (int s = 0; s < ary.Length; s++)
        {
            charaN[s + 1] = ary[s];
            Debug.Log(ary[s]);
            Debug.Log("charaN[" + (s + 1) + "]" + charaN[(s + 1)]);
        }
    }

    public void convertSiteInfo()
    {
        charaN[1] = SelectManager.getSiteAInfo(); // siteAの情報が charaN[1] に1～12の数値として代入される
        charaN[2] = SelectManager.getSiteBInfo();
        charaN[3] = SelectManager.getSiteCInfo();
        charaN[4] = SelectManager.getSiteDInfo();

        charaN[5] = SelectManager.getSiteEInfo();
        charaN[6] = SelectManager.getSiteFInfo();
        charaN[7] = SelectManager.getSiteGInfo();
        charaN[8] = SelectManager.getSiteHInfo();
        human_num = SelectManager.getHito_numInfo();
    }

    public void shakeTurnMark()
    {
        var ary = Enumerable.Range(1, 8).OrderBy(n => Guid.NewGuid()).Take(8).ToArray();

        for (int s = 0; s < ary.Length; s++)
        {
            turnM[s + 1] = ary[s];
            Debug.Log(ary[s]);
            Debug.Log("turnM[" + (s + 1) + "]" + turnM[(s + 1)]);
        }
    }

    public void shakeRollFace()
    {
        var ary = Enumerable.Range(1, 8).OrderBy(n => Guid.NewGuid()).Take(8).ToArray();

        for (int s = 0; s < ary.Length; s++)
        {
            rollF[s + 1] = ary[s];
            Debug.Log(ary[s]);
            Debug.Log("rollF[" + (s + 1) + "]" + rollF[(s + 1)]);
        }
    }

    public void NextRollCheck()
    {
        if (HandOfTime > 0)
        {
            var sequence = DOTween.Sequence();
            sequence.InsertCallback(0.1f, () => AppearPanelHandToNext());
            sequence.InsertCallback(1.5f, () => ClosePanelHandToNext());
            HandOfTime--;
        }
        else if (HandOfTime == 0)
        {
            var sequence = DOTween.Sequence();
            sequence.InsertCallback(0.1f, () => AppearPanelCheckEnd());
            sequence.InsertCallback(3.5f, () => AppearCanvasPlayPlace());
            sequence.InsertCallback(3.8f, () => CheckYourTurn());
            sequence.InsertCallback(3.7f, () => CloseCanvasRollCheck());
            HandOfTime--;
        }
        else
        {
            CheckYourTurn();
            CloseCanvasRollCheck();
        }
    }

    public void AppearPanelHandToNext()
    {
        PanelHandToNext.SetActive(true);
    }

    public void ClosePanelHandToNext()
    {
        PanelHandToNext.SetActive(false);
    }

    public void AppearRollInfo()
    {
        RollInfo.SetActive(true);
    }

    public void CloseRollInfo()
    {
        RollInfo.SetActive(false);
    }

    public void AppearPanelCheckEnd()
    {
        PanelCheckEnd.SetActive(true);
        FirstTimeCheck = false;
//        CheckYourTurn();

    }

    public void ClosePanelCheckEnd()
    {
        PanelCheckEnd.SetActive(false);
    }

    public void AppearCanvasRollCheck()
    {
        CanvasRollCheck.SetActive(true);
    }

    public void CloseCanvasRollCheck()
    {
        CanvasRollCheck.SetActive(false);
    }

    public void AppearCanvasPlayPlace()
    {
        CanvasPlayPlace.SetActive(true);
    }

    public void CloseCanvasPlayPlace()
    {
        CanvasPlayPlace.SetActive(false);
    }

    public void CheckYourTurn()
    {
        Debug.Log("今のターンは"+preventTurnNum);
        if (TurnChip_A == preventTurnNum)
        {
            NowActiveSiteN = 1;
        }
        else if (TurnChip_B == preventTurnNum)
        {
            NowActiveSiteN = 2;
        }
        else if (TurnChip_C == preventTurnNum)
        {
            NowActiveSiteN = 3;
        }
        else if (TurnChip_D == preventTurnNum)
        {
            NowActiveSiteN = 4;
        }
        else if (TurnChip_E == preventTurnNum)
        {
            NowActiveSiteN = 5;
        }
        else if (TurnChip_F == preventTurnNum)
        {
            NowActiveSiteN = 6;
        }
        else if (TurnChip_G == preventTurnNum)
        {
            NowActiveSiteN = 7;
        }
        else if (TurnChip_H == preventTurnNum)
        {
            NowActiveSiteN = 8;
        }
        Debug.Log("今アクティブなサイトは" + NowActiveSiteN);
        CharaMSC.AppearNowActiveSite();
        if(FirstTimeCheck)
        {
            preventTurnNum++;
        }
        Debug.Log("次のターンは" + preventTurnNum);
    }

    #region  Site_Aimed
    public void SiteA_Aimed()
    {
        if (NowActiveSiteN != 1)
        {
            TargetSiteNum = 1;
            SEMSC.cursor_SE();
        }else
        {
            SEMSC.cancel_SE();
        }
    }

    public void SiteB_Aimed()
    {
        TargetSiteNum = 2;
    }

    #endregion

    //#################################################################################

}
// End