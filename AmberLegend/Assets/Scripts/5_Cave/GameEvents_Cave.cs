using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents_Cave : MonoBehaviour {

    FadeIn fadeIn;

    public GameObject octavianObj; // オラヴィタン
    public GameObject edmondObj;   // エドモン
    public GameObject gateObj;     // ガード
    public GameObject escapeObj;   // 逃げる
    public GameObject doorObj;     // ドア
    public GameObject BG_BackObj;  // 背景(Back)
    public GameObject BG_FrontObj; // 背景(Front)
    public GameObject FadeInObj;   // フェードアウト
    public GameObject soundGameCrear;

    public bool gate = false;       // クリックしてガード、Bottunから指示
    public bool NP = false;         // ねずみやコウモリが現れている間
    public bool gameCrear = false;  // ゲームクリア
    public bool gameCrear2 = false;
    public bool gameOver = false;   // Heartから報告
    public bool doorCreate = false; // ドアを生成するかどうか
    public bool BG_B_Create = false;// 背景（B）を生成するか
    public bool BG_F_Create = false;// 背景（F）を生成するか
    public bool escapeOFF = false;  // 逃げ終わったか
    public bool sneeze = false;     // くしゃみしたか
    public bool bintaEnd = false;   // ビンタし終わったか

    public int point = 0;           // ドアが出現した数
    public int doorMathGoal = 0;    // ゴールする時のドアの数
    public string SkipSceneName_gameCrear;   // 次のシーンの名前
    public string SkipSceneName_gameOver;    // 次のシーンの名前

    bool one = true;   // escapeObj(Clone)用
    bool two = true;   // gateObj(Clone)用
    bool three = true; // octavianObj & edmondObj(Clone)用
    bool soundBool = true;

    void Update () {

        if(gate)
        {
            if(two)
            {
                Instantiate(gateObj);
                two = false;
            }
            three = true;
        }
        if(!gate){
            two = true;
            if(three)
            {
                Instantiate(octavianObj);
                Instantiate(edmondObj);
                three = false;
                bintaEnd = false;
            }
        }

        if(bintaEnd)
        {
            three = true;
            sneeze = false;
        }


        if (doorCreate)
        {
            Instantiate(doorObj);
            doorCreate = false;
        }

        if(BG_B_Create)
        {
            Instantiate(BG_BackObj);
            BG_B_Create = false;
        }

        if(BG_F_Create)
        {
            Instantiate(BG_FrontObj);
            BG_F_Create = false;
        }

        if(point == doorMathGoal)
        {
            gameCrear = true;
        }

        if(gameCrear2)
        {
            if(soundBool)
            {
                Instantiate(soundGameCrear);
                Instantiate(FadeInObj);
                soundBool = false;
            }
            fadeIn = FindObjectOfType<FadeIn>();
            fadeIn.sceneName = SkipSceneName_gameCrear;
        }

        if(gameOver)
        {
            if(one)
            {
                Instantiate(escapeObj);
                one = false;
            }
            if(escapeOFF)
            {
                if (soundBool)
                {
                    Instantiate(FadeInObj);
                    soundBool = false;
                }
                fadeIn = FindObjectOfType<FadeIn>();
                fadeIn.sceneName = SkipSceneName_gameOver;
                escapeOFF = false;
            }
        }
	}

    // 出現したドアの数。
    public void DoorMath(int a)
    {
        point = point + a;
    }

}
