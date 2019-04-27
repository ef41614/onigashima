using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider BGMslider;
    public Slider SEslider;

    public static float Eternal_BGMvol = 0.8f;
    public static float Eternal_SEvol = 0.8f;
    
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
        Debug.Log("Eternal_BGMvol" + Eternal_SEvol.ToString());


        BGMslider.value = Eternal_BGMvol;
        SEslider.value = Eternal_SEvol;

        BGMVolume2();
    }


    //####################################  Update  ###################################

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 2)
        {
            // Debug.Log("BGMslider.value" + BGMslider.value.ToString());
            // Debug.Log("SEslider.value" + SEslider.value.ToString());

            currentTime = 0f;
        }
    }

    //####################################  other  ####################################

    public void BGMVolume2()
    {
        mixer.SetFloat("BGMVolume", (BGMslider.value * 60) - 50);
    }

    public void SEVolume2()
    {
        mixer.SetFloat("SEVolume", (SEslider.value * 60) - 50);
    }

    public void SaveBGMvol()
    {
        Debug.Log("Eternal_BGMvol セーブ前 " + Eternal_BGMvol.ToString());
        Eternal_BGMvol = BGMslider.value;
        Debug.Log("Eternal_BGMvol セーブ後 " + Eternal_BGMvol.ToString());
    }

    public void SaveSEvol()
    {
        Debug.Log("Eternal_SEvol セーブ前 " + Eternal_SEvol.ToString());
        Eternal_SEvol = SEslider.value;
        Debug.Log("Eternal_SEvol セーブ後 " + Eternal_SEvol.ToString());
    }

    //#################################################################################

}
// End