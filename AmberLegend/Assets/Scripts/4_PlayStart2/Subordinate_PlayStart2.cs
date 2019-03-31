using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subordinate_PlayStart2 : MonoBehaviour
{

    Animator animator;
    StartMove_PlayStart2 startMove;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    public bool YouAreLeft  = true;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        startMove = FindObjectOfType<StartMove_PlayStart2>();
    }

    void Update()
    {
        SelectAnimation();

        if(YouAreLeft)
        {
            if(startMove.point == 17)
            {
                state = "TALK";
            }
        }

        if (!YouAreLeft)
        {
            if (startMove.point == 18)
            {
                state = "TALK";
            }
        }

        if (startMove.point == 19)
        {
            state = "STAND";
        }

    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STAND":
                    animator.SetBool("isStand", true);
                    animator.SetBool("isTalk", false);
                    break;

                case "TALK":
                    animator.SetBool("isStand", false);
                    animator.SetBool("isTalk", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
