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
    AudioSource audioSource2;

    public AudioClip NatsuMatsuri;
    public AudioClip Wakizashi;
    public AudioClip Yuuchou;
 //   public AudioClip Ending;


    // --------------------------------------------
    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource2 = this.gameObject.GetComponent<AudioSource>();
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

    public void Play_Ending_BGM()
    {
        Debug.Log("エンディングBGM開始");
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
//        audioSource.DOFade(0f, 5f).SetEase(Ease.Linear);
        audioSource.DOFade(0f, 5f);
    }


    //#################################################################################

}
// End