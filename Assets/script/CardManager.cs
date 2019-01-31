using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class CardManager : MonoBehaviour {

    public Sprite CardColorWhite;
    public Sprite CardColorGreen;
    public Sprite CardColorPink;
    public Sprite CardColorRed;

    public GameObject SiteManager;
    SiteManager SiteMSC;

//    Image image;

    //public Sprite SiteA_turn;
    //    public GameObject SiteA_turn;
    public Image SiteA_CardColor;
    public Image SiteB_CardColor;
    public Image SiteC_CardColor;
    public Image SiteD_CardColor;
    public Image SiteE_CardColor;
    public Image SiteF_CardColor;
    public Image SiteG_CardColor;
    public Image SiteH_CardColor;
    public Image SiteTrash_CardColor;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        SiteMSC = SiteManager.GetComponent<SiteManager>();
//        image = this.GetComponent<Image>();

        CardColorSet(SiteA_CardColor, 1);
        CardColorSet(SiteB_CardColor, 2);
        CardColorSet(SiteC_CardColor, 3);
        CardColorSet(SiteD_CardColor, 4);
        CardColorSet(SiteE_CardColor, 5);
        CardColorSet(SiteF_CardColor, 6);
        CardColorSet(SiteG_CardColor, 7);
        CardColorSet(SiteH_CardColor, 8);


        //this.gameObject.GetComponent<Image>().sprite = Turn_num_icon1;

    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void CardColorSet(Image CardColor, int x)
    {
        switch (SiteMSC.rollF[x])
        {
            case 1:
                CardColor.sprite = CardColorGreen;
                break;
            case 2:
                CardColor.sprite = CardColorGreen;
                break;
            case 3:
                CardColor.sprite = CardColorGreen;
                break;
            case 4:
                CardColor.sprite = CardColorGreen;
                break;
            case 5:
                CardColor.sprite = CardColorWhite;
                break;
            case 6:
                CardColor.sprite = CardColorWhite;
                break;
            case 7:
                CardColor.sprite = CardColorWhite;
                break;
            case 8:
                CardColor.sprite = CardColorWhite;
                break;
            case 9:
                CardColor.sprite = CardColorRed;
                break;
            case 10:
                CardColor.sprite = CardColorPink;
                break;
            default:
                // 処理３
                break;
        }
//        image = CardColor;
    }

    //#################################################################################

}
// End