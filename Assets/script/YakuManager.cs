using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class YakuManager : MonoBehaviour {

    public Sprite Yaku_icon1;
    public Sprite Yaku_icon2;
    public Sprite Yaku_icon3;
    public Sprite Yaku_icon4;
    public Sprite Yaku_icon5;
    public Sprite Yaku_icon6;
    public Sprite Yaku_icon7;
    public Sprite Yaku_icon8;

    public GameObject SiteManager;
    SiteManager SiteMSC;

    Image image;
    Image imageTen;
    Image imageKabaiKooniTen;

    float speed = 5f;   // デフォルトは 1.0
    float time;

    //public Sprite SiteA_turn;
    //    public GameObject SiteA_turn;
    public Image SiteA_rollF;
    public Image SiteB_rollF;
    public Image SiteC_rollF;
    public Image SiteD_rollF;
    public Image SiteE_rollF;
    public Image SiteF_rollF;
    public Image SiteG_rollF;
    public Image SiteH_rollF;
    public Image SiteTrash_rollF;

    string SiteA_roleNametext;
    string SiteB_roleNametext;
    string SiteC_roleNametext;
    string SiteD_roleNametext;
    string SiteE_roleNametext;
    string SiteF_roleNametext;
    string SiteG_roleNametext;
    string SiteH_roleNametext;

    public GameObject YakuCardA;
    public GameObject YakuCardB;
    public GameObject YakuCardC;
    public GameObject YakuCardD;
    public GameObject YakuCardE;
    public GameObject YakuCardF;
    public GameObject YakuCardG;
    public GameObject YakuCardH;
    public GameObject YakuCardTrash;

    public Image PreventRollFace;
    public GameObject RollNameText;
    public int countX = 1;

    public Image AimedRollFace;
    public Image AttackedRollFace;

     bool isDamaged = false; // 攻撃が当たったか
    bool isKabaied = false;  // かばうが成功したか
    public GameObject AttackedRollFaceObj;
    public GameObject KabaiKooniObj;

    public GameObject DamageEffectP;
    public GameObject DamageEffect01;
    public GameObject DamageStar02;
    //    SpriteRenderer renderer;

    public Image WinRole01;  // 結果画面に勝利者の役割を表示
    public Image WinRole02;
    public Image WinRole03;
    public Image WinRole04;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        image = this.GetComponent<Image>();

        SiteA_roleNametext = RollFaceSet(SiteA_rollF, 1, SiteA_roleNametext);
        SiteB_roleNametext = RollFaceSet(SiteB_rollF, 2, SiteB_roleNametext);
        SiteC_roleNametext = RollFaceSet(SiteC_rollF, 3, SiteC_roleNametext);
        SiteD_roleNametext = RollFaceSet(SiteD_rollF, 4, SiteD_roleNametext);
        SiteE_roleNametext = RollFaceSet(SiteE_rollF, 5, SiteE_roleNametext);
        SiteF_roleNametext = RollFaceSet(SiteF_rollF, 6, SiteF_roleNametext);
        SiteG_roleNametext = RollFaceSet(SiteG_rollF, 7, SiteG_roleNametext);
        SiteH_roleNametext = RollFaceSet(SiteH_rollF, 8, SiteH_roleNametext);

        //        RollFaceSet(SiteTrash_rollF, 8);
        //this.gameObject.GetComponent<Image>().sprite = Yaku_icon1;
        AppearPreventRoll(); //【初回時】巻物に現在手番の役職を表示させる（やくわりチェック）

        HideYakuCardA();
        HideYakuCardB();
        HideYakuCardC();
        HideYakuCardD();
        HideYakuCardE();
        HideYakuCardF();
        HideYakuCardG();
        HideYakuCardH();

        //点滅処理の為に呼び出しておく
//        renderer = AttackedRollFaceObj.gameObject.GetComponent<SpriteRenderer>();
        imageTen = AttackedRollFaceObj.gameObject.GetComponent<Image>();
        imageKabaiKooniTen = KabaiKooniObj.gameObject.GetComponent<Image>();
    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    // ----------------------------------------------------------

    void FixedUpdate()
    {
        //ダメージを受けた時の処理
        if (isDamaged)
        {
            Debug.Log("◆ダメージを受けた時の処理ON・・・点滅");
//            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            //            AttackedRollFaceObj.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, level);
//            renderer.color = new Color(1f, 1f, 1f, level);

            //オブジェクトのAlpha値を更新
            imageTen.color = GetAlphaColor(image.color);
        }

        //かばう成功時の処理
        if (isKabaied)
        {
            Debug.Log("◆かばう成功時の処理ON・・・点滅");
            //オブジェクトのAlpha値を更新
            imageKabaiKooniTen.color = GetAlphaColor(image.color);
        }
    }

    // ----------------------------------------------------------

    //####################################  other  ####################################

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

    public String RollFaceSet(Image RollFace, int x, string RoleName)
    {
        switch (SiteMSC.rollF[x])
        {
            case 1:
                RollFace.sprite = Yaku_icon1;
                RoleName = "ももたろう";
                break;
            case 2:
                RollFace.sprite = Yaku_icon2;
                RoleName = "いぬ";
                break;
            case 3:
                RollFace.sprite = Yaku_icon3;
                RoleName = "さる";
                break;
            case 4:
                RollFace.sprite = Yaku_icon4;
                RoleName = "きじ";
                break;
            case 5:
                RollFace.sprite = Yaku_icon5;
                RoleName = "オニのおやぶん";
                break;
            case 6:
                RollFace.sprite = Yaku_icon6;
                RoleName = "こオニ";
                break;
            case 7:
                RollFace.sprite = Yaku_icon7;
                RoleName = "こオニ";
                break;
            case 8:
                RollFace.sprite = Yaku_icon8;
                RoleName = "こオニ";
                break;
            default:
                // 処理３
                break;
        }
//        return RoleName;
        image = RollFace;
        image.SetNativeSize();
        return RoleName;
    }

    public void AppearPreventRoll() //【初回時】巻物に現在手番の役職を表示させる（やくわりチェック）
    {
        if (countX <= SiteMSC.human_num)
        {
            switch (SiteMSC.rollF[countX])
            {
                case 1:
                    PreventRollFace.sprite = Yaku_icon1;
                    RollNameText.GetComponent<Text>().text = "ももたろう";
                    break;
                case 2:
                    PreventRollFace.sprite = Yaku_icon2;
                    RollNameText.GetComponent<Text>().text = "いぬ";
                    break;
                case 3:
                    PreventRollFace.sprite = Yaku_icon3;
                    RollNameText.GetComponent<Text>().text = "さる";
                    break;
                case 4:
                    PreventRollFace.sprite = Yaku_icon4;
                    RollNameText.GetComponent<Text>().text = "きじ";
                    break;
                case 5:
                    PreventRollFace.sprite = Yaku_icon5;
                    RollNameText.GetComponent<Text>().text = "オニのおやぶん";
                    break;
                case 6:
                    PreventRollFace.sprite = Yaku_icon6;
                    RollNameText.GetComponent<Text>().text = "こオニ";
                    break;
                case 7:
                    PreventRollFace.sprite = Yaku_icon7;
                    RollNameText.GetComponent<Text>().text = "こオニ";
                    break;
                case 8:
                    PreventRollFace.sprite = Yaku_icon8;
                    RollNameText.GetComponent<Text>().text = "こオニ";
                    break;
                default:
                    // 処理３
                    break;
            }
        }
        countX++;
        image = PreventRollFace;
        image.SetNativeSize();

        //       PreventRollFace = Site_rollF1;
        //      image = PreventRollFace;

    }


    public void CheckPreventRole() // 【ゲーム開始後】巻物に現在手番の役職を表示させる（やくわりチェック）
    {
        switch (SiteMSC.NowActiveSiteN)
        {
            case 1:
                PreventRollFace.sprite = SiteA_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteA_roleNametext;
                break;
            case 2:
                PreventRollFace.sprite = SiteB_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteB_roleNametext;
                break;
            case 3:
                PreventRollFace.sprite = SiteC_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteC_roleNametext;
                break;
            case 4:
                PreventRollFace.sprite = SiteD_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteD_roleNametext;
                break;
            case 5:
                PreventRollFace.sprite = SiteE_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteE_roleNametext;
                break;
            case 6:
                PreventRollFace.sprite = SiteF_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteF_roleNametext;
                break;
            case 7:
                PreventRollFace.sprite = SiteG_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteG_roleNametext;
                break;
            case 8:
                PreventRollFace.sprite = SiteH_rollF.sprite;
                RollNameText.GetComponent<Text>().text = SiteH_roleNametext;
                break;
            default:
                // 処理３
                break;
        }
        image = PreventRollFace;
        image.SetNativeSize();
    }

    public void CheckAimedRole() // 【役わり名予想フェーズ】画面中央に役わり名を当てられた人の役職を表示させる
    {
        switch (SiteMSC.rollF[SiteMSC.TargetSiteNum])
        {
            case 1:
                AimedRollFace.sprite = Yaku_icon1;
                break;
            case 2:
                AimedRollFace.sprite = Yaku_icon2;
                break;
            case 3:
                AimedRollFace.sprite = Yaku_icon3;
                break;
            case 4:
                AimedRollFace.sprite = Yaku_icon4;
                break;
            case 5:
                AimedRollFace.sprite = Yaku_icon5;
                break;
            case 6:
                AimedRollFace.sprite = Yaku_icon6;
                break;
            case 7:
                AimedRollFace.sprite = Yaku_icon7;
                break;
            case 8:
                AimedRollFace.sprite = Yaku_icon8;
                break;
            default:
                // 処理３
                break;
        }
        image = AimedRollFace;
        image.SetNativeSize();
    }

    public void CheckAttackedRole() // 【攻撃フェーズ】画面中央に攻撃を狙われている人の役職を表示させる
    {
        switch (SiteMSC.rollF[SiteMSC.TargetSiteNum])
        {
            case 1:
                AttackedRollFace.sprite = Yaku_icon1;
                break;
            case 2:
                AttackedRollFace.sprite = Yaku_icon2;
                break;
            case 3:
                AttackedRollFace.sprite = Yaku_icon3;
                break;
            case 4:
                AttackedRollFace.sprite = Yaku_icon4;
                break;
            case 5:
                AttackedRollFace.sprite = Yaku_icon5;
                break;
            case 6:
                AttackedRollFace.sprite = Yaku_icon6;
                break;
            case 7:
                AttackedRollFace.sprite = Yaku_icon7;
                break;
            case 8:
                AttackedRollFace.sprite = Yaku_icon8;
                break;
            default:
                // 処理３
                break;
        }
        image = AttackedRollFace;
        image.SetNativeSize();
    }

    #region HideYakuCards
    public void HideYakuCardA()
    {
        YakuCardA.SetActive(false);
    }

    public void HideYakuCardB()
    {
        YakuCardB.SetActive(false);
    }

    public void HideYakuCardC()
    {
        YakuCardC.SetActive(false);
    }

    public void HideYakuCardD()
    {
        YakuCardD.SetActive(false);
    }

    public void HideYakuCardE()
    {
        YakuCardE.SetActive(false);
    }

    public void HideYakuCardF()
    {
        YakuCardF.SetActive(false);
    }

    public void HideYakuCardG()
    {
        YakuCardG.SetActive(false);
    }

    public void HideYakuCardH()
    {
        YakuCardH.SetActive(false);
    }

    public void HideYakuCardTrash()
    {
        YakuCardTrash.SetActive(false);
    }
    #endregion

    #region OpenYakuCards
    public void OpenYakuCardA()
    {
        YakuCardA.SetActive(true);
        if (SiteMSC.KabauFlg == false)
        {
            YakuCardA.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    public void OpenYakuCardB()
    {
        YakuCardB.SetActive(true);
        if (SiteMSC.KabauFlg == false)
        {
            YakuCardB.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    public void OpenYakuCardC()
    {
        YakuCardC.SetActive(true);
        if (SiteMSC.KabauFlg == false)
        {
            YakuCardC.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    public void OpenYakuCardD()
    {
        YakuCardD.SetActive(true);
        if (SiteMSC.KabauFlg == false)
        {
            YakuCardD.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    public void OpenYakuCardE()
    {
        YakuCardE.SetActive(true);
        if (SiteMSC.KabauFlg == false)
        {
            YakuCardE.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    public void OpenYakuCardF()
    {
        YakuCardF.SetActive(true);
        if (SiteMSC.KabauFlg == false)
        {
            YakuCardF.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    public void OpenYakuCardG()
    {
        YakuCardG.SetActive(true);
        if (SiteMSC.KabauFlg == false)
        {
            YakuCardG.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    public void OpenYakuCardH()
    {
        YakuCardH.SetActive(true);
        if (SiteMSC.KabauFlg == false)
        {
            YakuCardH.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    public void OpenYakuCardTrash()
    {
        YakuCardTrash.SetActive(true);
    }
    #endregion


    public void DamageTenmetu()
    {
        isDamaged = true;
        TenmetuCommonPhase();
    }

    public void KabaiKooniTenmetu()
    {
        isKabaied = true;
        TenmetuCommonPhase();
    }

    public void TenmetuCommonPhase()
    {
        //パーティクルを再生（追加）
        DamageEffectP.GetComponent<ParticleSystem>().Play();
        DamageStar02.GetComponent<ParticleSystem>().Play();
        DamageEffect01.SetActive(true);

        var sequence = DOTween.Sequence();
        sequence.InsertCallback(0.5f, () => DamageEffectOff());
        sequence.InsertCallback(1f, () => TenmetuFlgOff());  // 数秒後に点滅終了（通常に戻る）
    }

    public void DamageEffectOff()
    {
        DamageEffect01.SetActive(false);
    }

    public void TenmetuFlgOff()
    {
        isDamaged = false;
        Debug.Log("◎てんめつ おわり◎");
        //オブジェクトのAlpha値を更新
        imageTen.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        isKabaied = false;
        Debug.Log("◎てんめつ おわり◎");
        //オブジェクトのAlpha値を更新
        imageKabaiKooniTen.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    //#################################################################################

}
// End