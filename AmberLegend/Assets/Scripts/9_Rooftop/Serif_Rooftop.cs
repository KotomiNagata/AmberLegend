﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Serif_Rooftop : MonoBehaviour {
    GameEvents_Rooftop events;
    GameCrear_Rooftop crear;
    
    public string[] sentences; // 文章を格納する
    [SerializeField] Text uiText;   // uiTextへの参照

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f;           // 1文字の表示にかける時間

    private int currentSentenceNum = 0;             //現在表示している文章番号
    private string currentSentence = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;             // 表示にかかる時間
    private float timeBeganDisplay = 1;             // 文字列の表示を開始した時間
    private int lastUpdateCharCount = -1;           // 表示中の文字数

    public GameObject clickIconObj;
    int a = 1;                                      // GameEventsへ point追加
    bool one = true;                                // clickIconObj(Clone)用
    public bool gameCrear = false;

    void Start()
    {
        SetNextSentence();
        if(!gameCrear)
        {
            events = FindObjectOfType<GameEvents_Rooftop>();
            events.MoveAnimation(a);
        }
        if(gameCrear)
        {
            crear = FindObjectOfType<GameCrear_Rooftop>();
            crear.MoveAnimation(a);
        }
    }

    void Update()
    {
        // 文章の表示完了
        if (IsDisplayComplete())
        {
            if (one)
            {
                Instantiate(clickIconObj);
                one = false;
            }

            //最後の文章ではない & ボタンが押された
            if (currentSentenceNum < sentences.Length
                && Input.GetMouseButton(0)
                && GameObject.FindWithTag("ClickIcon") == true)
            {
                SetNextSentence();
                if(!gameCrear)
                {
                    events.MoveAnimation(a);
                }
                if (gameCrear)
                {
                    crear.MoveAnimation(a);
                }
                one = true;
            }
        }

        //表示される文字数を計算
        int displayCharCount = (int)(Mathf.Clamp01((Time.time - timeBeganDisplay) / timeUntilDisplay) * currentSentence.Length);
        //表示される文字数が表示している文字数と違う
        if (displayCharCount != lastUpdateCharCount)
        {
            uiText.text = currentSentence.Substring(0, displayCharCount);
            //表示している文字数の更新
            lastUpdateCharCount = displayCharCount;
        }

        //最後の文章が来たら次は文章を削除
        if (currentSentenceNum == sentences.Length)
        {
            Destroy(gameObject);
        }

    }

    // 次の文章をセットする
    void SetNextSentence()
    {
        currentSentence = sentences[currentSentenceNum];
        timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
        timeBeganDisplay = Time.time;
        currentSentenceNum++;
        lastUpdateCharCount = 0;
    }

    bool IsDisplayComplete()
    {
        return Time.time > timeBeganDisplay + timeUntilDisplay; //※2
    }
}
