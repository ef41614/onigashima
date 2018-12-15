﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class SEManager : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip OK_SE;
    public AudioClip OK2_SE;
    public AudioClip cancelSE;
    public AudioClip cursorSE;
    public AudioClip bridge10;
    public AudioClip select01;
    public AudioClip pon01;
    public AudioClip WoodPut;

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

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
        audioSource.PlayOneShot(WoodPut);
    }

    //#################################################################################

}
// End