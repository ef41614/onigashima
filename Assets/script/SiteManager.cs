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
    public GameObject PanelRollCheck;

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
    public int[] charaN = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };    //VTuberのキャラネーム
    public int[] rollF = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };    //役わり顔
                                                           //    public int[] StatusSite = { 1,1,1,1,1,1,1,1,1 };    //ステータス
                                                           //    public int[] StatusSite = Enumerable.Repeat<int>(1, 9).ToArray();
                                                           //public int[] StatusSite = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };    //ステータス
                                                           //    public int[] DEX = { 0, 1, 2, 3, 4, 5, 6 };    //命中力
    public int DEX = 0; //命中力
    public int human_num = 1;
    int HandOfTime = 0;    // 「つぎの人に渡してね」のメッセージを表示させる
    public int preventTurnNum = 1;
    public int TargetSiteNum = 0;
    int preventPlayerOrderNum = 1; // 今このターンで何人目か？
    public int MomoMakePoint = 0;  // 桃チームの負けポイント：一定以上で鬼チームの勝利

    public int StatusSiteA = 1;
    public int StatusSiteB = 1;
    public int StatusSiteC = 1;
    public int StatusSiteD = 1;
    public int StatusSiteE = 1;
    public int StatusSiteF = 1;
    public int StatusSiteG = 1;
    public int StatusSiteH = 1;

    public int teamSiteA = 0;  // 所属チーム :デフォルト「0」null 、おにチーム「1」、桃チーム「3」
    public int teamSiteB = 0;
    public int teamSiteC = 0;
    public int teamSiteD = 0;
    public int teamSiteE = 0;
    public int teamSiteF = 0;
    public int teamSiteG = 0;
    public int teamSiteH = 0;

    public int TurnChip_A = 0;  // 順番マーカーのナンバー
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

    public GameObject KizetuA;
    public GameObject KizetuB;
    public GameObject KizetuC;
    public GameObject KizetuD;
    public GameObject KizetuE;
    public GameObject KizetuF;
    public GameObject KizetuG;
    public GameObject KizetuH;

    public GameObject CardReverse;
    CardReverse CardReverseScr;
    public GameObject YakuManager;
    YakuManager YakuMSC;
    public GameObject HPManager;
    HPManager HPMSC;
    public GameObject TurnMarkManager;
    TurnMarkManager TurnMarkMSC;
    public GameObject KifudaManager;
    KifudaManager KifudaMSC;

    public GameObject AttackMissText;    // 「Miss」と書かれたテキスト文（攻撃失敗時に出す）
    public GameObject AttakedAfterText;   // 攻撃後のセリフ（当たった時、外れた時、共に）

    public bool faintingOccured = false;

    public GameObject PanelTurnNumber;
    public GameObject TurnNumNami;    // ターン開始時に中央に表示する
    public GameObject TurnNumUe;    // 何ターン目かを画面上に表示する
    public float NextTurnWait = 0.1f;  // 「〇ターンめ」の画面を表示するまで待つ時間

    public GameObject PanelMAKU;  // 定式幕
    public int MakuMoveMode = 0;  // 0:停止, 1:右（オープン）, 2:左（）クローズ

    public GameObject PanelWinner;  // 〇〇チームの勝利 を表示する
    public GameObject WinMomo;
    public GameObject WinOni;
    public GameObject ImageWinBack02;

    public int SiteAWinAppearFlg = 0; // SiteAがまだ表示されていない
    public int SiteBWinAppearFlg = 0; // SiteBがまだ表示されていない
    public int SiteCWinAppearFlg = 0;
    public int SiteDWinAppearFlg = 0;
    public int SiteEWinAppearFlg = 0;
    public int SiteFWinAppearFlg = 0;
    public int SiteGWinAppearFlg = 0;
    public int SiteHWinAppearFlg = 0;

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
        HPMSC = HPManager.GetComponent<HPManager>();
        TurnMarkMSC = TurnMarkManager.GetComponent<TurnMarkManager>();
        KifudaMSC = KifudaManager.GetComponent<KifudaManager>();
        StartTurnNum();
        ReloadTurnNumUe();
        ClosePanelWinner();
        ResetSiteWinAppearFlg();
        AppearPanelRollCheck();
        AppearPanelMAKU();
        //        statusReset(); // ステータスをすべて1にする
    }


    //####################################  Update  ###################################

    void Update()
    {
        if (selectTimeActive)
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


        Vector2 Position = PanelMAKU.gameObject.transform.position;
//        Debug.Log("Position.x : "+ Position.x);
        if (Position.x <= 550 && MakuMoveMode == 1)
        {
            Position.x += 2.0f;  // 右に幕を移動（開ける）
        }
        if (Position.x >= 100 && MakuMoveMode == 2)
        {
            Position.x -= 2.0f;  // 左に幕を移動（とじる）
        }
        PanelMAKU.gameObject.transform.position = Position;

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
            SEMSC.hyoushigi2_long_SE();
            var sequence = DOTween.Sequence();
            sequence.InsertCallback(0.1f, () => AppearPanelCheckEnd());
            sequence.InsertCallback(0.2f, () => ClosePanelRollCheck());
            sequence.InsertCallback(1.5f, () => SwitchMakuMoveMode1());
            sequence.InsertCallback(1.5f, () => AppearCanvasPlayPlace());
            sequence.InsertCallback(3.8f, () => CheckYourTurn());
            sequence.InsertCallback(4.5f, () => CloseCanvasRollCheck());
            HandOfTime--;
        }
        else
        {
            CheckYourTurn();
            CloseCanvasRollCheck();
        }
    }

    public void SwitchMakuMoveMode0()
    {
        MakuMoveMode = 0;
    }

    public void SwitchMakuMoveMode1()  // 幕を右へオープン
    {
        MakuMoveMode = 1;
    }

    public void SwitchMakuMoveMode2()  // 幕を左へクローズ
    {
        MakuMoveMode = 2;
    }
       
    public void AppearPanelMAKU()
    {
        PanelMAKU.SetActive(true);
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

    public void AppearPanelRollCheck()
    {
        PanelRollCheck.SetActive(true);
    }

    public void ClosePanelRollCheck()
    {
        PanelRollCheck.SetActive(false);
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
        TeamHanteiByKihuda();
        TeamHanteiByOpen01();
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
        if (FirstTimeCheck)
        {
            preventPlayerOrderNum++;
        }
        KizetuSkipTurn();
        //        Debug.Log("次このターンで何人目か？" + preventPlayerOrderNum);
    }

    public void KizetuSkipTurn()
    {
        Debug.Log("◆◎NowActiveSiteN：" + NowActiveSiteN);
        if (NowActiveSiteN == 1)
        {
            if (StatusSiteA == 6 || StatusSiteA == 5)  // もしアクティブキャラが気ぜつしていたら
            {
                SkipTurnPhase();
            }
        }
        else if (NowActiveSiteN == 2)
        {
            if (StatusSiteB == 6 || StatusSiteB == 5)  // もしアクティブキャラが気ぜつしていたら
            {
                SkipTurnPhase();
            }
        }
        else if (NowActiveSiteN == 3)
        {
            if (StatusSiteC == 6 || StatusSiteC == 5)  // もしアクティブキャラが気ぜつしていたら
            {
                SkipTurnPhase();
            }
        }
        else if (NowActiveSiteN == 4)
        {
            if (StatusSiteD == 6 || StatusSiteD == 5)  // もしアクティブキャラが気ぜつしていたら
            {
                SkipTurnPhase();
            }
        }
        else if (NowActiveSiteN == 5)
        {
            if (StatusSiteE == 6 || StatusSiteE == 5)  // もしアクティブキャラが気ぜつしていたら
            {
                SkipTurnPhase();
            }
        }
        else if (NowActiveSiteN == 6)
        {
            if (StatusSiteF == 6 || StatusSiteF == 5)  // もしアクティブキャラが気ぜつしていたら
            {
                SkipTurnPhase();
            }
        }
        else if (NowActiveSiteN == 7)
        {
            if (StatusSiteG == 6 || StatusSiteG == 5)  // もしアクティブキャラが気ぜつしていたら
            {
                SkipTurnPhase();
            }
        }
        else if (NowActiveSiteN == 8)
        {
            if (StatusSiteH == 6 || StatusSiteH == 5)  // もしアクティブキャラが気ぜつしていたら
            {
                SkipTurnPhase();
            }
        }
    }

    public void SkipTurnPhase() // もしアクティブキャラが気ぜつしていたら、スキップする
    {
        Debug.Log("◆アクティブキャラが気ぜつしているので、スキップする");
        AddplayerOrderNum();
        CharaMSC.AppearNowActiveSite();
        CheckYourTurn();
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
            AnswerSerifText.GetComponent<Text>().text = "おさけだ！ おさけ もってこい！";
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

    public void CheckOpenYakuCard()   // 当てられた相手の画像オープン
    {
        if (TargetSiteNum == 1)
        {
            YakuMSC.OpenYakuCardA();
            StatusSiteA = 4;
        }
        else if (TargetSiteNum == 2)
        {
            YakuMSC.OpenYakuCardB();
            StatusSiteB = 4;
        }
        else if (TargetSiteNum == 3)
        {
            YakuMSC.OpenYakuCardC();
            StatusSiteC = 4;
        }
        else if (TargetSiteNum == 4)
        {
            YakuMSC.OpenYakuCardD();
            StatusSiteD = 4;
        }
        else if (TargetSiteNum == 5)
        {
            YakuMSC.OpenYakuCardE();
            StatusSiteE = 4;
        }
        else if (TargetSiteNum == 6)
        {
            YakuMSC.OpenYakuCardF();
            StatusSiteF = 4;
        }
        else if (TargetSiteNum == 7)
        {
            YakuMSC.OpenYakuCardG();
            StatusSiteG = 4;
        }
        else if (TargetSiteNum == 8)
        {
            YakuMSC.OpenYakuCardH();
            StatusSiteH = 4;
        }
    }


    public void YosouNo()
    {
        JudgeAnswerText.GetComponent<Text>().text = "いいえ、" + "\n" + "ちがいます";
        // 間違えた質問者の画像オープン
        PenaltyOpenYakuCard();
    }

    public void PenaltyOpenYakuCard()    // 間違えた質問者の画像オープン
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
            YakuMSC.OpenYakuCardA();
        }
        else if (NowActiveSiteN == 2)
        {
            StatusSiteB = 4;
            YakuMSC.OpenYakuCardB();
        }
        else if (NowActiveSiteN == 3)
        {
            StatusSiteC = 4;
            YakuMSC.OpenYakuCardC();
        }
        else if (NowActiveSiteN == 4)
        {
            StatusSiteD = 4;
            YakuMSC.OpenYakuCardD();
        }
        else if (NowActiveSiteN == 5)
        {
            StatusSiteE = 4;
            YakuMSC.OpenYakuCardE();
        }
        else if (NowActiveSiteN == 6)
        {
            StatusSiteF = 4;
            YakuMSC.OpenYakuCardF();
        }
        else if (NowActiveSiteN == 7)
        {
            StatusSiteG = 4;
            YakuMSC.OpenYakuCardG();
        }
        else if (NowActiveSiteN == 8)
        {
            StatusSiteH = 4;
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
        Debug.Log("◆◎DEX：" + DEX);   // この値以下なら、攻撃成功
        int accuracy = UnityEngine.Random.Range(1, 7); // 攻撃が当たるかどうかのランダム数値

        if (1 <= accuracy && accuracy <= DEX)
        {
            // 攻撃成功
            SEMSC.punch_SE();
            AttackHitSerif();
            DecreaseHP();
            HPMSC.HP_check();
            YakuMSC.DamageTenmetu();      // ← ☆ NEW ☆  役職カードを点滅させる
        }
        else if (DEX <= accuracy && accuracy <= 7)
        {
            // 攻撃失敗
            SEMSC.suka_SE();
            AttackMissSerif();
            AttackMissText.SetActive(true);  // 「Miss」と書かれたテキスト文を表示させる
            var sequence = DOTween.Sequence();
            //sequence.InsertCallback(2f, () => AttackMissText.SetActive(false));  // Miss を非表示にする
            sequence.InsertCallback(2f, () => CloseMissText());  // Miss を非表示にする
        }
    }

    public void CloseMissText()
    {
        AttackMissText.SetActive(false);
    }


    public void AttackHitSerif()  // 攻撃後のセリフ（当たった時）
    {
        int AttackedSerif = UnityEngine.Random.Range(1, 5);
        switch (AttackedSerif)
        {
            case 1: //
                AttakedAfterText.GetComponent<Text>().text = "ぐはぁ！";
                break;
            case 2: //
                AttakedAfterText.GetComponent<Text>().text = "やーらーれーたぁー";
                break;
            case 3: //
                AttakedAfterText.GetComponent<Text>().text = "いたたぁ";
                break;
            case 4: //
                AttakedAfterText.GetComponent<Text>().text = "うわーん";
                break;
            default:
                // その他処理
                break;
        }
    }


    public void AttackMissSerif()  // 攻撃後のセリフ（外れた時）
    {
        int AttackedSerif = UnityEngine.Random.Range(1, 5);
        switch (AttackedSerif)
        {
            case 1: //
                AttakedAfterText.GetComponent<Text>().text = "ふぅ、セーフ";
                break;
            case 2: //
                AttakedAfterText.GetComponent<Text>().text = "あぶない、あぶない";
                break;
            case 3: //
                AttakedAfterText.GetComponent<Text>().text = "よかった、はずれたー";
                break;
            case 4: //
                AttakedAfterText.GetComponent<Text>().text = "みきった！";
                break;
            default:
                // その他処理
                break;
        }
    }



    public void DecreaseHP()  // 攻撃を受けたキャラの体力を1減らし、0になったらステータスを「5（気ぜつ直後）」にする。
    {
        if (TargetSiteNum == 1)
        {
            HPMSC.HP_A--;
            if (HPMSC.HP_A <= 0)
            {
                StatusSiteA = 5;
            }
        }
        else if (TargetSiteNum == 2)
        {
            HPMSC.HP_B--;
            if (HPMSC.HP_B <= 0)
            {
                StatusSiteB = 5;
            }
        }
        else if (TargetSiteNum == 3)
        {
            HPMSC.HP_C--;
            if (HPMSC.HP_C <= 0)
            {
                StatusSiteC = 5;
            }
        }
        else if (TargetSiteNum == 4)
        {
            HPMSC.HP_D--;
            if (HPMSC.HP_D <= 0)
            {
                StatusSiteD = 5;
            }
        }
        else if (TargetSiteNum == 5)
        {
            HPMSC.HP_E--;
            if (HPMSC.HP_E <= 0)
            {
                StatusSiteE = 5;
            }
        }
        else if (TargetSiteNum == 6)
        {
            HPMSC.HP_F--;
            if (HPMSC.HP_F <= 0)
            {
                StatusSiteF = 5;
            }
        }
        else if (TargetSiteNum == 7)
        {
            HPMSC.HP_G--;
            if (HPMSC.HP_G <= 0)
            {
                StatusSiteG = 5;
            }
        }
        else if (TargetSiteNum == 8)
        {
            HPMSC.HP_H--;
            if (HPMSC.HP_H <= 0)
            {
                StatusSiteH = 5;
            }
        }
        CheckFainting();
    }

    public void CheckFainting()
    {
        if (StatusSiteA == 5 || StatusSiteB == 5 || StatusSiteC == 5 || StatusSiteD == 5 || StatusSiteE == 5 || StatusSiteF == 5 || StatusSiteG == 5 || StatusSiteH == 5)
        {
            faintingOccured = true;  // ステータス「気絶した瞬間」のプレイヤーがいる
            NextTurnWait = 2.5f;
        }
        else
        {
            faintingOccured = false;
        }
    }

    public void KizetuPhase()
    {
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(1f, () => SEMSC.kizetu_SE());
        sequence.InsertCallback(1f, () => KizetuMarkAppear());
        sequence.InsertCallback(1.2f, () => WinHantei01());   // 勝ち負けの判定を行う
    }

    public void KizetuMarkAppear()
    {
        if (StatusSiteA == 5)
        {
            KizetuA.SetActive(true);
            StatusSiteA = 6;
        }
        if (StatusSiteB == 5)
        {
            KizetuB.SetActive(true);
            StatusSiteB = 6;
        }
        if (StatusSiteC == 5)
        {
            KizetuC.SetActive(true);
            StatusSiteC = 6;
        }
        if (StatusSiteD == 5)
        {
            KizetuD.SetActive(true);
            StatusSiteD = 6;
        }
        if (StatusSiteE == 5)
        {
            KizetuE.SetActive(true);
            StatusSiteE = 6;
        }
        if (StatusSiteF == 5)
        {
            KizetuF.SetActive(true);
            StatusSiteF = 6;
        }
        if (StatusSiteG == 5)
        {
            KizetuG.SetActive(true);
            StatusSiteG = 6;
        }
        if (StatusSiteH == 5)
        {
            KizetuH.SetActive(true);
            StatusSiteH = 6;
        }
        faintingOccured = false; // すべての処理が終わったところで、ステータスを「気絶後」に変更する
    }

    public void AddplayerOrderNum()  // その人のプレイ終わった後に、プレイヤー番号をプラスする
    {
        Debug.Log("今プレイした人はpreventPlayerOrderNum :::" + preventPlayerOrderNum);
        if (preventPlayerOrderNum < 8) // 1～8人目のターンの時
        {
            preventPlayerOrderNum++;
        }
        else if (preventPlayerOrderNum >= 8)  // そのターンがすべて終わり、次のターンに行く
        {
            GoToNextTurn();
        }
        Debug.Log("これからプレイする人はpreventPlayerOrderNum :::" + preventPlayerOrderNum);
    }

    public void GoToNextTurn()  // そのターンがすべて終わり、次のターンに行く
    {
        preventPlayerOrderNum = 1;
        shakeTurnMark();
        TurnMarkMSC.TurnMarkSetStart();

        var sequence = DOTween.Sequence();
        sequence.InsertCallback(NextTurnWait, () => PanelTurnNumberAppear());
//        PanelTurnNumberAppear();
    }

    public void PanelTurnNumberAppear() // ●「〇ターンめです」 を表示させる 
    {
        PanelTurnNumber.SetActive(true);
        AddpreventTurnNum();
        StartTurnNum();
        ReloadTurnNumUe();
        NextTurnWait = 0.1f;
        //        var sequence = DOTween.Sequence();
        //        sequence.InsertCallback(1.5f, () => PanelTurnNumberClose());
    }

    public void PanelTurnNumberClose() // ●非表示にする
    {
        PanelTurnNumber.SetActive(false);
    }

    public void StartTurnNum()  //ターン開始時に画面中央に「〇ターンめです」 を表示させる 
    {
        TurnNumNami.GetComponent<Text>().text = (preventTurnNum).ToString();
    }

    public void ReloadTurnNumUe()  //ターン開始時に画面上に「〇ターンめです」 を表示させる 
    {
        TurnNumUe.GetComponent<Text>().text = (preventTurnNum).ToString();
    }

    public void AddpreventTurnNum()  // ターン番号をプラスする
    {
        Debug.Log("今のターンはpreventTurnNumでした :::" + preventTurnNum);
        if (preventTurnNum < 5) // 1～8人目のターンの時
        {
            preventTurnNum++;
        }
        else if (preventTurnNum >= 5)  // そのターンがすべて終わり、次のターンに行く
        {
            preventTurnNum = 1;
        }
        Debug.Log("これからのターンはpreventTurnNum です:::" + preventTurnNum);

    }

    public void TeamHanteiByKihuda()  // 特定の木札が載っていたら所属チームの判定を行う
    {
        if (KifudaMSC.kifuda_A == 1)  // もしオニ木札が載っていたら
        {
            teamSiteA = 1;   // オニチーム所属である
        }
        if (KifudaMSC.kifuda_A == 3)  // もし桃木札が載っていたら
        {
            teamSiteA = 3;   // 桃チーム所属である
        }

        if (KifudaMSC.kifuda_B == 1)  // もしオニ木札が載っていたら
        {
            teamSiteB = 1;   // オニチーム所属である
        }
        if (KifudaMSC.kifuda_B == 3)  // もし桃木札が載っていたら
        {
            teamSiteB = 3;   // 桃チーム所属である
        }

        if (KifudaMSC.kifuda_C == 1)  // もしオニ木札が載っていたら
        {
            teamSiteC = 1;   // オニチーム所属である
        }
        if (KifudaMSC.kifuda_C == 3)  // もし桃木札が載っていたら
        {
            teamSiteC = 3;   // 桃チーム所属である
        }

        if (KifudaMSC.kifuda_D == 1)  // もしオニ木札が載っていたら
        {
            teamSiteD = 1;   // オニチーム所属である
        }
        if (KifudaMSC.kifuda_D == 3)  // もし桃木札が載っていたら
        {
            teamSiteD = 3;   // 桃チーム所属である
        }

        if (KifudaMSC.kifuda_E == 1)  // もしオニ木札が載っていたら
        {
            teamSiteE = 1;   // オニチーム所属である
        }
        if (KifudaMSC.kifuda_E == 3)  // もし桃木札が載っていたら
        {
            teamSiteE = 3;   // 桃チーム所属である
        }

        if (KifudaMSC.kifuda_F == 1)  // もしオニ木札が載っていたら
        {
            teamSiteF = 1;   // オニチーム所属である
        }
        if (KifudaMSC.kifuda_F == 3)  // もし桃木札が載っていたら
        {
            teamSiteF = 3;   // 桃チーム所属である
        }

        if (KifudaMSC.kifuda_G == 1)  // もしオニ木札が載っていたら
        {
            teamSiteG = 1;   // オニチーム所属である
        }
        if (KifudaMSC.kifuda_G == 3)  // もし桃木札が載っていたら
        {
            teamSiteG = 3;   // 桃チーム所属である
        }

        if (KifudaMSC.kifuda_H == 1)  // もしオニ木札が載っていたら
        {
            teamSiteH = 1;   // オニチーム所属である
        }
        if (KifudaMSC.kifuda_H == 3)  // もし桃木札が載っていたら
        {
            teamSiteH = 3;   // 桃チーム所属である
        }
    }

    public void TeamHanteiAll()  // （強制的に）全員の所属チームの判定を行う
    {
        teamSiteA = TeamHanteiByOpen02(1);   // 所属チームを明らかにする
        teamSiteB = TeamHanteiByOpen02(2);   // 所属チームを明らかにする
        teamSiteC = TeamHanteiByOpen02(3);   // 所属チームを明らかにする
        teamSiteD = TeamHanteiByOpen02(4);   // 所属チームを明らかにする
        teamSiteE = TeamHanteiByOpen02(5);   // 所属チームを明らかにする
        teamSiteF = TeamHanteiByOpen02(6);   // 所属チームを明らかにする
        teamSiteG = TeamHanteiByOpen02(7);   // 所属チームを明らかにする
        teamSiteH = TeamHanteiByOpen02(8);   // 所属チームを明らかにする
    }

    public void TeamHanteiByOpen01()  // 役割カードがオープンしていたら所属チームの判定を行う
    {
        if (StatusSiteA >= 3)  //  役割カードがオープンしていたら
        {
            teamSiteA = TeamHanteiByOpen02(1);   // 所属チームを明らかにする
        }
        if (StatusSiteB >= 3)  //  役割カードがオープンしていたら
        {
            teamSiteB = TeamHanteiByOpen02(2);   // 所属チームを明らかにする
        }
        if (StatusSiteC >= 3)  //  役割カードがオープンしていたら
        {
            teamSiteC = TeamHanteiByOpen02(3);   // 所属チームを明らかにする
        }
        if (StatusSiteD >= 3)  //  役割カードがオープンしていたら
        {
            teamSiteD = TeamHanteiByOpen02(4);   // 所属チームを明らかにする
        }

        if (StatusSiteE >= 3)  //  役割カードがオープンしていたら
        {
            teamSiteE = TeamHanteiByOpen02(5);   // 所属チームを明らかにする
        }
        if (StatusSiteF >= 3)  //  役割カードがオープンしていたら
        {
            teamSiteF = TeamHanteiByOpen02(6);   // 所属チームを明らかにする
        }
        if (StatusSiteG >= 3)  //  役割カードがオープンしていたら
        {
            teamSiteG = TeamHanteiByOpen02(7);   // 所属チームを明らかにする
        }
        if (StatusSiteH >= 3)  //  役割カードがオープンしていたら
        {
            teamSiteH = TeamHanteiByOpen02(8);   // 所属チームを明らかにする
        }
    }

    public int TeamHanteiByOpen02(int x)  // 所属チームを明らかにする
    {
        if (rollF[x] >= 1 && rollF[x] <= 4) // 役わりカードが ももたろう、いぬ、さる、きじ
        {
            return 3;   // 桃チーム所属である
        }

        else if (rollF[x] >= 5 && rollF[x] <= 8) // 役わりカードが おにのおやぶん、こオニたち
        {
            return 1;   // おにチーム所属である
        }

        else
        {
            return 0;
        }
    }



    public void WinHantei01()  // 勝ち負けの判定を行う
    {
        MomoMakePoint = 0;   // 桃チームの負けポイント初期化
        if (StatusSiteA >= 5)  //  ステータスが気絶していたら
        {
            WinHantei02(1);   // 勝ち負けの判定を行う
        }
        if (StatusSiteB >= 5)  //  ステータスが気絶していたら
        {
            WinHantei02(2);   // 勝ち負けの判定を行う
        }
        if (StatusSiteC >= 5)  //  ステータスが気絶していたら
        {
            WinHantei02(3);   // 勝ち負けの判定を行う
        }
        if (StatusSiteD >= 5)  //  ステータスが気絶していたら
        {
            WinHantei02(4);   // 勝ち負けの判定を行う
        }

        if (StatusSiteE >= 5)  //  ステータスが気絶していたら
        {
            WinHantei02(5);   // 勝ち負けの判定を行う
        }
        if (StatusSiteF >= 5)  //  ステータスが気絶していたら
        {
            WinHantei02(6);   // 勝ち負けの判定を行う
        }
        if (StatusSiteG >= 5)  //  ステータスが気絶していたら
        {
            WinHantei02(7);   // 勝ち負けの判定を行う
        }
        if (StatusSiteH >= 5)  //  ステータスが気絶していたら
        {
            WinHantei02(8);   // 勝ち負けの判定を行う
        }
        if (MomoMakePoint >= 13)  // 桃チームのメンバーが全員きぜつしていたら
        {
            // 鬼チームの勝利である
            StartWinPhase();
            TeamHanteiAll();
            CheckWinTeam(1); // チームナンバー： 1（おにチーム）
            ApperWinOni();
        }
    }

    public void WinHantei02(int x)  // 勝ち負けの判定を行う
    {
        if (rollF[x] == 1) // 役わりカードが ももたろう
        {
            MomoMakePoint = MomoMakePoint + 10;  // 桃チームの負けポイントに +10
        }

        else if (rollF[x] >= 2 && rollF[x] <= 4) // 役わりカードが いぬ、さる、きじ
        {
            MomoMakePoint++;  // 桃チームの負けポイントに +1
        }

        else if (rollF[x] == 5) // 役わりカードが おにのおやぶん
        {
            // 桃チームの勝利である
            StartWinPhase();
            TeamHanteiAll();
            CheckWinTeam(3); // チームナンバー： 3（桃チーム）
            ApperWinMomo();
        }

        else  // 役わりカードが こおに → 何もおきない（勝ち負けに影響しない）
        {
        }
    }

    public void StartWinPhase()  // 勝ち負けが決まったら、まず初めに動き出すフェーズ
    {
        var sequence = DOTween.Sequence();
        CloseWinMomo();  // 勝ちマーク クローズ（初期化）
        CloseWinOni();   // 勝ちマーク クローズ（初期化）
        SwitchMakuMoveMode2();  // 幕を左へクローズ
        SEMSC.hyoushigi2_long_SE();
        sequence.InsertCallback(5.8f, () => ApperPanelWinner());  // 数秒後、win画面表示
    }

    public void AppearImageWinBack02()
    {
        ImageWinBack02.SetActive(true);
    }

    public void CloseImageWinBack02()
    {
        ImageWinBack02.SetActive(false);
    }


    public void ApperPanelWinner()
    {
        PanelWinner.SetActive(true);
    }

    public void ClosePanelWinner()
    {
        PanelWinner.SetActive(false);
    }

    public void ApperWinMomo()
    {
        WinMomo.SetActive(true);
    }

    public void CloseWinMomo()
    {
        WinMomo.SetActive(false);
    }

    public void ApperWinOni()
    {
        WinOni.SetActive(true);
    }

    public void CloseWinOni()
    {
        WinOni.SetActive(false);
    }


    public void ResetSiteWinAppearFlg()
    {
        SiteAWinAppearFlg = 0;
        SiteBWinAppearFlg = 0;
        SiteCWinAppearFlg = 0;
        SiteDWinAppearFlg = 0;
        SiteEWinAppearFlg = 0;
        SiteFWinAppearFlg = 0;
        SiteGWinAppearFlg = 0;
        SiteHWinAppearFlg = 0;
    }

    public void CheckWinTeam(int T)  // ゲームの勝利確定時、勝ったチームのキャラを表示させる
    {
        CharaMSC.AppearWinTeam(T, teamSiteA, SiteAWinAppearFlg, CharaMSC.SiteA_charaF, YakuMSC.SiteA_rollF);
        CharaMSC.AppearWinTeam(T, teamSiteB, SiteBWinAppearFlg, CharaMSC.SiteB_charaF, YakuMSC.SiteB_rollF);
        CharaMSC.AppearWinTeam(T, teamSiteC, SiteCWinAppearFlg, CharaMSC.SiteC_charaF, YakuMSC.SiteC_rollF);
        CharaMSC.AppearWinTeam(T, teamSiteD, SiteDWinAppearFlg, CharaMSC.SiteD_charaF, YakuMSC.SiteD_rollF);
        CharaMSC.AppearWinTeam(T, teamSiteE, SiteEWinAppearFlg, CharaMSC.SiteE_charaF, YakuMSC.SiteE_rollF);
        CharaMSC.AppearWinTeam(T, teamSiteF, SiteFWinAppearFlg, CharaMSC.SiteF_charaF, YakuMSC.SiteF_rollF);
        CharaMSC.AppearWinTeam(T, teamSiteG, SiteGWinAppearFlg, CharaMSC.SiteG_charaF, YakuMSC.SiteG_rollF);
        CharaMSC.AppearWinTeam(T, teamSiteH, SiteHWinAppearFlg, CharaMSC.SiteH_charaF, YakuMSC.SiteH_rollF);
    }

    //#################################################################################

}
// End