using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class HPManager : MonoBehaviour {

    public Sprite Heart_iconRed;
    public Sprite Heart_iconWhite;

    public GameObject SiteManager;
    SiteManager SiteMSC;

    Image image;

    public Image SiteA_HP3;
    public Image SiteA_HP2;
    public Image SiteA_HP1;
    public Image[] SiteA_HP;

    public Image SiteB_HP3;
    public Image SiteB_HP2;
    public Image SiteB_HP1;

    public Image SiteC_HP3;
    public Image SiteC_HP2;
    public Image SiteC_HP1;

    public Image SiteD_HP3;
    public Image SiteD_HP2;
    public Image SiteD_HP1;

    public Image SiteE_HP3;
    public Image SiteE_HP2;
    public Image SiteE_HP1;

    public Image SiteF_HP3;
    public Image SiteF_HP2;
    public Image SiteF_HP1;

    public Image SiteG_HP3;
    public Image SiteG_HP2;
    public Image SiteG_HP1;

    public Image SiteH_HP3;
    public Image SiteH_HP2;
    public Image SiteH_HP1;

    public int HP_A;
    public int HP_B;
    public int HP_C;
    public int HP_D;

    public int HP_E;
    public int HP_F;
    public int HP_G;
    public int HP_H;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {

        SiteMSC = SiteManager.GetComponent<SiteManager>();
        image = this.GetComponent<Image>();

        HP_A = Yaku_HP_set(1);
        HP_B = Yaku_HP_set(2);
        HP_C = Yaku_HP_set(3);
        HP_D = Yaku_HP_set(4);
        HP_E = Yaku_HP_set(5);
        HP_F = Yaku_HP_set(6);
        HP_G = Yaku_HP_set(7);
        HP_H = Yaku_HP_set(8);

        HP_check();

    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public int Yaku_HP_set(int x)
    {
        int HP = 0;
        switch (SiteMSC.rollF[x])
        {
            case 1: // ももたろう
                HP = 2;
                break;
            case 2:
                HP = 1;
                break;
            case 3:
                HP = 1;
                break;
            case 4:
                HP = 1;
                break;
            case 5: // おにのおやぶん 
                HP = 3;
                break;
            case 6: // こおに
                HP = 1;
                break;
            case 7:// こおに
                HP = 1;
                break;
            case 8:// こおに
                HP = 1;
                break;
            default:
                // 処理３
                break;
        }
        return HP;
    }

    public void HP_check()
    {
        HPA_Set(HP_A);
        HPB_Set(HP_B);
        HPC_Set(HP_C);
        HPD_Set(HP_D);

        HPE_Set(HP_E);
        HPF_Set(HP_F);
        HPG_Set(HP_G);
        HPH_Set(HP_H);
    }


    public void HPA_Set(int hp)
    {
        Debug.Log(hp + " HPA_Setを実施");
        switch (hp)
        {
            case 0:
                SiteA_HP3.sprite = Heart_iconWhite;
                SiteA_HP2.sprite = Heart_iconWhite;
                SiteA_HP1.sprite = Heart_iconWhite;
                break;
            case 1:
                SiteA_HP3.sprite = Heart_iconWhite;
                SiteA_HP2.sprite = Heart_iconWhite;
                SiteA_HP1.sprite = Heart_iconRed;
                break;
            case 2:
                SiteA_HP3.sprite = Heart_iconWhite;
                SiteA_HP2.sprite = Heart_iconRed;
                SiteA_HP1.sprite = Heart_iconRed;
                break;
            case 3:
                SiteA_HP3.sprite = Heart_iconRed;
                SiteA_HP2.sprite = Heart_iconRed;
                SiteA_HP1.sprite = Heart_iconRed;
                break;
            default:
                // 処理３
                break;
        }
//        image = HP;
 //       image.SetNativeSize();
    }

    public void HPB_Set(int hp)
    {
        Debug.Log(hp+ " HPB_Setを実施");
        switch (hp)
        {
            case 0:
                SiteB_HP3.sprite = Heart_iconWhite;
                SiteB_HP2.sprite = Heart_iconWhite;
                SiteB_HP1.sprite = Heart_iconWhite;
                break;
            case 1:
                SiteB_HP3.sprite = Heart_iconWhite;
                SiteB_HP2.sprite = Heart_iconWhite;
                SiteB_HP1.sprite = Heart_iconRed;
                break;
            case 2:
                SiteB_HP3.sprite = Heart_iconWhite;
                SiteB_HP2.sprite = Heart_iconRed;
                SiteB_HP1.sprite = Heart_iconRed;
                break;
            case 3:
                SiteB_HP3.sprite = Heart_iconRed;
                SiteB_HP2.sprite = Heart_iconRed;
                SiteB_HP1.sprite = Heart_iconRed;
                break;
            default:
                // 処理３
                break;
        }
    }

    public void HPC_Set(int hp)
    {
        Debug.Log(hp + " HPC_Setを実施");
        switch (hp)
        {
            case 0:
                SiteC_HP3.sprite = Heart_iconWhite;
                SiteC_HP2.sprite = Heart_iconWhite;
                SiteC_HP1.sprite = Heart_iconWhite;
                break;
            case 1:
                SiteC_HP3.sprite = Heart_iconWhite;
                SiteC_HP2.sprite = Heart_iconWhite;
                SiteC_HP1.sprite = Heart_iconRed;
                break;
            case 2:
                SiteC_HP3.sprite = Heart_iconWhite;
                SiteC_HP2.sprite = Heart_iconRed;
                SiteC_HP1.sprite = Heart_iconRed;
                break;
            case 3:
                SiteC_HP3.sprite = Heart_iconRed;
                SiteC_HP2.sprite = Heart_iconRed;
                SiteC_HP1.sprite = Heart_iconRed;
                break;
            default:
                // 処理３
                break;
        }
    }

    public void HPD_Set(int hp)
    {
        Debug.Log(hp + " HPD_Setを実施");
        switch (hp)
        {
            case 0:
                SiteD_HP3.sprite = Heart_iconWhite;
                SiteD_HP2.sprite = Heart_iconWhite;
                SiteD_HP1.sprite = Heart_iconWhite;
                break;
            case 1:
                SiteD_HP3.sprite = Heart_iconWhite;
                SiteD_HP2.sprite = Heart_iconWhite;
                SiteD_HP1.sprite = Heart_iconRed;
                break;
            case 2:
                SiteD_HP3.sprite = Heart_iconWhite;
                SiteD_HP2.sprite = Heart_iconRed;
                SiteD_HP1.sprite = Heart_iconRed;
                break;
            case 3:
                SiteD_HP3.sprite = Heart_iconRed;
                SiteD_HP2.sprite = Heart_iconRed;
                SiteD_HP1.sprite = Heart_iconRed;
                break;
            default:
                // 処理３
                break;
        }
    }


    public void HPE_Set(int hp)
    {
        Debug.Log(hp + " HPE_Setを実施");
        switch (hp)
        {
            case 0:
                SiteE_HP3.sprite = Heart_iconWhite;
                SiteE_HP2.sprite = Heart_iconWhite;
                SiteE_HP1.sprite = Heart_iconWhite;
                break;
            case 1:
                SiteE_HP3.sprite = Heart_iconWhite;
                SiteE_HP2.sprite = Heart_iconWhite;
                SiteE_HP1.sprite = Heart_iconRed;
                break;
            case 2:
                SiteE_HP3.sprite = Heart_iconWhite;
                SiteE_HP2.sprite = Heart_iconRed;
                SiteE_HP1.sprite = Heart_iconRed;
                break;
            case 3:
                SiteE_HP3.sprite = Heart_iconRed;
                SiteE_HP2.sprite = Heart_iconRed;
                SiteE_HP1.sprite = Heart_iconRed;
                break;
            default:
                // 処理３
                break;
        }
    }

    public void HPF_Set(int hp)
    {
        Debug.Log(hp + " HPF_Setを実施");
        switch (hp)
        {
            case 0:
                SiteF_HP3.sprite = Heart_iconWhite;
                SiteF_HP2.sprite = Heart_iconWhite;
                SiteF_HP1.sprite = Heart_iconWhite;
                break;
            case 1:
                SiteF_HP3.sprite = Heart_iconWhite;
                SiteF_HP2.sprite = Heart_iconWhite;
                SiteF_HP1.sprite = Heart_iconRed;
                break;
            case 2:
                SiteF_HP3.sprite = Heart_iconWhite;
                SiteF_HP2.sprite = Heart_iconRed;
                SiteF_HP1.sprite = Heart_iconRed;
                break;
            case 3:
                SiteF_HP3.sprite = Heart_iconRed;
                SiteF_HP2.sprite = Heart_iconRed;
                SiteF_HP1.sprite = Heart_iconRed;
                break;
            default:
                // 処理３
                break;
        }
    }

    public void HPG_Set(int hp)
    {
        Debug.Log(hp + " HPG_Setを実施");
        switch (hp)
        {
            case 0:
                SiteG_HP3.sprite = Heart_iconWhite;
                SiteG_HP2.sprite = Heart_iconWhite;
                SiteG_HP1.sprite = Heart_iconWhite;
                break;
            case 1:
                SiteG_HP3.sprite = Heart_iconWhite;
                SiteG_HP2.sprite = Heart_iconWhite;
                SiteG_HP1.sprite = Heart_iconRed;
                break;
            case 2:
                SiteG_HP3.sprite = Heart_iconWhite;
                SiteG_HP2.sprite = Heart_iconRed;
                SiteG_HP1.sprite = Heart_iconRed;
                break;
            case 3:
                SiteG_HP3.sprite = Heart_iconRed;
                SiteG_HP2.sprite = Heart_iconRed;
                SiteG_HP1.sprite = Heart_iconRed;
                break;
            default:
                // 処理３
                break;
        }
    }

    public void HPH_Set(int hp)
    {
        Debug.Log(hp + " HPH_Setを実施");
        switch (hp)
        {
            case 0:
                SiteH_HP3.sprite = Heart_iconWhite;
                SiteH_HP2.sprite = Heart_iconWhite;
                SiteH_HP1.sprite = Heart_iconWhite;
                break;
            case 1:
                SiteH_HP3.sprite = Heart_iconWhite;
                SiteH_HP2.sprite = Heart_iconWhite;
                SiteH_HP1.sprite = Heart_iconRed;
                break;
            case 2:
                SiteH_HP3.sprite = Heart_iconWhite;
                SiteH_HP2.sprite = Heart_iconRed;
                SiteH_HP1.sprite = Heart_iconRed;
                break;
            case 3:
                SiteH_HP3.sprite = Heart_iconRed;
                SiteH_HP2.sprite = Heart_iconRed;
                SiteH_HP1.sprite = Heart_iconRed;
                break;
            default:
                // 処理３
                break;
        }
    }

    //#################################################################################

}
// End