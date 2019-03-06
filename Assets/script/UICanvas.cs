using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class UICanvas : MonoBehaviour
{
    public float AdjustSize = 0.9f;
    //public GameObject UICanvas_01;
    public GameObject StableAspect;
    StableAspect StableASC;

    // Use this for initialization
    void Start()
    {
        StableASC = StableAspect.GetComponent<StableAspect>();
        Debug.Log("UICanvas Start");

        RectTransform rectTransform = GetComponent<RectTransform>();
        CanvasScaler cs = GetComponent<CanvasScaler>();

        float mwh = cs.matchWidthOrHeight;
 //       float Hiritsu = 1.777777f;   // 16÷9 の値

        Rect rect = rectTransform.rect;
        float width = rect.width;
        float height = rect.height;

        Debug.Log("width=" + width);
        Debug.Log("height=" + height);


        float r = height / width;
        Debug.Log("r=" + r);
        if (StableASC.GamenSize == 0)  // 0：「16:9」
        {
            //9：16 もしくは iPad
            Debug.Log("スマホ　9：16 もしくは iPad");
            cs.matchWidthOrHeight = 1;
        }
        else if (StableASC.GamenSize == 1)  // 1：XR（たて型）
        {
            //XR 細長い
            Debug.Log("XR 細長い");
            cs.matchWidthOrHeight = AdjustSize;
        }
        mwh = cs.matchWidthOrHeight;
        Debug.Log("mwh=" + mwh);
    }

    // Update is called once per frame
    void Update()
    {

    }
}