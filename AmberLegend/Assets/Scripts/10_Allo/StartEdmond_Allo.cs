using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEdmond_Allo : MonoBehaviour {

    Animator animator;
    GameStart_Allo start;

    public bool human = true;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    void Start () {
        this.animator = GetComponent<Animator>();
        start = FindObjectOfType<GameStart_Allo>();
        state = "STOP";
    }
	
	void Update () {
        if(human)
        {
            HumanAnimation();
            HumanMove();
        }
        if(!human)
        {
            DinasourAnimation();
            DinasourMove();
        }
	}

    void HumanMove()
    {
        if(start.point == 2)
        {
            state = "TALK";
        }
        if (start.point == 3)
        {
            state = "STOP";
        }
        if (start.point == 4)
        {
            state = "TALK";
        }
        if (start.point == 5)
        {
            state = "STOP";
        }
        if (start.point == 6)
        {
            state = "TALK";
        }
        if (start.point == 7)
        {
            Destroy(this.gameObject);
        }
    }

    void DinasourMove()
    {
        if (start.point == 2)
        {
            state = "TALK";
        }
        if (start.point == 3)
        {
            state = "ENJOY";
        }
        if (start.point == 6)
        {
            state = "SIT";
        }
        if (start.point == 8)
        {
            Destroy(this.gameObject);
        }
    }

    void HumanAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STOP":
                    animator.SetBool("isStop", true);
                    animator.SetBool("isTalk", false);
                    break;
                case "TALK":
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

    void DinasourAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STOP":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isEnjoy", false);
                    animator.SetBool("isSit", false);
                    break;
                case "TALK":
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isEnjoy", false);
                    animator.SetBool("isSit", false);
                    break;
                case "ENJOY":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isEnjoy", true);
                    animator.SetBool("isSit", false);
                    break;
                case "SIT":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isEnjoy", false);
                    animator.SetBool("isSit", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
