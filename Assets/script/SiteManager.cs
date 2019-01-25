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
//    public int[] StatusSite = { 1,1,1,1,1,1,1,1,1 };    //ステータス
    public int[] StatusSite = Enumerable.Repeat<int>(1, 9).ToArray();
    //public int[] StatusSite = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };    //ステータス
    //    public int[] DEX = { 0, 1, 2, 3, 4, 5, 6 };    //命中力
    public int DEX = 0; //命中力
    public int human_num = 1;
    int HandOfTime = 0;    // 「つぎの人に渡してね」のメッセージを表示させる
    int preventTurnNum = 1;
    public int TargetSiteNum = 0;
    int preventPlayerOrderNum = 1; // 今このターンで何人目か？

    public int StatusSiteA = 1;
    public int StatusSiteB = 1;
    public int StatusSiteC = 1;
    public int StatusSiteD = 1;
    public int StatusSiteE = 1;
    public int StatusSiteF = 1;
    public int StatusSiteG = 1;
    public int StatusSiteH = 1;

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

    public GameObject UnmaskMode;
    public GameObject BeforeUnmask;
    public GameObject AfterUnmask;

    public GameObject AttackMode;
    public GameObject BeforeAttack;
    public GameObject AfterAttack;

    public GameObject AnswerSerifText;
    public GameObject JudgeAnswerText;
    public GameObject RollNameText;

    public GameObject CardReverse;
    CardReverse CardReverseScr;
    public GameObject YakuManager;
    YakuManager YakuMSC;

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
        CardReverseScr = CardReverse.GetComponent<CardReverse>();
        YakuMSC = YakuManager.GetComponent<YakuManager>();
//        statusReset(); // ステータスをすべて1にする
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
        Debug.Log("今このターンで何人目か？" + preventPlayerOrderNum);
        if (TurnChip_A == preventPlayerOrderNum)
        {
            NowActiveSiteN = 1;
        }
        else if (TurnChip_B == preventPlayerOrderNum)
        {
            NowActiveSiteN = 2;
        }
        else if (TurnChip_C == preventPlayerOrderNum)
        {
            NowActiveSiteN = 3;
        }
        else if (TurnChip_D == preventPlayerOrderNum)
        {
            NowActiveSiteN = 4;
        }
        else if (TurnChip_E == preventPlayerOrderNum)
        {
            NowActiveSiteN = 5;
        }
        else if (TurnChip_F == preventPlayerOrderNum)
        {
            NowActiveSiteN = 6;
        }
        else if (TurnChip_G == preventPlayerOrderNum)
        {
            NowActiveSiteN = 7;
        }
        else if (TurnChip_H == preventPlayerOrderNum)
        {
            NowActiveSiteN = 8;
        }
        Debug.Log("今アクティブなサイトは" + NowActiveSiteN);
        CharaMSC.AppearNowActiveSite();
        if(FirstTimeCheck)
        {
            preventPlayerOrderNum++;
        }
