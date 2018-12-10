using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class TurnMarkManager : MonoBehaviour {

    public Sprite Turn_num_icon1;
    public Sprite Turn_num_icon2;
    public Sprite Turn_num_icon3;
    public Sprite Turn_num_icon4;
    public Sprite Turn_num_icon5;
    public Sprite Turn_num_icon6;
    public Sprite Turn_num_icon7;
    public Sprite Turn_num_icon8;

    public GameObject SiteManager;
    SiteManager SiteMSC;

    Image image;

    //public Sprite SiteA_turn;
    //    public GameObject SiteA_turn;
    public Image SiteA_turn;
    public Image SiteB_turn;
    public Image SiteC_turn;
    public Image SiteD_turn;
    public Image SiteE_turn;
    public Image SiteF_turn;
    public Image SiteG_turn;
    public Image SiteH_turn;
    

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        image = this.GetComponent<Image>();

        SiteMSC.TurnChip_A = TurnMarkSet(SiteA_turn, 1);
        SiteMSC.TurnChip_B = TurnMarkSet(SiteB_turn, 2);
        SiteMSC.TurnChip_C = TurnMarkSet(SiteC_turn, 3);
        SiteMSC.TurnChip_D = TurnMarkSet(SiteD_turn, 4);
        SiteMSC.TurnChip_E = TurnMarkSet(SiteE_turn, 5);
        SiteMSC.TurnChip_F = TurnMarkSet(SiteF_turn, 6);
        SiteMSC.TurnChip_G = TurnMarkSet(SiteG_turn, 7);
        SiteMSC.TurnChip_H = TurnMarkSet(SiteH_turn, 8);


        //this.gameObject.GetComponent<Image>().sprite = Turn_num_icon1;

    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public int TurnMarkSet(Image turnMark, int x)
    {
        switch (SiteMSC.turnM[x])
        {
            case 1:
                turnMark.sprite = Turn_num_icon1;
                break;
            case 2:
                turnMark.sprite = Turn_num_icon2;
                break;
            case 3:
                turnMark.sprite = Turn_num_icon3;
                break;
            case 4:
                turnMark.sprite = Turn_num_icon4;
                break;
            case 5:
                turnMark.sprite = Turn_num_icon5;
                break;
            case 6:
                turnMark.sprite = Turn_num_icon6;
                break;
            case 7:
                turnMark.sprite = Turn_num_icon7;
                break;
            case 8:
                turnMark.sprite = Turn_num_icon8;
                break;
            default:
                // 処理３
                break;
        }
        return SiteMSC.turnM[x];
        image = turnMark;
    }

    //#################################################################################

}
// End