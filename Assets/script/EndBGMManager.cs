using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBGMManager : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip Ending;

    public GameObject BGMManager;
    BGMManager BGMMSC;
    public GameObject VolumeManager;
    VolumeManager VolumeMSC;

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        BGMMSC = BGMManager.GetComponent<BGMManager>();
        VolumeMSC = VolumeManager.GetComponent<VolumeManager>();

        audioSource = this.gameObject.GetComponent<AudioSource>();
    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################

    public void Play_Ending_BGM()
    {
        Debug.Log("エンディングBGM開始");
        Debug.Log("audioSource.volume"+ audioSource.volume);

        audioSource.volume = VolumeMSC.ForEnding_BGMvol;  // 現在のBGM音量を audioSource3 に適応させる
        BGMMSC.StopBGM();
        audioSource.clip = Ending;
        audioSource.loop = true;
        audioSource.Play();
        Debug.Log("audioSource.volume" + audioSource.volume);

    }

    //#################################################################################

}
// End