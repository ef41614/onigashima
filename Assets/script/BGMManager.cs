using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;
using UnityEngine.Audio;


public class BGMManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource audioSource2;
    AudioSource audioSource3;


    public AudioClip NatsuMatsuri;
    public AudioClip Wakizashi;
    public AudioClip Yuuchou;
 //   public AudioClip Ending;


    // --------------------------------------------
    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource2 = this.gameObject.GetComponent<AudioSource>();
        audioSource3 = this.gameObject.GetComponent<AudioSource>();
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
        Debug.Log("Play_CharaSelect_BGM 開始");
        StopBGM();
        audioSource.clip = NatsuMatsuri;
        audioSource.Play();
    }

    public void Play_Battle_BGM()
    {
        Debug.Log("Play_Battle_BGM 開始");
  //      StopBGM();
        audioSource3.clip = Wakizashi;
        audioSource3.Play();
    }

    public void Play_Opening_BGM()
    {
        Debug.Log("Play_Opening_BGM 開始");
        StopBGM();
        audioSource.clip = Yuuchou;
        audioSource.Play();
    }

    public void Play_Ending_BGM()
    {
        Debug.Log("エンディングBGM 開始");
        StopBGM();
        audioSource2.volume = 1.0f;
 //       audioSource2.clip = Ending;
        audioSource2.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void Continue_BattleBGM()
    {
        // Sceneを遷移してもオブジェクトが消えないようにする
        DontDestroyOnLoad(this);
    }

    public void FadeoutBGM()
    {
        audioSource.DOFade(0f, 5f);
    }


    //#################################################################################

}
// End