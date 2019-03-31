using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents_HolePast : MonoBehaviour {

    FadeIn fadeIn;

    public int turn = 1;          // Liopleurodonのターン回数
    public int PosNumber = 2;     // ツタの番号(左から123の順番)・Liopleurodonのため
                                  // Buttonから命令
    public GameObject LvyObj;     // ツタを複製
    public GameObject LineObj;    // 壁の模様線を複製
    public GameObject LioObj;
    public GameObject fadeInObj;
    public GameObject soundGameCrear;

    public bool LvyBool = false;  // LvyObj(Clone)用
    public bool LineBool = false; // LineObj(Clone)用
    public bool LioBool = true;   // LioObj(Clone)用
    public bool fadeInBool = true;
    public bool jumpNow = false;
    public bool LioTwo = false;   // Liopleurodonが２匹になる
    public string SkipSceneName_gameOver;
    public string SkipSceneName_gameCrear;

    public bool gameOver = false;  // Octavianから指示
    public bool gameCrear = false; // biteNumberの回数で判定
    public bool gameCrearFade = false; // Octavianから指示

    int biteNumber = 0;            // 噛み付いてきた回数 
    bool one = true;

	void Start () {
        PosNumber = 2;
	}
	
	void Update () {

        if(LvyBool)
        {
            Instantiate(LvyObj);
            LvyBool = false;
        }

        if(LineBool)
        {
            Instantiate(LineObj);
            LineBool = false;
        }

        // ２匹目投入
        if(biteNumber == 3)
        {
            if (LioBool)
            {
                Instantiate(LioObj);
                LioBool = false;
            }
        }

        //３匹目投入
        if (biteNumber == 10)
        {
            if (!LioBool)
            {
                Instantiate(LioObj);
                LioBool = true;
            }
        }

        if(biteNumber > 14)
        {
            gameCrear = true;
            if(one)
            {
                Instantiate(soundGameCrear);
                one = false;
            }
        }

        if (gameOver)
        {
            if(fadeInBool)
            {
                Instantiate(fadeInObj);
                fadeIn = FindObjectOfType<FadeIn>();
                fadeIn.sceneName = SkipSceneName_gameOver;
                fadeInBool = false;
            }
        }

        if(gameCrearFade)
        {
            if (fadeInBool)
            {
                Instantiate(fadeInObj);
                fadeIn = FindObjectOfType<FadeIn>();
                fadeIn.sceneName = SkipSceneName_gameCrear;
                fadeInBool = false;
            }
        }
	}

    public void BiteEvents(int a)
    {
        biteNumber = biteNumber + a;
    }

}
