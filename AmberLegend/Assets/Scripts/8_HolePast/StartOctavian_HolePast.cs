using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOctavian_HolePast : MonoBehaviour {

    Start_HolePast events;
    Animator animator;
    Rigidbody2D rb;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    float run = 0f;            // 移動方向
    public float speed = 3f;   // 移動スピード

    bool running = false;

    void Start () {
        events = FindObjectOfType<Start_HolePast>();
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        run = 0f;
    }
	
	void Update () {
        SelectAnimation();

        if (events.point == 1)
        {
            state = "LOOKAROUND";
        }
        if (events.point == 2)
        {
            state = "TALKLEFT";
        }
        if (events.point == 3)
        {
            state = "TALKRIGHT";
        }
        if (events.point == 4)
        {
            state = "WALK";
            running = true;
        }

        if(running)
        {
            rb.velocity = new Vector2(run * speed, rb.velocity.y);
            run = -1f;
        }

        if(this.transform.position.x < -4.9)
        {
            events.runEnd = true;
            Destroy(this.gameObject);
        }
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "LOOKAROUND":
                    animator.SetBool("isLookAround", true);
                    animator.SetBool("isTalkLeft", false);
                    animator.SetBool("isTalkRight", false);
                    animator.SetBool("isWalk", false);
                    break;

                case "TALKLEFT":
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isTalkLeft", true);
                    animator.SetBool("isTalkRight", false);
                    animator.SetBool("isWalk", false);
                    break;

                case "TALKRIGHT":
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isTalkLeft", false);
                    animator.SetBool("isTalkRight", true);
                    animator.SetBool("isWalk", false);
                    break;

                case "WALK":
                    animator.SetBool("isLookAround", false);
                    animator.SetBool("isTalkLeft", false);
                    animator.SetBool("isTalkRight", false);
                    animator.SetBool("isWalk", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
