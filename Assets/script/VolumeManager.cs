using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider BGMslider;

    public static float Eternal_BGMvol = 0.8f;
    float NowBGMvol;

    float currentTime = 0f;  //〇秒間に一度する処理用


    // --------------------------------------------
    private void Awake()
    {

    }

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        Debug.Log("VolumeManager 出席");
        Debug.Log("Eternal_BGMvol" + Eternal_BGMvol.ToString());

        NowBGMvol = Eternal_BGMvol;
        BGMslider.value = NowBGMvol;
        BGMVolume2();
    }


    //####################################  Update  ###################################

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 1)
        {
            Debug.Log("BGMslider.value" + BGMslider.value.ToString());

            currentTime = 0f;
        }
    }

    //####################################  other  ####################################

    public void ChangeBGMVolume(float vol)
    {
        mixer.SetFloat("BGMVolume", vol);
    }

    public void ChangeSEVolume(float vol)
    {
        mixer.SetFloat("SEVolume", vol);
    }

    public void BGMVolume(Slider slider)
    {
        mixer.SetFloat("BGMVolume", (slider.value*60)-50);
    }

    public void BGMVolume2()
    {
        mixer.SetFloat("BGMVolume", (BGMslider.value * 60) - 50);
    }

    public void SaveBGMvol()
    {
        Debug.Log("Eternal_BGMvol セーブ前 " + Eternal_BGMvol.ToString());
        Eternal_BGMvol = BGMslider.value;
        Debug.Log("Eternal_BGMvol セーブ後 " + Eternal_BGMvol.ToString());
    }

    //#################################################################################

}
// End