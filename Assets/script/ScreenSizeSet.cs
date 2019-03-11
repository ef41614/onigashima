using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeSet : MonoBehaviour
{

    public int ScreenWidth = 338;
    public int ScreenHeight = 600;

    [RuntimeInitializeOnLoadMethod()]
    static void Init()
    {
        // PC向けビルドだったらサイズ変更
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.OSXPlayer ||
            Application.platform == RuntimePlatform.LinuxPlayer)
        {
            //			Screen.SetResolution(ScreenWidth, ScreenHeight, false);
            Screen.SetResolution(338, 600, false);
        }

    }

}