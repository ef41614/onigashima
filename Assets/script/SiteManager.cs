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
    public int MakuMoveMode = 0;  // 0:停止, 1:右（オープン）, 2:左（）クローズ
    public GameObject ImagePole_Right;
    public GameObject ImagePole_Left;
    Vector2 PoleRightPos;
    Vector2 PoleLeftPos;

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
        //        statusReset(); // ステータスをすべて1にする
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

        PoleRightPos = ImagePole_Right.gameObject.transform.position;
        PoleLeftPos = ImagePole_Left.gameObject.transform.position;
        FirstCheckCPU_Operation();  // 各サイトがCPUであるかどうかのチェック（初回のみ一回確認）
    }


    //####################################  Update  ###################################

    void Update()
    {
//        Debug.Log("MenuButtonMode？ " + MenuButtonMode);
               
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


        if (Position.x <= PoleRightPos.x && MakuMoveMode == 1)
        {
            Position.x += 2.0f;  // 右に幕を移動（開ける）
        }
        if (Position.x >= PoleLeftPos.x && MakuMoveMode == 2)
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

    public void CheckCanPushQuestion()
    {
//        CanPush_Question = true;  // しつもんモードボタンは押せる(一旦状態リセット)
        Debug.Log("■CheckCanPushQuestion");
        Debug.Log("◆◎NowActiveSiteN：" + NowActiveSiteN);

        if (StatusSiteA < 2 || StatusSiteB < 2 || StatusSiteC < 2 || StatusSiteD < 2 || StatusSiteE < 2 || StatusSiteF < 2 || StatusSiteG < 2 || StatusSiteH < 2)
        {   // もしまだ木札がONになっていないキャラが一人以上いるならば
            // フリーなのが自分だけしか残っていない場合 → 選択できないようにする
            // フリーなのが自分以外である → 行動ボタンは押せる
            CanPush_Question = CheckCanPushButton_Common(2, CanPush_Question);
        }
        else
        {
            CanPush_Question = false;  // しつもんモードボタンは押せない
        }
    }

    public void CheckCanPushUnmask()
    {
        if (StatusSiteA < 4 || StatusSiteB < 4 || StatusSiteC < 4 || StatusSiteD < 4 || StatusSiteE < 4 || StatusSiteF < 4 || StatusSiteG < 4 || StatusSiteH < 4)
        {   // もしまだ役割が当てられていないキャラが一人以上いるならば
            CanPush_Unmask = true;  // 役割当てモードボタンは押せる
        }
        else
        {
            CanPush_Unmask = false;  // 役割当てモードボタンは押せない
        }
    }

    public void CheckCanPushAttack()
    {
        if (StatusSiteA == 4 || StatusSiteB == 4 || StatusSiteC == 4 || StatusSiteD == 4 || StatusSiteE == 4 || StatusSiteF == 4 || StatusSiteG == 4 || StatusSiteH == 4)
        {   // もし役割が当てられており、かつ元気なキャラが一人以上いるならば
            CanPush_Attack = true;  // 攻撃モードボタンは押せる
        }
        else
        {
            CanPush_Attack = false;  // 攻撃モードボタンは押せない
        }
    }

    public bool CheckCanPushButton_Common(int statusNum, bool CanPush_ActButton) // フリーなのが自分だけ → 選択できない || フリーなのが自分以外 → 行動ボタンは押せる
    {
        if (NowActiveSiteN == 1)  // 今のアクティブサイトがサイトA
        {
            if (StatusSiteA < statusNum && StatusSiteB >= statusNum && StatusSiteC >= statusNum && StatusSiteD >= statusNum && StatusSiteE >= statusNum && StatusSiteF >= statusNum && StatusSiteG >= statusNum && StatusSiteH >= statusNum)
            {  // フリーなのが自分だけしか残っていない
                CanPush_ActButton = false;  // 今選んでいる行動ボタンは押せない
            }
            else  // フリーなのが自分以外である
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
            if (UkkariSerif == 1)
            {
                AnswerSerifText.GetComponent<Text>().text = "カレー たべたいな オニ";
            }
            else
            {
                AnswerSerifText.GetComponent<Text>().text = "カレー たべたいな";
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

    public void JudgeHitting()   // ★更新
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
            WinFlgON = 1;  // 1で勝利フラグが立った （勝利時演出のダブり防止策）
            StartWinPhase();
            TeamHanteiAll();
            CheckWinTeam(1); // チームナンバー： 1（おにチーム）
            ApperWinOni();
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
            AppearNext_InfoCPUWillOperate();  //  CPUがこれから操作する旨を画面中央にメッセージ表示
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
        AppearInfoCPU();  // 「CPU そうさ中」のメッセージを表示（ON）
                          // 行動ボタン、いずれか押下
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

    public void AppearInfoCPU()
    {
        PanelInfoCPU.SetActive(true);
    }

    public void CloseInfoCPU()
    {
        PanelInfoCPU.SetActive(false);
    }

    public void AppearNext_InfoCPUWillOperate()
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