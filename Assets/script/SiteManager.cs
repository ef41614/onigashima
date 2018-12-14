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
    public GameObject selectBottonA;
    public GameObject selectBottonB;
    public GameObject selectBottonC;
    public GameObject selectBottonD;
    public GameObject selectBottonE;
    public GameObject selectBottonF;
    public GameObject selectBottonG;
    public GameObject selectBottonH;

    public bool FirstTimeCheck;
    public int MenuButtonMode = 0;

    public GameObject PanelBattleFieldBox;
    public GameObject QuestionMode;
    public GameObject BeforeQuestion;
    public GameObject AfterQuestion;

    public GameObject AnswerSerifText;

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
            selectBottonA.SetActive(true);
            selectBottonB.SetActive(true);
            selectBottonC.SetActive(true);
            selectBottonD.SetActive(true);
            selectBottonE.SetActive(true);
            selectBottonF.SetActive(true);
            selectBottonG.SetActive(true);
            selectBottonH.SetActive(true);
        }
        else if (selectTimeActive == false)
        {
            selectBottonA.SetActive(false);
            selectBottonB.SetActive(false);
            selectBottonC.SetActive(false);
            selectBottonD.SetActive(false);
            selectBottonE.SetActive(false);
            selectBottonF.SetActive(false);
            selectBottonG.SetActive(false);
            selectBottonH.SetActive(false);
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
            TurnActMode();
            OpenPanelBattleFieldBox();
        }
        else
        {
            SEMSC.cancel_SE();
        }
    }

    public void SiteB_Aimed()
    {
        TargetSiteNum = 2;
    }

    #endregion

    public void selectTimeEnd()
    {
        selectTimeActive = false;
    }

    public void MenuButtonModeQuestion()
    {
        MenuButtonMode = 1;
    }

    public void MenuButtonModeUnmask()
    {
        MenuButtonMode = 2;
    }

    public void MenuButtonModeAttack()
    {
        MenuButtonMode = 3;
    }

    public void TurnActMode()
    {
        switch (MenuButtonMode)
        {
            case 1: // 食事をしつもんする
                QuestionMode.SetActive(true);
                BeforeQuestion.SetActive(true);
                break;
            case 2: // 役わりをあてる

                break;
            case 3: // こうげきする

                break;
            default:
                // 処理３
                break;
        }
    }

    public void CloseBeforeQuestion()
    {
        BeforeQuestion.SetActive(false);
    }

    public void CloseQuestionMode()
    {
        QuestionMode.SetActive(false);
    }

    public void AppearAfterQuestion()
    {
        AfterQuestion.SetActive(true);
    }

    public void CloseAfterQuestion()
    {
        AfterQuestion.SetActive(false);
    }
    
    public void OpenPanelBattleFieldBox()
    {
        PanelBattleFieldBox.SetActive(true);
    }

    public void ClosePanelBattleFieldBox()
    {
        PanelBattleFieldBox.SetActive(false);
    }

    public void SerifDependOnRole()
    {
        for (int s = 0; s < 8; s++)
        {
            if (rollF[s + 1] == 1) // ももたろう
            {
                AnswerSerifText.GetComponent<Text>().text = "おばあさんの おみそしるが たべたい";
            }
            else if(rollF[s + 1] >= 2 && rollF[s + 1] <=4) // いぬ、さる、きじ
            {
                AnswerSerifText.GetComponent<Text>().text = "カレーが たべたいな";
            }
            else if (rollF[s + 1] == 5) // おにのおやぶん
            {
                AnswerSerifText.GetComponent<Text>().text = "ママの いうことを きかない わるい子だ！";
            }
            else if (rollF[s + 1] >= 6 && rollF[s + 1] <= 8) // こオニたち
            {
                AnswerSerifText.GetComponent<Text>().text = "カレーが たべたいな";
            }
        }
    }
    //#################################################################################

}
// End