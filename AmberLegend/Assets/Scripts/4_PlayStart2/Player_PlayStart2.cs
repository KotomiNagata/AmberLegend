using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PlayStart2 : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;
    StartMove_PlayStart2 startMove;
    Serif_PlayStart2 serif;
    Octavian_PlayStart2 octavian;

    string state;               // 見た目の切り替え
    string prevState;           // 前の状態を保存
    float run = 0f;
    float speed = 4f;           // 移動スピード
    int a = 1;

    public bool catch1 = false; // CatchPlayerから命令
    bool one = true;            // pointを一回送るため
    bool two = true;            // テキスト送りを１回

    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        startMove = FindObjectOfType<StartMove_PlayStart2>();
        octavian = FindObjectOfType<Octavian_PlayStart2>();
        state = "WALK";
        run = 1f;
    }


    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, run * speed);
        SelectAnimation();

        // 立ち止まる
        if (this.transform.position.y > 0)
        {
            run = 0f;
            state = "STOP";
            octavian.playerArrive = true;

            if(one)
            {
                startMove.MoveAnimation(a);
                one = false;
            }

            if (catch1)
            {
                state = "HELPME";
                if(two)
                {
                    serif = FindObjectOfType<Serif_PlayStart2>();
                    serif.NextText = true;
                    two = false;
                }
                run = -1f;
                speed = 2f;
            }
        }
        if (this.transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }

        if (startMove.point == 3)
        {
            state = "TALK";
        }
        if (startMove.point >= 4 && startMove.point <= 7)
        {
            state = "STOP";
        }
        if (startMove.point == 8)
        {
            state = "TALK";
        }

    }

    void SelectAnimation()
    {

        if (prevState != state)
        {
            switch (state)
            {
                case "WALK":
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isHelpMe", false);
                    break;

                case "STOP":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isStop", true);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isHelpMe", false);
                    break;

                case "TALK":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isHelpMe", false);
                    break;

                case "HELPME":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isHelpMe", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
