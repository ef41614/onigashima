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

    public Image PreventRollFace;
    public GameObject RollNameText;
    public int countX = 1;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        image = this.GetComponent<Image>();

        RollFaceSet(SiteA_rollF, 1);
        RollFaceSet(SiteB_rollF, 2);
        RollFaceSet(SiteC_rollF, 3);
        RollFaceSet(SiteD_rollF, 4);
        RollFaceSet(SiteE_rollF, 5);
        RollFaceSet(SiteF_rollF, 6);
        RollFaceSet(SiteG_rollF, 7);
        RollFaceSet(SiteH_rollF, 8);
        RollFaceSet(SiteTrash_rollF, 8);


        //this.gameObject.GetComponent<Image>().sprite = Yaku_icon1;
        AppearPreventRoll();

    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void RollFaceSet(Image RollFace, int x)
    {
        switch (SiteMSC.rollF[x])
        {
            case 1:
                RollFace.sprite = Yaku_icon1;
                break;
            case 2:
                RollFace.sprite = Yaku_icon2;
                break;
            case 3:
                RollFace.sprite = Yaku_icon3;
                break;
            case 4:
                RollFace.sprite = Yaku_icon4;
                break;
            case 5:
                RollFace.sprite = Yaku_icon5;
                break;
            case 6:
                RollFace.sprite = Yaku_icon6;
                break;
            case 7:
                RollFace.sprite = Yaku_icon7;
                break;
            case 8:
                RollFace.sprite = Yaku_icon8;
                break;
            default:
                // 処理３
                break;
        }
        image = RollFace;
        image.SetNativeSize();
    }

    public void AppearPreventRoll()
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

    //#################################################################################

}
// End