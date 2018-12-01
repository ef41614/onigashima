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

    Image image;
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
    
    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        SiteMSC = SiteManager.GetComponent<SiteManager>();
        image = this.GetComponent<Image>();

        CharaFaceSet(SiteA_charaF, 1);
        CharaFaceSet(SiteB_charaF, 2);
        CharaFaceSet(SiteC_charaF, 3);
        CharaFaceSet(SiteD_charaF, 4);
        CharaFaceSet(SiteE_charaF, 5);
        CharaFaceSet(SiteF_charaF, 6);
        CharaFaceSet(SiteG_charaF, 7);
        CharaFaceSet(SiteH_charaF, 8);


        //        image.SetNativeSize();

        //this.gameObject.GetComponent<Image>().sprite = VTuber_icon1;

    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void CharaFaceSet(Image charaFace, int x)
    {
        switch (SiteMSC.charaN[x])
        {
            case 1:
                charaFace.sprite = VTuber_icon1;
                break;
            case 2:
                charaFace.sprite = VTuber_icon2;
                break;
            case 3:
                charaFace.sprite = VTuber_icon3;
                break;
            case 4:
                charaFace.sprite = VTuber_icon4;
                break;
            case 5:
                charaFace.sprite = VTuber_icon5;
                break;
            case 6:
                charaFace.sprite = VTuber_icon6;
                break;
            case 7:
                charaFace.sprite = VTuber_icon7;
                break;
            case 8:
                charaFace.sprite = VTuber_icon8;
                break;
            case 9:
                charaFace.sprite = VTuber_icon9;
                break;
            case 10:
                charaFace.sprite = VTuber_icon10;
                break;
            case 11:
                charaFace.sprite = VTuber_icon11;
                break;
            case 12:
                charaFace.sprite = VTuber_icon12;
                break;
            default:
                // 処理３
                break;
        }
        image = charaFace;
    }
    
    //#################################################################################

}
// End