using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReverse_Ba : MonoBehaviour {


    public GameObject YakuCard;
    public int cardOpenedstep = 0;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {

        Debug.Log("this.transform.localRotation.y :" + this.transform.localRotation.y);

    }


    //####################################  Update  ###################################

    void Update()
    {


    }

    //####################################  other  ####################################


    public void ImageReset()
    {
        YakuCard.SetActive(false);
    }

    public void ImageSet()
    {
        YakuCard.SetActive(true);
    }

    public void StartCardOpen()
    {
        //        ImageSet();
        if (this.transform.localRotation.y >= 0.7f)
        {
            StartCoroutine(CardOpen());
            cardOpenedstep = 2;
        }
        else
        { }
    }

    //カードのGameObjectにアタッチしたScriptに記述
    //右回転用
    public IEnumerator CardOpen()
    {
        //カードを予め-180度回転させ裏面用の画像を表示する
        //裏面表示はコルーチン外で行っても良い
        //CanvasGroupでなくspriteのalpha値を操作しても良い
        transform.eulerAngles = new Vector3(0, 90, 0);

        float angle = -90f;
        float Speed = 100f;

        //-90度を超えるまで回転
        while (angle < -90f)
        {
            angle += Speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, angle, 0);
            yield return null;
        }

        //0度まで回転
        while (angle < 0f)
        {
            angle += Speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, angle, 0);
            yield return null;
        }

        //綺麗に0度にならないことがあるため、補正
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    //#################################################################################

}
// End