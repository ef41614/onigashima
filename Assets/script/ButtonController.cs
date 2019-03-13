using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonController : MonoBehaviour {

    public GameObject brown_box;
    public GameObject Text_Question;
    public GameObject Text_Unmask;
    public GameObject Text_Attack;
    public GameObject Text_Scroll;

    public GameObject SiteManager;
    SiteManager SiteMSC;
    public GameObject SEManager;
    SEManager SEMSC;

    public Text GuideText;  // 行動ボタンの真上に、現在の行動モードに応じてテキストを表示させる

    public GameObject Question_Ten;  // 選択中に点滅する
    public GameObject Unmask_Ten;
    public GameObject Attack_Ten;
    public GameObject Scroll_Ten;

    public GameObject PanelCannotSelect;
    public Image ImageP_CannotSelect;
    public Sprite ImageP_cry;
    public Sprite ImageP_gakkari;

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        CloseBrownBox();
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        SEMSC = SEManager.GetComponent<SEManager>();
        ResetGuideText();
        ResetActButtonTen();  // 一旦、すべての行動ボタンの点滅を解除
        ClosePanelCannotSelect();
    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void OpenBrownBox()
    {
        brown_box.SetActive(true);
    }

    public void CloseBrownBox()
    {
        if (Text_Question != null)
        {
            CloseQuestion();
        }
        if (Text_Unmask != null)
        {
            CloseUnmask();
        }
        if (Text_Attack != null)
        {
            CloseAttack();
        }
        if (Text_Scroll != null)
        {
            CloseScroll();
        }
        brown_box.SetActive(false);
    }

    public void OpenQuestion()
    {
        if (brown_box != null)
        {
            CloseBrownBox();
            OpenBrownBox();
        }
        Text_Question.SetActive(true);
    }

    public void CloseQuestion()
    {
        Text_Question.SetActive(false);
    }

    public void OpenUnmask()
    {
        if (brown_box != null)
        {
            CloseBrownBox();
            OpenBrownBox();
        }
        Text_Unmask.SetActive(true);
    }

    public void CloseUnmask()
    {
        Text_Unmask.SetActive(false);
    }

    public void OpenAttack()
    {
        if (brown_box != null)
        {
            CloseBrownBox();
            OpenBrownBox();
        }
        Text_Attack.SetActive(true);
    }

    public void CloseAttack()
    {
        Text_Attack.SetActive(false);
    }


    public void OpenScroll()  // 自身の役割チェック ← 画面後ろに隠れてしまうので、はじめから実質無意味
    {
        ResetActButtonTen();  // 点灯解除
        Scroll_Ten.SetActive(true);
        if (brown_box != null)
        {
            CloseBrownBox();
            OpenBrownBox();
        }
        Text_Scroll.SetActive(true);
        ResetGuideText();
    }

    public void CloseScroll()
    {
        Text_Scroll.SetActive(false);
    }

    public void selectTimeStart()
    {
        SiteMSC.selectTimeStart();
        if (SiteMSC.NowActiveSite_isCPU == false)  // プレイヤーが人間の時
        {
            SEMSC.Kettei2_SE();  // SEも入れる（チュイーン）
        }
        else
        {
    //        SEMSC.select01_SE();
        }
    }

    public void JudgeGoSelectTime()
    {
        SiteMSC.CheckCanPushMenuButtons();
        if (SiteMSC.MenuButtonMode == 1) // 質問の時
        {
            if (SiteMSC.CanPush_Question)  // しつもんボタン 押せる状態であるなら
            {
                selectTimeStart();
            }
            else   // しつもんボタン 押せないよ
            {
                CannotSelectInform();
            }
        }
        else if (SiteMSC.MenuButtonMode == 2) // 役割当ての時
        {
            if (SiteMSC.CanPush_Unmask)  // 役割当てボタン 押せる状態であるなら
            {
                selectTimeStart();
            }
            else   // 役割当てボタン 押せないよ
            {
                CannotSelectInform();
            }
        }
        else if (SiteMSC.MenuButtonMode == 3) // 攻撃の時
        {
            if (SiteMSC.CanPush_Attack)  // 攻撃ボタン 押せる状態であるなら
            {
                selectTimeStart();
            }
            else   // 攻撃ボタン 押せないよ  
            {
                CannotSelectInform();
            }
        }
    }

    public void CannotSelectInform()  // 行動ボタンを押しても、セレクトできない旨を表示する
    {
        SEMSC.NoSelect_SE();  // カッキッコン
        AppearP_image();
        OpenPanelCannotSelect();
        SiteMSC.selectTimeEnd();
        ResetGuideText();
    }

    public void OpenPanelCannotSelect()
    {
        PanelCannotSelect.SetActive(true);
    }

    public void ClosePanelCannotSelect()
    {
        PanelCannotSelect.SetActive(false);
    }

    public void AppearP_image()
    {
        int rndP = UnityEngine.Random.Range(1, 3);
        switch (rndP)
        {
            case 1: //
                ImageP_CannotSelect.sprite = ImageP_cry;
                break;
            case 2: //
                ImageP_CannotSelect.sprite = ImageP_gakkari;
                break;
            default:
                // その他処理
                break;
        }
    }

    public void ResetGuideText()  // ★ 各キャラの順番開始時に、SiteManager経由で毎回呼び出すようにする
    {
        GuideText.text = "ボタンを おしてね";
        ResetActButtonTen();  // 点灯解除
    }

    public void PushActButtonCommon()  // 行動ボタン共通処理（ガイド文ONの時）
    {
        OpenBrownBox();
        SEMSC.Kettei_SE(); // SEも入れる（ピピン）
        SiteMSC.selectTimeEnd();
    }

    public void PushActButtonGideTextOFFCommon()  // 行動ボタン共通処理（ガイド文OFFの時）
    {
        // selectTimeStart();
        JudgeGoSelectTime();
    }

    public void BranchOpenQuestion()  // しつもん
    {
        SiteMSC.CheckCanPushMenuButtons();
        ResetActButtonTen();  // 点灯解除
        Question_Ten.SetActive(true);
        GuideText.text = "しつもん モード";
        SiteMSC.MenuButtonModeQuestion();
        if (SiteMSC.GuideLevel == 1)  // 1 でガイド文ON
        {
            PushActButtonCommon();  // 行動ボタン共通処理
            OpenQuestion();
        }
        else    // ガイド文OFFで いきなりキャラ選択へ進む（説明文スキップ）
        { 
            PushActButtonGideTextOFFCommon();
        }
    }


    public void BranchOpenUnmask()  // やくわりあて
    {
        SiteMSC.CheckCanPushMenuButtons();
        ResetActButtonTen();  // 点灯解除
        Unmask_Ten.SetActive(true);
        GuideText.text = "やくわりあて モード";
        SiteMSC.MenuButtonModeUnmask();
        if (SiteMSC.GuideLevel == 1)  // 1 でガイド文ON
        {
            PushActButtonCommon();  // 行動ボタン共通処理
            OpenUnmask();
        }
        else
        {
            PushActButtonGideTextOFFCommon();
        }
    }


    public void BranchOpenAttack()  // こうげき
    {
        SiteMSC.CheckCanPushMenuButtons();
        ResetActButtonTen();  // 点灯解除
        Attack_Ten.SetActive(true);
        GuideText.text = "こうげき モード";
        SiteMSC.MenuButtonModeAttack();
        if (SiteMSC.GuideLevel == 1)  // 1 でガイド文ON
        {
            PushActButtonCommon();  // 行動ボタン共通処理
            OpenAttack();
        }
        else
        {
            PushActButtonGideTextOFFCommon();
        }
    }

    public void ResetActButtonTen()  // 一旦、すべての行動ボタンの点滅を解除（どれも選択されていない状態にする）
    {
        Question_Ten.SetActive(false);
        Unmask_Ten.SetActive(false);
        Attack_Ten.SetActive(false);
        Scroll_Ten.SetActive(false);
    }


    //#################################################################################

}
// End