using System.Collections;
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

    //#################################################################################

}
// End