using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class SiteManager : MonoBehaviour
{
    #region Parameters
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
    public int ActiveSiteRoll = 0;  // 今アクティブなキャラの役割
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
    public int[] UkkariSite = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };    // しつもんの回答で うっかり正体を バラしてしまったか

    public int[] Maybe_Momotaro = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };    // ももたろう       である可能性値
    public int[] Maybe_MomoMate = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };    // ももたろうの仲間 である可能性値
    public int[] Maybe_Kooni = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };       // こおに           である可能性値
    public int[] Maybe_Oyabun = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };      // おにのおやぶん   である可能性値

    int RollFNum = 0;   // 現在エイムされているサイトの役わり
    public int DEX = 0; //命中力
    public int human_num = 1;
    int HandOfTime = 0;    // 「つぎの人に渡してね」のメッセージを表示させる
    public int preventTurnNum = 1; // 現在「〇ターンめです」 を表示させる時に参照する
    public int TargetSiteNum = 0;  // 現在エイムされているサイトがどこか？
    int preventPlayerOrderNum = 1; // 今このターンで何人目か？
    int TargetSiteOrderNum = 0;    // 現在エイムされているサイトの手番は、このターンの何人目か？
    int WorthAiming = 1;  // そのエイムサイトが、狙う（攻撃する）価値があるか(デフォルト：1 で「価値あり」)
    int AimedFlg = 0;  // 【しつもんモード】エイムセレクトの処理で使用するフラグ
    public int MomoMakePoint = 0;  // 桃チームの負けポイント：一定以上で鬼チームの勝利

    public int StatusSiteA = 1;
    public int StatusSiteB = 1;
    public int StatusSiteC = 1;
    public int StatusSiteD = 1;
    public int StatusSiteE = 1;
    public int StatusSiteF = 1;
    public int StatusSiteG = 1;
    public int StatusSiteH = 1;
    public int NowOyabunStatus = 1;  // 現在の おやぶんの ステータス
    public int NowMomotaroStatus = 1;  // 現在の ももたろうの ステータス
    public int NowActiveSiteStatus = 1;  // 現在の アクティブサイトの ステータス

    public int teamSiteA = 0;  // 所属チーム :デフォルト「0」null 、おにチーム「1」、桃チーム「3」
    public int teamSiteB = 0;
    public int teamSiteC = 0;
    public int teamSiteD = 0;
    public int teamSiteE = 0;
    public int teamSiteF = 0;
    public int teamSiteG = 0;
    public int teamSiteH = 0;
    
    public int KifudaProgressA = 0;
    public int KifudaProgressB = 0;
    public int KifudaProgressC = 0;
    public int KifudaProgressD = 0;
    public int KifudaProgressE = 0;
    public int KifudaProgressF = 0;
    public int KifudaProgressG = 0;
    public int KifudaProgressH = 0;
    public int KifudaProgressTotal = 0;  // 木札ONの進捗状況

    public int KurunProgressA = 0;
    public int KurunProgressB = 0;
    public int KurunProgressC = 0;
    public int KurunProgressD = 0;
    public int KurunProgressE = 0;
    public int KurunProgressF = 0;
    public int KurunProgressG = 0;
    public int KurunProgressH = 0;
    public int KurunProgressTotal = 0;  // 役割カードがオープンになったキャラが どれだけいるか の進捗状況

    public int TurnChip_A = 0;  // 順番マーカーのナンバー
    public int TurnChip_B = 0;
    public int TurnChip_C = 0;
    public int TurnChip_D = 0;
    public int TurnChip_E = 0;
    public int TurnChip_F = 0;
    public int TurnChip_G = 0;
    public int TurnChip_H = 0;

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
    public GameObject CardReverseCounter;
    CardReverseCounter CardReverseCounterScr;
    public GameObject YakuManager;
    YakuManager YakuMSC;
    public GameObject HPManager;
    HPManager HPMSC;
    public GameObject TurnMarkManager;
    TurnMarkManager TurnMarkMSC;
    public GameObject KifudaManager;
    KifudaManager KifudaMSC;
    public GameObject ButtonController;
    ButtonController ButtonCscr;
    public GameObject MainFlow;
    MainFlow MainFlowScr;

    public GameObject Yaku_A;
    CardReverse_Ba CardR_BaASC;
    public GameObject Yaku_B;
    CardReverse_Ba CardR_BaBSC;
    public GameObject Yaku_C;
    CardReverse_Ba CardR_BaCSC;
    public GameObject Yaku_D;
    CardReverse_Ba CardR_BaDSC;
    public GameObject Yaku_E;
    CardReverse_Ba CardR_BaESC;
    public GameObject Yaku_F;
    CardReverse_Ba CardR_BaFSC;
    public GameObject Yaku_G;
    CardReverse_Ba CardR_BaGSC;
    public GameObject Yaku_H;
    CardReverse_Ba CardR_BaHSC;

    public GameObject AttackMissText;    // 「Miss」と書かれたテキスト文（攻撃失敗時に出す）
    public GameObject TextCounterHit;    // 「カウンターだ」と書かれたテキスト文（カウンター発動時に出す）
    public GameObject AttakedAfterText;   // 攻撃後のセリフ（当たった時、外れた時、共に）
    public GameObject KabaiSerif;

    public bool faintingOccured = false;

    public GameObject PanelTurnNumber;
    public GameObject TurnNumNami;    // ターン開始時に中央に表示する
    public GameObject TurnNumUe;    // 何ターン目かを画面上に表示する
    public float NextTurnWait = 0.1f;  // 「〇ターンめ」の画面を表示するまで待つ時間
    public Image Eyecatch;  // ターン開始時にアイキャッチ画像を中央に表示する

    public Sprite EyecatchImage01;
    public Sprite EyecatchImage02;
    public Sprite EyecatchImage03;
    public Sprite EyecatchImage04;
    public Sprite EyecatchImage05;
    public Sprite EyecatchImage06;
    public Sprite EyecatchImage07;
    public Sprite EyecatchImage08;

    public GameObject PanelMAKU;  // 定式幕
    public GameObject ImagePole_Right;
    public GameObject ImagePole_Left;
    Vector2 PoleRightPos;
    Vector2 PoleLeftPos;
    Vector2 PanelMAKUPositon;
     float MakuMoveTime = 10.0f;        // 何秒間かけて幕が移動するか

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

    public GameObject CheckBoxes;

    public int OniLevel;  // SelectM で選択した「おにの強さ」を引き継いだもの
    public bool KabauFlg = false;  // 「かばう」の発動フラグ
    int OyabunHP = 3;
    int ActiveKooni = 0;
    public GameObject KabaiKooni;
    Vector2 KabaiKooniPositon;

    public bool CounterFlg = false;  // 「カウンター」の発動フラグ

    public int GuideLevel;  // 1 でガイド文 ON

    public GameObject Haguruma_Box;
    public GameObject GuideCheckBox2;
    public GameObject GuideCheckMark2; // チェックマーク2。
    public GameObject HomeButton_Box;

    public int WinFlgON = 0;  // 0で勝利フラグまだ立っていない
    public Image ImageP_WinMessage;
    public Sprite ImageP_happy;
    public Sprite ImageP_smile;

    public GameObject PanelInfoCPU;  // CPUが今操作中であるかのメッセージ表示
    public GameObject Next_InfoCPUWillOperate;  //  CPUがこれから操作する旨をメッセージ表示

    public bool SiteAisCPU = false;  // CPUであるかどうかのフラグ（falseで人）
    public bool SiteBisCPU = false;
    public bool SiteCisCPU = false;
    public bool SiteDisCPU = false;
    public bool SiteEisCPU = false;
    public bool SiteFisCPU = false;
    public bool SiteGisCPU = false;
    public bool SiteHisCPU = false;

    public bool NowActiveSite_isCPU = false;  // 今アクティブなサイトがCPUか
    public float WaitCPU = 1.0f;

    public bool CanPush_Question = true;
    public bool CanPush_Unmask = true;
    public bool CanPush_Attack = false;

    float currentTime = 0f;  //〇秒間に一度する処理用
    int PushedBtnFlg = 0;  // 処理を実施したかどうか：初期化

    public int InokoriMate = 0;  // ステータス2以下 & 桃メイト の総数
    public int InokoriKooni = 0;   // ステータス2以下 & こおに の総数

    #endregion

    // --------------------------------------------
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
        ResetCanPushAcButtons();
        HandOfTime = human_num - 1;
        AppearCanvasRollCheck();
        CloseCanvasPlayPlace();
        CharaMSC = CharaManager.GetComponent<CharaManager>();
        SEMSC = SEManager.GetComponent<SEManager>();
        CardReverseScr = CardReverse.GetComponent<CardReverse>();
        CardReverseCounterScr = CardReverseCounter.GetComponent<CardReverseCounter>();
        YakuMSC = YakuManager.GetComponent<YakuManager>();
        HPMSC = HPManager.GetComponent<HPManager>();
        TurnMarkMSC = TurnMarkManager.GetComponent<TurnMarkManager>();
        KifudaMSC = KifudaManager.GetComponent<KifudaManager>();
        ButtonCscr = ButtonController.GetComponent<ButtonController>();
        StartTurnNum();
        ReloadTurnNumUe();
        ClosePanelWinner();
        ResetSiteWinAppearFlg();
        AppearPanelRollCheck();
        AppearPanelMAKU();
        preventTurnNum = 1;
        AppearEyecatch();
        ResetStatusAllSites();  // すべてのサイトのステータスをリセットする（初期化）        
        NowOyabunStatus = 1;  // 現在の おやぶんの ステータスをリセット
        OniLevel = SelectManager.getOniStrong(); // ゲッター関数を呼び出し、値を引き継ぐ
        KabaiKooniPositon = KabaiKooni.transform.position;  // かばいこおにの現在位置をPositionに代入
        GuideLevel = SelectManager.getGuideMode(); // ゲッター関数を呼び出し、値を引き継ぐ

        ButtonCscr.ResetGuideText();
        MainFlowScr = MainFlow.GetComponent<MainFlow>();
        FirstCheckGuideLevel();
        WinFlgON = 0;  // // 0で勝利フラグ初期化
        CloseHomeButton_Box();
        CloseHaguruma_Box();
        CloseInfoCPU();
        KifudaProgressTotal = 0;  // 木札ONの進捗状況 初期化

        PoleRightPos = ImagePole_Right.gameObject.transform.position;
        PoleLeftPos = ImagePole_Left.gameObject.transform.position;
        FirstCheckCPU_Operation();  // 各サイトがCPUであるかどうかのチェック（初回のみ一回確認）
        PanelMAKUPositon = PanelMAKU.transform.position;  // 幕の現在位置(初期位置)をPositionに代入
        SetPositionPanelMAKU();  // 幕の位置を初期化
        selectTimeEnd();  //  キャラセレクトボタン初期化（ボタン消灯）
        PushedBtnFlg = 0;  // CPU操作 処理を実施したかどうかのフラグ：初期化
        ResetMaybe_Allrolls();  // 役割 可能性値の初期化 ⇒ 各25％
        ResetUkkariFlg();  // うっかりフラグをOFF（リセット）
        WorthAiming = 1;  // そのエイムサイトが、狙う（攻撃する）価値があるか (デフォルト：1 で「価値あり」)

        CardR_BaASC = Yaku_A.GetComponent<CardReverse_Ba>();
        CardR_BaBSC = Yaku_B.GetComponent<CardReverse_Ba>();
        CardR_BaCSC = Yaku_C.GetComponent<CardReverse_Ba>();
        CardR_BaDSC = Yaku_D.GetComponent<CardReverse_Ba>();
        CardR_BaESC = Yaku_E.GetComponent<CardReverse_Ba>();
        CardR_BaFSC = Yaku_F.GetComponent<CardReverse_Ba>();
        CardR_BaGSC = Yaku_G.GetComponent<CardReverse_Ba>();
        CardR_BaHSC = Yaku_H.GetComponent<CardReverse_Ba>();
    }


    //####################################  Update  ###################################

    void Update()
    {
        //        Debug.Log("MenuButtonMode？ " + MenuButtonMode);
        currentTime += Time.deltaTime;

        if (currentTime > 3)
        {
            Debug.Log("◆◎NowOyabunStatus：" + NowOyabunStatus);
            currentTime = 0f;
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
        charaN[1] = SelectManager.getSiteAInfo(); // SelectManagerで決めたsiteAの情報が charaN[1] に1～12の数値として代入される
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
            sequence.InsertCallback(1.5f, () => SlideRightPanelMAKU());  // 幕を右へオープン
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

    public void selectTimeStart()  //  キャラセレクト開始（ボタン点灯）
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

    public void selectTimeEnd()  //  キャラセレクト終了（ボタン消灯）
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

    public void AppearPanelMAKU()
    {
        PanelMAKU.SetActive(true);
    }

    public void SlideRightPanelMAKU()  // 幕が みぎ に移動する（ひらく）
    {
        Debug.Log("◆幕が ひら～く");
        PanelMAKU.transform.DOLocalMoveX(PoleRightPos.x, MakuMoveTime);
    }

    public void SlideLeftPanelMAKU()  // 幕が ひだり に移動する（とじる）
    {
        Debug.Log("◆幕が とじ～る");
        PanelMAKU.transform.DOLocalMoveX(PoleLeftPos.x, MakuMoveTime * 0.5f);
    }


    public void SetPositionPanelMAKU()  // 幕の位置を初期化
    {
        PanelMAKU.transform.position = PanelMAKUPositon;
        Debug.Log("◆幕の位置を初期化");
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
        CheckKifudaProgressTotal();  // 木札ONの進捗状況
        CheckKurunProgressTotal();  // 役割カードがオープンになったキャラが どれだけいるか の進捗状況 確認
        TeamHanteiByOpen01();
        Debug.Log("今このターンで何人目か？" + preventPlayerOrderNum);
        if (TurnChip_A == preventPlayerOrderNum)
        {
            NowActiveSiteN = 1;  // 今のアクティブサイトは SiteA
            NowActiveSiteStatus = StatusSiteA;
        }
        else if (TurnChip_B == preventPlayerOrderNum)
        {
            NowActiveSiteN = 2; // 今のアクティブサイトは SiteB
            NowActiveSiteStatus = StatusSiteB;
        }
        else if (TurnChip_C == preventPlayerOrderNum)
        {
            NowActiveSiteN = 3;  // 今のアクティブサイトは SiteC
            NowActiveSiteStatus = StatusSiteC;
        }
        else if (TurnChip_D == preventPlayerOrderNum)
        {
            NowActiveSiteN = 4;  // 今のアクティブサイトは SiteD
            NowActiveSiteStatus = StatusSiteD;
        }
        else if (TurnChip_E == preventPlayerOrderNum)
        {
            NowActiveSiteN = 5;  // 今のアクティブサイトは SiteE
            NowActiveSiteStatus = StatusSiteE;
        }
        else if (TurnChip_F == preventPlayerOrderNum)
        {
            NowActiveSiteN = 6;  // 今のアクティブサイトは SiteF
            NowActiveSiteStatus = StatusSiteF;
        }
        else if (TurnChip_G == preventPlayerOrderNum)
        {
            NowActiveSiteN = 7;  // 今のアクティブサイトは SiteG
            NowActiveSiteStatus = StatusSiteG;
        }
        else if (TurnChip_H == preventPlayerOrderNum)
        {
            NowActiveSiteN = 8;  // 今のアクティブサイトは SiteH
            NowActiveSiteStatus = StatusSiteH;
        }
        Debug.Log("今アクティブなサイトは" + NowActiveSiteN);
        Debug.Log("今アクティブなサイトのステータスは" + NowActiveSiteStatus);
        CharaMSC.AppearNowActiveSite();
        if (FirstTimeCheck)
        {
            preventPlayerOrderNum++;
        }
        KizetuSkipTurn();
        ButtonCscr.ResetGuideText();  // 毎回キャラの順番が進むごとにリセット 
        CheckCanPushMenuButtons();  // 各行動ボタンを押せるかどうかの確認をする
        var sequence2 = DOTween.Sequence();
        sequence2.InsertCallback(1.0f, () => CheckNowActiveSite_isCPU());
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

    public void CommonAimedOK()  // 各行動ボタンのねらいが正常に作動した時
    {
        SEMSC.cursor_SE();
        TurnActMode();           // 行動ボタンに応じて、該当のボックスを表示させる
        OpenPanelBattleFieldBox();
    }
    #endregion

    public void MenuButtonModeQuestion()
    {
        MenuButtonMode = 1;  // 質問モ―ド
    }

    public void MenuButtonModeUnmask()
    {
        MenuButtonMode = 2;  // 役割当てモ―ド
    }

    public void MenuButtonModeAttack()
    {
        MenuButtonMode = 3;  // 攻撃モード
    }

    public void CheckCanPushMenuButtons()  // 各行動ボタンを押せるかどうかの確認をする
    {
        CheckCanPushQuestion();
        CheckCanPushUnmask();
        CheckCanPushAttack();
    }

    public void CheckCanPushQuestion()  // 行動ボタン（質問）押せるかのチェック
    {
        Debug.Log("■CheckCanPushQuestion");
        Debug.Log("◆◎NowActiveSiteN：" + NowActiveSiteN);

        if (StatusSiteA < 2 || StatusSiteB < 2 || StatusSiteC < 2 || StatusSiteD < 2 || StatusSiteE < 2 || StatusSiteF < 2 || StatusSiteG < 2 || StatusSiteH < 2)  // 木札無しキャラ（ステータスが1）が 少なくとも一人いる → 判定に回す
        {
            CanPush_Question = CheckCanPushButton_Common(2, CanPush_Question);  // 結果（true or false） が代入される
        }
        else  // 木札無しキャラが 1人もいない ＝ 全員ステータス2以上（木札ON）
        {
            CanPush_Question = false;  // しつもんモードボタンは押せない
        }
    }

    public void CheckCanPushUnmask()
    {
        if (StatusSiteA < 4 || StatusSiteB < 4 || StatusSiteC < 4 || StatusSiteD < 4 || StatusSiteE < 4 || StatusSiteF < 4 || StatusSiteG < 4 || StatusSiteH < 4)
        {   // もしまだ役割が当てられていないキャラが一人以上いるならば
            CanPush_Unmask = CheckCanPushButton_Common(4, CanPush_Unmask);
        }
        else
        {
            CanPush_Unmask = false;  // 役割当てモードボタンは押せない
        }
    }

    public void CheckCanPushAttack()
    {
        if (StatusSiteA == 4 || StatusSiteB == 4 || StatusSiteC == 4 || StatusSiteD == 4 || StatusSiteE == 4 || StatusSiteF == 4 || StatusSiteG == 4 || StatusSiteH == 4)
        {   // もし役割が当てられており、かつ元気(==ステータス4)なキャラが一人以上いるならば
            int statusNum = 4;
            if (NowActiveSiteN == 1)  // 今のアクティブサイトがサイトA
            {
                if (StatusSiteA == statusNum && StatusSiteB != statusNum && StatusSiteC != statusNum && StatusSiteD != statusNum && StatusSiteE != statusNum && StatusSiteF != statusNum && StatusSiteG != statusNum && StatusSiteH != statusNum)
                {  // 役割オープン後(ステータス4)なのが自分だけ
                    CanPush_Attack = false;  // 攻撃ボタンは押せない
                }
                else  // 役割オープン後(ステータス4)なのが自分以外である
                {
                    CanPush_Attack = true;  // 攻撃ボタンは押せる
                }
            }
            else if (NowActiveSiteN == 2)  // 今のアクティブサイトがサイトB
            {
                if (StatusSiteA != statusNum && StatusSiteB == statusNum && StatusSiteC != statusNum && StatusSiteD != statusNum && StatusSiteE != statusNum && StatusSiteF != statusNum && StatusSiteG != statusNum && StatusSiteH != statusNum)
                {  // 役割オープン後(ステータス4)なのが自分だけ
                    CanPush_Attack = false;  // 攻撃ボタンは押せない
                }
                else
                {
                    CanPush_Attack = true;  // 攻撃ボタンは押せる
                }
            }
            else if (NowActiveSiteN == 3)  // 今のアクティブサイトがサイトC
            {
                if (StatusSiteA != statusNum && StatusSiteB != statusNum && StatusSiteC == statusNum && StatusSiteD != statusNum && StatusSiteE != statusNum && StatusSiteF != statusNum && StatusSiteG != statusNum && StatusSiteH != statusNum)
                {  // 役割オープン後(ステータス4)なのが自分だけ
                    CanPush_Attack = false;  // 攻撃ボタンは押せない
                }
                else
                {
                    CanPush_Attack = true;  // 攻撃ボタンは押せる
                }
            }
            else if (NowActiveSiteN == 4)  // 今のアクティブサイトがサイトD
            {
                if (StatusSiteA != statusNum && StatusSiteB != statusNum && StatusSiteC != statusNum && StatusSiteD == statusNum && StatusSiteE != statusNum && StatusSiteF != statusNum && StatusSiteG != statusNum && StatusSiteH != statusNum)
                {  // 役割オープン後(ステータス4)なのが自分だけ
                    CanPush_Attack = false;  // 攻撃ボタンは押せない
                }
                else
                {
                    CanPush_Attack = true;  // 攻撃ボタンは押せる
                }
            }

            else if (NowActiveSiteN == 5)  // 今のアクティブサイトがサイトE
            {
                if (StatusSiteA != statusNum && StatusSiteB != statusNum && StatusSiteC != statusNum && StatusSiteD != statusNum && StatusSiteE == statusNum && StatusSiteF != statusNum && StatusSiteG != statusNum && StatusSiteH != statusNum)
                {  // 役割オープン後(ステータス4)なのが自分だけ
                    CanPush_Attack = false;  // 攻撃ボタンは押せない
                }
                else
                {
                    CanPush_Attack = true;  // 攻撃ボタンは押せる
                }
            }
            else if (NowActiveSiteN == 6)  // 今のアクティブサイトがサイトF
            {
                if (StatusSiteA != statusNum && StatusSiteB != statusNum && StatusSiteC != statusNum && StatusSiteD != statusNum && StatusSiteE != statusNum && StatusSiteF == statusNum && StatusSiteG != statusNum && StatusSiteH != statusNum)
                {  // 役割オープン後(ステータス4)なのが自分だけ
                    CanPush_Attack = false;  // 攻撃ボタンは押せない
                }
                else
                {
                    CanPush_Attack = true;  // 攻撃ボタンは押せる
                }
            }
            else if (NowActiveSiteN == 7)  // 今のアクティブサイトがサイトG
            {
                if (StatusSiteA != statusNum && StatusSiteB != statusNum && StatusSiteC != statusNum && StatusSiteD != statusNum && StatusSiteE != statusNum && StatusSiteF != statusNum && StatusSiteG == statusNum && StatusSiteH != statusNum)
                {  // 役割オープン後(ステータス4)なのが自分だけ
                    CanPush_Attack = false;  // 攻撃ボタンは押せない
                }
                else
                {
                    CanPush_Attack = true;  // 攻撃ボタンは押せる
                }
            }
            else if (NowActiveSiteN == 8)  // 今のアクティブサイトがサイトH
            {
                if (StatusSiteA != statusNum && StatusSiteB != statusNum && StatusSiteC != statusNum && StatusSiteD != statusNum && StatusSiteE != statusNum && StatusSiteF != statusNum && StatusSiteG != statusNum && StatusSiteH == statusNum)
                {  // 役割オープン後(ステータス4)なのが自分だけ
                    CanPush_Attack = false;  // 攻撃ボタンは押せない
                }
                else
                {
                    CanPush_Attack = true;  // 攻撃ボタンは押せる
                }
            }
            else
            {
                CanPush_Attack = true;  // 攻撃ボタンは押せる
            }
        }
        else  // ステータス4のキャラが一人もいないならば
        {
            CanPush_Attack = false;  // 攻撃モードボタンは押せない
        }
    }

    public bool CheckCanPushButton_Common(int statusNum, bool CanPush_ActButton) // 行動ボタンが押せるかどうか、判定する（前提：（ステータスが statusNum 未満が 少なくとも一人いる）
    {
        if (NowActiveSiteN == 1)  // 今のアクティブサイトがサイトA
        {
            if (StatusSiteA < statusNum && StatusSiteB >= statusNum && StatusSiteC >= statusNum && StatusSiteD >= statusNum && StatusSiteE >= statusNum && StatusSiteF >= statusNum && StatusSiteG >= statusNum && StatusSiteH >= statusNum)   // フリーなのが自分だけ（自分のみステータスが statusNum 未満）
            {
                CanPush_ActButton = false;  // 今選んでいる行動ボタンは押せない
            }
            else  // フリーなのが自分ではなく他のキャラ                 or   フリーなのが自分と他にも存在している                ⇒ 自分以外のキャラでフリー(ステータス:statusNum 未満)なキャラが存在する
                  // 例A：(StatusSiteA == 2) && (StatusSiteB == 1)           例B：(StatusSiteA == 1) && (StatusSiteB == 1)
            {
                CanPush_ActButton = true;  // 今選んでいる行動ボタンは押せる
            }
        }
        else if (NowActiveSiteN == 2)  // 今のアクティブサイトがサイトB
        {
            if (StatusSiteA >= statusNum && StatusSiteB < statusNum && StatusSiteC >= statusNum && StatusSiteD >= statusNum && StatusSiteE >= statusNum && StatusSiteF >= statusNum && StatusSiteG >= statusNum && StatusSiteH >= statusNum)
            {  // フリーなのが自分だけしか残っていない
                CanPush_ActButton = false;  // 今選んでいる行動ボタンは押せない
            }
            else
            {
                CanPush_ActButton = true;  // 今選んでいる行動ボタンは押せる
            }
        }
        else if (NowActiveSiteN == 3)  // 今のアクティブサイトがサイトC
        {
            if (StatusSiteA >= statusNum && StatusSiteB >= statusNum && StatusSiteC < statusNum && StatusSiteD >= statusNum && StatusSiteE >= statusNum && StatusSiteF >= statusNum && StatusSiteG >= statusNum && StatusSiteH >= statusNum)
            {  // フリーなのが自分だけしか残っていない
                CanPush_ActButton = false;  // 今選んでいる行動ボタンは押せない
            }
            else
            {
                CanPush_ActButton = true;  // 今選んでいる行動ボタンは押せる
            }
        }
        else if (NowActiveSiteN == 4)  // 今のアクティブサイトがサイトD
        {
            if (StatusSiteA >= statusNum && StatusSiteB >= statusNum && StatusSiteC >= statusNum && StatusSiteD < statusNum && StatusSiteE >= statusNum && StatusSiteF >= statusNum && StatusSiteG >= statusNum && StatusSiteH >= statusNum)
            {  // フリーなのが自分だけしか残っていない
                CanPush_ActButton = false;  // 今選んでいる行動ボタンは押せない
            }
            else
            {
                CanPush_ActButton = true;  // 今選んでいる行動ボタンは押せる
            }
        }
        else if (NowActiveSiteN == 5)  // 今のアクティブサイトがサイトE
        {
            if (StatusSiteA >= statusNum && StatusSiteB >= statusNum && StatusSiteC >= statusNum && StatusSiteD >= statusNum && StatusSiteE < statusNum && StatusSiteF >= statusNum && StatusSiteG >= statusNum && StatusSiteH >= statusNum)
            {  // フリーなのが自分だけしか残っていない
                CanPush_ActButton = false;  // 今選んでいる行動ボタンは押せない
            }
            else
            {
                CanPush_ActButton = true;  // 今選んでいる行動ボタンは押せる
            }
        }
        else if (NowActiveSiteN == 6)  // 今のアクティブサイトがサイトF
        {
            if (StatusSiteA >= statusNum && StatusSiteB >= statusNum && StatusSiteC >= statusNum && StatusSiteD >= statusNum && StatusSiteE >= statusNum && StatusSiteF < statusNum && StatusSiteG >= statusNum && StatusSiteH >= statusNum)
            {  // フリーなのが自分だけしか残っていない
                CanPush_ActButton = false;  // 今選んでいる行動ボタンは押せない
            }
            else
            {
                CanPush_ActButton = true;  // 今選んでいる行動ボタンは押せる
            }
        }
        else if (NowActiveSiteN == 7)  // 今のアクティブサイトがサイトG
        {
            if (StatusSiteA >= statusNum && StatusSiteB >= statusNum && StatusSiteC >= statusNum && StatusSiteD >= statusNum && StatusSiteE >= statusNum && StatusSiteF >= statusNum && StatusSiteG < statusNum && StatusSiteH >= statusNum)
            {  // フリーなのが自分だけしか残っていない
                CanPush_ActButton = false;  // 今選んでいる行動ボタンは押せない
            }
            else
            {
                CanPush_ActButton = true;  // 今選んでいる行動ボタンは押せる
            }
        }
        else if (NowActiveSiteN == 8)  // 今のアクティブサイトがサイトH
        {
            if (StatusSiteA >= statusNum && StatusSiteB >= statusNum && StatusSiteC >= statusNum && StatusSiteD >= statusNum && StatusSiteE >= statusNum && StatusSiteF >= statusNum && StatusSiteG >= statusNum && StatusSiteH < statusNum)
            {  // フリーなのが自分だけしか残っていない
                CanPush_ActButton = false;  // 今選んでいる行動ボタンは押せない
            }
            else
            {
                CanPush_ActButton = true;  // 今選んでいる行動ボタンは押せる
            }
        }
        else
        {
            CanPush_ActButton = true;  // 今選んでいる行動ボタンは押せる
        }
        return CanPush_ActButton;  // 選択できるか否かの結果を、bool型で返す
    }

    public void TurnActMode()   // 行動ボタンに応じて、該当のボックスを表示させる
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

    public void SerifDependOnRole()  // しつもん「好きな食べ物は？」に対する回答
    {
        int UkkariSerif = UnityEngine.Random.Range(1, 7);
        if (rollF[TargetSiteNum] == 1) // ももたろう
        {
            AnswerSerifText.GetComponent<Text>().text = "おばあさんの おみそしるを たべたい";
        }
        else if (rollF[TargetSiteNum] >= 2 && rollF[TargetSiteNum] <= 4) // いぬ、さる、きじ
        {
            if (UkkariSerif == 1)
            {
                AnswerSerifText.GetComponent<Text>().text = "きびだん・・、 カレー たべたいなー";
                UkkariSite[TargetSiteNum] = 1;  // しつもんの回答で うっかり正体を バラしてしまったか → フラグON
            }
            else
            {
                AnswerSerifText.GetComponent<Text>().text = "カレー たべたいな";
            }
        }
        else if (rollF[TargetSiteNum] == 5) // おにのおやぶん
        {
            AnswerSerifText.GetComponent<Text>().text = "おさけだ！ おさけ もってこーい！";
        }
        else if (rollF[TargetSiteNum] >= 6 && rollF[TargetSiteNum] <= 8) // こオニたち
        {
            if (UkkariSerif == 1)
            {
                AnswerSerifText.GetComponent<Text>().text = "カレー たべたいな オニ";
                UkkariSite[TargetSiteNum] = 1;  // しつもんの回答で うっかり正体を バラしてしまったか → フラグON
            }
            else
            {
                AnswerSerifText.GetComponent<Text>().text = "カレー たべたいな";
            }
        }

        // おやぶんが 確定なのに、おやぶんを狙わない  ⇒ スルーして「しつもん」をしたキャラ(今のアクティブプレーヤー)は こおにの 可能性大！
        if (NowOyabunStatus >= 2)
        {
            if (rollF[NowActiveSiteN] != 5)  // 今のアクティブプレーヤーが おやぶん 以外
            {
                Maybe_Momotaro[NowActiveSiteN] = 2;
                Maybe_MomoMate[NowActiveSiteN] = 2;
                Maybe_Oyabun[NowActiveSiteN] = 0;
                Maybe_Kooni[NowActiveSiteN] = Maybe_Kooni[NowActiveSiteN] + 50;
            }
            else  // 今のアクティブプレーヤーが おやぶん
            {
                Maybe_Momotaro[NowActiveSiteN] = 2;
                Maybe_MomoMate[NowActiveSiteN] = 2;
                Maybe_Oyabun[NowActiveSiteN] = 98;
                Maybe_Kooni[NowActiveSiteN] = 2;
            }
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
        JudgeMaybe_Parameter();  // メイビーパラメータ(キャラがこの役割ではないか？の可能性を数値化したもの) をチェックする（CPU操作で使う）
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
        JudgeMaybe_Parameter();  // メイビーパラメータ(キャラがこの役割ではないか？の可能性を数値化したもの) をチェックする（CPU操作で使う）
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
        JudgeMaybe_Parameter();  // メイビーパラメータ(キャラがこの役割ではないか？の可能性を数値化したもの) をチェックする（CPU操作で使う）
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
        JudgeMaybe_Parameter();  // メイビーパラメータ(キャラがこの役割ではないか？の可能性を数値化したもの) をチェックする（CPU操作で使う）
    }

    public void YosouYes()
    {
        NextTurnWait = 1.0f;  // 次のターンに行くまでの待機時間
        JudgeAnswerText.GetComponent<Text>().text = "はい、そうです";
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.5f, () => YosouYes2());
        sequence.InsertCallback(3.0f, () => CardReverseScr.ImageReset());
    }

    public void YosouYes2()
    {
        // 当てられた相手の画像オープン
        CardReverseScr.ImageSet();
        YakuMSC.CheckAimedRole();   // 【役わり名予想フェーズ】画面中央に役わり名を当てられた人の役職を表示させる
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
        CheckNowOyabunStatus();  // おやぶんのステータス確認
        CheckNowMomotaroStatus();  // ももたろうのステータス確認
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
        Debug.Log("◆◎ペナルティーでオープンします");
        Debug.Log("◆◎NowActiveSiteN：" + NowActiveSiteN);
        if (NowActiveSiteN == 1)
        {
            if (MenuButtonMode == 2)
            {
                StatusSiteA = 4;
            }
            YakuMSC.OpenYakuCardA();
        }
        else if (NowActiveSiteN == 2)
        {
            if (MenuButtonMode == 2)
            {
                StatusSiteB = 4;
            }
            YakuMSC.OpenYakuCardB();
        }
        else if (NowActiveSiteN == 3)
        {
            if (MenuButtonMode == 2)
            {
                StatusSiteC = 4;
            }
            YakuMSC.OpenYakuCardC();
        }
        else if (NowActiveSiteN == 4)
        {
            if (MenuButtonMode == 2)
            {
                StatusSiteD = 4;
            }
            YakuMSC.OpenYakuCardD();
        }
        else if (NowActiveSiteN == 5)
        {
            if (MenuButtonMode == 2)
            {
                StatusSiteE = 4;
            }
            YakuMSC.OpenYakuCardE();
        }
        else if (NowActiveSiteN == 6)
        {
            if (MenuButtonMode == 2)
            {
                StatusSiteF = 4;
            }
            YakuMSC.OpenYakuCardF();
        }
        else if (NowActiveSiteN == 7)
        {
            if (MenuButtonMode == 2)
            {
                StatusSiteG = 4;
            }
            YakuMSC.OpenYakuCardG();
        }
        else if (NowActiveSiteN == 8)
        {
            if (MenuButtonMode == 2)
            {
                StatusSiteH = 4;
            }
            YakuMSC.OpenYakuCardH();
        }
        CheckNowOyabunStatus();  // おやぶんのステータス確認
        CheckNowMomotaroStatus();  // ももたろうのステータス確認
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

    public void JudgeHitting()   // 攻撃がヒットしたかの判定
    {
        Debug.Log("◆◎DEX：" + DEX);   // この値以下なら、攻撃成功
        int accuracy = UnityEngine.Random.Range(1, 7); // 攻撃が当たるかどうかのランダム数値
        Debug.Log("◆◎accuracy：" + accuracy);
        CardReverseCounterScr.ImageReset();

        if (1 <= accuracy && accuracy <= DEX)  // 命中するよ
        {
            CheckKabau();  // 「かばう」発動条件に合致しているか確認

            if (KabauFlg)  // 合致している → 「かばう」発動！
            {
                ProtectOyabun();
            }
            else          // 合致していない → 無事攻撃成功！
            {
                SuccessHitting();
            }
            KabauFlg = false; // かばうフラグを初期化
        }
        else if (DEX < accuracy && accuracy <= 7)  // 命中しないよ
        {
            CheckCounter();  // 「カウンター」発動条件の確認

            if (CounterFlg)  // 合致している → 「カウンター」発動！
            {
                CounterAttack();
            }
            else          // 合致していない → そのまま攻撃はずれる
            {
                FailureHitting();   // 攻撃失敗
            }
            CounterFlg = false; // カウンターフラグを初期化
        }
        HPMSC.HP_check();  // HPの残りに応じて、プレイ画面を更新
        JudgeMaybe_Parameter();  // メイビーパラメータ(キャラがこの役割ではないか？の可能性を数値化したもの) をチェックする（CPU操作で使う）
    }

    public void SuccessHitting()   // 攻撃成功   
    {
        SEMSC.punch_SE();
        AttackHitSerif();
        DecreaseHP();
        HPMSC.HP_check();
        YakuMSC.DamageTenmetu();      // 役職カードを点滅させる
    }

    public void FailureHitting()   // 攻撃失敗
    {
        SEMSC.suka_SE();
        AttackMissSerif();
        AttackMissText.SetActive(true);  // 「Miss」と書かれたテキスト文を表示させる
        var sequence = DOTween.Sequence();
        //sequence.InsertCallback(2f, () => AttackMissText.SetActive(false));  // Miss を非表示にする
        sequence.InsertCallback(2f, () => CloseMissText());  // Miss を非表示にする
    }

    public void CheckKabau()  // 「かばう」発動条件の確認
    {
        Debug.Log("◆◎OniLevel：" + OniLevel);   // この値が1以下なら、「かばう」発動しない
        if (OniLevel >= 2)
        {
            if (rollF[TargetSiteNum] == 5)       // 狙われた人の役割が「オニのおやぶんである」
            {
                CheckOyabunHP();
                if (OyabunHP == 1)                // おやぶんの残り体力が「1」である
                {
                    CheckActiveKooni();
                    if (ActiveKooni >= 1)// 元気な こオニが1人以上いる
                    {
                        int accuracy = UnityEngine.Random.Range(1, 7); // かばうが成功するかどうかのランダム数値  
                        if (1 <= accuracy && accuracy <= 3)   // ★7だと100％かばう成功
                        {
                            KabauFlg = true;  // かばう条件を満たしている →かばうフラグをON → 「かばう」発動！
                        }
                    }

                }
            }
        }
    }

    public void JudgeMaybe_Parameter()  // メイビーパラメータ (キャラがこの役割ではないか？の可能性を数値化したもの) を判定する
    {
        Debug.Log("今アクティブなサイトは" + NowActiveSiteN);
        if ((rollF[TargetSiteNum] >= 5) && (rollF[TargetSiteNum] <= 8))  // 狙った相手が おにチーム である → 今のアクティブプレーヤーは  桃チーム である可能性が高い
        {
            Maybe_Momotaro[NowActiveSiteN] = Maybe_Momotaro[NowActiveSiteN] + 25;
            Maybe_MomoMate[NowActiveSiteN] = Maybe_MomoMate[NowActiveSiteN] + 25;
            Maybe_Oyabun[NowActiveSiteN] = 2;
            Maybe_Kooni[NowActiveSiteN] = 2;
        }
        else if ((rollF[TargetSiteNum] >= 1) && (rollF[TargetSiteNum] <= 4))  // 狙った相手が 桃チームチーム である → 今のアクティブプレーヤーは  おにチーム である可能性が高い
        {
            Maybe_Momotaro[NowActiveSiteN] = 2;
            Maybe_MomoMate[NowActiveSiteN] = 2;
            Maybe_Oyabun[NowActiveSiteN] = Maybe_Oyabun[NowActiveSiteN] + 25;
            Maybe_Kooni[NowActiveSiteN] = Maybe_Kooni[NowActiveSiteN] + 25;
        }
    }

    public void CheckOyabunHP()  // おやぶんの残り体力を確認する
    {
        if (TargetSiteNum == 1)
        {
            OyabunHP = HPMSC.HP_A;
        }
        else if (TargetSiteNum == 2)
        {
            OyabunHP = HPMSC.HP_B;
        }
        else if (TargetSiteNum == 3)
        {
            OyabunHP = HPMSC.HP_C;
        }
        else if (TargetSiteNum == 4)
        {
            OyabunHP = HPMSC.HP_D;
        }
        else if (TargetSiteNum == 5)
        {
            OyabunHP = HPMSC.HP_E;
        }
        else if (TargetSiteNum == 6)
        {
            OyabunHP = HPMSC.HP_F;
        }
        else if (TargetSiteNum == 7)
        {
            OyabunHP = HPMSC.HP_G;
        }
        else if (TargetSiteNum == 8)
        {
            OyabunHP = HPMSC.HP_H;
        }
    }

    public void CheckNowOyabunStatus()  // おやぶんのステータス確認
    {
        if (rollF[1] == 5) // 役割が おにのおやぶん
        {
            NowOyabunStatus = StatusSiteA;  // おやぶんのステータス 上書き
        }
        else if (rollF[2] == 5) // 役割が おにのおやぶん
        {
            NowOyabunStatus = StatusSiteB;  // おやぶんのステータス 上書き
        }
        else if (rollF[3] == 5) // 役割が おにのおやぶん
        {
            NowOyabunStatus = StatusSiteC;  // おやぶんのステータス 上書き
        }
        else if (rollF[4] == 5) // 役割が おにのおやぶん
        {
            NowOyabunStatus = StatusSiteD;  // おやぶんのステータス 上書き
        }
        else if (rollF[5] == 5) // 役割が おにのおやぶん
        {
            NowOyabunStatus = StatusSiteE;  // おやぶんのステータス 上書き
        }
        else if (rollF[6] == 5) // 役割が おにのおやぶん
        {
            NowOyabunStatus = StatusSiteF;  // おやぶんのステータス 上書き
        }
        else if (rollF[7] == 5) // 役割が おにのおやぶん
        {
            NowOyabunStatus = StatusSiteG;  // おやぶんのステータス 上書き
        }
        else if (rollF[8] == 5) // 役割が おにのおやぶん
        {
            NowOyabunStatus = StatusSiteH;  // おやぶんのステータス 上書き
        }
    }

    public void CheckNowMomotaroStatus()  // ももたろうのステータス確認
    {
        if (rollF[1] == 5) // 役割が ももたろう
        {
            NowMomotaroStatus = StatusSiteA;  // ももたろうのステータス 上書き
        }
        else if (rollF[2] == 5) // 役割が ももたろう
        {
            NowMomotaroStatus = StatusSiteB;  // ももたろうのステータス 上書き
        }
        else if (rollF[3] == 5) // 役割が ももたろう
        {
            NowMomotaroStatus = StatusSiteC;  // ももたろうのステータス 上書き
        }
        else if (rollF[4] == 5) // 役割が ももたろう
        {
            NowMomotaroStatus = StatusSiteD;  // ももたろうのステータス 上書き
        }
        else if (rollF[5] == 5) // 役割が ももたろう
        {
            NowMomotaroStatus = StatusSiteE;  // ももたろうのステータス 上書き
        }
        else if (rollF[6] == 5) // 役割が ももたろう
        {
            NowMomotaroStatus = StatusSiteF;  // ももたろうのステータス 上書き
        }
        else if (rollF[7] == 5) // 役割が ももたろう
        {
            NowMomotaroStatus = StatusSiteG;  // ももたろうのステータス 上書き
        }
        else if (rollF[8] == 5) // 役割が ももたろう
        {
            NowMomotaroStatus = StatusSiteH;  // ももたろうのステータス 上書き
        }
    }


    public void CheckActiveKooni()  // 元気なこオニの人数を確認
    {
        ActiveKooni = 0;  // 確認開始時に初期化する

        if (rollF[1] >= 6 && rollF[1] <= 8) // 役割が こオニ である
        {
            if (StatusSiteA <= 4)  //  状態（ステータス）が元気である
            {
                ActiveKooni++;
            }
        }
        if (rollF[2] >= 6 && rollF[2] <= 8) // 役割が こオニ である
        {
            if (StatusSiteB <= 4)  //  状態（ステータス）が元気である
            {
                ActiveKooni++;
            }
        }
        if (rollF[3] >= 6 && rollF[3] <= 8) // 役割が こオニ である
        {
            if (StatusSiteC <= 4)  //  状態（ステータス）が元気である
            {
                ActiveKooni++;
            }
        }
        if (rollF[4] >= 6 && rollF[4] <= 8) // 役割が こオニ である
        {
            if (StatusSiteD <= 4)  //  状態（ステータス）が元気である
            {
                ActiveKooni++;
            }
        }
        if (rollF[5] >= 6 && rollF[5] <= 8) // 役割が こオニ である
        {
            if (StatusSiteE <= 4)  //  状態（ステータス）が元気である
            {
                ActiveKooni++;
            }
        }
        if (rollF[6] >= 6 && rollF[6] <= 8) // 役割が こオニ である
        {
            if (StatusSiteF <= 4)  //  状態（ステータス）が元気である
            {
                ActiveKooni++;
            }
        }
        if (rollF[7] >= 6 && rollF[7] <= 8) // 役割が こオニ である
        {
            if (StatusSiteG <= 4)  //  状態（ステータス）が元気である
            {
                ActiveKooni++;
            }
        }
        if (rollF[8] >= 6 && rollF[8] <= 8) // 役割が こオニ である
        {
            if (StatusSiteH <= 4)  //  状態（ステータス）が元気である
            {
                ActiveKooni++;
            }
        }
    }


    #region ProtectOyabunGroup    おやぶんをかばう動作の本丸フェーズ
    public void ProtectOyabun()  // かばう条件を満たしている → 「かばう」発動！
    {
        var sequence = DOTween.Sequence();
        Debug.Log("◆◎「かばう」発動！");
        SEMSC.Kabai_SE();
        SetPositionKabaiKooni();  // こおにの位置を初期化
        AppearKabaiKooni();       // こおにが、おやぶんの横位置に現れる
        SlideKabaiKooni();        // こおにが 横に移動する
        KabaiKooniSerif();        // こおに のセリフ
        KabawareSerif();          // かばわれた人のメッセージ表示 「！！」
        sequence.InsertCallback(0.5f, () => YakuMSC.KabaiKooniTenmetu());      // かばいこおにを点滅させる（こおに にダメージ当たる）
        sequence.InsertCallback(0.5f, () => SEMSC.punch_SE());
        sequence.InsertCallback(1f, () => ResetKabaiKooniSerif());
        sequence.InsertCallback(3f, () => CloseKabaiKooni()); // こおにを非表示にする
        DecreaseKabaiKooniHP();  // こおに のHPを減らす（おやぶんの体力はそのまま）
        HPMSC.HP_check();  // HPの残りに応じて、プレイ画面を更新
    }

    public void SetPositionKabaiKooni()  // こおにの位置を初期化
    {
        KabaiKooni.transform.position = KabaiKooniPositon;
        Debug.Log("◆こおにの位置を初期化");
    }

    public void AppearKabaiKooni()  // こおにが、おやぶんの横位置に現れる
    {
        KabaiKooni.SetActive(true);
        Debug.Log("◆こおにが、おやぶんの横位置に現れる");
    }

    public void SlideKabaiKooni()  // こおにが 横に移動する
    {
        KabaiKooni.transform.DOLocalMoveX(-30.5f, 0.5f);
        Debug.Log("◆こおにが 横に移動する");
    }

    public void CloseKabaiKooni()
    {
        KabaiKooni.SetActive(false);
        Debug.Log("◆こおにを非表示にする");
    }

    public void DecreaseKabaiKooniHP()  // こおに のHPを減らす（おやぶんの体力はそのまま）
    {
        WhoIsKabaiKooni();  // 「TargetSiteNum 」を こおに のサイト番号に上書きする
        YosouYes2();
        DecreaseHP();
    }

    public void WhoIsKabaiKooni()
    {
        for (int TN = 1; TN < 9; TN++)
        {
            if (TurnChip_A == TN)
            {
                if (rollF[1] >= 6 && rollF[1] <= 8) // 役割がこオニである
                {
                    if (StatusSiteA <= 4)  // ステータスがまだ気絶していない
                    {
                        TargetSiteNum = 1;
                        TN = 10;
                    }
                }
            }
            else if (TurnChip_B == TN)
            {
                if (rollF[2] >= 6 && rollF[2] <= 8) // 役割がこオニである
                {
                    if (StatusSiteB <= 4)
                    {
                        TargetSiteNum = 2;
                        TN = 10;
                    }
                }
            }
            else if (TurnChip_C == TN)
            {
                if (rollF[3] >= 6 && rollF[3] <= 8) // 役割がこオニである
                {
                    if (StatusSiteC <= 4)
                    {
                        TargetSiteNum = 3;
                        TN = 10;
                    }
                }
            }
            else if (TurnChip_D == TN)
            {
                if (rollF[4] >= 6 && rollF[4] <= 8) // 役割がこオニである
                {
                    if (StatusSiteD <= 4)
                    {
                        TargetSiteNum = 4;
                        TN = 10;
                    }
                }
            }
            else if (TurnChip_E == TN)
            {
                if (rollF[5] >= 6 && rollF[5] <= 8) // 役割がこオニである
                {
                    if (StatusSiteE <= 4)
                    {
                        TargetSiteNum = 5;
                        TN = 10;
                    }
                }
            }
            else if (TurnChip_F == TN)
            {
                if (rollF[6] >= 6 && rollF[6] <= 8) // 役割がこオニである
                {
                    if (StatusSiteF <= 4)
                    {
                        TargetSiteNum = 6;
                        TN = 10;
                    }
                }
            }
            else if (TurnChip_G == TN)
            {
                if (rollF[7] >= 6 && rollF[7] <= 8) // 役割がこオニである
                {
                    if (StatusSiteG <= 4)
                    {
                        TargetSiteNum = 7;
                        TN = 10;
                    }
                }
            }
            else if (TurnChip_H == TN)
            {
                if (rollF[8] >= 6 && rollF[8] <= 8) // 役割がこオニである
                {
                    if (StatusSiteH <= 4)
                    {
                        TargetSiteNum = 8;
                        TN = 10;
                    }
                }
            }
        }
    }

    #endregion

    public void CheckCounter()  // 「カウンター」発動条件の確認
    {
        Debug.Log("◆◎OniLevel：" + OniLevel);   // この値が3以上なら、「かばう」発動する
        if (OniLevel >= 3)
        {
            if (rollF[TargetSiteNum] == 5)       // 狙われた人の役割が「オニのおやぶんである」
            {
                int accuracy = UnityEngine.Random.Range(1, 7); // カウンターが成功するかどうかのランダム数値  
                if (1 <= accuracy && accuracy <= 2)   // ★7だと100％カウンター成功
                {
                    CounterFlg = true;  // カウンター条件を満たしている →カウンターフラグをON → 「カウンター」発動！
                }
            }

        }
    }

    #region CounterAttackGroup    「カウンター」発動動作の本丸フェーズ
    public void CounterAttack()  // 「カウンター」発動条件に合致している → 「カウンター」発動！
    {
        var sequence = DOTween.Sequence();
        Debug.Log("◆◎「カウンター」発動！");
        SEMSC.jidai_SE();
        CounterSerif();  // カウンター攻撃時のセリフ
        AttackMissText.SetActive(true);  // 「Miss」と書かれたテキスト文を表示させる
        TextCounterHit.SetActive(true);  // 「カウンターだ」と書かれたテキスト文を表示させる
        sequence.InsertCallback(1f, () => CloseMissText());  // Miss を非表示にする
        sequence.InsertCallback(3f, () => CloseCounteText());  // カウンター を非表示にする
        OpenKurunCounter();    // 攻撃してきたキャラをクルンと回して表示する
        sequence.InsertCallback(1.5f, () => YakuMSC.CounteredCharaTenmetu());  // 攻撃してきたキャラを点滅させる（攻撃してきたキャラ にダメージ当たる）
        sequence.InsertCallback(1.5f, () => SEMSC.punch_SE());
        DecreaseCounteredCharaHP();  // 攻撃してきたキャラ のHPを減らす（おやぶんの体力はそのまま）
        HPMSC.HP_check();  // HPの残りに応じて、プレイ画面を更新
    }

    public void OpenKurunCounter()  // 攻撃してきたキャラをクルンと回して表示する
    {
        //       CardReverseCounterScr.ImageReset();
        NextTurnWait = 1.0f;  // 次のターンに行くまでの待機時間
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.4f, () => OpenKurunCounter2());
        //        sequence.InsertCallback(3.0f, () => CardReverseCounterScr.ImageReset());
    }

    public void OpenKurunCounter2()
    {
        // 攻撃してきたキャラの画像オープン
        CardReverseCounterScr.ImageSet();
        YakuMSC.OpenCounteredRole();   // 【カウンター発動時、反撃フェーズ】画面中央にカウンターを当てられた人の役職を表示させる
        StartCoroutine(CardReverseCounterScr.CardOpen());
    }

    public void DecreaseCounteredCharaHP()  // カウンターをくらったキャラ のHPを減らす（おやぶんの体力はそのまま）
    {
        TargetSiteNum = NowActiveSiteN;     // 今攻撃してきたキャラを TargetSiteNum に上書きする
//        YosouYes2();
        PenaltyOpenYakuCard();    // 今攻撃してきたキャラの画像オープン
        DecreaseHP();
    }

    #endregion

    public void CloseMissText()
    {
        AttackMissText.SetActive(false);
    }

    public void CloseCounteText()
    {
        TextCounterHit.SetActive(false);
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

    public void KabawareSerif()  // かばわれた時のセリフ
    {
        AttakedAfterText.GetComponent<Text>().text = "！！";
    }

    public void KabaiKooniSerif()  // かばいこおに のセリフ
    {
        int AttackedSerif = UnityEngine.Random.Range(1, 5);
        switch (AttackedSerif)
        {
            case 1: //
                KabaiSerif.GetComponent<Text>().text = "あぶなーい！";
                break;
            case 2: //
                KabaiSerif.GetComponent<Text>().text = "させないよ！";
                break;
            case 3: //
                KabaiSerif.GetComponent<Text>().text = "とりゃ！";
                break;
            case 4: //
                KabaiSerif.GetComponent<Text>().text = "えーい！";
                break;
            default:
                // その他処理
                break;
        }
    }

    public void ResetKabaiKooniSerif()  // かばいこおに のセリフを消す (実際には半角スペースを入れて、あたかも消えているように見える)
    {
        KabaiSerif.GetComponent<Text>().text = "";
    }

    public void CounterSerif()  // カウンター攻撃時のセリフ
    {
        int AttackedSerif = UnityEngine.Random.Range(1, 5);
        switch (AttackedSerif)
        {
            case 1: //
                AttakedAfterText.GetComponent<Text>().text = "カウンターだ！！";
                break;
            case 2: //
                AttakedAfterText.GetComponent<Text>().text = "あまいっ！！";
                break;
            case 3: //
                AttakedAfterText.GetComponent<Text>().text = "そこだ！！";
                break;
            case 4: //
                AttakedAfterText.GetComponent<Text>().text = "みきった！！";
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
        CheckNowOyabunStatus();  // おやぶんのステータス確認
        CheckNowMomotaroStatus();  // ももたろうのステータス確認
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
        CheckNowOyabunStatus();  // おやぶんのステータス確認
        CheckNowMomotaroStatus();  // ももたろうのステータス確認
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
        AppearEyecatch();
        PanelTurnNumber.SetActive(true);
        AddpreventTurnNum();
        StartTurnNum();
        ReloadTurnNumUe();
        NextTurnWait = 0.1f;
        //        var sequence = DOTween.Sequence();
        //        sequence.InsertCallback(1.5f, () => PanelTurnNumberClose());
    }

    public void AppearEyecatch()
    {
        int eyecatchNum = UnityEngine.Random.Range(1, 9);
        Debug.Log("これからAppearEyecatch :::" + eyecatchNum);
        switch (eyecatchNum)
        {
            case 1: //
                Eyecatch.sprite = EyecatchImage01;
                break;
            case 2: //
                Eyecatch.sprite = EyecatchImage02;
                break;
            case 3: //
                Eyecatch.sprite = EyecatchImage03;
                break;
            case 4: //
                Eyecatch.sprite = EyecatchImage04;
                break;
            case 5: //
                Eyecatch.sprite = EyecatchImage05;
                break;
            case 6: //
                Eyecatch.sprite = EyecatchImage06;
                break;
            case 7: //
                Eyecatch.sprite = EyecatchImage07;
                break;
            case 8: //
                Eyecatch.sprite = EyecatchImage08;
                break;
            default:
                // その他処理
                break;
        }
    }

    public void ResetWaitTime()
    {
        NextTurnWait = 0.1f;
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
        if (preventTurnNum < 4) // 1～8人目のターンの時
        {
            preventTurnNum++;
        }
        if (preventTurnNum >= 4)  // そのターンがすべて終わり、次のターンに行く
        {
            Debug.Log("3ターン経過。これでおにチームの勝ち確定:::" + preventTurnNum);
            WinOniTeam();   // 鬼チームの勝利である
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

    public void CheckKifudaProgressTotal()  // 木札ONの進捗状況
    {
        if(StatusSiteA >= 2)
        {
            KifudaProgressA = 1;
        }
        if (StatusSiteB >= 2)
        {
            KifudaProgressB = 1;
        }
        if (StatusSiteC >= 2)
        {
            KifudaProgressC = 1;
        }
        if (StatusSiteD >= 2)
        {
            KifudaProgressD = 1;
        }
        if (StatusSiteE >= 2)
        {
            KifudaProgressE = 1;
        }
        if (StatusSiteF >= 2)
        {
            KifudaProgressF = 1;
        }
        if (StatusSiteG >= 2)
        {
            KifudaProgressG = 1;
        }
        if (StatusSiteH >= 2)
        {
            KifudaProgressH = 1;
        }
        KifudaProgressTotal = KifudaProgressA + KifudaProgressB + KifudaProgressC + KifudaProgressD + KifudaProgressE + KifudaProgressF + KifudaProgressG + KifudaProgressH;
        // KifudaProgressTotal の範囲は 0 ～ 16 ：鬼チームは1pt、 桃チームは3pt 
        Debug.Log("KifudaProgressTotal(木札ONの進捗状況) " + KifudaProgressTotal);
    }

    public void CheckKurunProgressTotal()  // 役割カードがオープンになったキャラが どれだけいるか の進捗状況 確認
    {
        if (StatusSiteA >= 4)
        {
            KurunProgressA = 1;
        }
        if (StatusSiteB >= 4)
        {
            KurunProgressB = 1;
        }
        if (StatusSiteC >= 4)
        {
            KurunProgressC = 1;
        }
        if (StatusSiteD >= 4)
        {
            KurunProgressD = 1;
        }
        if (StatusSiteE >= 4)
        {
            KurunProgressE = 1;
        }
        if (StatusSiteF >= 4)
        {
            KurunProgressF = 1;
        }
        if (StatusSiteG >= 4)
        {
            KurunProgressG = 1;
        }
        if (StatusSiteH >= 4)
        {
            KurunProgressH = 1;
        }
        KurunProgressTotal = KurunProgressA + KurunProgressB + KurunProgressC + KurunProgressD + KurunProgressE + KurunProgressF + KurunProgressG + KurunProgressH;
        Debug.Log("KurunProgressTotal(役割カードがオープンの進捗状況) " + KurunProgressTotal);
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
            WinOniTeam();
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
            WinMomoTeam();
        }

        else  // 役わりカードが こおに → 何もおきない（勝ち負けに影響しない）
        {
        }
    }

    public void WinMomoTeam() // ももチーム勝利判定時の処理
    {
        StartWinPhase();
        TeamHanteiAll();
        CheckWinTeam(3); // チームナンバー： 3（桃チーム）
        ApperWinMomo();
    }

    public void WinOniTeam() // 鬼チーム勝利判定時の処理
    {
        if (WinFlgON == 0)  // 勝利時演出のダブり防止策用（0ならば、まだ勝利演出これから開始）
        {
            if (NowOyabunStatus < 5)  // おやぶんが気絶していなければ
            {
                WinFlgON = 1;  // 1で勝利フラグが立った （勝利時演出のダブり防止策）
                StartWinPhase();
                TeamHanteiAll();
                CheckWinTeam(1); // チームナンバー： 1（おにチーム）
                ApperWinOni();
            }
        }
    }

    public void StartWinPhase()  // 勝ち負けが決まったら、まず初めに動き出すフェーズ
    {
        var sequence = DOTween.Sequence();
        CloseWinMomo();  // 勝ちマーク クローズ（初期化）
        CloseWinOni();   // 勝ちマーク クローズ（初期化）
        SlideLeftPanelMAKU();  // 幕を左へクローズ
        SEMSC.hyoushigi2_long_SE();
        sequence.InsertCallback(5.8f, () => ApperPanelWinner());  // 数秒後、win画面表示
        CloseCheckBoxes();
        AppearP_WINimage();
    }

    public void AppearP_WINimage()
    {
        int rndP = UnityEngine.Random.Range(1, 3);
        switch (rndP)
        {
            case 1: //
                ImageP_WinMessage.sprite = ImageP_happy;
                break;
            case 2: //
                ImageP_WinMessage.sprite = ImageP_smile;
                break;
            default:
                // その他処理
                break;
        }
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

    public void AppearCheckBoxes()
    {
        CheckBoxes.SetActive(true);
    }

    public void CloseCheckBoxes()
    {
        CheckBoxes.SetActive(false);
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


    public void OpenHaguruma_Box()
    {
        Haguruma_Box.SetActive(true);
    }

    public void CloseHaguruma_Box()
    {
        Haguruma_Box.SetActive(false);
    }


    public void FirstCheckGuideLevel()  // GameScene が読み込まれた時点での状態確認
    {
        if (GuideLevel == 1)  // 現在 「GuideLevel == 1」だったなら、
        {
            AppearGuideCheckMark2();
        }
        else
        {
            CloseGuideCheckMark2();
        }
    }


    public void SwitchGuideLevel()  // チェックボックスを押すたびにオンオフ切り替え
    {
        if (GuideLevel == 1)  // 現在 「GuideLevel == 1」だったなら、
        {
            GuideLevel0();  // 「GuideLevel == 0」の状態に切り替える
        }
        else
        {
            GuideLevel1();
        }
    }


    public void GuideLevel0()  // チェック無し（＝0 でガイド文 OFF）
    {
        GuideLevel = 0;
        CloseGuideCheckMark2();  // チェックマークを非表示にする
        SEMSC.checkOFF_SE();    // SE（キャンセル音）
    }


    public void GuideLevel1()  // チェック入り（＝1 でガイド文ON）
    {
        GuideLevel = 1;
        AppearGuideCheckMark2(); // チェックマークを表示する
        SEMSC.checkON_SE();     // SE（決定音、押下音）
    }



    public void AppearGuideCheckMark2()  // チェック入り（＝1 でガイド文ON）
    {
        GuideCheckMark2.SetActive(true);
    }

    public void CloseGuideCheckMark2()
    {
        GuideCheckMark2.SetActive(false);
    }



    public void OpenHomeButton_Box()
    {
        HomeButton_Box.SetActive(true);
    }

    public void CloseHomeButton_Box()
    {
        HomeButton_Box.SetActive(false);
    }


    public void GoToHome()
    {
        MainFlowScr.LoadStartScene();  // スタートシーンに遷移する
    }

    public void ResetCanPushAcButtons()
    {
        CanPush_Question = true;
        CanPush_Unmask = true;
        CanPush_Attack = false;
    }

    public void ResetUkkariFlg()  // うっかりフラグをOFF（リセット）
    {
        UkkariSite[1] = 0;
        UkkariSite[2] = 0;
        UkkariSite[3] = 0;
        UkkariSite[4] = 0;
        UkkariSite[5] = 0;
        UkkariSite[6] = 0;
        UkkariSite[7] = 0;
        UkkariSite[8] = 0;
    }

    public void ResetStatusAllSites()  // すべてのサイトのステータスをリセットする（初期化）
    {
        StatusSiteA = 1;
        StatusSiteB = 1;
        StatusSiteC = 1;
        StatusSiteD = 1;
        StatusSiteE = 1;
        StatusSiteF = 1;
        StatusSiteG = 1;
        StatusSiteH = 1;
    }

    #region(ResetMaybe_rolls)  // 役割 可能性値の初期化 ⇒ 各25％
    public void ResetMaybe_Allrolls()
    {
        ResetMaybe_Momotaro();
        ResetMaybe_MomoMate();
        ResetMaybe_Kooni();
        ResetMaybe_Oyabun();
    }

    public void ResetMaybe_Momotaro()  // Momotaro可能性値の初期化
    {
        for (int i = 1; i < 9; i++)
        {
            Maybe_Momotaro[i] = 25;
            Debug.Log("Maybe_Momotaro[i] : " + Maybe_Momotaro[i]);
            Debug.Log("i :" + i);
        }
    }

    public void ResetMaybe_MomoMate()  // MomoMate可能性値の初期化
    {
        for (int i = 1; i < 9; i++)
        {
            Maybe_MomoMate[i] = 25;
            Debug.Log("Maybe_MomoMate[i] : " + Maybe_MomoMate[i]);
            Debug.Log("i :" + i);
        }
    }

    public void ResetMaybe_Kooni()  // Kooni可能性値の初期化
    {
        for (int i = 1; i < 9; i++)
        {
            Maybe_Kooni[i] = 25;
            Debug.Log("Maybe_Kooni[i] : " + Maybe_Kooni[i]);
            Debug.Log("i :" + i);
        }
    }

    public void ResetMaybe_Oyabun()  // Oyabun可能性値の初期化
    {
        for (int i = 1; i < 9; i++)
        {
            Maybe_Oyabun[i] = 25;
            Debug.Log("Maybe_Oyabun[i] : " + Maybe_Oyabun[i]);
            Debug.Log("i :" + i);
        }
    }
    #endregion

    #region(ZeroMaybe_rolls)  // 役割 可能性ゼロ 0％ 判明
    public void ZeroMaybe_Momotaro()  // Momotaro可能性値がゼロ％（とりあえず全てゼロにする）
    {
        for (int i = 1; i < 9; i++)
        {
            Maybe_Momotaro[i] = 0;
            Debug.Log("Maybe_Momotaro[i] : " + Maybe_Momotaro[i]);
            Debug.Log("i :" + i);
        }
    }

    public void ZeroMaybe_MomoMate()  // MomoMate可能性値がゼロ％（とりあえず全てゼロにする）
    {
        for (int i = 1; i < 9; i++)
        {
            Maybe_MomoMate[i] = 0;
            Debug.Log("Maybe_MomoMate[i] : " + Maybe_MomoMate[i]);
            Debug.Log("i :" + i);
        }
    }

    public void ZeroMaybe_Kooni()  // Kooni可能性値がゼロ％（とりあえず全てゼロにする）
    {
        for (int i = 1; i < 9; i++)
        {
            Maybe_Kooni[i] = 0;
            Debug.Log("Maybe_Kooni[i] : " + Maybe_Kooni[i]);
            Debug.Log("i :" + i);
        }
    }

    public void ZeroMaybe_Oyabun()  // Oyabun可能性値がゼロ％（とりあえず全てゼロにする）
    {
        for (int i = 1; i < 9; i++)
        {
            Maybe_Oyabun[i] = 0;
            Debug.Log("Maybe_Oyabun[i] : " + Maybe_Oyabun[i]);
            Debug.Log("i :" + i);
        }
    }
    #endregion

    
    #region(CPU_OperationSection)  // CPU操作のフェーズ

    public void FirstCheckCPU_Operation()  // 各サイトがCPUであるかどうかのチェック（初回のみ一回確認）
    {
        CPUFlgAllSiteON();   // 一旦、すべてのサイトのCPUフラグをON
        SiteAisCPU = false;  // SiteA は必ず「人」
        if (human_num >= 2)
        {
            SiteBisCPU = false;  // SiteB は「人」である
        }
        if (human_num >= 3)
        {
            SiteCisCPU = false;  // SiteC は「人」である
        }
        if (human_num >= 4)
        {
            SiteDisCPU = false;  // SiteD は「人」である
        }
        if (human_num >= 5)
        {
            SiteEisCPU = false;  // SiteE は「人」である
        }
        if (human_num >= 6)
        {
            SiteFisCPU = false;  // SiteF は「人」である
        }
        if (human_num >= 7)
        {
            SiteGisCPU = false;  // SiteG は「人」である
        }
        if (human_num >= 8)
        {
            SiteHisCPU = false;  // SiteH は「人」である
        }
    }


    public void CPUFlgAllSiteON()  // 一旦、すべてのサイトのCPUフラグをON（true）にする
    {
 //       SiteAisCPU = true;  // CPUであるかどうかのフラグ（trueでCPU）
        SiteBisCPU = true;
        SiteCisCPU = true;
        SiteDisCPU = true;
        SiteEisCPU = true;
        SiteFisCPU = true;
        SiteGisCPU = true;
        SiteHisCPU = true;
    }


    public void CheckNowActiveSite_isCPU()  // 今アクティブなサイトがCPUか確認（順番毎に）
    {
        Debug.Log("★今アクティブなサイトがCPUか確認時の NowActiveSiteN：" + NowActiveSiteN);
        if (NowActiveSiteN == 1)
        {
            NowActiveSite_isCPU = false;  // 今アクティブなサイトは CPU ではない（＝「人」である）【SiteAの場合、必然】
        }
        else if (NowActiveSiteN == 2)
        {
            NowActiveSite_isCPU = SiteBisCPU;  // 今アクティブなサイトが CPU であるかは、SiteBの CPUフラグを見よ
        }
        else if (NowActiveSiteN == 3)
        {
            NowActiveSite_isCPU = SiteCisCPU;  // 今アクティブなサイトが CPU であるかは、SiteCの CPUフラグを見よ
        }
        else if (NowActiveSiteN == 4)
        {
            NowActiveSite_isCPU = SiteDisCPU;  // 今アクティブなサイトが CPU であるかは、SiteDの CPUフラグを見よ
        }
        else if (NowActiveSiteN == 5)
        {
            NowActiveSite_isCPU = SiteEisCPU;  // 今アクティブなサイトが CPU であるかは、SiteEの CPUフラグを見よ
        }
        else if (NowActiveSiteN == 6)
        {
            NowActiveSite_isCPU = SiteFisCPU;  // 今アクティブなサイトが CPU であるかは、SiteFの CPUフラグを見よ
        }
        else if (NowActiveSiteN == 7)
        {
            NowActiveSite_isCPU = SiteGisCPU;  // 今アクティブなサイトが CPU であるかは、SiteGの CPUフラグを見よ
        }
        else if (NowActiveSiteN == 8)
        {
            NowActiveSite_isCPU = SiteHisCPU;  // 今アクティブなサイトが CPU であるかは、SiteHの CPUフラグを見よ
        }

        if (NowActiveSite_isCPU)
        {
            AppearNext_InfoCPUWillOperate();  //  CPUがこれから操作する旨を画面中央にメッセージ表示（予告）
        }
        else
        {
            CloseNext_InfoCPUWillOperate();
        }
    }


    public void CheckWakeUpCPU()  // 今アクティブなサイトがCPUなら、CPU操作開始
    {
        Debug.Log("◎今アクティブなサイトがCPU時の NowActiveSiteN：" + NowActiveSiteN);
        if (NowActiveSite_isCPU)
        {
                Debug.Log("このターンで何人目か？" + preventPlayerOrderNum);
                Debug.Log("CPU操作開始");
                var sequence = DOTween.Sequence();
                StartCPU_Operation();   // CPU操作開始
                sequence.InsertCallback(3f, () => FinishCPU_Operation());  // CPU操作終了
        }
    }

    public void StartCPU_Operation()  // CPU操作開始
    {
        var sequence = DOTween.Sequence();
        AppearInfoCPU();         // 「CPU そうさ中」のメッセージを画面下に表示（ON）
        CheckMyRole();           // 自身の役割確認:  rollF[NowActiveSiteN] 
                                 // 他人がどちらのチームか？どの役割か？予想するフェーズ。

        sequence.InsertCallback(2f, () => PushActButton_byCPU());   // 行動ボタン、いずれか押下(●可能性値に基づき行動を選択する)
                                                                    // 行動ボタンBoxひらいて、Box内の操作
                                                                    // 行動ボタンBox 閉じる
                                                                    // （CPU操作 ここまで）
                                                                    // （適宜、SEも）
    }

    public void FinishCPU_Operation()  // CPU操作終了
    {
        CloseInfoCPU();  // 「CPU そうさ中」のメッセージを非表示（OFF）
                         //  ターン終わり（何か処理あれば）
        NowActiveSite_isCPU = true;
    }

    public void AppearInfoCPU()  // 「CPU そうさ中」のメッセージを画面下に表示（ON）
    {
        PanelInfoCPU.SetActive(true);
    }

    public void CloseInfoCPU()
    {
        PanelInfoCPU.SetActive(false);
    }


    public void CheckMyRole() //自分の役割チェック
    {
        if (rollF[NowActiveSiteN] == 1) // ももたろう
        {
            ActiveSiteRoll = 1;
        }
        else if (rollF[NowActiveSiteN] >= 2 && rollF[NowActiveSiteN] <= 4) // いぬ、さる、きじ
        {
            ActiveSiteRoll = 2;
        }
        else if (rollF[NowActiveSiteN] == 5) // おにのおやぶん
        {
            ActiveSiteRoll = 5;
        }
        else if (rollF[NowActiveSiteN] >= 6 && rollF[NowActiveSiteN] <= 8) // こオニたち
        {
            ActiveSiteRoll = 6;
        }
        Debug.Log("NowActiveSiteN "+ NowActiveSiteN);
        Debug.Log("自分の役割チェック " + rollF[NowActiveSiteN]);
    }


    public void PushActButton_byCPU()
    {
        var sequence = DOTween.Sequence();
        // アクティブサイトが 桃チーム
        if (ActiveSiteRoll == 1 || ActiveSiteRoll == 2)  
        {
            RollFNum = 0;  // 現在エイムされているサイトの役わり：初期化
            PushedBtnFlg = 0;  // 処理を実施したかどうか
            Debug.Log("アクティブサイトが 桃チーム");
            if (NowOyabunStatus == 4)  // もし おやぶんが 役割オープン（ステータス：4）なら → 攻撃
            {
                Debug.Log("おやぶんが 役割オープン（ステータス：4）なら → 攻撃");
                AttackToHogeCommon(5);  // おやぶん に攻撃(CPU)
            }
            else if (NowOyabunStatus == 2)  // もし おやぶんが 木札ON（ステータス：2）なら → 役割当て
            {
                Debug.Log("おやぶんが 木札ON（ステータス：2）なら → 役割当て");
                PushYakuwariBtn_Common(5);  // M-2：この場合は「役割あて」ボタン・・・その役割だと確定し、迷いなく処理する
            }
            else if (NowOyabunStatus == 1)  // もし おやぶんが 木札無し（ステータス：1）なら → 役割当て or しつもん
            {
                PushedBtnFlg = 0;  // 処理を実施したかどうか：初期化
                CheckKifudaProgressTotal();  // 木札ONの進捗状況
                Debug.Log("KifudaProgressTotal(木札ONの進捗状況) " + KifudaProgressTotal);
                Debug.Log("おやぶんが 木札無し（ステータス：1）なら → 役割当て or しつもん");
                if (KifudaProgressTotal == 7)  // 他のキャラが全部札付きで「おに」だけ残っている ◆場の全体を見て おやぶん だと判明した場合
                {
                    Debug.Log("他のキャラが全部札付きで「おに」だけ残っている");
                    PushYakuwariBtn_Common(5);  // M-2：この場合は「役割あて」ボタン・・・その役割だと確定し、迷いなく処理する
                    PushedBtnFlg = 1;  // 処理を実施したかどうか
                }
                else if (KifudaProgressTotal == 6)  // 自分が桃チームで、残りの木札がおやぶんと もうプラス1 ◆場の全体を見て おやぶん 判明した場合
                {
                    if (NowActiveSiteStatus == 1)  // 今のアクティブサイト（自分:桃チーム所属） が 木札無し（ステータス1）
                    {
                        Debug.Log("自分が桃チームで、残りの木札がおやぶんと自分のみ 残っている");
                        PushYakuwariBtn_Common(5);  // M-2：この場合は「役割あて」ボタン・・・その役割だと確定し、迷いなく処理する
                        PushedBtnFlg = 1;  // 処理を実施したかどうか
                    }
                }
                if (PushedBtnFlg == 0) // 処理を実施したかどうか
                {
                    // ◆それでも おやぶんが どこのサイトか 不明な時 → ランダム で しつもん
                    ButtonCscr.BranchOpenQuestion();  // M-1：この場合は「しつもん」ボタン  // 行動ボタン押せるかのチェック ＆ BrownBoxを開く
                    CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                    sequence.InsertCallback(2f, () => WhatIsYourFavorite_Question());  // 【しつもんモード】エイムセレクト画面で ランダム で選択する （条件：選択したのが自分自身ではない）（3ターン目で、行動済みのキャラに対してエイムしない）
                    sequence.InsertCallback(4f, () => WhatIsYourFavorite2_Question());  // OKボタン 押下で 木札をON
                    sequence.InsertCallback(8f, () => WhatIsYourFavorite3_Question());  // OKボタン 押下で ウインドウ 閉じる
                }
            }
        }

        // アクティブサイトが おにのおやぶん
        else if (ActiveSiteRoll == 5)  
        {
            RollFNum = 0;  // 現在エイムされているサイトの役わり：初期化
            PushedBtnFlg = 0;  // 処理を実施したかどうか
            Debug.Log("アクティブサイトが おにのおやぶん");

            // 桃太郎が 残りHP1(ももっち) なら → 攻撃
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                CheckAttackToMomocchi();  // 桃太郎が 残りHP1(ももっち) であるか確認後、あてはまれば攻撃 or 条件を満たさなければスルー （3ターン目で、行動済みのキャラに対してはエイムしない）
                if (PushedBtnFlg == 1)
                {
                    Debug.Log("桃太郎が 残りHP1(ももっち) なら → 攻撃");
                }
            }

            // 桃メイトが 役割オープンなら → 攻撃
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                SearchMomoMateCommon(4);  // ステータスが4（役割カードオープン） ＆ 役割が いぬ・さる・きじ のキャラがいるか探す （3ターン目で、行動済みのキャラに対してエイムしない）
                if (PushedBtnFlg == 1)  // オープンしている いぬ、さる、きじ が見つかったら
                {
                    AttackToMomoMate();  // ももたろうの仲間 に攻撃(CPU)
                    Debug.Log("桃メイトが 役割オープンなら → 攻撃");
                }
            }

            // 桃太郎が   役割オープン（HP2：ももじ）なら → 攻撃
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                CheckAttackToMomoji();  // 桃太郎が 役割オープン（HP2：ももじ）なら 攻撃  or 条件を満たさなければスルー （3ターン目で、行動済みのキャラに対してはエイムしない）
                if (PushedBtnFlg == 1)
                {
                    Debug.Log("桃太郎が   役割オープン（HP2：ももじ）なら → 攻撃");
                }
            }

            // うっかり桃メイト（木札ON） がいるなら → 役割当て
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                UkkariAte(); // うっかりフラグが1 & ステータス2 のものがあれば、それを当てる（役割当て）
                if (PushedBtnFlg == 1)
                {
                    Debug.Log("うっかりフラグが1 & ステータス2 のものがあれば、それを当てる（役割当て）");
                }
            }

            // 桃太郎が   木札ON(ももじ)なら → 役割当て
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                KifudaOnMomojiAte();  // 桃太郎が 木札ON（ステータス2）なら 役割当て or 条件を満たさなければスルー
                if (PushedBtnFlg == 1)
                {
                    Debug.Log("ももたろうが 木札ONなら → 役割当て");
                }
            }

            // ステータスが2以下である 桃メイト がいれば  → 条件を満たせば 役割当て (その役割だと確定し、迷いなく処理する)
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                // *桃メイト を役割当て
                CheckKurunProgressTotal();  // 役割カードがオープンになったキャラが どれだけいるか の進捗状況 確認
                SearchMomoMateCommon(1);  // ステータスが1（札無し） ＆ 役割が いぬ・さる・きじ のキャラがいるか探す （3ターン目で、行動済みのキャラに対してエイムしない）
                SearchMomoMateCommon(2);  // ステータスが2（木札ON） ＆ 役割が いぬ・さる・きじ のキャラがいるか探す。 「RollFNum：現在エイムされているサイトの役わり」が上書きされる
                if (PushedBtnFlg == 1)    // ステータスが2以下の いぬ、さる、きじ が見つかったら
                {
                    PushedBtnFlg = 0;  // 処理を実施したかどうか ：一旦フラグを初期化（リセット）
                    if (KurunProgressTotal == 7) // 他のキャラが全部オープン済みで 一つだけステータスが2以下 で残っている ◆場の全体を見て その役割 だと判明した場合
                    {
                        Debug.Log("他のキャラが全部カードオープンで 、その役割カード（いぬ・さる・きじ のいずれか1枚）だけ ステータスが2以下で残っている");
                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                    }
                    else if (KurunProgressTotal == 6) // 自分がおやぶんで、ステータスが2以下が 2人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
                    {
                        if (NowOyabunStatus <= 2)  // おやぶん（自分）がステータスが2以下
                        {
                            Debug.Log("自分がおやぶんで、ステータスが2以下 なのが自分と 桃メイト（他のキャラは全部オープン済み）");
                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                        }
                        else  // おやぶん（自分）がステータスが3以上（オープン後）
                        {
                            Sum_InokoriMate();   // 居残りメイトの合計を求める
                            Sum_InokoriKooni();   // 居残りこおにの合計を求める
                            if (InokoriMate == 2)   // 残りのサイト（ステータスが2以下）が、両方とも桃メイト
                            {
                                Debug.Log("残りのサイト（ステータスが2以下）が、両方とも桃メイト（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                            else if (InokoriMate == 1)
                            {
                                if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは ももたろう）
                                {
                                    CheckKifudaProgressTotal();  // 木札ONの進捗状況
                                    if (KifudaProgressTotal >= 7)  // ももたろう か 桃メイト の少なくとも一方に 木札ON
                                    {
                                        Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と 桃メイト（他のキャラは全部オープン済み）");
                                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                    }
                                }
                            }
                        }
                    }
                    else if (KurunProgressTotal == 5) // 自分がおやぶんで、ステータスが2以下が 3人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
                    {
                        Sum_InokoriMate();   // 居残りメイトの合計を求める
                        Sum_InokoriKooni();   // 居残りこおにの合計を求める
                        if (NowOyabunStatus <= 2)  // おやぶん（自分）がステータスが2以下
                        {
                            if (InokoriMate == 2)   // 残りのサイト（ステータスが2以下）が、自分（おやぶん）と 桃メイト×2
                            {
                                Debug.Log("自分がおやぶんで、ステータスが2以下 なのが自分（おやぶん）と 桃メイト×2（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                            else if (InokoriMate == 1)
                            {
                                if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは ももたろう）
                                {
                                    CheckKifudaProgressTotal();  // 木札ONの進捗状況
                                    if (NowOyabunStatus == 1)  // おやぶん（自分）がステータスが1
                                    {
                                        if (KifudaProgressTotal >= 6)  // 居残り組3人中、 木札ON 1枚以上（おやぶん札無し）
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、自分（おやぶん） と ももたろう と 桃メイト （他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                    else if (NowOyabunStatus == 2)  // おやぶん（自分）がステータスが2(木札ON)
                                    {
                                        if (KifudaProgressTotal >= 7)  // 居残り組3人中、 木札ON 2枚以上（おやぶん札あり）
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、自分（おやぶん） と ももたろう と 桃メイト （他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                }
                            }
                        }
                        else  // おやぶん（自分）がステータスが3以上（オープン後）
                        {
                            if (InokoriMate == 3)   // 残りのサイト（ステータスが2以下）が、3人とも桃メイト
                            {
                                Debug.Log("残りのサイト（ステータスが2以下）が、3人とも桃メイト（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                            else if (InokoriMate == 2)
                            {
                                if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは ももたろう）
                                {
                                    CheckKifudaProgressTotal();  // 木札ONの進捗状況
                                    if (NowMomotaroStatus == 2)  // ももたろう がステータス2(木札ON)
                                    {
                                        if (KifudaProgressTotal >= 6)  // 居残り組3人中、 ももたろう に木札ON で確定
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と 桃メイト×2（他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                    else if (NowMomotaroStatus == 1)  // ももたろう がステータス1(木札無し)
                                    {
                                        if (KifudaProgressTotal >= 7)  // 居残り組3人中、 木札ON 2枚以上 で確定
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と 桃メイト×2（他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (KurunProgressTotal == 4) // 自分がおやぶんで、ステータスが2以下が 4人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
                    {
                        Sum_InokoriMate();   // 居残りメイトの合計を求める
                        Sum_InokoriKooni();   // 居残りこおにの合計を求める
                        if (NowOyabunStatus <= 2)  // おやぶん（自分）がステータスが2以下
                        {
                            if (InokoriMate == 3)   // 残りのサイト（ステータスが2以下）が、自分（おやぶん）と 桃メイト×3
                            {
                                Debug.Log("自分がおやぶんで、ステータスが2以下 なのが自分（おやぶん）と 桃メイト×3（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                            else if (InokoriMate == 2)
                            {
                                if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは ももたろう）
                                {
                                    CheckKifudaProgressTotal();  // 木札ONの進捗状況
                                    if (NowOyabunStatus == 1)  // おやぶん（自分）がステータスが1
                                    {
                                        if (KifudaProgressTotal >= 5)  // 居残り組4人中、 木札ON 1枚以上 (おやぶんは札無し)
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、自分（おやぶん）と ももたろう と 桃メイト×2（他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                    else if (NowOyabunStatus == 2)  // おやぶん（自分）がステータスが2(木札ON)
                                    {
                                        if (KifudaProgressTotal >= 6)  // 居残り組4人中、 木札ON 2枚以上  (おやぶんは札あり)
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、自分（おやぶん）と ももたろう と 桃メイト×2（他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                }
                            }
                        }
                        else  // おやぶん（自分）がステータスが3以上（オープン後）
                        {
                            if (InokoriMate == 3)   // 残りのサイト（ステータスが2以下）が、ももたろう と 桃メイト×3
                            {
                                CheckKifudaProgressTotal();  // 木札ONの進捗状況
                                if (KifudaProgressTotal >= 5)  // 居残り組4人中、 木札ON 1枚以上
                                {
                                    Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と 桃メイト×3（他のキャラは全部オープン済み）");
                                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                }
                            }
                        }
                    }
                    else if (KurunProgressTotal == 3) // 自分がおやぶんで、ステータスが2以下が 4人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
                    {
                        Sum_InokoriMate();   // 居残りメイトの合計を求める
                        Sum_InokoriKooni();   // 居残りこおにの合計を求める
                        if (NowOyabunStatus <= 2)  // おやぶん（自分）がステータスが2以下
                        {
                            if (InokoriMate == 3)   // 残りのサイト（ステータスが2以下）が、自分（おやぶん）と 桃メイト×3 と ももたろう
                            {
                                if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは ももたろう）
                                {
                                    CheckKifudaProgressTotal();  // 木札ONの進捗状況
                                    if (NowOyabunStatus == 1)  // おやぶん（自分）がステータスが1
                                    {
                                        if (KifudaProgressTotal >= 4)  // 居残り組5人中、 木札ON 1枚以上 (おやぶんは札無し)
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、自分（おやぶん）と ももたろう と 桃メイト×3（他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                    else if (NowOyabunStatus == 2)  // おやぶん（自分）がステータスが2(木札ON)
                                    {
                                        if (KifudaProgressTotal >= 5)  // 居残り組5人中、 木札ON 2枚以上  (おやぶんは札あり)
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、自分（おやぶん）と ももたろう と 桃メイト×3（他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // 桃太郎が 木札無しなら → 条件を満たせば 役割当て
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                // * 桃太郎 を 役割当て
                CheckKifudaProgressTotal();  // 木札ONの進捗状況 確認
                SearchMomotaroCommon(1);  // ももたろう の ステータスが1（札無し）であるか確認 → 条件に合えば、RollFNum を そのサイトの番号に上書き （3ターン目で、行動済みのキャラに対してはエイムしない）
                CheckNowMomotaroStatus();  // ももたろうのステータス確認
                if (NowMomotaroStatus == 1)  // ももたろう の ステータスが1（札無し）だったら
                {
                    if (KifudaProgressTotal == 7) // 他のキャラが全部 木札ONで 一つだけデフォルト（札無し）で残っている ◆場の全体を見て その役割 だと判明した場合
                    {
                        Debug.Log("他のキャラが全部 木札ONで 、その役割カード（ももたろう）だけ 札無しで残っている");
                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン
                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                    }
                    else if (KifudaProgressTotal == 6) // 自分がおやぶんで、木札無しが 2人いる（他のキャラは全部木札ON済み） ◆場の全体を見て その役割 だと判明した場合
                    {
                        if (NowOyabunStatus == 1)  // おやぶん（自分）が 木札無し
                        {
                            Debug.Log("自分がおやぶんで、札無し が自分(おやぶん)と ももたろうう である（他のキャラは全部 木札ON）");
                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン
                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                        }
                    }
                }
            }

            // *メイビーパラメータを元に、桃メイト と思われるキャラを1人選ぶ(役割当て) ※ 木札の有無は問わない （前提：ステータス4の桃メイトが一人もいない）& 初期値ならば このフェーズはスルー
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                MaybeMomoMate_Ate();  // 桃メイトのうち、少なくとも1人オープン前（ステータス2以下）のキャラが存在するならば
                if (PushedBtnFlg == 1)  // 条件に合う 桃メイト と思われるキャラ が見つかったら
                {
                    Debug.Log("*メイビーパラメータを元に、桃メイト と思われるキャラを1人選ぶ(役割当て)");
                }
            }

            // *桃チームに 対して しつもん (少なくとも一人は札無しがいる) 
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                CheckKifudaProgressTotal();  // 木札ONの進捗状況 確認
                if (KifudaProgressTotal < 8) // 木札ONの進捗状況が 8未満（＝少なくとも一人は札無しがいる）
                {
                    CheckCanPushQuestion();  // 行動ボタン（質問）押せるかのチェック
                    if (CanPush_Question)  // 行動ボタン（質問）押せる
                    {
                        Debug.Log("◆*桃チームに 対して しつもん (自分以外で一人は札無しがいる) ");
                        ButtonCscr.BranchOpenQuestion();  // M-1：この場合は「しつもん」ボタン  // 行動ボタン押せるかのチェック ＆ BrownBoxを開く
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence.InsertCallback(2f, () => WhatIsYourFavorite_Question());  // 【しつもんモード】エイムセレクト画面で ランダム で選択する（条件：選択したのが自分自身ではない） （3ターン目で、行動済みのキャラに対してエイムしない）
                        if (AimedFlg == 1)  // エイム条件を満たしているならば （3ターン目で、行動済みのキャラに対してエイムしない）
                        {
                            sequence.InsertCallback(4f, () => WhatIsYourFavorite2_Question());  // OKボタン 押下で 木札をON
                            sequence.InsertCallback(8f, () => WhatIsYourFavorite3_Question());  // OKボタン 押下で ウインドウ 閉じる
                            PushedBtnFlg = 1;  // 処理を実施したかどうか
                        }
                    }
                }
            }

            // *特に参考になる情報がなければ、おやぶん・ももたろう以外で 木札ONのキャラから ランダムで一人選ぶ(役割当て) （前提：木札無しがいない＝全員ステータス2以上）
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                SearchMomoOniCommon(2);  // ステータスが2（木札ON）＆ 役割が いぬ・さる・きじ・こおにたち  のキャラがいるか探す 「RollFNum：現在エイムされているサイトの役わり」が上書きされる
                if (PushedBtnFlg == 1)  // ステータスが2（木札ON）の いぬ、さる、きじ、こおにたち が 少なくとも一人以上いれば
                {
                    Debug.Log("おやぶん・ももたろう以外で木札ONのキャラから ランダムで一人選ぶ(役割当て)");
                    // RollFNum に いぬ、さる、きじ、こおにたち のいずれかが入っている
                    var sequence2 = DOTween.Sequence();
                    ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン
                    CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                    sequence2.InsertCallback(2f, () => YouAreHoge(RollFNum));     // 木札ONの キャラ を探して エイムでセレクト
                    sequence2.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 「桃メイト」 のアイコンを クリック（自分がおやぶんなので、こおにを選ぶことはしない）
                    sequence2.InsertCallback(8f, () => YouAreHoge3_Unmask());  // 役割当て画面クローズ
                }
            }

            // 3ターン目：行動条件すべて該当なし → もうこれ以降、ももチームの手番は無いので、ただいまをもって おにチームの勝ち
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                WinOniTeam();   // 鬼チームの勝利である
            }
        }

        // アクティブサイトが こおに （こおにの役割・・・おやぶんが攻撃できるように、役割を当てる）
        else if (ActiveSiteRoll == 6)  
        {
            RollFNum = 0;  // 現在エイムされているサイトの役わり：初期化
            PushedBtnFlg = 0;  // 処理を実施したかどうか
            Debug.Log("アクティブサイトが こおに");

            if (preventTurnNum <= 2) // こおに 1,2ターン目
            {
                // うっかり桃メイト（木札ON） がいるなら → 役割当て
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    UkkariAte();  // うっかりフラグが1 & ステータス2 のものがあれば、それを当てる（役割当て）
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("うっかりフラグが1 & ステータス2 のものがあれば、それを当てる（役割当て）");
                    }
                }

                // 桃太郎が   木札ON(ももじ)なら → 役割当て
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    KifudaOnMomojiAte();  // 桃太郎が 木札ON（ステータス2）なら 役割当て or 条件を満たさなければスルー
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("ももたろうが 木札ONなら → 役割当て");
                    }
                }

                // ステータスが2以下である 桃メイト がいれば  → 条件を満たせば 役割当て (旧名：桃メイトが 木札無しなら → 役割当て) (その役割だと確定し、迷いなく処理する)
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    MomoMateYakuwariAte_WithConviction(); // *桃メイト を役割当て
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("ステータスが2以下である 桃メイト → 条件を満たせば 役割当て :その役割だと確定し、迷いなく処理する");
                    }
                }

                // 桃太郎が 木札無しなら → 条件を満たせば 役割当て (その役割だと確定し、迷いなく処理する)
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    MomotaroYakuwariAte_WithConviction(); // * 桃太郎 を 役割当て
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("桃太郎が 木札無し → 条件を満たせば 役割当て :その役割だと確定し、迷いなく処理する");
                    }
                }

                // *メイビーパラメータを元に、桃メイト と思われるキャラを1人選ぶ(役割当て) ※ 木札の有無は問わない
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    MaybeMomoMate_Ate();  // 桃メイトのうち、少なくとも1人オープン前（ステータス2以下）のキャラが存在するならば
                    if (PushedBtnFlg == 1)  // 条件に合う 桃メイト と思われるキャラ が見つかったら
                    {
                        Debug.Log("*メイビーパラメータを元に、桃メイト と思われるキャラを1人選ぶ(役割当て)");
                    }
                }

                // 桃太郎が 残りHP1(ももっち) なら → 攻撃
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    CheckAttackToMomocchi();  // 桃太郎が 残りHP1(ももっち) であるか確認後、あてはまれば攻撃 or 条件を満たさなければスルー （3ターン目で、行動済みのキャラに対してはエイムしない）
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("桃太郎が 残りHP1(ももっち) なら → 攻撃");
                    }
                }

                // 桃メイトが 役割オープンなら → 攻撃
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    SearchMomoMateCommon(4);  // ステータスが4（役割カードオープン） ＆ 役割が いぬ・さる・きじ のキャラがいるか探す （3ターン目で、行動済みのキャラに対してエイムしない）
                    if (PushedBtnFlg == 1)  // オープンしている いぬ、さる、きじ が見つかったら
                    {
                        AttackToMomoMate();  // ももたろうの仲間 に攻撃(CPU)
                        Debug.Log("桃メイトが 役割オープンなら → 攻撃");
                    }
                }

                // 桃太郎が   役割オープン（HP2：ももじ）なら → 攻撃
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    CheckAttackToMomoji();  // 桃太郎が 役割オープン（HP2：ももじ）なら 攻撃  or 条件を満たさなければスルー （3ターン目で、行動済みのキャラに対してはエイムしない）
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("桃太郎が   役割オープン（HP2：ももじ）なら → 攻撃");
                    }
                }

                // *桃チームに 対して しつもん (少なくとも一人は札無しがいる) 
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    CheckKifudaProgressTotal();  // 木札ONの進捗状況 確認
                    if (KifudaProgressTotal < 8) // 木札ONの進捗状況が 8未満（＝少なくとも一人は札無しがいる）
                    {
                        CheckCanPushQuestion();  // 行動ボタン（質問）押せるかのチェック
                        if (CanPush_Question)  // 行動ボタン（質問）押せる
                        {
                            ButtonCscr.BranchOpenQuestion();  // M-1：この場合は「しつもん」ボタン  // 行動ボタン押せるかのチェック ＆ BrownBoxを開く
                            CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                            sequence.InsertCallback(2f, () => WhatIsYourFavorite_Question());  // 【しつもんモード】エイムセレクト画面で ランダム で選択する（条件：選択したのが自分自身ではない） （3ターン目で、行動済みのキャラに対してエイムしない）
                            if (AimedFlg == 1)  // エイム条件を満たしているならば （3ターン目で、行動済みのキャラに対してエイムしない）
                            {
                                sequence.InsertCallback(4f, () => WhatIsYourFavorite2_Question());  // OKボタン 押下で 木札をON
                                sequence.InsertCallback(8f, () => WhatIsYourFavorite3_Question());  // OKボタン 押下で ウインドウ 閉じる
                                PushedBtnFlg = 1;  // 処理を実施したかどうか
                                Debug.Log("◆*桃チームに 対して しつもん (自分以外で一人は札無しがいる) ");
                            }
                        }
                    }
                }

                // *特に参考になる情報がなければ、おやぶん・ももたろう以外で 木札ONのキャラから ランダムで一人選ぶ(役割当て) （前提：木札無しがいない＝全員ステータス2以上）
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    SearchMomoOniCommon(2);  // ステータスが2（木札ON）＆ 役割が いぬ・さる・きじ・こおにたち  のキャラがいるか探す 「RollFNum：現在エイムされているサイトの役わり」が上書きされる
                    if (PushedBtnFlg == 1)  // ステータスが2（木札ON）の いぬ、さる、きじ、こおにたち が 少なくとも一人以上いれば
                    {
                        Debug.Log("おやぶん・ももたろう以外で木札ONのキャラから ランダムで一人選ぶ(役割当て)");
                        // RollFNum に いぬ、さる、きじ、こおにたち のいずれかが入っている
                        var sequence2 = DOTween.Sequence();
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence2.InsertCallback(2f, () => YouAreHoge(RollFNum));     // 木札ONの キャラ を探して エイムでセレクト
                        sequence2.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 「桃メイト」 のアイコンを クリック（自分がおやぶんなので、こおにを選ぶことはしない）
                        sequence2.InsertCallback(8f, () => YouAreHoge3_Unmask());  // 役割当て画面クローズ
                    }
                }
            }
            else if (preventTurnNum >= 3) // こおに 3ターン目
            {
                // 桃太郎が 残りHP1(ももっち) なら → 攻撃
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    CheckAttackToMomocchi();  // 桃太郎が 残りHP1(ももっち) であるか確認後、あてはまれば攻撃 or 条件を満たさなければスルー （3ターン目で、行動済みのキャラに対してはエイムしない）
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("桃太郎が 残りHP1(ももっち) なら → 攻撃");
                    }
                }

                // 桃メイトが 役割オープンなら → 攻撃
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    SearchMomoMateCommon(4);  // ステータスが4（役割カードオープン） ＆ 役割が いぬ・さる・きじ のキャラがいるか探す （3ターン目で、行動済みのキャラに対してエイムしない）
                    if (PushedBtnFlg == 1)  // オープンしている いぬ、さる、きじ が見つかったら
                    {
                        AttackToMomoMate();  // ももたろうの仲間 に攻撃(CPU)
                        Debug.Log("桃メイトが 役割オープンなら → 攻撃");
                    }
                }

                // 桃太郎が   役割オープン（HP2：ももじ）なら → 攻撃
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    CheckAttackToMomoji();  // 桃太郎が 役割オープン（HP2：ももじ）なら 攻撃  or 条件を満たさなければスルー （3ターン目で、行動済みのキャラに対してはエイムしない）
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("桃太郎が   役割オープン（HP2：ももじ）なら → 攻撃");
                    }
                }

                // うっかり桃メイト（木札ON） がいるなら → 役割当て
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    UkkariAte();  // うっかりフラグが1 & ステータス2 のものがあれば、それを当てる（役割当て）
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("うっかりフラグが1 & ステータス2 のものがあれば、それを当てる（役割当て）");
                    }
                }

                // 桃太郎が   木札ON(ももじ)なら → 役割当て
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    KifudaOnMomojiAte();  // 桃太郎が 木札ON（ステータス2）なら 役割当て or 条件を満たさなければスルー
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("ももたろうが 木札ONなら → 役割当て");
                    }
                }

                // ステータスが2以下である 桃メイト がいれば  → 条件を満たせば 役割当て (旧名：桃メイトが 木札無しなら → 役割当て) (その役割だと確定し、迷いなく処理する)
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    MomoMateYakuwariAte_WithConviction(); // *桃メイト を役割当て
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("ステータスが2以下である 桃メイト → 条件を満たせば 役割当て :その役割だと確定し、迷いなく処理する");
                    }
                }

                // 桃太郎が 木札無しなら → 条件を満たせば 役割当て (その役割だと確定し、迷いなく処理する)
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    MomotaroYakuwariAte_WithConviction(); // * 桃太郎 を 役割当て
                    if (PushedBtnFlg == 1)
                    {
                        Debug.Log("桃太郎が 木札無し → 条件を満たせば 役割当て :その役割だと確定し、迷いなく処理する");
                    }
                }

                // *メイビーパラメータを元に、桃メイト と思われるキャラを1人選ぶ(役割当て) ※ 木札の有無は問わない
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    MaybeMomoMate_Ate();  // 桃メイトのうち、少なくとも1人オープン前（ステータス2以下）のキャラが存在するならば
                    if (PushedBtnFlg == 1)  // 条件に合う 桃メイト と思われるキャラ が見つかったら
                    {
                        Debug.Log("*メイビーパラメータを元に、桃メイト と思われるキャラを1人選ぶ(役割当て)");
                    }
                }

                // *桃チームに 対して しつもん (少なくとも一人は札無しがいる) 
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    CheckKifudaProgressTotal();  // 木札ONの進捗状況 確認
                    if (KifudaProgressTotal < 8) // 木札ONの進捗状況が 8未満（＝少なくとも一人は札無しがいる）
                    {
                        CheckCanPushQuestion();  // 行動ボタン（質問）押せるかのチェック
                        if (CanPush_Question)  // 行動ボタン（質問）押せる
                        {
                            ButtonCscr.BranchOpenQuestion();  // M-1：この場合は「しつもん」ボタン  // 行動ボタン押せるかのチェック ＆ BrownBoxを開く
                            CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                            sequence.InsertCallback(2f, () => WhatIsYourFavorite_Question());  // 【しつもんモード】エイムセレクト画面で ランダム で選択する（条件：選択したのが自分自身ではない） （3ターン目で、行動済みのキャラに対してエイムしない）
                            if (AimedFlg == 1)  // エイム条件を満たしているならば （3ターン目で、行動済みのキャラに対してエイムしない）
                            {
                                sequence.InsertCallback(4f, () => WhatIsYourFavorite2_Question());  // OKボタン 押下で 木札をON
                                sequence.InsertCallback(8f, () => WhatIsYourFavorite3_Question());  // OKボタン 押下で ウインドウ 閉じる
                                PushedBtnFlg = 1;  // 処理を実施したかどうか
                                Debug.Log("◆*桃チームに 対して しつもん (自分以外で一人は札無しがいる) ");
                            }
                        }
                    }
                }

                // *特に参考になる情報がなければ、おやぶん・ももたろう以外で 木札ONのキャラから ランダムで一人選ぶ(役割当て) （前提：木札無しがいない＝全員ステータス2以上）
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    SearchMomoOniCommon(2);  // ステータスが2（木札ON）＆ 役割が いぬ・さる・きじ・こおにたち  のキャラがいるか探す 「RollFNum：現在エイムされているサイトの役わり」が上書きされる
                    if (PushedBtnFlg == 1)  // ステータスが2（木札ON）の いぬ、さる、きじ、こおにたち が 少なくとも一人以上いれば
                    {
                        Debug.Log("おやぶん・ももたろう以外で木札ONのキャラから ランダムで一人選ぶ(役割当て)");
                        // RollFNum に いぬ、さる、きじ、こおにたち のいずれかが入っている
                        var sequence2 = DOTween.Sequence();
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence2.InsertCallback(2f, () => YouAreHoge(RollFNum));     // 木札ONの キャラ を探して エイムでセレクト
                        sequence2.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 「桃メイト」 のアイコンを クリック（自分がおやぶんなので、こおにを選ぶことはしない）
                        sequence2.InsertCallback(8f, () => YouAreHoge3_Unmask());  // 役割当て画面クローズ
                    }
                }

                // 3ターン目：行動条件すべて該当なし → もうこれ以降、ももチームの手番は無いので、ただいまをもって おにチームの勝ち
                if (PushedBtnFlg == 0)  // 処理を実施したかどうか
                {
                    WinOniTeam();   // 鬼チームの勝利である
                }
            }
        }
    }

    public void MomoMateYakuwariAte_WithConviction()  // *桃メイト を役割当て
    {
        CheckKurunProgressTotal();  // 役割カードがオープンになったキャラが どれだけいるか の進捗状況 確認
        SearchMomoMateCommon(1);  // ステータスが1（札無し） ＆ 役割が いぬ・さる・きじ のキャラがいるか探す （3ターン目で、行動済みのキャラに対してエイムしない）
        SearchMomoMateCommon(2);  // ステータスが2（木札ON） ＆ 役割が いぬ・さる・きじ のキャラがいるか探す。 「RollFNum：現在エイムされているサイトの役わり」が上書きされる
        if (PushedBtnFlg == 1)    // ステータスが2以下の いぬ、さる、きじ が見つかったら
        {
            PushedBtnFlg = 0;  // 処理を実施したかどうか ：一旦フラグを初期化（リセット）
            if (KurunProgressTotal == 7) // 他のキャラが全部オープン済みで 一つだけステータスが2以下 で残っている ◆場の全体を見て その役割 だと判明した場合
            {
                Debug.Log("他のキャラが全部カードオープンで 、その役割カード（いぬ・さる・きじ のいずれか1枚）だけ ステータスが2以下で残っている");
                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
            }
            else if (KurunProgressTotal == 6) // 自分がこおにで、ステータスが2以下が 2人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
            {
                if (NowActiveSiteStatus <= 2)  // こおに（自分）がステータスが2以下
                {
                    Debug.Log("自分がこおにで、ステータスが2以下 なのが自分と 桃メイト（他のキャラは全部オープン済み）");
                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                }
                else  // こおに（自分）がステータスが3以上（オープン後）
                {
                    Sum_InokoriMate();   // 居残りメイトの合計を求める
                    Sum_InokoriKooni();   // 居残りこおにの合計を求める
                    if (InokoriMate == 2)   // 残りのサイト（ステータスが2以下）が、両方とも桃メイト
                    {
                        Debug.Log("残りのサイト（ステータスが2以下）が、両方とも桃メイト（他のキャラは全部オープン済み）");
                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                    }
                    else if (InokoriMate == 1)
                    {
                        if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは [ももたろう か おやぶん]）
                        {
                            CheckKifudaProgressTotal();  // 木札ONの進捗状況
                            if (KifudaProgressTotal >= 7)  // [ももたろう か おやぶん] か 桃メイト の少なくとも一方に 木札ON
                            {
                                Debug.Log("残りのサイト（ステータスが2以下）が、[ももたろう か おやぶん] と 桃メイト（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                        }
                    }
                }
            }
            else if (KurunProgressTotal == 5) // 自分がこおにで、ステータスが2以下が 3人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
            {
                Sum_InokoriMate();   // 居残りメイトの合計を求める
                Sum_InokoriKooni();   // 居残りこおにの合計を求める
                if (NowActiveSiteStatus <= 2)  // こおに（自分）がステータスが2以下
                {
                    if (InokoriMate == 2)   // 残りのサイト（ステータスが2以下）が、自分（こおに）と 桃メイト×2
                    {
                        Debug.Log("自分がこおにで、ステータスが2以下 なのが自分（こおに）と 桃メイト×2（他のキャラは全部オープン済み）");
                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                    }
                    else if (InokoriMate == 1)
                    {
                        if (InokoriKooni == 1)  // 居残りこおにが1(自分)（＝後の居残りは [ももたろう か おやぶん]）
                        {
                            CheckKifudaProgressTotal();  // 木札ONの進捗状況
                            if (NowActiveSiteStatus == 1)  // こおに（自分）がステータスが1
                            {
                                if (KifudaProgressTotal >= 6)  // 居残り組3人中、 木札ON 1枚以上（こおに札無し）
                                {
                                    Debug.Log("残りのサイト（ステータスが2以下）が、自分（こおに） と [ももたろう か おやぶん] と 桃メイト （他のキャラは全部オープン済み）");
                                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                }
                            }
                            else if (NowActiveSiteStatus == 2)  // こおに（自分）がステータスが2(木札ON)
                            {
                                if (KifudaProgressTotal >= 7)  // 居残り組3人中、 木札ON 2枚以上（こおに札あり）
                                {
                                    Debug.Log("残りのサイト（ステータスが2以下）が、自分（こおに） と [ももたろう か おやぶん] と 桃メイト （他のキャラは全部オープン済み）");
                                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                }
                            }
                        }
                    }
                }
                else  // こおに（自分）がステータスが3以上（オープン後）
                {
                    if (InokoriMate == 3)   // 残りのサイト（ステータスが2以下）が、3人とも桃メイト
                    {
                        Debug.Log("残りのサイト（ステータスが2以下）が、3人とも桃メイト（他のキャラは全部オープン済み）");
                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                    }
                    else if (InokoriMate == 2)
                    {
                        if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは [ももたろう か おやぶん]）
                        {
                            CheckKifudaProgressTotal();  // 木札ONの進捗状況
                            if (KifudaProgressTotal >= 6)  // 居残り組3人中、 誰か1人 に木札ON で確定
                            {
                                Debug.Log("残りのサイト（ステータスが2以下）が、[ももたろう か おやぶん] と 桃メイト×2（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                        }
                    }
                    else if (InokoriMate == 1)
                    {
                        if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは ももたろう と おやぶん）
                        {
                            CheckKifudaProgressTotal();  // 木札ONの進捗状況
                            CheckNowMomotaroStatus();  // ももたろうのステータス確認
                            if (KifudaProgressTotal >= 7)  // 居残り組3人中、 誰か2人 に木札ON で確定
                            {
                                Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と おやぶん と 桃メイト（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                            else if (KifudaProgressTotal == 6)  // 居残り組3人中、 桃メイト1人 に木札ON で確定
                            {
                                if (NowMomotaroStatus == 1)  // ももたろう の ステータスが1（札無し）だったら
                                {
                                    if (NowOyabunStatus == 1)  // おやぶん がステータス1
                                    {
                                        Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と おやぶん と 桃メイト（他のキャラは全部オープン済み）");
                                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (KurunProgressTotal == 4) // 自分がこおにで、ステータスが2以下が 4人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
            {
                Sum_InokoriMate();   // 居残りメイトの合計を求める
                Sum_InokoriKooni();   // 居残りこおにの合計を求める
                if (NowActiveSiteStatus <= 2)  // こおに（自分）がステータスが2以下
                {
                    if (InokoriMate == 3)   // 残りのサイト（ステータスが2以下）が、自分（こおに）と 桃メイト×3
                    {
                        Debug.Log("自分がこおにで、ステータスが2以下 なのが自分（こおに）と 桃メイト×3（他のキャラは全部オープン済み）");
                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                    }
                    else if (InokoriMate == 2)
                    {
                        if (InokoriKooni == 1)  // 居残りこおにが1(自分)（＝後の居残りは [ももたろう か おやぶん]）
                        {
                            CheckKifudaProgressTotal();  // 木札ONの進捗状況
                            if (NowActiveSiteStatus == 1)  // こおに（自分）がステータスが1
                            {
                                if (KifudaProgressTotal >= 5)  // 居残り組4人中、 木札ON 1枚以上 (こおに（自分）は札無し)
                                {
                                    Debug.Log("残りのサイト（ステータスが2以下）が、自分（こおに）と [ももたろう か おやぶん] と 桃メイト×2（他のキャラは全部オープン済み）");
                                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                }
                            }
                            else if (NowActiveSiteStatus == 2)  // こおに（自分）がステータスが2(木札ON)
                            {
                                if (KifudaProgressTotal >= 6)  // 居残り組4人中、 木札ON 2枚以上  (こおに（自分）は札あり)
                                {
                                    Debug.Log("残りのサイト（ステータスが2以下）が、自分（こおに）と ももたろう と 桃メイト×2（他のキャラは全部オープン済み）");
                                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                }
                            }
                        }
                    }
                    else if (InokoriMate == 1)
                    {
                        if (InokoriKooni == 1)  // 居残りこおにが1(自分)（＝後の居残りは ももたろう と おやぶん）
                        {
                            CheckKifudaProgressTotal();  // 木札ONの進捗状況
                            CheckNowMomotaroStatus();  // ももたろうのステータス確認
                            if (NowActiveSiteStatus == 1)  // こおに（自分）がステータスが1
                            {
                                if (KifudaProgressTotal >= 6)  // 居残り組4人中、 2人 に木札ON で確定
                                {
                                    Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と おやぶん と 桃メイト（他のキャラは全部オープン済み）");
                                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                }
                                else if (KifudaProgressTotal == 5)  // 居残り組4人中、 桃メイト に木札ON 1枚 (こおに（自分）は札無し)
                                {
                                    if (NowMomotaroStatus == 1)  // ももたろう の ステータスが1（札無し）だったら
                                    {
                                        if (NowOyabunStatus == 1)  // おやぶん がステータス1
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と おやぶん と 桃メイト（他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                }
                            }
                            else if (NowActiveSiteStatus == 2)  // こおに（自分）がステータスが2(木札ON)
                            {
                                if (KifudaProgressTotal >= 7)  // 居残り組4人中、 3人 に木札ON で確定
                                {
                                    Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と おやぶん と 桃メイト（他のキャラは全部オープン済み）");
                                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                }
                                else if (KifudaProgressTotal == 6)  // 居残り組4人中、 桃メイト に木札ON 1枚 (こおに（自分）は札あり)
                                {
                                    if (NowMomotaroStatus == 1)  // ももたろう の ステータスが1（札無し）だったら
                                    {
                                        if (NowOyabunStatus == 1)  // おやぶん がステータス1
                                        {
                                            Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と おやぶん と 桃メイト（他のキャラは全部オープン済み）");
                                            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                            PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                else  // こおに（自分）がステータスが3以上（オープン後）
                {
                    if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは [ももたろう か おやぶん] と 桃メイト×3）
                    {
                        CheckKifudaProgressTotal();  // 木札ONの進捗状況
                        CheckNowMomotaroStatus();  // ももたろうのステータス確認

                        if (InokoriMate == 3)   // 残りのサイト（ステータスが2以下）が、[ももたろう か おやぶん] と 桃メイト×3
                        {
                            if (KifudaProgressTotal >= 5)  // 居残り組5人中、 木札ON 1枚以上
                            {
                                Debug.Log("残りのサイト（ステータスが2以下）が、[ももたろう か おやぶん] と 桃メイト×3（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                        }
                        else if (InokoriMate == 2)  // 残りのサイト（ステータスが2以下）が、ももたろう と おやぶん と 桃メイト×2
                        {
                            if (KifudaProgressTotal >= 6)  // 居残り組4人中、 2人 に木札ON で確定
                            {
                                Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と おやぶん と 桃メイト×2（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                            else if (KifudaProgressTotal == 5)  // 居残り組4人中、 桃メイト に木札ON 1枚 (こおに（自分）は札あり)
                            {
                                if (NowMomotaroStatus == 1)  // ももたろう の ステータスが1（札無し）だったら
                                {
                                    if (NowOyabunStatus == 1)  // おやぶん がステータス1
                                    {
                                        Debug.Log("残りのサイト（ステータスが2以下）が、ももたろう と おやぶん と 桃メイト×2（他のキャラは全部オープン済み）");
                                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (KurunProgressTotal == 3) // 自分がこおにで、ステータスが2以下が 5人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
            {
                Sum_InokoriMate();   // 居残りメイトの合計を求める
                Sum_InokoriKooni();   // 居残りこおにの合計を求める
                CheckKifudaProgressTotal();  // 木札ONの進捗状況
                if (NowActiveSiteStatus <= 2)  // こおに（自分）がステータスが2以下
                {
                    if (InokoriMate == 3)   // 残りのサイト（ステータスが2以下）が、自分（こおに）と 桃メイト×3 と [ももたろう か おやぶん]
                    {
                        if (InokoriKooni == 1)  // 居残りこおにが1(自分)（＝後の居残りは [ももたろう か おやぶん] と 桃メイト×3）
                        {
                            if (NowActiveSiteStatus == 1)  // こおに（自分）がステータスが1
                            {
                                if (KifudaProgressTotal >= 4)  // 居残り組5人中、 木札ON 1枚以上 (こおに（自分）は札無し)
                                {
                                    Debug.Log("残りのサイト（ステータスが2以下）が、自分（こおに）と [ももたろう か おやぶん] と 桃メイト×3（他のキャラは全部オープン済み）");
                                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                }
                            }
                            else if (NowActiveSiteStatus == 2)  // こおに（自分）がステータスが2(木札ON)
                            {
                                if (KifudaProgressTotal >= 5)  // 居残り組5人中、 木札ON 2枚以上  (こおに（自分）は札あり)
                                {
                                    Debug.Log("残りのサイト（ステータスが2以下）が、自分（こおに）と [ももたろう か おやぶん] と 桃メイト×3（他のキャラは全部オープン済み）");
                                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                    PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                }
                            }
                        }
                    }
                }
                else  // こおに（自分）がステータスが3以上（オープン後）
                {
                    if (InokoriMate == 3)   // 残りのサイト（ステータスが2以下）が、桃メイト×3 と ももたろう と おやぶん
                    {
                        if (InokoriKooni == 0)  // 居残りこおにがゼロ（＝後の居残りは ももたろう と おやぶん と 桃メイト×3）
                        {
                            if (KifudaProgressTotal >= 5)  // 居残り組5人中、 木札ON 2枚以上  で確定
                            {
                                Debug.Log("残りのサイト（ステータスが2以下）が、と ももたろう と おやぶん と 桃メイト×3（他のキャラは全部オープン済み）");
                                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                            }
                            else if (KifudaProgressTotal == 4)  // 居残り組5人中、 桃メイト に木札ON 1枚 
                            {
                                if (NowMomotaroStatus == 1)  // ももたろう の ステータスが1（札無し）だったら
                                {
                                    if (NowOyabunStatus == 1)  // おやぶん がステータス1
                                    {
                                        Debug.Log("残りのサイト（ステータスが2以下）が、と ももたろう と おやぶん と 桃メイト×3（他のキャラは全部オープン済み）");
                                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン ・・・その役割だと確定し、迷いなく処理する
                                        PushedBtnFlg = 1;  // 処理を実施したかどうか → 実施済み
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void MomotaroYakuwariAte_WithConviction()  // * 桃太郎 を 役割当て
    {
        CheckKurunProgressTotal();  // 役割カードがオープンになったキャラが どれだけいるか の進捗状況 確認
        SearchMomotaroCommon(1);  // ステータスが1（札無し） ＆ 役割が ももたろう のキャラがいるか探す （3ターン目で、行動済みのキャラに対してはエイムしない）
        if (PushedBtnFlg == 1)  // ステータスが1（札無し）の ももたろう が見つかったら
        {
            Debug.Log("ステータスが1（札無し）の ももたろう が残っている");
            if (KurunProgressTotal == 7) // 他のキャラが全部オープン済みで 一つだけデフォルト（札無し）で残っている ◆場の全体を見て その役割 だと判明した場合
            {
                Debug.Log("他のキャラが全部カードオープンで 、その役割カード だけ 札無しで残っている");
                PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン
            }
            else if (KurunProgressTotal == 6) // 自分が こおに で、木札無しが 2人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
            {
                if (NowActiveSiteStatus == 1)  // こおに（自分）が木札無し
                {
                    int FindMomotaroFlg = 0; // 条件に合う ももたろう がいるかどうか
                    if (rollF[1] == 1) // 役割が ももたろう である
                    {
                        if (StatusSiteA == 1)  //  状態（ステータス）が木札無し（デフォルト）
                        {
                            FindMomotaroFlg = 1;
                        }
                    }
                    if (rollF[2] == 1) // 役割が ももたろう である
                    {
                        if (StatusSiteB == 1)  //  状態（ステータス）が木札無し（デフォルト）
                        {
                            FindMomotaroFlg = 1;
                        }
                    }
                    if (rollF[3] == 1) // 役割が ももたろう である
                    {
                        if (StatusSiteC == 1)  //  状態（ステータス）が木札無し（デフォルト）
                        {
                            FindMomotaroFlg = 1;
                        }
                    }
                    if (rollF[4] == 1) // 役割が ももたろう である
                    {
                        if (StatusSiteD == 1)  //  状態（ステータス）が木札無し（デフォルト）
                        {
                            FindMomotaroFlg = 1;
                        }
                    }
                    if (rollF[5] == 1) // 役割が ももたろう である
                    {
                        if (StatusSiteE == 1)  //  状態（ステータス）が木札無し（デフォルト）
                        {
                            FindMomotaroFlg = 1;
                        }
                    }
                    if (rollF[6] == 1) // 役割が ももたろう である
                    {
                        if (StatusSiteF == 1)  //  状態（ステータス）が木札無し（デフォルト）
                        {
                            FindMomotaroFlg = 1;
                        }
                    }
                    if (rollF[7] == 1) // 役割が ももたろう である
                    {
                        if (StatusSiteG == 1)  //  状態（ステータス）が木札無し（デフォルト）
                        {
                            FindMomotaroFlg = 1;
                        }
                    }
                    if (rollF[8] == 1) // 役割が ももたろう である
                    {
                        if (StatusSiteH == 1)  //  状態（ステータス）が木札無し（デフォルト）
                        {
                            FindMomotaroFlg = 1;
                        }
                    }

                    if (FindMomotaroFlg == 1)  // 条件に合う桃メイトがいたら
                    {
                        Debug.Log("自分が こおに で、木札無しが自分と もう1人（ももたろう）いる（他のキャラは全部オープン済み）");
                        PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン
                    }
                }
            }
            else
            {
                PushedBtnFlg = 0;  // 条件を満たしていなければ、フラグをリセット（次に進む）
            }
        }
    }


    public void MaybeMomoMate_Ate()  // 桃メイトのうち、少なくとも1人オープン前（ステータス2以下）のキャラが存在するならば
    {
        var sequence = DOTween.Sequence();
        SearchMomoMateCommon(1);  // ステータスが1（札無し） ＆ 役割が いぬ・さる・きじ のキャラがいるか探す （該当者居れば PushedBtnFlg = 1 になる） （3ターン目で、行動済みのキャラに対してエイムしない）
        SearchMomoMateCommon(2);  // ステータスが2（木札ON） ＆ 役割が いぬ・さる・きじ のキャラがいるか探す （該当者居れば PushedBtnFlg = 1 になる）
        if (PushedBtnFlg == 1)    // ステータスが2以下の いぬ、さる、きじ が見つかったら
        {
            PushedBtnFlg = 0;  // 処理を実施したかどうか（一旦初期化）
            Debug.Log("*ステータス4の桃メイトが一人もいない ＆ ステータスが2以下の いぬ、さる、きじ が存在する");
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                if (Maybe_MomoMate[8] > 25)  // ももたろうの仲間 である可能性値 が一定以上（初期値より上）
                {
                    if (StatusSiteH <= 2)  // メイビーサイトのステータスが 2以下 である
                    {
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン押下 (確証はない、多分そうで予想する)
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence.InsertCallback(2f, () => SiteH_Aimed());                 // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(2f, () => CharaMSC.ShowSiteH_Aimed());    // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 桃メイト のアイコンを クリック
                        sequence.InsertCallback(8f, () => YouAreHoge3_Unmask());   // 役割当て画面クローズ
                        PushedBtnFlg = 1;  // 処理を実施したかどうか
                        Maybe_MomoMate[8] = -1;  // メイビー当て処理を実施済み のしるし
                    }
                }
            }
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                if (Maybe_MomoMate[7] > 25)  // ももたろうの仲間 である可能性値 が一定以上（初期値より上）
                {
                    if (StatusSiteG <= 2)  // メイビーサイトのステータスが 2以下 である
                    {
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン押下 (確証はない、多分そうで予想する)
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence.InsertCallback(2f, () => SiteG_Aimed());                 // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(2f, () => CharaMSC.ShowSiteG_Aimed());    // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 桃メイト のアイコンを クリック
                        sequence.InsertCallback(8f, () => YouAreHoge3_Unmask());   // 役割当て画面クローズ
                        PushedBtnFlg = 1;  // 処理を実施したかどうか
                        Maybe_MomoMate[7] = -1;  // メイビー当て処理を実施済み のしるし
                    }
                }
            }
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                if (Maybe_MomoMate[6] > 25)  // ももたろうの仲間 である可能性値 が一定以上（初期値より上）
                {
                    if (StatusSiteF <= 2)  // メイビーサイトのステータスが 2以下 である
                    {
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン押下 (確証はない、多分そうで予想する)
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence.InsertCallback(2f, () => SiteF_Aimed());                 // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(2f, () => CharaMSC.ShowSiteF_Aimed());    // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 桃メイト のアイコンを クリック
                        sequence.InsertCallback(8f, () => YouAreHoge3_Unmask());   // 役割当て画面クローズ
                        PushedBtnFlg = 1;  // 処理を実施したかどうか
                        Maybe_MomoMate[6] = -1;  // メイビー当て処理を実施済み のしるし
                    }
                }
            }
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                if (Maybe_MomoMate[5] > 25)  // ももたろうの仲間 である可能性値 が一定以上（初期値より上）
                {
                    if (StatusSiteE <= 2)  // メイビーサイトのステータスが 2以下 である
                    {
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン押下 (確証はない、多分そうで予想する)
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence.InsertCallback(2f, () => SiteE_Aimed());                 // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(2f, () => CharaMSC.ShowSiteE_Aimed());    // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 桃メイト のアイコンを クリック
                        sequence.InsertCallback(8f, () => YouAreHoge3_Unmask());   // 役割当て画面クローズ
                        PushedBtnFlg = 1;  // 処理を実施したかどうか
                        Maybe_MomoMate[5] = -1;  // メイビー当て処理を実施済み のしるし
                    }
                }
            }
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                if (Maybe_MomoMate[4] > 25)  // ももたろうの仲間 である可能性値 が一定以上（初期値より上）
                {
                    if (StatusSiteD <= 2)  // メイビーサイトのステータスが 2以下 である
                    {
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン押下 (確証はない、多分そうで予想する)
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence.InsertCallback(2f, () => SiteD_Aimed());                 // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(2f, () => CharaMSC.ShowSiteD_Aimed());    // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 桃メイト のアイコンを クリック
                        sequence.InsertCallback(8f, () => YouAreHoge3_Unmask());   // 役割当て画面クローズ
                        PushedBtnFlg = 1;  // 処理を実施したかどうか
                        Maybe_MomoMate[4] = -1;  // メイビー当て処理を実施済み のしるし
                    }
                }
            }
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                if (Maybe_MomoMate[3] > 25)  // ももたろうの仲間 である可能性値 が一定以上（初期値より上）
                {
                    if (StatusSiteC <= 2)  // メイビーサイトのステータスが 2以下 である
                    {
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン押下 (確証はない、多分そうで予想する)
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence.InsertCallback(2f, () => SiteC_Aimed());                 // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(2f, () => CharaMSC.ShowSiteC_Aimed());    // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 桃メイト のアイコンを クリック
                        sequence.InsertCallback(8f, () => YouAreHoge3_Unmask());   // 役割当て画面クローズ
                        PushedBtnFlg = 1;  // 処理を実施したかどうか
                        Maybe_MomoMate[3] = -1;  // メイビー当て処理を実施済み のしるし
                    }
                }
            }
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                if (Maybe_MomoMate[2] > 25)  // ももたろうの仲間 である可能性値 が一定以上（初期値より上）
                {
                    if (StatusSiteB <= 2)  // メイビーサイトのステータスが 2以下 である
                    {
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン押下 (確証はない、多分そうで予想する)
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence.InsertCallback(2f, () => SiteB_Aimed());                 // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(2f, () => CharaMSC.ShowSiteB_Aimed());    // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 桃メイト のアイコンを クリック
                        sequence.InsertCallback(8f, () => YouAreHoge3_Unmask());   // 役割当て画面クローズ
                        PushedBtnFlg = 1;  // 処理を実施したかどうか
                        Maybe_MomoMate[2] = -1;  // メイビー当て処理を実施済み のしるし
                    }
                }
            }
            if (PushedBtnFlg == 0)  // 処理を実施したかどうか
            {
                if (Maybe_MomoMate[1] > 25)  // ももたろうの仲間 である可能性値 が一定以上（初期値より上）
                {
                    if (StatusSiteA <= 2)  // メイビーサイトのステータスが 2以下 である
                    {
                        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン押下 (確証はない、多分そうで予想する)
                        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
                        sequence.InsertCallback(2f, () => SiteA_Aimed());                 // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(2f, () => CharaMSC.ShowSiteA_Aimed());    // 場から該当のサイトを エイムでセレクト
                        sequence.InsertCallback(4f, () => YouAreHoge2_Unmask(2));  // 役割当て画面で 桃メイト のアイコンを クリック
                        sequence.InsertCallback(8f, () => YouAreHoge3_Unmask());   // 役割当て画面クローズ
                        PushedBtnFlg = 1;  // 処理を実施したかどうか
                        Maybe_MomoMate[1] = -1;  // メイビー当て処理を実施済み のしるし
                    }
                }
            }
        }
    }


    public void CloseBrownBoxCommon()
    {
        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.2f, () => ButtonCscr.CloseBrownBox());  // OKボタン 押下で BrownBox 閉じる
        sequence.InsertCallback(0.2f, () => ButtonCscr.JudgeGoSelectTime());   // セレクト画面に行けるか、エラーかを判定する
    }

    public void WhatIsYourFavorite_Question()  // 【しつもんモード】エイムセレクト画面で ランダム で選択する （条件：選択したのが自分自身ではない） （3ターン目で、行動済みのキャラに対してはエイムしない）
    {
        var AimedSite = Enumerable.Range(1, 8).OrderBy(n => Guid.NewGuid()).Take(8).ToArray();  // 配列に 1～8 までの数値を ランダムに入れる
        AimedFlg = 0;  // エイムドフラグ 初期化
        Debug.Log("エイムセレクト画面で ランダム で選択する");

        for (int s = 0; AimedFlg == 0; s++)
        {
            Debug.Log(AimedSite[s]);
            if (AimedSite[s] == 1)
            {
                if (StatusSiteA <= 1)  // 木札無しならば
                {
                    if (AimedSite[s] != NowActiveSiteN)  // 選択したのが自分自身でなければ
                    {
                        TargetSiteOrderNum = TurnChip_A;  // 今狙われているエイムサイトは SiteA
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (rollF[1] == 5) //  エイムサイトが おにのおやぶん であれば 価値あり
                        {
                            WorthAiming = 1;
                        }
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            SiteA_Aimed();
                            CharaMSC.ShowSiteA_Aimed();
                            AimedFlg = 1;
                        }
                    }
                }
            }
            else if (AimedSite[s] == 2)
            {
                if (StatusSiteB <= 1)  // 木札無しならば
                {
                    if (AimedSite[s] != NowActiveSiteN)  // 選択したのが自分自身でなければ
                    {
                        TargetSiteOrderNum = TurnChip_B;  // 今狙われているエイムサイトは SiteB
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (rollF[2] == 5) //  エイムサイトが おにのおやぶん であれば 価値あり
                        {
                            WorthAiming = 1;
                        }
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            SiteB_Aimed();
                            CharaMSC.ShowSiteB_Aimed();
                            AimedFlg = 1;
                        }
                    }
                }
            }
            else if (AimedSite[s] == 3)
            {
                if (StatusSiteC <= 1)  // 木札無しならば
                {
                    if (AimedSite[s] != NowActiveSiteN)  // 選択したのが自分自身でなければ
                    {
                        TargetSiteOrderNum = TurnChip_C;  // 今狙われているエイムサイトは SiteC
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (rollF[3] == 5) //  エイムサイトが おにのおやぶん であれば 価値あり
                        {
                            WorthAiming = 1;
                        }
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            SiteC_Aimed();
                            CharaMSC.ShowSiteC_Aimed();
                            AimedFlg = 1;
                        }
                    }
                }
            }
            else if (AimedSite[s] == 4)
            {
                if (StatusSiteD <= 1)  // 木札無しならば
                {
                    if (AimedSite[s] != NowActiveSiteN)  // 選択したのが自分自身でなければ
                    {
                        TargetSiteOrderNum = TurnChip_D;  // 今狙われているエイムサイトは SiteD
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (rollF[4] == 5) //  エイムサイトが おにのおやぶん であれば 価値あり
                        {
                            WorthAiming = 1;
                        }
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            SiteD_Aimed();
                            CharaMSC.ShowSiteD_Aimed();
                            AimedFlg = 1;
                        }
                    }
                }
            }
            else if (AimedSite[s] == 5)
            {
                if (StatusSiteE <= 1)  // 木札無しならば
                {
                    if (AimedSite[s] != NowActiveSiteN)  // 選択したのが自分自身でなければ
                    {
                        TargetSiteOrderNum = TurnChip_E;  // 今狙われているエイムサイトは SiteE
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (rollF[5] == 5) //  エイムサイトが おにのおやぶん であれば 価値あり
                        {
                            WorthAiming = 1;
                        }
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            SiteE_Aimed();
                            CharaMSC.ShowSiteE_Aimed();
                            AimedFlg = 1;
                        }
                    }
                }
            }
            else if (AimedSite[s] == 6)
            {
                if (StatusSiteF <= 1)  // 木札無しならば
                {
                    if (AimedSite[s] != NowActiveSiteN)  // 選択したのが自分自身でなければ
                    {
                        TargetSiteOrderNum = TurnChip_F;  // 今狙われているエイムサイトは SiteF
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (rollF[6] == 5) //  エイムサイトが おにのおやぶん であれば 価値あり
                        {
                            WorthAiming = 1;
                        }
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            SiteF_Aimed();
                            CharaMSC.ShowSiteF_Aimed();
                            AimedFlg = 1;
                        }
                    }
                }
            }
            else if (AimedSite[s] == 7)
            {
                if (StatusSiteG <= 1)  // 木札無しならば
                {
                    if (AimedSite[s] != NowActiveSiteN)  // 選択したのが自分自身でなければ
                    {
                        TargetSiteOrderNum = TurnChip_G;  // 今狙われているエイムサイトは SiteG
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (rollF[7] == 5) //  エイムサイトが おにのおやぶん であれば 価値あり
                        {
                            WorthAiming = 1;
                        }
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            SiteG_Aimed();
                            CharaMSC.ShowSiteG_Aimed();
                            AimedFlg = 1;
                        }
                    }
                }
            }
            else if (AimedSite[s] == 8)
            {
                if (StatusSiteH <= 1)  // 木札無しならば
                {
                    if (AimedSite[s] != NowActiveSiteN)  // 選択したのが自分自身でなければ
                    {
                        TargetSiteOrderNum = TurnChip_H;  // 今狙われているエイムサイトは SiteH
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (rollF[8] == 5) //  エイムサイトが おにのおやぶん であれば 価値あり
                        {
                            WorthAiming = 1;
                        }
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            SiteH_Aimed();
                            CharaMSC.ShowSiteH_Aimed();
                            AimedFlg = 1;
                        }
                    }
                }
            }
            if (s == 7)
            {
                AimedFlg = -1;  // ここのフェーズでは該当なし
                Debug.Log("条件を満たさなかったため、エイムセレクト画面で ランダム で選択する のは中断する");
            }
        }
    }
    
    public void WhatIsYourFavorite2_Question()
    {
        CloseBeforeQuestion();
        AppearAfterQuestion();
        SerifDependOnRole();
    }

    public void WhatIsYourFavorite3_Question()
    {
        CloseAfterQuestion();
        CloseQuestionMode();
        AfterPushActButtonCommon();  // 各行動ボタン押下後の共通処理
        KifudaMSC.askedQuestionSite_active();
        KifudaMSC.AppearKifudaWait();
    }

    public void PushYakuwariBtn_Common(int rollNum_Um)  // 役割が 1:ももたろう、2:いぬ、3:さる、4:きじ、5:おやぶん、6:こおに  ・・・その役割だと確定し、迷いなく処理する
    {
        var sequence = DOTween.Sequence();
        ButtonCscr.BranchOpenUnmask();  // M-2：この場合は「役割あて」ボタン
        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
        sequence.InsertCallback(2f, () => YouAreHoge(rollNum_Um));     // 木札ONの キャラ を探して エイムでセレクト  ・・・その役割だと確定し、迷いなく処理する
        sequence.InsertCallback(4f, () => YouAreHoge2_Unmask(rollNum_Um));  // 役割当て画面で 該当キャラ のアイコンを クリック
        sequence.InsertCallback(8f, () => YouAreHoge3_Unmask());  // 役割当て画面クローズ
    }

    public void YouAreHoge(int cnum)  // エイムセレクト画面で 1:ももたろう、2:いぬ、3:さる、4:きじ、5:おやぶん、6:こおに を選択する
    {
        if (rollF[1] == cnum) // 役割が 1:ももたろう、2:いぬさるきじ、5:おやぶん、6:こおに
        {
            SiteA_Aimed();
            CharaMSC.ShowSiteA_Aimed();
        }
        else if (rollF[2] == cnum) // 役割が 1:ももたろう、2:いぬさるきじ、5:おやぶん、6:こおに
        {
            SiteB_Aimed();
            CharaMSC.ShowSiteB_Aimed();
        }
        else if (rollF[3] == cnum) // 役割が 1:ももたろう、2:いぬさるきじ、5:おやぶん、6:こおに
        {
            SiteC_Aimed();
            CharaMSC.ShowSiteC_Aimed();
        }
        else if (rollF[4] == cnum) // 役割が 1:ももたろう、2:いぬさるきじ、5:おやぶん、6:こおに
        {
            SiteD_Aimed();
            CharaMSC.ShowSiteD_Aimed();
        }
        else if (rollF[5] == cnum) // 役割が 1:ももたろう、2:いぬさるきじ、5:おやぶん、6:こおに
        {
            SiteE_Aimed();
            CharaMSC.ShowSiteE_Aimed();
        }
        else if (rollF[6] == cnum) // 役割が 1:ももたろう、2:いぬさるきじ、5:おやぶん、6:こおに
        {
            SiteF_Aimed();
            CharaMSC.ShowSiteF_Aimed();
        }
        else if (rollF[7] == cnum) // 役割が 1:ももたろう、2:いぬさるきじ、5:おやぶん、6:こおに
        {
            SiteG_Aimed();
            CharaMSC.ShowSiteG_Aimed();
        }
        else if (rollF[8] == cnum) // 役割が 1:ももたろう、2:いぬさるきじ、5:おやぶん、6:こおに
        {
            SiteH_Aimed();
            CharaMSC.ShowSiteH_Aimed();
        }
    }


    public void YouAreHoge2_Unmask(int cnum)  // 役割当て画面で[ 1:ももたろう、2:いぬさるきじ、5:おやぶん、6:こおに ] のアイコンを クリック
    {
        CloseBeforeUnmask();
        AppearAfterUnmask();
        if (cnum == 1)                   // ももたろう
        {
            YosouMomotaro();
            Debug.Log("エイムセレクト画面で ももたろう を選択する");
        }
        else if (cnum >= 2 && cnum <= 4) // いぬ、さる、きじ
        {
            YosouMomomates();
            Debug.Log("エイムセレクト画面で ももたろうの仲間 を選択する");
        }
        else if (cnum == 5)              // おやぶん
        {
            YosouOyabun();
            Debug.Log("エイムセレクト画面で おやぶん を選択する");
        }
        else if (cnum >= 6 && cnum <= 8) // こおに
        {
            YosouKooni();
            Debug.Log("エイムセレクト画面で こおに を選択する");
        }
    }

    public void YouAreHoge3_Unmask()  // 役割当て画面クローズ
    {
        CloseAfterUnmask();
        CloseUnmaskMode();
        AfterPushActButtonCommon();  // 各行動ボタン押下後の共通処理

        CardR_BaASC.StartCardOpen();
        CardR_BaBSC.StartCardOpen();
        CardR_BaCSC.StartCardOpen();
        CardR_BaDSC.StartCardOpen();
        CardR_BaESC.StartCardOpen();
        CardR_BaFSC.StartCardOpen();
        CardR_BaGSC.StartCardOpen();
        CardR_BaHSC.StartCardOpen();
    }

    public void YouAreHoge2_Attack()  // こうげき画面： OKボタン 押下で 攻撃 実行
    {
        CloseBeforeAttack();
        AppearAfterAttack();
        checkDEX();
        JudgeHitting();
    }

    public void YouAreHoge3_Attack()  //  OKボタン 押下で ウインドウ 閉じる
    {
        CloseAfterAttack();
        CloseAttackMode();
        AfterPushActButtonCommon();  // 各行動ボタン押下後の共通処理
    }
    
    public void SearchMomoMateCommon(int StatusSiteNum)  // 役割が いぬ・さる・きじ のキャラがいるか探す （3ターン目で、行動済みのキャラに対してはエイムしない）
    {
        for (int TN = 8; TN > 0; TN--)  // 順番マーカーが 8 のものからチェック
        {
            if (TurnChip_A == TN)       // サイトAの順番マーカーがTN番である
            {
                if (rollF[1] >= 2 && rollF[1] <= 4) // いぬ、さる、きじ
                {
                    if (StatusSiteA == StatusSiteNum)  // 桃メイトが 指定のステータスである
                    {
                        TargetSiteOrderNum = TurnChip_A;  // 今狙われているエイムサイトは SiteA
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            RollFNum = rollF[1];  // 現在エイムされているサイトの役わり が サイトA の役割 に上書きあれる
                            TN = -1;
                        }
                    }
                }
            }
            else if (TurnChip_B == TN)
            {
                if (rollF[2] >= 2 && rollF[2] <= 4) // いぬ、さる、きじ
                {
                    if (StatusSiteB == StatusSiteNum)
                    {
                        TargetSiteOrderNum = TurnChip_B;  // 今狙われているエイムサイトは SiteB
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            RollFNum = rollF[2];  // 現在エイムされているサイトの役わり が サイトB の役割 に上書きあれる
                            TN = -1;
                        }
                    }
                }
            }
            else if (TurnChip_C == TN)
            {
                if (rollF[3] >= 2 && rollF[3] <= 4) // いぬ、さる、きじ
                {
                    if (StatusSiteC == StatusSiteNum)
                    {
                        TargetSiteOrderNum = TurnChip_C;  // 今狙われているエイムサイトは SiteC
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            RollFNum = rollF[3];  // 現在エイムされているサイトの役わり が サイトC の役割 に上書きあれる
                            TN = -1;
                        }
                    }
                }
            }
            else if (TurnChip_D == TN)
            {
                if (rollF[4] >= 2 && rollF[4] <= 4) // いぬ、さる、きじ
                {
                    if (StatusSiteD == StatusSiteNum)
                    {
                        TargetSiteOrderNum = TurnChip_D;  // 今狙われているエイムサイトは SiteD
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            RollFNum = rollF[4];  // 現在エイムされているサイトの役わり が サイトD の役割 に上書きあれる
                            TN = -1;
                        }
                    }
                }
            }
            else if (TurnChip_E == TN)
            {
                if (rollF[5] >= 2 && rollF[5] <= 4) // いぬ、さる、きじ
                {
                    if (StatusSiteE == StatusSiteNum)
                    {
                        TargetSiteOrderNum = TurnChip_E;  // 今狙われているエイムサイトは SiteE
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            RollFNum = rollF[5];  // 現在エイムされているサイトの役わり が サイトE の役割 に上書きあれる
                            TN = -1;
                        }
                    }
                }
            }
            else if (TurnChip_F == TN)
            {
                if (rollF[6] >= 2 && rollF[6] <= 4) // いぬ、さる、きじ
                {
                    if (StatusSiteF == StatusSiteNum)
                    {
                        TargetSiteOrderNum = TurnChip_F;  // 今狙われているエイムサイトは SiteF
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            RollFNum = rollF[6];  // 現在エイムされているサイトの役わり が サイトF の役割 に上書きあれる
                            TN = -1;
                        }
                    }
                }
            }
            else if (TurnChip_G == TN)
            {
                if (rollF[7] >= 2 && rollF[7] <= 4) // いぬ、さる、きじ
                {
                    if (StatusSiteG == StatusSiteNum)
                    {
                        TargetSiteOrderNum = TurnChip_G;  // 今狙われているエイムサイトは SiteG
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            RollFNum = rollF[7];  // 現在エイムされているサイトの役わり が サイトG の役割 に上書きあれる
                            TN = -1;
                        }
                    }
                }
            }
            else if (TurnChip_H == TN)
            {
                if (rollF[8] >= 2 && rollF[8] <= 4) // いぬ、さる、きじ
                {
                    if (StatusSiteH == StatusSiteNum)
                    {
                        TargetSiteOrderNum = TurnChip_H;  // 今狙われているエイムサイトは SiteH
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            RollFNum = rollF[8];  // 現在エイムされているサイトの役わり が サイトH の役割 に上書きあれる
                            TN = -1;
                        }
                    }
                }
            }

            if (TN == -1)  // いぬ、さる、きじ が見つかったら
            {
                PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
            }
        }
    }


    public void SearchMomotaroCommon(int StatusSiteNum)  // 現在、ももたろう が 指定されたステータス（= StatusSiteNum） であるかチェックする （3ターン目で、行動済みのキャラに対してはエイムしない）
    {
        if (rollF[1] == 5) // ももたろう
        {
            if (StatusSiteA == StatusSiteNum)  // ももたろう が 指定されたステータス である
            {
                TargetSiteOrderNum = TurnChip_A;  // 今狙われているエイムサイトは SiteA
                HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                {
                    RollFNum = rollF[1];  // 現在エイムされているサイトの役わり が サイトA の役割 に上書きあれる
                    PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
                }
            }
        }
        else if (rollF[2] == 5) // ももたろう
        {
            if (StatusSiteB == StatusSiteNum)
            {
                TargetSiteOrderNum = TurnChip_B;  // 今狙われているエイムサイトは SiteB
                HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                {
                    RollFNum = rollF[2];
                    PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
                }
            }
        }
        else if (rollF[3] == 5) // ももたろう
        {
            if (StatusSiteC == StatusSiteNum)
            {
                TargetSiteOrderNum = TurnChip_C;  // 今狙われているエイムサイトは SiteC
                HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                {
                    RollFNum = rollF[3];
                    PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
                }
            }
        }
        else if (rollF[4] == 5) // ももたろう
        {
            if (StatusSiteD == StatusSiteNum)
            {
                TargetSiteOrderNum = TurnChip_D;  // 今狙われているエイムサイトは SiteD
                HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                {
                    RollFNum = rollF[4];
                    PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
                }
            }
        }
        else if (rollF[5] == 5) // ももたろう
        {
            if (StatusSiteE == StatusSiteNum)
            {
                TargetSiteOrderNum = TurnChip_E;  // 今狙われているエイムサイトは SiteE
                HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                {
                    RollFNum = rollF[5];
                    PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
                }
            }
        }
        else if (rollF[6] == 5) // ももたろう
        {
            if (StatusSiteF == StatusSiteNum)
            {
                TargetSiteOrderNum = TurnChip_F;  // 今狙われているエイムサイトは SiteF
                HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                {
                    RollFNum = rollF[6];
                    PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
                }
            }
        }
        else if (rollF[7] == 5) // ももたろう
        {
            if (StatusSiteG == StatusSiteNum)
            {
                TargetSiteOrderNum = TurnChip_G;  // 今狙われているエイムサイトは SiteG
                HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                {
                    RollFNum = rollF[7];
                    PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
                }
            }
        }
        else if (rollF[8] == 5) // ももたろう
        {
            if (StatusSiteH == StatusSiteNum)
            {
                TargetSiteOrderNum = TurnChip_H;  // 今狙われているエイムサイトは SiteH
                HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                {
                    RollFNum = rollF[8];
                    PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
                }
            }
        }
    }


    public void SearchMomoOniCommon(int StatusSiteNum)  // ステータスが 指定された状態であり ＆ 役割が いぬ・さる・きじ・こおにたち のキャラがいるか探す
    {
        for (int TN = 8; TN > 0; TN--)  // 順番マーカーが 8 のものからチェック
        {
            if (TurnChip_A == TN)       // サイトAの順番マーカーがTN番である
            {
                if (rollF[1] != 1 && rollF[1] != 5) // 役割が いぬ・さる・きじ・こおにたち
                {
                    if (StatusSiteA == StatusSiteNum)  // ステータスが 指定された状態である (2:木札ON)
                    {
                        RollFNum = rollF[1];  // 現在エイムされているサイトの役わり が サイトA の役割 に上書きあれる
                        TN = -1;
                    }
                }
            }
            else if (TurnChip_B == TN)
            {
                if (rollF[2] != 1 && rollF[2] != 5) // 役割が いぬ・さる・きじ・こおにたち
                {
                    if (StatusSiteB == StatusSiteNum)
                    {
                        RollFNum = rollF[2];
                        TN = -1;
                    }
                }
            }
            else if (TurnChip_C == TN)
            {
                if (rollF[3] != 1 && rollF[3] != 5) // 役割が いぬ・さる・きじ・こおにたち
                {
                    if (StatusSiteC == StatusSiteNum)
                    {
                        RollFNum = rollF[3];
                        TN = -1;
                    }
                }
            }
            else if (TurnChip_D == TN)
            {
                if (rollF[4] != 1 && rollF[4] != 5) // 役割が いぬ・さる・きじ・こおにたち
                {
                    if (StatusSiteD == StatusSiteNum)
                    {
                        RollFNum = rollF[4];
                        TN = -1;
                    }
                }
            }
            else if (TurnChip_E == TN)
            {
                if (rollF[5] != 1 && rollF[5] != 5) // 役割が いぬ・さる・きじ・こおにたち
                {
                    if (StatusSiteE == StatusSiteNum)
                    {
                        RollFNum = rollF[5];
                        TN = -1;
                    }
                }
            }
            else if (TurnChip_F == TN)
            {
                if (rollF[6] != 1 && rollF[6] != 5) // 役割が いぬ・さる・きじ・こおにたち
                {
                    if (StatusSiteF == StatusSiteNum)
                    {
                        RollFNum = rollF[6];
                        TN = -1;
                    }
                }
            }
            else if (TurnChip_G == TN)
            {
                if (rollF[7] != 1 && rollF[7] != 5) // 役割が いぬ・さる・きじ・こおにたち
                {
                    if (StatusSiteG == StatusSiteNum)
                    {
                        RollFNum = rollF[7];
                        TN = -1;
                    }
                }
            }
            else if (TurnChip_H == TN)
            {
                if (rollF[8] != 1 && rollF[8] != 5) // 役割が いぬ・さる・きじ・こおにたち
                {
                    if (StatusSiteH == StatusSiteNum)
                    {
                        RollFNum = rollF[8];
                        TN = -1;
                    }
                }
            }
            if (TN == -1)  // いずれか一名を指名したら（条件に合うキャラが見つかったら）
            {
                PushedBtnFlg = 1;  // 処理を実施したかどうか → オンにする
            }
        }
    }
       
    public void UkkariAte()   // うっかり桃メイト（木札ON） がいるなら → 役割当て （3ターン目で、行動済みのキャラに対してはエイムしない）
    {
        if (PushedBtnFlg == 0)  // 処理を実施したかどうか
        {
            if (UkkariSite[1] == 1)    // *うっかりフラグが1のものが 存在する
            {
                if (StatusSiteA == 2)  // うっかりサイトのステータスが木札ON（ステータス2）である
                {
                    if (rollF[1] >= 2 && rollF[1] <= 4) // 役割が いぬ、さる、きじ のどれかである
                    {
                        TargetSiteOrderNum = TurnChip_A;  // 今狙われているエイムサイトは SiteA
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            PushYakuwariBtn_Common(rollF[1]);     // その木札ONのサイトの役割を当てる(2,3,4 の いずれかが入る)
                            PushedBtnFlg = 1;  // 処理を実施したかどうか
                            UkkariSite[1] = -1;  // うっかり当て処理を実施済み のしるし
                        }
                    }
                }
            }
        }
        if (PushedBtnFlg == 0)  // 処理を実施したかどうか
        {
            if (UkkariSite[2] == 1)    // *うっかりフラグが1のものが 存在する
            {
                if (StatusSiteB == 2)  // うっかりサイトのステータスが木札ON（ステータス2）である
                {
                    if (rollF[2] >= 2 && rollF[2] <= 4) // 役割が いぬ、さる、きじ のどれかである
                    {
                        TargetSiteOrderNum = TurnChip_B;  // 今狙われているエイムサイトは SiteB
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            PushYakuwariBtn_Common(rollF[2]);     // その木札ONのサイトの役割を当てる(2,3,4 の いずれかが入る)
                            PushedBtnFlg = 1;  // 処理を実施したかどうか
                            UkkariSite[2] = -1;  // うっかり当て処理を実施済み のしるし
                        }
                    }
                }
            }
        }
        if (PushedBtnFlg == 0)  // 処理を実施したかどうか
        {
            if (UkkariSite[3] == 1)    // *うっかりフラグが1のものが 存在する
            {
                if (StatusSiteC == 2)  // うっかりサイトのステータスが木札ON（ステータス2）である
                {
                    if (rollF[3] >= 2 && rollF[3] <= 4) // 役割が いぬ、さる、きじ のどれかである
                    {
                        TargetSiteOrderNum = TurnChip_C;  // 今狙われているエイムサイトは SiteC
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            PushYakuwariBtn_Common(rollF[3]);     // その木札ONのサイトの役割を当てる(2,3,4 の いずれかが入る)
                            PushedBtnFlg = 1;  // 処理を実施したかどうか
                            UkkariSite[3] = -1;  // うっかり当て処理を実施済み のしるし
                        }
                    }
                }
            }
        }
        if (PushedBtnFlg == 0)  // 処理を実施したかどうか
        {
            if (UkkariSite[4] == 1)    // *うっかりフラグが1のものが 存在する
            {
                if (StatusSiteD == 2)  // うっかりサイトのステータスが木札ON（ステータス2）である
                {
                    if (rollF[4] >= 2 && rollF[4] <= 4) // 役割が いぬ、さる、きじ のどれかである
                    {
                        TargetSiteOrderNum = TurnChip_D;  // 今狙われているエイムサイトは SiteD
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            PushYakuwariBtn_Common(rollF[4]);     // その木札ONのサイトの役割を当てる(2,3,4 の いずれかが入る)
                            PushedBtnFlg = 1;  // 処理を実施したかどうか
                            UkkariSite[4] = -1;  // うっかり当て処理を実施済み のしるし
                        }
                    }
                }
            }
        }
        if (PushedBtnFlg == 0)  // 処理を実施したかどうか
        {
            if (UkkariSite[5] == 1)    // *うっかりフラグが1のものが 存在する
            {
                if (StatusSiteE == 2)  // うっかりサイトのステータスが木札ON（ステータス2）である
                {
                    if (rollF[5] >= 2 && rollF[5] <= 4) // 役割が いぬ、さる、きじ のどれかである
                    {
                        TargetSiteOrderNum = TurnChip_E;  // 今狙われているエイムサイトは SiteE
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            PushYakuwariBtn_Common(rollF[5]);     // その木札ONのサイトの役割を当てる(2,3,4 の いずれかが入る)
                            PushedBtnFlg = 1;  // 処理を実施したかどうか
                            UkkariSite[5] = -1;  // うっかり当て処理を実施済み のしるし
                        }
                    }
                }
            }
        }
        if (PushedBtnFlg == 0)  // 処理を実施したかどうか
        {
            if (UkkariSite[6] == 1)    // *うっかりフラグが1のものが 存在する
            {
                if (StatusSiteF == 2)  // うっかりサイトのステータスが木札ON（ステータス2）である
                {
                    if (rollF[6] >= 2 && rollF[6] <= 4) // 役割が いぬ、さる、きじ のどれかである
                    {
                        TargetSiteOrderNum = TurnChip_F;  // 今狙われているエイムサイトは SiteF
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            PushYakuwariBtn_Common(rollF[6]);     // その木札ONのサイトの役割を当てる(2,3,4 の いずれかが入る)
                            PushedBtnFlg = 1;  // 処理を実施したかどうか
                            UkkariSite[6] = -1;  // うっかり当て処理を実施済み のしるし
                        }
                    }
                }
            }
        }
        if (PushedBtnFlg == 0)  // 処理を実施したかどうか
        {
            if (UkkariSite[7] == 1)    // *うっかりフラグが1のものが 存在する
            {
                if (StatusSiteG == 2)  // うっかりサイトのステータスが木札ON（ステータス2）である
                {
                    if (rollF[7] >= 2 && rollF[7] <= 4) // 役割が いぬ、さる、きじ のどれかである
                    {
                        TargetSiteOrderNum = TurnChip_G;  // 今狙われているエイムサイトは SiteG
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            PushYakuwariBtn_Common(rollF[7]);     // その木札ONのサイトの役割を当てる(2,3,4 の いずれかが入る)
                            PushedBtnFlg = 1;  // 処理を実施したかどうか
                            UkkariSite[7] = -1;  // うっかり当て処理を実施済み のしるし
                        }
                    }
                }
            }
        }
        if (PushedBtnFlg == 0)  // 処理を実施したかどうか
        {
            if (UkkariSite[8] == 1)    // *うっかりフラグが1のものが 存在する
            {
                if (StatusSiteH == 2)  // うっかりサイトのステータスが木札ON（ステータス2）である
                {
                    if (rollF[8] >= 2 && rollF[8] <= 4) // 役割が いぬ、さる、きじ のどれかである
                    {
                        TargetSiteOrderNum = TurnChip_H;  // 今狙われているエイムサイトは SiteH
                        HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
                        if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
                        {
                            PushYakuwariBtn_Common(rollF[8]);     // その木札ONのサイトの役割を当てる(2,3,4 の いずれかが入る)
                            PushedBtnFlg = 1;  // 処理を実施したかどうか
                            UkkariSite[8] = -1;  // うっかり当て処理を実施済み のしるし
                        }
                    }
                }
            }
        }
    }

    public void HanteiWorthAiming()  // そのエイムサイトが、もう手番を終えているか確認 →終えていたら攻撃する価値なし
    {
        WorthAiming = 1;  // そのエイムサイトが、狙う（攻撃する）価値があるか → ある に初期化
        if (preventTurnNum == 3)  //  現在、3ターン目であるならば
        {
            if (TargetSiteOrderNum > preventPlayerOrderNum)  // エイムサイトの手番がまだこれからである
            {
                WorthAiming = 1;  // そのエイムサイトを、狙う（攻撃する）価値があるか → ある
            }
            else  // エイムサイトの手番はもう終了している
            {
                WorthAiming = 0;  // そのエイムサイトを、狙う（攻撃する）価値があるか → ない
            }
        }
    }

    public void CheckTargetSiteOrderNum()  // 現在エイムされているサイトの手番は、このターンの何人目か？ を調べる
    {
        Debug.Log("preventPlayerOrderNum：今このターンで何人目か？ " + preventPlayerOrderNum);
        Debug.Log("TargetSiteNum：現在エイムされているサイトがどこか？ " + TargetSiteNum);

        if (TargetSiteNum == 1)
        {
            TargetSiteOrderNum = TurnChip_A;  // 今狙われているエイムサイトは SiteA
        }
        else if (TargetSiteNum == 2)
        {
            TargetSiteOrderNum = TurnChip_B;  // 今狙われているエイムサイトは SiteB
        }
        else if (TargetSiteNum == 3)
        {
            TargetSiteOrderNum = TurnChip_C;  // 今狙われているエイムサイトは SiteC
        }
        else if (TargetSiteNum == 4)
        {
            TargetSiteOrderNum = TurnChip_D;  // 今狙われているエイムサイトは SiteD
        }
        else if (TargetSiteNum == 5)
        {
            TargetSiteOrderNum = TurnChip_E;  // 今狙われているエイムサイトは SiteE
        }
        else if (TargetSiteNum == 6)
        {
            TargetSiteOrderNum = TurnChip_F;  // 今狙われているエイムサイトは SiteF
        }
        else if (TargetSiteNum == 7)
        {
            TargetSiteOrderNum = TurnChip_G;  // 今狙われているエイムサイトは SiteG
        }
        else if (TargetSiteNum == 8)
        {
            TargetSiteOrderNum = TurnChip_H;  // 今狙われているエイムサイトは SiteH
        }

        Debug.Log("TargetSiteOrderNum：今狙われているエイムサイトの手番は " + TargetSiteOrderNum);
    }


    public void KifudaOnMomojiAte()  // 桃太郎が 木札ON(ももじ)なら → 役割当て （3ターン目で、行動済みのキャラに対してはエイムしない）
    {
        TargetSiteOrderNum = 0;  // オーダーナンバーを初期化（0のままでは意味をなさない）
        if (rollF[1] == 1) // ももたろう
        {
            if (StatusSiteA == 2)  // ももたろう が 木札ON
            {
                TargetSiteOrderNum = TurnChip_A;  // 今狙われているエイムサイトは SiteA
            }
        }
        else if (rollF[2] == 1) // ももたろう
        {
            if (StatusSiteB == 2)
            {
                TargetSiteOrderNum = TurnChip_B;  // 今狙われているエイムサイトは SiteB
            }
        }
        else if (rollF[3] == 1) // ももたろう
        {
            if (StatusSiteC == 2)
            {
                TargetSiteOrderNum = TurnChip_C;  // 今狙われているエイムサイトは SiteC
            }
        }
        else if (rollF[4] == 1) // ももたろう
        {
            if (StatusSiteD == 2)
            {
                TargetSiteOrderNum = TurnChip_D;  // 今狙われているエイムサイトは SiteD
            }
        }
        else if (rollF[5] == 1) // ももたろう
        {
            if (StatusSiteE == 2)
            {
                TargetSiteOrderNum = TurnChip_E;  // 今狙われているエイムサイトは SiteE
            }
        }
        else if (rollF[6] == 1) // ももたろう
        {
            if (StatusSiteF == 2)
            {
                TargetSiteOrderNum = TurnChip_F;  // 今狙われているエイムサイトは SiteF
            }
        }
        else if (rollF[7] == 1) // ももたろう
        {
            if (StatusSiteG == 2)
            {
                TargetSiteOrderNum = TurnChip_G;  // 今狙われているエイムサイトは SiteG
            }
        }
        else if (rollF[8] == 1) // ももたろう
        {
            if (StatusSiteH == 2)
            {
                TargetSiteOrderNum = TurnChip_H;  // 今狙われているエイムサイトは SiteH
            }
        }

        if (TargetSiteOrderNum != 0)    // オーダーナンバーが初期値（ゼロ）から変化している（エイムする一段階目の条件を満たしている）
        {
            HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたらエイムする価値なし
            if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
            {
                PushYakuwariBtn_Common(1);  // M-2：この場合は「役割あて」ボタン
                PushedBtnFlg = 1;  // 処理を実施したかどうか
            }
        }
    }


    public void Sum_InokoriMate()   // 居残りメイトの合計を求める
    {
        InokoriMate = 0;  // ステータス2以下 & 桃メイト の総数_初期化
            if (StatusSiteA <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[1] >= 2 && rollF[1] <= 4) // 役割が いぬ、さる、きじ のどれかである
            {
                InokoriMate++;
            }
        }
        if (StatusSiteB <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[2] >= 2 && rollF[2] <= 4) // 役割が いぬ、さる、きじ のどれかである
            {
                InokoriMate++;
            }
        }
        if (StatusSiteC <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[3] >= 2 && rollF[3] <= 4) // 役割が いぬ、さる、きじ のどれかである
            {
                InokoriMate++;
            }
        }
        if (StatusSiteD <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[4] >= 2 && rollF[4] <= 4) // 役割が いぬ、さる、きじ のどれかである
            {
                InokoriMate++;
            }
        }
        if (StatusSiteE <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[5] >= 2 && rollF[5] <= 4) // 役割が いぬ、さる、きじ のどれかである
            {
                InokoriMate++;
            }
        }
        if (StatusSiteF <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[6] >= 2 && rollF[6] <= 4) // 役割が いぬ、さる、きじ のどれかである
            {
                InokoriMate++;
            }
        }
        if (StatusSiteG <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[7] >= 2 && rollF[7] <= 4) // 役割が いぬ、さる、きじ のどれかである
            {
                InokoriMate++;
            }
        }
        if (StatusSiteH <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[8] >= 2 && rollF[8] <= 4) // 役割が いぬ、さる、きじ のどれかである
            {
                InokoriMate++;
            }
        }
        Debug.Log("居残りメイトの合計(InokoriMate) = " + InokoriMate);
    }


    public void Sum_InokoriKooni()   // 居残りこおにの合計を求める
    {
        InokoriKooni = 0;  // ステータス2以下 & こおに の総数_初期化
            if (StatusSiteA <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[1] >= 6 && rollF[1] <= 8) // 役割が こおに である
            {
                InokoriKooni++;
            }
        }
        if (StatusSiteB <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[2] >= 6 && rollF[2] <= 8) // 役割が こおに である
            {
                InokoriKooni++;
            }
        }
        if (StatusSiteC <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[3] >= 6 && rollF[3] <= 8) // 役割が こおに である
            {
                InokoriKooni++;
            }
        }
        if (StatusSiteD <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[4] >= 6 && rollF[4] <= 8) // 役割が こおに である
            {
                InokoriKooni++;
            }
        }
        if (StatusSiteE <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[5] >= 6 && rollF[5] <= 8) // 役割が こおに である
            {
                InokoriKooni++;
            }
        }
        if (StatusSiteF <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[6] >= 6 && rollF[6] <= 8) // 役割が こおに である
            {
                InokoriKooni++;
            }
        }
        if (StatusSiteG <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[7] >= 6 && rollF[7] <= 8) // 役割が こおに である
            {
                InokoriKooni++;
            }
        }
        if (StatusSiteH <= 2)  // ステータスが2以下の 居残り組
        {
            if (rollF[8] >= 6 && rollF[8] <= 8) // 役割が こおに である
            {
                InokoriKooni++;
            }
        }
        Debug.Log("居残りこおにの合計(InokoriKooni) = " + InokoriKooni);
    }


    public void KifudaOffMomoteamAte()  // 桃チームが 木札OFFなら → 役割当て
    {
        if (KurunProgressTotal == 7) // 他のキャラが全部オープン済みで 一つだけデフォルト（札無し）で残っている ◆場の全体を見て その役割 だと判明した場合
        {
            Debug.Log("他のキャラが全部カードオープンで 、その役割カード だけ 札無しで残っている");
            PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン
        }
        else if (KurunProgressTotal == 6) // 自分が こおに で、木札無しが 2人いる（他のキャラは全部オープン済み） ◆場の全体を見て その役割 だと判明した場合
        {
            if (NowActiveSiteStatus == 1)  // こおに（自分）が木札無し
            {
                int FindMomomateFlg = 0; // 条件に合う桃メイトがいるかどうか
                if (rollF[1] >= 6 && rollF[1] <= 8) // 役割が こオニ である
                {
                    if (StatusSiteA == 1)  //  状態（ステータス）が木札無し（デフォルト）
                    {
                        FindMomomateFlg = 1;
                    }
                }
                if (rollF[2] >= 6 && rollF[2] <= 8) // 役割が こオニ である
                {
                    if (StatusSiteB == 1)  //  状態（ステータス）が木札無し（デフォルト）
                    {
                        FindMomomateFlg = 1;
                    }
                }
                if (rollF[3] >= 6 && rollF[3] <= 8) // 役割が こオニ である
                {
                    if (StatusSiteC == 1)  //  状態（ステータス）が木札無し（デフォルト）
                    {
                        FindMomomateFlg = 1;
                    }
                }
                if (rollF[4] >= 6 && rollF[4] <= 8) // 役割が こオニ である
                {
                    if (StatusSiteD == 1)  //  状態（ステータス）が木札無し（デフォルト）
                    {
                        FindMomomateFlg = 1;
                    }
                }
                if (rollF[5] >= 6 && rollF[5] <= 8) // 役割が こオニ である
                {
                    if (StatusSiteE == 1)  //  状態（ステータス）が木札無し（デフォルト）
                    {
                        FindMomomateFlg = 1;
                    }
                }
                if (rollF[6] >= 6 && rollF[6] <= 8) // 役割が こオニ である
                {
                    if (StatusSiteF == 1)  //  状態（ステータス）が木札無し（デフォルト）
                    {
                        FindMomomateFlg = 1;
                    }
                }
                if (rollF[7] >= 6 && rollF[7] <= 8) // 役割が こオニ である
                {
                    if (StatusSiteG == 1)  //  状態（ステータス）が木札無し（デフォルト）
                    {
                        FindMomomateFlg = 1;
                    }
                }
                if (rollF[8] >= 6 && rollF[8] <= 8) // 役割が こオニ である
                {
                    if (StatusSiteH == 1)  //  状態（ステータス）が木札無し（デフォルト）
                    {
                        FindMomomateFlg = 1;
                    }
                }

                if (FindMomomateFlg == 1)  // 条件に合う桃メイトがいたら
                {
                    Debug.Log("自分が こおに で、木札無しが自分と もう1人（桃チーム）いる（他のキャラは全部オープン済み）");
                    PushYakuwariBtn_Common(RollFNum);  // M-2：この場合は「役割あて」ボタン
                }
            }
        }
        else
        {
            PushedBtnFlg = 0;  // 条件を満たしていなければ、フラグをリセット（次に進む）
        }
    }

    public void CheckAttackToMomocchi()  // 桃太郎が 残りHP1(ももっち)で条件を満たせば攻撃 or 条件を満たさなければスルー （3ターン目で、行動済みのキャラに対してはエイムしない）
    {
        TargetSiteOrderNum = 0;  // オーダーナンバーを初期化（0のままでは意味をなさない）
        if (rollF[1] == 1) // ももたろう
        {
            if (HPMSC.HP_A == 1)
            {
                TargetSiteOrderNum = TurnChip_A;  // 今狙われているエイムサイトは SiteA
            }
        }
        else if (rollF[2] == 1) // ももたろう
        {
            if (HPMSC.HP_B == 1)
            {
                TargetSiteOrderNum = TurnChip_B;  // 今狙われているエイムサイトは SiteB
            }
        }
        else if (rollF[3] == 1) // ももたろう
        {
            if (HPMSC.HP_C == 1)
            {
                TargetSiteOrderNum = TurnChip_C;  // 今狙われているエイムサイトは SiteC
            }
        }
        else if (rollF[4] == 1) // ももたろう
        {
            if (HPMSC.HP_D == 1)
            {
                TargetSiteOrderNum = TurnChip_D;  // 今狙われているエイムサイトは SiteD
            }
        }
        else if (rollF[5] == 1) // ももたろう
        {
            if (HPMSC.HP_E == 1)
            {
                TargetSiteOrderNum = TurnChip_E;  // 今狙われているエイムサイトは SiteE
            }
        }
        else if (rollF[6] == 1) // ももたろう
        {
            if (HPMSC.HP_F == 1)
            {
                TargetSiteOrderNum = TurnChip_F;  // 今狙われているエイムサイトは SiteF
            }
        }
        else if (rollF[7] == 1) // ももたろう
        {
            if (HPMSC.HP_G == 1)
            {
                TargetSiteOrderNum = TurnChip_G;  // 今狙われているエイムサイトは SiteG
            }
        }
        else if (rollF[8] == 1) // ももたろう
        {
            if (HPMSC.HP_H == 1)
            {
                TargetSiteOrderNum = TurnChip_H;  // 今狙われているエイムサイトは SiteH
            }
        }

        if (TargetSiteOrderNum != 0)    // オーダーナンバーが初期値（ゼロ）から変化している（エイムする一段階目の条件を満たしている）
        {
            HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたら攻撃する価値なし
            if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
            {
                AttackToMomotaro();  // ももたろう に攻撃(CPU)
                PushedBtnFlg = 1;  // 処理を実施したかどうか
            }
        }
    }
    
    public void CheckAttackToMomoji()  // 桃太郎が 役割オープン（HP2：ももじ）なら 攻撃  or 条件を満たさなければスルー （3ターン目で、行動済みのキャラに対してはエイムしない）
    {
        TargetSiteOrderNum = 0;  // オーダーナンバーを初期化（0のままでは意味をなさない）
        if (rollF[1] == 1) // ももたろう
        {
            if (StatusSiteA == 4)  // ももたろう が 役割オープン
            {
                TargetSiteOrderNum = TurnChip_A;  // 今狙われているエイムサイトは SiteA
            }
        }
        else if (rollF[2] == 1) // ももたろう
        {
            if (StatusSiteB == 4)
            {
                TargetSiteOrderNum = TurnChip_B;  // 今狙われているエイムサイトは SiteB
            }
        }
        else if (rollF[3] == 1) // ももたろう
        {
            if (StatusSiteC == 4)
            {
                TargetSiteOrderNum = TurnChip_C;  // 今狙われているエイムサイトは SiteC
            }
        }
        else if (rollF[4] == 1) // ももたろう
        {
            if (StatusSiteD == 4)
            {
                TargetSiteOrderNum = TurnChip_D;  // 今狙われているエイムサイトは SiteD
            }
        }
        else if (rollF[5] == 1) // ももたろう
        {
            if (StatusSiteE == 4)
            {
                TargetSiteOrderNum = TurnChip_E;  // 今狙われているエイムサイトは SiteE
            }
        }
        else if (rollF[6] == 1) // ももたろう
        {
            if (StatusSiteF == 4)
            {
                TargetSiteOrderNum = TurnChip_F;  // 今狙われているエイムサイトは SiteF
            }
        }
        else if (rollF[7] == 1) // ももたろう
        {
            if (StatusSiteG == 4)
            {
                TargetSiteOrderNum = TurnChip_G;  // 今狙われているエイムサイトは SiteG
            }
        }
        else if (rollF[8] == 1) // ももたろう
        {
            if (StatusSiteH == 4)
            {
                TargetSiteOrderNum = TurnChip_H;  // 今狙われているエイムサイトは SiteH
            }
        }

        if (TargetSiteOrderNum != 0)    // オーダーナンバーが初期値（ゼロ）から変化している（エイムする一段階目の条件を満たしている）
        {
            HanteiWorthAiming();  // そのエイムサイトが、もう手番を終えているか確認 →終えていたら攻撃する価値なし
            if (WorthAiming == 1)  // エイムする二段階目の条件を満たしている
            {
                AttackToMomotaro();  // ももたろう に攻撃(CPU)
                PushedBtnFlg = 1;  // 処理を実施したかどうか
            }
        }
    }



    public void AttackToMomotaro()
    {
        Debug.Log("ももたろう に攻撃");
        AttackToHogeCommon(1);
    }

    public void AttackToMomoMate()
    {
        Debug.Log("ももたろうの 仲間 に攻撃");
        AttackToHogeCommon(RollFNum);  // RollFNum に いぬ、さる、きじ のいずれかが入っている
    }

    public void AttackToHogeCommon(int AiteTeamMate)  // AiteTeamMate：相手のチームメイトの役割 に対して攻撃する
    {
        var sequence = DOTween.Sequence();
        ButtonCscr.BranchOpenAttack();  // M-3：この場合は「こうげき」ボタン
        CloseBrownBoxCommon();  // OKボタン 押下で BrownBox 閉じる
        sequence.InsertCallback(2f, () => YouAreHoge(AiteTeamMate));  // エイムセレクト画面で 相手 を選択する
        sequence.InsertCallback(4f, () => YouAreHoge2_Attack());  // OKボタン 押下で 攻撃
        sequence.InsertCallback(8f, () => YouAreHoge3_Attack());  // OKボタン 押下で ウインドウ 閉じる
    }

    public void AfterPushActButtonCommon()  // 各行動ボタン押下後の共通処理
    {
        ClosePanelBattleFieldBox();
        selectTimeEnd();
        AddplayerOrderNum();
        CharaMSC.OpenPanelYourTurn();
        CharaMSC.AppearNowActiveSite();
        CheckYourTurn();
    }


    public void AppearNext_InfoCPUWillOperate()  //  CPUがこれから操作する旨を画面中央にメッセージ表示（予告）
    {
        Next_InfoCPUWillOperate.SetActive(true);
    }

    public void CloseNext_InfoCPUWillOperate()
    {
        Next_InfoCPUWillOperate.SetActive(false);
    }

    #endregion





    //#################################################################################

}
// End