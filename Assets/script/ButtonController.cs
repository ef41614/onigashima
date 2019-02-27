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

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        CloseBrownBox();
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        SEMSC = SEManager.GetComponent<SEManager>();
        ResetGuideText();
        ResetActButtonTen();  // 一旦、すべての行動ボタンの点滅を解除
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
        ResetActButtonTen();  // 点滅解除
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
        SiteMSC.selectTimeActive = true;
    }


    public void ResetGuideText()  // ★ 各キャラの順番開始時に、SiteManager経由で毎回呼び出すようにする
    {
        GuideText.text = "ボタンを おしてね";
        ResetActButtonTen();  // 点滅解除
    }

    public void PushActButtonCommon()  // 行動ボタン共通処理
    {
        OpenBrownBox();
        SEMSC.Kettei_SE(); // SEも入れる（ピピン）
        SiteMSC.selectTimeEnd();
    }

    public void PushActButtonGideTextOFFCommon()
    {
        selectTimeStart();
        SEMSC.Kettei2_SE();  // SEも入れる（チュイーン）
    }

    public void BranchOpenQuestion()  // しつもん
    {
        ResetActButtonTen();  // 点滅解除
        Question_Ten.SetActive(true);
        GuideText.text = "しつもん モード";
        if (SiteMSC.GuideLevel == 1)  // 1 でガイド文ON
        {
            PushActButtonCommon();  // 行動ボタン共通処理
            OpenQuestion();
        }
        else    // ガイド文OFFで いきなりキャラ選択へ進む（説明文スキップ）
        {       // （→ MenuButtonMode が 1 で、selectTimeActive = true になる）
            PushActButtonGideTextOFFCommon();
        }
        SiteMSC.MenuButtonModeQuestion();
    }


    public void BranchOpenUnmask()  // やくわりあて
    {
        ResetActButtonTen();  // 点滅解除
        Unmask_Ten.SetActive(true);
        GuideText.text = "やくわりあて モード";
        if (SiteMSC.GuideLevel == 1)  // 1 でガイド文ON
        {
            PushActButtonCommon();  // 行動ボタン共通処理
            OpenUnmask();
        }
        else
        {
            PushActButtonGideTextOFFCommon();
        }
        SiteMSC.MenuButtonModeUnmask();
    }


    public void BranchOpenAttack()  // こうげき
    {
        ResetActButtonTen();  // 点滅解除
        Attack_Ten.SetActive(true);
        GuideText.text = "こうげき モード";
        if (SiteMSC.GuideLevel == 1)  // 1 でガイド文ON
        {
            PushActButtonCommon();  // 行動ボタン共通処理
            OpenAttack();
        }
        else
        {
            PushActButtonGideTextOFFCommon();
        }
        SiteMSC.MenuButtonModeAttack();
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