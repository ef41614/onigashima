using System.Collections;
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
    public GameObject TurnMarkManager;
    TurnMarkManager TurnMarkMSC;
    public GameObject YakuManager;
    YakuManager YakuMSC;

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

    public Image SiteA_charaF_Copy;
    public Image SiteB_charaF_Copy;
    public Image SiteC_charaF_Copy;
    public Image SiteD_charaF_Copy;
    public Image SiteE_charaF_Copy;
    public Image SiteF_charaF_Copy;
    public Image SiteG_charaF_Copy;
    public Image SiteH_charaF_Copy;

    public Image PreventCharaFace;
    public GameObject CharaNameText;
    public int countX = 1;

    public Image NowActiveCharaFace;
    public Image NowActiveCharaFace2;
    public GameObject NowActiveCharaNameText;
    public GameObject NowActiveCharaNameText2;
    public GameObject PanelYourTurn;

    public Image AimedCharaFace;
    public GameObject AimedCharaNameText;
    //    public GameObject NowActiveCharaNameText;

    public Image Winner01;  // 結果画面に勝利者を表示
    public Image Winner02;
    public Image Winner03;
    public Image Winner04;

    public int Win01AppearFlg = 0; // Win01がまだ表示されていない
    public int Win02AppearFlg = 0;
    public int Win03AppearFlg = 0;
    public int Win04AppearFlg = 0;



    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        //countX = SiteMSC.human_num;
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        TurnMarkMSC = TurnMarkManager.GetComponent<TurnMarkManager>();
        YakuMSC = YakuManager.GetComponent<YakuManager>();
        //        image = this.GetComponent<Image>();
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

        CopyCharaFace(); // 役わりカードの上にキャラ顔を小さく表示させる
        ResetWinAppearFlg();  // 勝利者表示フラグのリセット
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
//        Debug.Log("★CharaName: "+ CharaName);
//        Debug.Log("★SiteA_charaNametext はじめの: " + SiteA_charaNametext);
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
//        image = PreventCharaFace;

 //       PreventCharaFace.sprite = VTuber_icon1;
 //      image = PreventCharaFace;

    }

    public void AppearNowActiveSite() // 下のスクロール欄と画面中央に現在手番のキャラを表示させる
    {
        Debug.Log("◎●SiteMSC.NowActiveSiteN: " + SiteMSC.NowActiveSiteN);
        switch (SiteMSC.NowActiveSiteN)
        {
            case 1:
                NowActiveCharaFace.sprite = SiteA_charaF.sprite;
                NowActiveCharaFace2.sprite = SiteA_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteA_charaNametext;
                NowActiveCharaNameText2.GetComponent<Text>().text = SiteA_charaNametext;
                break;
            case 2:
                NowActiveCharaFace.sprite = SiteB_charaF.sprite;
                NowActiveCharaFace2.sprite = SiteB_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteB_charaNametext;
                NowActiveCharaNameText2.GetComponent<Text>().text = SiteB_charaNametext;
                break;
            case 3:
                NowActiveCharaFace.sprite = SiteC_charaF.sprite;
                NowActiveCharaFace2.sprite = SiteC_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteC_charaNametext;
                NowActiveCharaNameText2.GetComponent<Text>().text = SiteC_charaNametext;
                break;
            case 4:
                NowActiveCharaFace.sprite = SiteD_charaF.sprite;
                NowActiveCharaFace2.sprite = SiteD_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteD_charaNametext;
                NowActiveCharaNameText2.GetComponent<Text>().text = SiteD_charaNametext;
                break;
            case 5:
                NowActiveCharaFace.sprite = SiteE_charaF.sprite;
                NowActiveCharaFace2.sprite = SiteE_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteE_charaNametext;
                NowActiveCharaNameText2.GetComponent<Text>().text = SiteE_charaNametext;
                break;
            case 6:
                NowActiveCharaFace.sprite = SiteF_charaF.sprite;
                NowActiveCharaFace2.sprite = SiteF_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteF_charaNametext;
                NowActiveCharaNameText2.GetComponent<Text>().text = SiteF_charaNametext;
                break;
            case 7:
                NowActiveCharaFace.sprite = SiteG_charaF.sprite;
                NowActiveCharaFace2.sprite = SiteG_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteG_charaNametext;
                NowActiveCharaNameText2.GetComponent<Text>().text = SiteG_charaNametext;
                break;
            case 8:
                NowActiveCharaFace.sprite = SiteH_charaF.sprite;
                NowActiveCharaFace2.sprite = SiteH_charaF.sprite;
                NowActiveCharaNameText.GetComponent<Text>().text = SiteH_charaNametext;
                NowActiveCharaNameText2.GetComponent<Text>().text = SiteH_charaNametext;
                break;
            default:
                // 処理３
                break;
        }
//        image = NowActiveCharaFace;
        Debug.Log("◎●SiteA_charaNametext: " + SiteA_charaNametext);
//        Debug.Log("◎●NowActiveCharaNameText: " + NowActiveCharaNameText);
    }

    public void OpenPanelYourTurn()
    {
        if (SiteMSC.faintingOccured) // ステータス「気絶した瞬間」のプレイヤーがいる → 気絶処理後に次のターンへ行く
        {
            SiteMSC.KizetuPhase();
            var sequence = DOTween.Sequence();
            sequence.InsertCallback(3.1f, () => PanelYourTurn.SetActive(true));
        }
        else
        {
            //       PanelYourTurn.SetActive(true);
            var sequence = DOTween.Sequence();
            sequence.InsertCallback(1.1f, () => PanelYourTurn.SetActive(true));
        }
        SiteMSC.CheckFainting();
        TurnMarkMSC.ResetTurnMarkRedBack();
        var sequence2 = DOTween.Sequence();
//        sequence2.InsertCallback(1.0f, () => SiteMSC.CheckNowActiveSite_isCPU());
  //      sequence2.InsertCallback(1.0f, () => SiteMSC.GoStartCPU_ON());
    //    sequence2.InsertCallback(1.0f, () => SiteMSC.CheckWakeUpCPU());
//        SiteMSC.CheckNowActiveSite_isCPU();  // 今アクティブなサイトがCPUか確認（順番毎に）
//        SiteMSC.GoStartCPU_ON();  // CPU操作を開始するタイミングかどうかのフラグをONにする
     //   SiteMSC.CheckWakeUpCPU();
    }

    public void ClosePanelYourTurn()
    {
        PanelYourTurn.SetActive(false);
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

    #region  ShowSite_Aimed
    public void ShowSiteA_Aimed()
    {
        AimedCharaFace.sprite = SiteA_charaF.sprite;
        AimedCharaNameText.GetComponent<Text>().text = SiteA_charaNametext;
    }

    public void ShowSiteB_Aimed()
    {
        AimedCharaFace.sprite = SiteB_charaF.sprite;
        AimedCharaNameText.GetComponent<Text>().text = SiteB_charaNametext;
    }

    public void ShowSiteC_Aimed()
    {
        AimedCharaFace.sprite = SiteC_charaF.sprite;
        AimedCharaNameText.GetComponent<Text>().text = SiteC_charaNametext;
    }

    public void ShowSiteD_Aimed()
    {
        AimedCharaFace.sprite = SiteD_charaF.sprite;
        AimedCharaNameText.GetComponent<Text>().text = SiteD_charaNametext;
    }

    public void ShowSiteE_Aimed()
    {
        AimedCharaFace.sprite = SiteE_charaF.sprite;
        AimedCharaNameText.GetComponent<Text>().text = SiteE_charaNametext;
    }

    public void ShowSiteF_Aimed()
    {
        AimedCharaFace.sprite = SiteF_charaF.sprite;
        AimedCharaNameText.GetComponent<Text>().text = SiteF_charaNametext;
    }

    public void ShowSiteG_Aimed()
    {
        AimedCharaFace.sprite = SiteG_charaF.sprite;
        AimedCharaNameText.GetComponent<Text>().text = SiteG_charaNametext;
    }

    public void ShowSiteH_Aimed()
    {
        AimedCharaFace.sprite = SiteH_charaF.sprite;
        AimedCharaNameText.GetComponent<Text>().text = SiteH_charaNametext;
    }

    #endregion

    public void CopyCharaFace()
    {
        SiteA_charaF_Copy.sprite = SiteA_charaF.sprite;
        SiteB_charaF_Copy.sprite = SiteB_charaF.sprite;
        SiteC_charaF_Copy.sprite = SiteC_charaF.sprite;
        SiteD_charaF_Copy.sprite = SiteD_charaF.sprite;
        SiteE_charaF_Copy.sprite = SiteE_charaF.sprite;
        SiteF_charaF_Copy.sprite = SiteF_charaF.sprite;
        SiteG_charaF_Copy.sprite = SiteG_charaF.sprite;
        SiteH_charaF_Copy.sprite = SiteH_charaF.sprite;
    }

    
    public void AppearWinTeam(int TeamNum, int x, int y, Image img, Image imgRole) // 【ゲーム終了後】勝ったチームのキャラを表示させる
    {
        if (x == TeamNum)  // そのキャラが[3]桃チーム/[1]おにチームであるならば、
        {
            if (y == 0)  // そのSite（キャラ）がまだ表示されていなければ、
            {
                if (Win01AppearFlg == 0)  // Win01がまだ表示されていなければ、
                {
                    Winner01.sprite = img.sprite;
                    YakuMSC.WinRole01.sprite = imgRole.sprite;
                    image = YakuMSC.WinRole01;
                    image.SetNativeSize();
                    y = 1;
                    Win01AppearFlg = 1;
                }
            }

            if (y == 0)  // そのSite（キャラ）がまだ表示されていなければ、
            {
                if (Win02AppearFlg == 0)
                {
                    Winner02.sprite = img.sprite;
                    YakuMSC.WinRole02.sprite = imgRole.sprite;
                    image = YakuMSC.WinRole02;
                    image.SetNativeSize();
                    y = 1;
                    Win02AppearFlg = 1;
                }
            }

            if (y == 0)  // そのSite（キャラ）がまだ表示されていなければ、
            {
                if (Win03AppearFlg == 0)
                {
                    Winner03.sprite = img.sprite;
                    YakuMSC.WinRole03.sprite = imgRole.sprite;
                    image = YakuMSC.WinRole03;
                    image.SetNativeSize();
                    y = 1;
                    Win03AppearFlg = 1;
                }
            }

            if (y == 0)  // そのSite（キャラ）がまだ表示されていなければ、
            {
                if (Win04AppearFlg == 0)
                {
                    Winner04.sprite = img.sprite;
                    YakuMSC.WinRole04.sprite = imgRole.sprite;
                    image = YakuMSC.WinRole04;
                    image.SetNativeSize();
                    y = 1;
                    Win04AppearFlg = 1;
                }
            }
        }
    }

    public void ResetWinAppearFlg() // 勝利者表示フラグのリセット
    {
        Win01AppearFlg = 0;
        Win02AppearFlg = 0;
        Win03AppearFlg = 0;
        Win04AppearFlg = 0;
    }

        //#################################################################################

    }
// End