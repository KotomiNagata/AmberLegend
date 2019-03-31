using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God_GodRoom : MonoBehaviour {

    Animator animator;
    GameEvents_GodRoom events;
    Octavian_GodRoom octavian;

    public int moving = 1;     // GodDamaと動きを同期するため

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    void Start()
    {
        this.animator = GetComponent<Animator>();
        events = FindObjectOfType<GameEvents_GodRoom>();
        octavian = FindObjectOfType<Octavian_GodRoom>();
    }

    void Update()
    {
        SelectAnimation();

        if (events.point == 2 ||
           events.point == 3 ||
           events.point == 4 ||
           events.point == 8 && octavian.serifNumber == "2_1"||
           events.point == 9 && octavian.serifNumber == "2_1" ||
           events.point == 10 && octavian.serifNumber == "2_1" ||
           events.point == 12 && octavian.serifNumber != "3_2" ||
           events.point == 13 && octavian.serifNumber != "3_2" ||
           events.point == 14 && octavian.serifNumber != "3_2" ||
           events.point == 17 ||
           events.point == 19 ||
           events.point == 20 )
        {
            state = "TALK";
            moving = 2; // 玉が止まる
            if (GameObject.FindGameObjectWithTag("ClickIcon"))
            {
                state = "USUALLY";
                moving = 1; // 玉も動く
            }
        }

        if(events.point == 16)
        {
            state = "STOP";
            moving = 2;
        }

        if(events.point == 23 ||
           events.point == 24)
        {
            state = "TALK";
            moving = 2;
            if (GameObject.FindGameObjectWithTag("ClickIcon"))
            {
                state = "STOP";
                moving = 1;
            }
        }
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "USUALLY":
                    animator.SetBool("isUsually", true);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isStop", false);
                    break;

                case "TALK":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isStop", false);
                    break;

                case "STOP":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isStop", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
