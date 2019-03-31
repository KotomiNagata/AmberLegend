using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Cave : MonoBehaviour {

    Animator animator;
    GameEvents_Cave events;

    public float totalTime;
    int seconds;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    bool one = true; // タイマーを止める準備

    void Start () {
        this.animator = GetComponent<Animator>();
        events = FindObjectOfType<GameEvents_Cave>();
        state = "H1";
    }
	
	void Update () {
        SelectAnimation();


        if(one)
        {
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
        }

        if(totalTime < 30f)
        {
            state = "H2";

            if(totalTime < 10f)
            {
                state = "H3";

                if(totalTime <= 0f)
                {
                    events.gameOver = true;
                    one = false;
                }
            }
        }

        if(GameObject.FindGameObjectWithTag("Pose") || events.gameCrear)
        {
            one = false;
        }else{
            one = true;
        }
    }

    public void Damage(int a)
    {
        totalTime = totalTime - a;
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "H1":
                    animator.SetBool("isH1", true);
                    animator.SetBool("isH2", false);
                    animator.SetBool("isH3", false);
                    break;

                case "H2":
                    animator.SetBool("isH1", false);
                    animator.SetBool("isH2", true);
                    animator.SetBool("isH3", false);
                    break;

                case "H3":
                    animator.SetBool("isH1", false);
                    animator.SetBool("isH2", false);
                    animator.SetBool("isH3", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
