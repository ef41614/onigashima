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


    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        CloseBrownBox();
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


    public void OpenScroll()
    {
        if (brown_box != null)
        {
            CloseBrownBox();
            OpenBrownBox();
        }
        Text_Scroll.SetActive(true);
    }

    public void CloseScroll()
    {
        Text_Scroll.SetActive(false);
    }

    //#################################################################################

}
// End