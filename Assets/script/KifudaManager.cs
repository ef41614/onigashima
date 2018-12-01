using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class KifudaManager : MonoBehaviour {

    public Sprite FudaIconOni;
    public Sprite FudaIconOniMomo;
    public Sprite FudaIconMomo;

    public GameObject SiteManager;
    SiteManager SiteMSC;

    Image image;

    //public Sprite SiteA_turn;
    //    public GameObject SiteA_turn;
    public Image SiteA_FudaIcon;
    public Image SiteB_FudaIcon;
    public Image SiteC_FudaIcon;
    public Image SiteD_FudaIcon;
    public Image SiteE_FudaIcon;
    public Image SiteF_FudaIcon;
    public Image SiteG_FudaIcon;
    public Image SiteH_FudaIcon;

    public int kifuda_A = 1;
    public int kifuda_B = 1;
    public int kifuda_C = 1;
    public int kifuda_D = 1;
    public int kifuda_E = 1;
    public int kifuda_F = 1;
    public int kifuda_G = 1;
    public int kifuda_H = 1;

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        image = this.GetComponent<Image>();

        FudaIconSet(SiteA_FudaIcon, kifuda_A);
        FudaIconSet(SiteB_FudaIcon, kifuda_B);
        FudaIconSet(SiteC_FudaIcon, kifuda_C);
        FudaIconSet(SiteD_FudaIcon, kifuda_D);
        FudaIconSet(SiteE_FudaIcon, kifuda_E);
        FudaIconSet(SiteF_FudaIcon, kifuda_F);
        FudaIconSet(SiteG_FudaIcon, kifuda_G);
        FudaIconSet(SiteH_FudaIcon, kifuda_H);

    //this.gameObject.GetComponent<Image>().sprite = Turn_num_icon1;
    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void FudaIconSet(Image FudaIcon, int x)
    {
        switch (x)
        {
            case 1:
                FudaIcon.sprite = FudaIconOni;
                break;
            case 2:
                FudaIcon.sprite = FudaIconOniMomo;
                break;
            case 3:
                FudaIcon.sprite = FudaIconMomo;
                break;
            default:
                // 処理３
                break;
        }
//        image = FudaIcon;
    }

    //#################################################################################

}
// End