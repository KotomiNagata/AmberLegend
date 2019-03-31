using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOctavian_Allo : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;
    GameRule rule;
    GameStart_Allo events;

    float run = 0f;            // 移動方向
    float speed = 2f;          // 移動スピード
    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    int a = 1;

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        rule = FindObjectOfType<GameRule>();
        events = FindObjectOfType<GameStart_Allo>();

        state = "STOP";
    }
	
	
	void Update () {
        rb.velocity = new Vector2(run * speed, rb.velocity.y);
        Animation();

        if (rule.EdmondIsHuman)
        {
            HumanTalk();
        }
        if (!rule.EdmondIsHuman)
        {
            DinasourTalk();
        }
    }

    void HumanTalk()
    {
        if(events.point == 1)
        {
            state = "ANGRY";
        }
        if (events.point == 2)
        {
            state = "STOP";
        }
        if (events.point == 3)
        {
            state = "WALK";
            run = 1;
            if(this.transform.position.x > 1.1)
            {
                run = 0f;
                state = "TALK";
            }
        }
        if (events.point == 4)
        {
            run = 0f;
            state = "STOP";
        }
        if (events.point == 5)
        {
            state = "TALK";
        }
        if (events.point == 7)
        {
            Destroy(this.gameObject);
        }
    }

    void DinasourTalk()
    {
        if (events.point == 1)
        {
            state = "ANGRY";
        }
        if (events.point == 2)
        {
            state = "STOP";
        }
        if (events.point == 4)
        {
            state = "TALK";
        }
        if (events.point == 5)
        {
            state = "ANGRY";
        }
        if (events.point == 6)
        {
            state = "STOP";
        }
        if (events.point == 7)
        {
            state = "WALK";
            run = 1;
            if (this.transform.position.x > 1.1)
            {
                events.MoveAnimation(a);
            }
        }
        if(events.point == 8)
        {
            Destroy(this.gameObject);
        }
    }

    void Animation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "ANGRY":
                    animator.SetBool("isAngry", true);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isWalk", false);
                    break;
                case "STOP":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isStop", true);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isWalk", false);
                    break;
                case "TALK":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isWalk", false);
                    break;
                case "WALK":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isWalk", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
