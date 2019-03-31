using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octavian_AlloGameCreaar : MonoBehaviour {

    Animator animator;
    GameCrearEvent_Allo events;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    void Start () {
        this.animator = GetComponent<Animator>();
        events = FindObjectOfType<GameCrearEvent_Allo>();
        state = "FEAR";
    }
	
	void Update () {
        OctavianAnimation();

        if (events.point == 1)
        {
            state = "FEARSTOP";
        }
        if (events.point == 2)
        {
            state = "FEAR";
        }
        if (events.point == 3)
        {
            state = "FEARSTOP";
        }
        if (events.point == 4)
        {
            state = "FEAR";
        }
        if (events.point == 5)
        {
            state = "FEARSTOP";
        }
        if (events.point == 6)
        {
            state = "FEAR";
        }
        if (events.point == 10)
        {
            state = "FEARSTOP";
        }
        if (events.point == 12)
        {
            state = "RIFEAR";
        }
        if (events.point == 13)
        {
            state = "RISTOP";
        }
        if (events.point == 16)
        {
            state = "RIFEAR";
        }
        if (events.point == 17)
        {
            state = "RITALK";
        }
        if (events.point == 18)
        {
            state = "RIFEAR";
        }

    }

    void OctavianAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "FEAR":
                    animator.SetBool("isFear", true);
                    animator.SetBool("isFearStop", false);
                    animator.SetBool("isRiStop", false);
                    animator.SetBool("isRiTalk", false);
                    animator.SetBool("isRiFear", false);
                    break;

                case "FEARSTOP":
                    animator.SetBool("isFear", false);
                    animator.SetBool("isFearStop", true);
                    animator.SetBool("isRiStop", false);
                    animator.SetBool("isRiTalk", false);
                    animator.SetBool("isRiFear", false);
                    break;

                case "RISTOP":
                    animator.SetBool("isFear", false);
                    animator.SetBool("isFearStop", false);
                    animator.SetBool("isRiStop", true);
                    animator.SetBool("isRiTalk", false);
                    animator.SetBool("isRiFear", false);
                    break;

                case "RITALK":
                    animator.SetBool("isFear", false);
                    animator.SetBool("isFearStop", false);
                    animator.SetBool("isRiStop", false);
                    animator.SetBool("isRiTalk", true);
                    animator.SetBool("isRiFear", false);
                    break;

                case "RIFEAR":
                    animator.SetBool("isFear", false);
                    animator.SetBool("isFearStop", false);
                    animator.SetBool("isRiStop", false);
                    animator.SetBool("isRiTalk", false);
                    animator.SetBool("isRiFear", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