//        Debug.Log("次このターンで何人目か？" + preventPlayerOrderNum);
    }

    public void statusReset()
    {
        StatusSite[0] = 1;
        StatusSite[1] = 1;
        StatusSite[2] = 1;
        StatusSite[3] = 1;
        StatusSite[4] = 1;
        StatusSite[5] = 1;
        StatusSite[6] = 1;
        StatusSite[7] = 1;
        StatusSite[8] = 1;
    }

    #region  Site_Aimed
    public void SiteAimedHantei(int x, int y)
    {
        Debug.Log("int x: " + x);
        Debug.Log("int y: " + y);
        if (NowActiveSiteN != x) // もし自分以外の相手をちゃんと選んでいたら
        {
            if (MenuButtonMode == 1) // 質問の時
            {
                if (y == 1) //ステータスがデフォルト（木札ON前）であるなら
                {
                    TargetSiteNum = x;
                    CommonAimedOK();
                }
                else
                {
                    SEMSC.cancel_SE();
                }
            }
            else if (MenuButtonMode == 2) // 役割当ての時
            {
                if (y < 4) //ステータスがデフォルトか木札ONであるなら
                {
                    TargetSiteNum = x;
                    CommonAimedOK();
                }
                else
                {
                    SEMSC.cancel_SE();
                }
            }
            else if (MenuButtonMode == 3) // 攻撃の時
            {
                if (y == 4) //ステータスが役割当てられた後であるなら
                {
                    TargetSiteNum = x;
                    CommonAimedOK();
                }
                else
                {
                    SEMSC.cancel_SE();
                }
            }
        }
        else // もし自分を選んでいたら
        {
            SEMSC.cancel_SE();
        }
    }

    public void SiteA_Aimed()
    {
        SiteAimedHantei(1, StatusSiteA);
    }

    public void SiteB_Aimed()
    {
        SiteAimedHantei(2, StatusSiteB);
    }

    public void SiteC_Aimed()
    {
        SiteAimedHantei(3, StatusSiteC);
    }

    public void SiteD_Aimed()
    {
        SiteAimedHantei(4, StatusSiteD);
    }

    public void SiteE_Aimed()
    {
        SiteAimedHantei(5, StatusSiteE);
    }

    public void SiteF_Aimed()
    {
        SiteAimedHantei(6, StatusSiteF);
    }

    public void SiteG_Aimed()
    {
        SiteAimedHantei(7, StatusSiteG);
    }

    public void SiteH_Aimed()
    {
        SiteAimedHantei(8, StatusSiteH);
    }

    public void SiteAimedHanteiGo(int x)
    {
        TargetSiteNum = x;
        CommonAimedOK();
    }

        public void CommonAimedOK()
    {
        SEMSC.cursor_SE();
        TurnActMode();
        OpenPanelBattleFieldBox();
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
                UnmaskMode.SetActive(true);
                BeforeUnmask.SetActive(true);
                break;
            case 3: // こうげきする
                AttackMode.SetActive(true);
                BeforeAttack.SetActive(true);
                YakuMSC.CheckAttackedRole();
                break;
            default:
                // 処理３
                break;
        }
    }

    #region Question
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
    #endregion


    #region Unmask
    public void CloseBeforeUnmask()
    {
        BeforeUnmask.SetActive(false);
    }

    public void CloseUnmaskMode()
    {
        UnmaskMode.SetActive(false);
    }

    public void AppearAfterUnmask()
    {
        AfterUnmask.SetActive(true);
    }

    public void CloseAfterUnmask()
    {
        AfterUnmask.SetActive(false);
    }
    #endregion

    #region Attack
    public void CloseBeforeAttack()
    {
        BeforeAttack.SetActive(false);
    }

    public void CloseAttackMode()
    {
        AttackMode.SetActive(false);
    }

    public void AppearAfterAttack()
    {
        AfterAttack.SetActive(true);
    }

    public void CloseAfterAttack()
    {
        AfterAttack.SetActive(false);
    }
    #endregion

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
        if (rollF[TargetSiteNum] == 1) // ももたろう
        {
            AnswerSerifText.GetComponent<Text>().text = "おばあさんの おみそしるが たべたい";
        }
        else if (rollF[TargetSiteNum] >= 2 && rollF[TargetSiteNum] <= 4) // いぬ、さる、きじ
        {
            AnswerSerifText.GetComponent<Text>().text = "カレーかきびだんごが たべたいな";
        }
        else if (rollF[TargetSiteNum] == 5) // おにのおやぶん
        {
            AnswerSerifText.GetComponent<Text>().text = "ママの いうことを きかない わるい子だ！";
        }
        else if (rollF[TargetSiteNum] >= 6 && rollF[TargetSiteNum] <= 8) // こオニたち
        {
            AnswerSerifText.GetComponent<Text>().text = "カレーが たべたいなオニ";
        }
    }


    public void YosouMomotaro()
    {
        Debug.Log("TargetSiteNum：" + TargetSiteNum);
        Debug.Log("rollF[TargetSiteNum]：" + rollF[TargetSiteNum]);
        CardReverseScr.ImageReset();
        RollNameText.GetComponent<Text>().text = "「ももたろう」";
        if (rollF[TargetSiteNum] == 1) // ももたろう
        {
            YosouYes();
            // ももたろうの画像オープン
        }
        else // ももたろう以外
        {
            YosouNo();
        }
    }
    
    public void YosouMomomates()
    {
        Debug.Log("TargetSiteNum：" + TargetSiteNum);
        Debug.Log("rollF[TargetSiteNum]：" + rollF[TargetSiteNum]);
        CardReverseScr.ImageReset();
        RollNameText.GetComponent<Text>().text = "「ももたろうの なかま」";
        if (rollF[TargetSiteNum] >= 2 && rollF[TargetSiteNum] <= 4) // いぬ、さる、きじ
        {
            YosouYes();
            // いぬ、さる、きじの画像オープン
        }
        else // いぬ、さる、きじ以外
        {
            YosouNo();
        }
    }

    public void YosouOyabun()
    {
        Debug.Log("TargetSiteNum：" + TargetSiteNum);
        Debug.Log("rollF[TargetSiteNum]：" + rollF[TargetSiteNum]);
        CardReverseScr.ImageReset();
        RollNameText.GetComponent<Text>().text = "「オニのおやぶん」";
        if (rollF[TargetSiteNum] == 5) // オニのおやぶん
        {
            YosouYes();
            // オニのおやぶんの画像オープン
        }
        else // オニのおやぶん以外
        {
            YosouNo();
        }
    }

    public void YosouKooni()
    {
        Debug.Log("TargetSiteNum：" + TargetSiteNum);
        Debug.Log("rollF[TargetSiteNum]：" + rollF[TargetSiteNum]);
        CardReverseScr.ImageReset();
        RollNameText.GetComponent<Text>().text = "「こオニ」";
        if (rollF[TargetSiteNum] >= 6 && rollF[TargetSiteNum] <= 8) // こオニたち
        {
            YosouYes();
            // 小鬼の画像オープン
        }
        else // こオニたち以外
        {
            YosouNo();
        }
    }

    public void YosouYes()
    {
        JudgeAnswerText.GetComponent<Text>().text = "はい、そうです";
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.5f, () => YosouYes2());
        sequence.InsertCallback(3.0f, () => CardReverseScr.ImageReset());
    }

    public void YosouYes2()
    {
        // 当てられた相手の画像オープン
        CardReverseScr.ImageSet();
        YakuMSC.CheckAimedRole();
        StartCoroutine(CardReverseScr.CardOpen());
        CheckOpenYakuCard();
    }

    public void CheckOpenYakuCard()
    {
       if(TargetSiteNum == 1)
        {
            YakuMSC.OpenYakuCardA();
            StatusSiteA = 4;
            StatusSite[1] = 4;
        }
        else if (TargetSiteNum == 2)
        {
            YakuMSC.OpenYakuCardB();
            StatusSiteB = 4;
            StatusSite[2] = 4;
        }
        else if (TargetSiteNum == 3)
        {
            YakuMSC.OpenYakuCardC();
            StatusSiteC = 4;
            StatusSite[3] = 4;
        }
        else if (TargetSiteNum == 4)
        {
            YakuMSC.OpenYakuCardD();
            StatusSiteD = 4;
            StatusSite[4] = 4;
        }
        else if (TargetSiteNum == 5)
        {
            YakuMSC.OpenYakuCardE();
            StatusSiteE = 4;
            StatusSite[5] = 4;
        }
        else if (TargetSiteNum == 6)
        {
            YakuMSC.OpenYakuCardF();
            StatusSiteF = 4;
            StatusSite[6] = 4;
        }
        else if (TargetSiteNum == 7)
        {
            YakuMSC.OpenYakuCardG();
            StatusSiteG = 4;
            StatusSite[7] = 4;
        }
        else if (TargetSiteNum == 8)
        {
            YakuMSC.OpenYakuCardH();
            StatusSiteH = 4;
            StatusSite[8] = 4;
        }
    }


    public void YosouNo()
    {
        JudgeAnswerText.GetComponent<Text>().text = "いいえ、" + "\n" + "ちがいます";
        // 間違えた質問者の画像オープン
        PenaltyOpenYakuCard();
    }

    public void PenaltyOpenYakuCard()
    {
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.0f, () => PenaltyOpenYakuCard02());
    }

    public void PenaltyOpenYakuCard02()
    {
        Debug.Log("◆◎NowActiveSiteN：" + NowActiveSiteN);
        if (NowActiveSiteN == 1)
        {
            StatusSiteA = 4;
            StatusSite[1] = 4;
            YakuMSC.OpenYakuCardA();
        }
        else if (NowActiveSiteN == 2)
        {
            StatusSiteB = 4;
            StatusSite[2] = 4;
            YakuMSC.OpenYakuCardB();
        }
        else if (NowActiveSiteN == 3)
        {
            StatusSiteC = 4;
            StatusSite[3] = 4;
            YakuMSC.OpenYakuCardC();
        }
        else if (NowActiveSiteN == 4)
        {
            StatusSiteD = 4;
            StatusSite[4] = 4;
            YakuMSC.OpenYakuCardD();
        }
        else if (NowActiveSiteN == 5)
        {
            StatusSiteE = 4;
            StatusSite[5] = 4;
            YakuMSC.OpenYakuCardE();
        }
        else if (NowActiveSiteN == 6)
        {
            StatusSiteF = 4;
            StatusSite[6] = 4;
            YakuMSC.OpenYakuCardF();
        }
        else if (NowActiveSiteN == 7)
        {
            StatusSiteG = 4;
            StatusSite[7] = 4;
            YakuMSC.OpenYakuCardG();
        }
        else if (NowActiveSiteN == 8)
        {
            StatusSiteH = 4;
            StatusSite[8] = 4;
            YakuMSC.OpenYakuCardH();
        }
    }

    public void checkDEX() //命中率チェック
    {
        if (rollF[NowActiveSiteN] == 1) // ももたろう
        {
            DEX = 5;
        }
        else if (rollF[NowActiveSiteN] >= 2 && rollF[NowActiveSiteN] <= 4) // いぬ、さる、きじ
        {
            DEX = 3;
        }
        else if (rollF[NowActiveSiteN] == 5) // おにのおやぶん
        {
            DEX = 4;
        }
        else if (rollF[NowActiveSiteN] >= 6 && rollF[NowActiveSiteN] <= 8) // こオニたち
        {
            DEX = 1;
        }
    }

    public void JudgeHitting()
    {
        int accuracy = UnityEngine.Random.Range(1,7);

        if (1 <= accuracy && accuracy <= DEX)
        {
            // 攻撃成功
            SEMSC.punch_SE();
        }
        else if (DEX <= accuracy && accuracy <= 7)
        {
            // 攻撃失敗
            SEMSC.suka_SE();
        }
    }

    public void AddplayerOrderNum()
    {
        preventPlayerOrderNum++;
    }
    //#################################################################################

}
// End