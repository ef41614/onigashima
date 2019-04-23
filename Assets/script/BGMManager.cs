using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class BGMManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip NatsuMatsuri;
    public AudioClip Wakizashi;
    public AudioClip Yuuchou;


    // --------------------------------------------
    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = Yuuchou;
    }

    //☆################☆################  Start  ################☆################☆

    void Start()
    {

    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void Play_CharaSelect_BGM()
    {
        StopBGM();
        audioSource.clip = NatsuMatsuri;
        audioSource.Play();
    }

    public void Play_Battle_BGM()
    {
        StopBGM();
        audioSource.clip = Wakizashi;
        audioSource.Play();
    }

    public void Play_Opening_BGM()
    {
        StopBGM();
        audioSource.clip = Yuuchou;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }


    //#################################################################################

}
// End