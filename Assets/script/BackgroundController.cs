using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // スクロール速度
    private float scrollSpeed = -1f;
    // 背景終了位置
    float deadLine = -100;
    // 背景開始位置
    float startLine = 300;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 背景を移動する
        transform.Translate(this.scrollSpeed, 0, 0);

        // 画面外に出たら、画面右端に移動する
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, transform.position.y);
        }
    }
}
