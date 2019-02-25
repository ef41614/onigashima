using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class SEManager : MonoBehaviour {

    AudioSource audioSource;
    AudioSource audioSource2;
    public AudioClip OK_SE;
    public AudioClip OK2_SE;
    public AudioClip cancelSE;
    public AudioClip cursorSE;
    public AudioClip bridge10;
    public AudioClip select01;
    public AudioClip pon01;
    public AudioClip WoodPut2;
    public AudioClip punch;
    public AudioClip suka;
    public AudioClip kizetu;
    public AudioClip hyoushigi1;
    public AudioClip hyoushigi2_long;
    public AudioClip kotsudumi1;
    public AudioClip taiko1;
    public AudioClip Kabai;
    public AudioClip jidai;
    public AudioClip checkON;
    public AudioClip checkOFF;

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource2 = this.gameObject.GetComponent<AudioSource>();

    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void Kettei_SE()
    {
        audioSource.PlayOneShot(OK_SE);
    }

    public void Kettei2_SE()
    {
        audioSource.PlayOneShot(OK2_SE);
    }

    public void cancel_SE()
    {
        audioSource.PlayOneShot(cancelSE);
    }

    public void cursor_SE()
    {
        audioSource.PlayOneShot(cursorSE);
    }

    public void bridge10_SE()
    {
        audioSource.PlayOneShot(bridge10);
    }

    public void select01_SE()
    {
        audioSource.PlayOneShot(select01);
    }

    public void pon01_SE()
    {
        audioSource.PlayOneShot(pon01);
    }

    public void WoodPut_SE()
    {
        audioSource2.PlayOneShot(WoodPut2);
    }

    public void punch_SE()
    {
        audioSource2.PlayOneShot(punch);
    }

    public void suka_SE()
    {
        audioSource2.PlayOneShot(suka);
    }

    public void kizetu_SE()
    {
        audioSource2.PlayOneShot(kizetu);
    }

    public void hyoushigi1_SE()
    {
        audioSource2.PlayOneShot(hyoushigi1);
    }
       
    public void hyoushigi2_long_SE()
    {
        audioSource2.PlayOneShot(hyoushigi2_long);
    }

    public void kotsudumi1_SE()
    {
        audioSource2.PlayOneShot(kotsudumi1);
    }

    public void taiko1_SE()
    {
        audioSource2.PlayOneShot(taiko1);
    }

    public void Kabai_SE()
    {
        audioSource.PlayOneShot(Kabai);
    }

    public void jidai_SE()
    {
        audioSource.PlayOneShot(jidai);
    }

    public void checkON_SE()
    {
        audioSource.PlayOneShot(checkON);
    }

    public void checkOFF_SE()
    {
        audioSource.PlayOneShot(checkOFF);
    }


    //#################################################################################

}
// End