using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edmond_PlayStart2 : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;
    StartMove_PlayStart2 startMove;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    float run = 0f;
    float speed = 2f;           // 移動スピード

    void Start () {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        startMove = FindObjectOfType<StartMove_PlayStart2>();

        state = "STANDFRONT";
    }
	
	void Update () {
        SelectAnimation();
        rb.velocity = new Vector2(run * speed, rb.velocity.y);

        if (startMove.point == 25)
        {
            state = "TALKFRONT";
        }
        if (startMove.point == 26)
        {
            state = "WALKYOKO";
            run = -1f;
        }

        if (this.transform.position.x < 0)
        {
            run = 0f;
            state = "STANDBACK";
        }
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STANDBACK":
                    animator.SetBool("isStandBack", true);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkBack", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isWalkBack", false);
                    animator.SetBool("isWalkYoko", false);
                    break;

                case "STANDFRONT":
                    animator.SetBool("isStandBack", false);
                    animator.SetBool("isStandFront", true);
                    animator.SetBool("isTalkBack", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isWalkBack", false);
                    animator.SetBool("isWalkYoko", false);
                    break;

                case "TALKBACK":
                    animator.SetBool("isStandBack", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkBack", true);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isWalkBack", false);
                    animator.SetBool("isWalkYoko", false);
                    break;

                case "TALKFRONT":
                    animator.SetBool("isStandBack", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkBack", false);
                    animator.SetBool("isTalkFront", true);
                    animator.SetBool("isWalkBack", false);
                    animator.SetBool("isWalkYoko", false);
                    break;

                case "WALKBACK":
                    animator.SetBool("isStandBack", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkBack", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isWalkBack", true);
                    animator.SetBool("isWalkYoko", false);
                    break;

                case "WALKYOKO":
                    animator.SetBool("isStandBack", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isTalkBack", false);
                    animator.SetBool("isTalkFront", false);
                    animator.SetBool("isWalkBack", false);
                    animator.SetBool("isWalkYoko", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
