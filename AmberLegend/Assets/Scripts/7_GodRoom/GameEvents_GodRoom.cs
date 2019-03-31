using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents_GodRoom : MonoBehaviour {

    FadeIn fadeIn;
    GameRule rule;
    GodDama_GodRoom dama;

    public GameObject button1Obj;
    public GameObject button2Obj;
    public GameObject serif1BoyObj;
    public GameObject serif1GirlObj;
    public GameObject serif3_4Obj;
    public GameObject maruObj;
    public GameObject fadeObj;
    public string nextScene;

    public int point = 0;     // セリフと動きを合わせるため
    bool start = true;  // serif1用
    bool fadeBool = true;
    bool one = true;    // button1Obj用
    bool two = true;    // button2Obj用
    bool four = true;   // serif3_4Obj用

    void Start () {
        rule = FindObjectOfType<GameRule>();
        dama = FindObjectOfType<GodDama_GodRoom>();
    }
	
	void Update () {

        if(start)
        {
            FadeInStart();
        }

        if(point == 7)
        {
            if(one)
            {
                Instantiate(button1Obj);
                one = false;
            }
        }
        if(point == 8)
        {
            one = true;
        }
        if (point == 11)
        {
            if(two)
            {
                Instantiate(button2Obj);
                two = false;
            }
        }
        if (point == 12)
        {
            two = true;
        }
        if (point == 15)
        {
            if(four)
            {
                Instantiate(serif3_4Obj);
                Instantiate(maruObj);
                four = false;
            }
        }
        if (point == 18)
        {
            dama.give = true;
        }
        if(point == 25)
        {
            if(fadeBool)
            {
                Instantiate(fadeObj);
                fadeBool = false;
            }
            fadeIn = FindObjectOfType<FadeIn>();
            fadeIn.sceneName = nextScene;
        }

    }

    void FadeInStart()
    {
        if (!GameObject.FindGameObjectWithTag("Fade"))
        {
            if(rule.IamBoy)
            {
                Instantiate(serif1BoyObj);
            }
            if(!rule.IamBoy)
            {
                Instantiate(serif1GirlObj);
            }
            start = false;
        }
    }

    // Serif_PlayStart2の流れとアニメを同期するため
    public void MoveAnimation(int a)
    {
        point = point + a;
    }
}
