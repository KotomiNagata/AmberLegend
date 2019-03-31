using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octavian_GodroomHole : MonoBehaviour {

    GodRoomHole events;
    Animator animator;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    void Start () {
        events = FindObjectOfType<GodRoomHole>();
        this.animator = GetComponent<Animator>();
    }
	
	void Update () {
        SelectAnimation();

        if(events.point == 1)
        {
            state = "LOOKAROUND";
        }
        if (events.point == 2)
        {
            state = "STANDRIGHT";
        }
        if (events.point == 3)
        {
            state = "TALKRIGHT";
        }
        if (events.point == 4)
        {
            state = "SEKI";
        }
        if (events.point == 5)
        {
            state = "TALKFRONT";
        }
        if (events.point == 6)
        {
            state = "TALKRIGHT";
        }
        if (events.point == 7)
        {
            state = "STANDRIGHT";
        }
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STANDRIGHT":
                    animator.SetBool("isStandRight", true);
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isTalkRight", false);
                    animator.SetBool("isSeki", false);
                    break;

                case "LOOKAROUND":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isLookAround", true);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isTalkRight", false);
                    animator.SetBool("isSeki", false);
                    break;

                case "STANDFRONT":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isStandFront", true);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isTalkRight", false);
                    animator.SetBool("isSeki", false);
                    break;

                case "TALKFRONT":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkFront", true);
                    animator.SetBool("isTalkRight", false);
                    animator.SetBool("isSeki", false);
                    break;

                case "TALKRIGHT":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isTalkRight", true);
                    animator.SetBool("isSeki", false);
                    break;

                case "SEKI":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isTalkRight", false);
                    animator.SetBool("isSeki", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
