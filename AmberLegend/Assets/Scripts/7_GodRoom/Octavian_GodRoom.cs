using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octavian_GodRoom : MonoBehaviour {

    GameEvents_GodRoom events;
    Animator animator;

    public string serifNumber;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    void Start () {
        events = FindObjectOfType<GameEvents_GodRoom>();
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
        if (events.point == 5)
        {
            state = "STANDFRONT";
        }
        if (events.point == 6)
        {
            state = "TALKFRONT";
        }
        if (events.point == 7)
        {
            state = "STANDFRONT";
        }
        // １回目の選択肢
        if (events.point == 8)
        {
            if(serifNumber == "2_1")
            {
                state = "STANDRIGHT";
            }
            if (serifNumber == "2_2" ||
                serifNumber == "2_3")
            {
                state = "TALKFRONT";
            }
        }
        if (events.point == 9)
        {
            if (serifNumber == "2_2" ||
                serifNumber == "2_3")
            {
                state = "TALKRIGHT";
            }
        }
        if (events.point == 10)
        {
            if (serifNumber == "2_1")
            {
                state = "STANDRIGHT";
            }
            if (serifNumber == "2_2" ||
                serifNumber == "2_3")
            {
                events.point = 7;
            }
        }
        if (events.point == 11)
        {
            state = "STANDFRONT";
        }
        if (events.point == 12)
        {
            if (serifNumber == "3_1" ||
                serifNumber == "3_3")
            {
                state = "STANDRIGHT";
            }
            if (serifNumber == "3_2")
            {
                state = "TALKFRONT";
            }
        }
        if (events.point == 13)
        {
            if (serifNumber == "3_2")
            {
                state = "TALKRIGHT";
            }
        }
        if (events.point == 14)
        {
            if (serifNumber == "3_1" ||
                serifNumber == "3_3")
            {
                state = "STANDRIGHT";
            }
            if (serifNumber == "3_2")
            {
                events.point = 11;
            }
        }
        if (events.point == 15)
        {
            state = "STANDFRONT";
        }
        if (events.point == 21)
        {
            state = "LOOKAROUND";
        }
        if (events.point == 22)
        {
            state = "TALKRIGHT";
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
                    break;

                case "LOOKAROUND":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isLookAround", true);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isTalkRight", false);
                    break;

                case "STANDFRONT":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isStandFront", true);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isTalkRight", false);
                    break;

                case "TALKFRONT":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkFront", true);
                    animator.SetBool("isTalkRight", false);
                    break;

                case "TALKRIGHT":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isTalkRight", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

    void OnMouseDown()
    {
        if(events.point == 16)
        {
            state = "TALKFRONT";
            Invoke("MouseDownAfter", 1f);
        }
    }

    void MouseDownAfter()
    {
        state = "STANDFRONT";
    }

}
