using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octavian_PlayStart2 : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;
    StartMove_PlayStart2 startMove;
    Serif_PlayStart2 serif;

    public GameObject serifObj;
    public GameObject catchPlayerObj;
    public bool playerArrive = false;  // Player_PlayStart2 から指示
    public bool catchOK = false;       // CatchPlayerから命令

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    float run = 0f;
    float speed = 2f;          // 移動スピード
    bool animationEnd = false; // アニメーション終了の合図
    bool one = true;   // serif(Clone)用
    bool two = true;   // AnimationEND用
    bool three = true; // catchPlayerObj(Clone)用
    bool fore = true;  // two = !two を１回

    void Start () {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        startMove = FindObjectOfType<StartMove_PlayStart2>();
        state = "STOP";
        run = 0f;
    }
	
	void Update () {

        SelectAnimation();
        serif = FindObjectOfType<Serif_PlayStart2>();

        // プレイヤーから指示
        if (playerArrive)
        {
            state = "SPIN";
            if (one)
            {
                Instantiate(serifObj);
                one = false;
            }
        }

        if (startMove.point == 2)
        {
            state = "TALK";
            playerArrive = false;
        }
        if (startMove.point == 3)
        {
            state = "STAND";
        }
        if (startMove.point == 4)
        {
            state = "TALK";
        }
        // よくきいた！
        if(startMove.point == 5)
        {
            state = "RIBON";
            if(two)
            {
                Invoke("AnimationEND", 1f);
                serif.clickOK = false;
            }
            if(animationEnd)
            {
                state = "TALK";
                serif.NextText = true;
                serif.clickOK = true;
                animationEnd = false;
            }
        }
        if (startMove.point == 7)
        {
            state = "TALK";
        }
        if (startMove.point == 8)
        {
            state = "STAND";
        }
        if (startMove.point == 9)
        {
            state = "ANGRY";
        }
        if (startMove.point == 10)
        {
            state = "SEKI";
        }
        if (startMove.point == 11)
        {
            state = "STAND";
        }
        if (startMove.point == 12)
        {
            state = "TALK";
        }
        // Playerを追い出す
        if (startMove.point == 13)
        {
            state = "YUBI";
            serif.clickOK = false;

            if (!two)
            {
                Invoke("AnimationEND", 1f);
            }
            if (animationEnd)
            {
                if (three)
                {
                    Instantiate(catchPlayerObj);
                    three = false;
                }
                animationEnd = false;
            }

        }
        if(startMove.point == 14 )
        {
            state = "STAND";
            if (catchOK)
            {
                serif.NextText = true;
                serif.clickOK = true;
            }
        }
        if(startMove.point == 15)
        {
            state = "STAND";
        }
        if (startMove.point == 16)
        {
            state = "WALK";
        }
        if (startMove.point == 17)
        {
            rb.velocity = new Vector2(rb.velocity.x, run * speed);
            state = "WALK";
            run = 1f;
            if(this.transform.position.y > 3.1)
            {
                run = 0f;
                state = "STOP";
            }
        }
        if (startMove.point == 18)
        {
            state = "STOP";
        }
        if (startMove.point == 19)
        {
            state = "SPIN";
        }
        if (startMove.point == 20)
        {
            state = "TALK";
        }
        if (startMove.point == 21 || startMove.point == 22)
        {
            state = "STAND";
        }
        if (startMove.point == 23)
        {
            state = "TALK";
        }
        if (startMove.point == 24)
        {
            state = "TALK2";
            rb.velocity = new Vector2(run * speed, rb.velocity.y);
            run = -1;
            if(this.transform.position.x < -2)
            {
                run = 0;
            }
        }


    }

    void AnimationEND()
    {
        animationEnd = true;
        if(fore)
        {
            two = !two;
            fore = false;
        }
    }

    void SelectAnimation()
    {

        if (prevState != state)
        {
            switch (state)
            {
                case "ANGRY":
                    animator.SetBool("isAngry", true);
                    animator.SetBool("isRibon", false);
                    animator.SetBool("isSeki", false);
                    animator.SetBool("isSpin", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalk2", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isYubi", false);
                    break;

                case "RIBON":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isRibon", true);
                    animator.SetBool("isSeki", false);
                    animator.SetBool("isSpin", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalk2", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isYubi", false);
                    break;

                case "SEKI":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isRibon", false);
                    animator.SetBool("isSeki", true);
                    animator.SetBool("isSpin", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalk2", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isYubi", false);
                    break;

                case "SPIN":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isRibon", false);
                    animator.SetBool("isSeki", false);
                    animator.SetBool("isSpin", true);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalk2", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isYubi", false);
                    break;

                case "STAND":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isRibon", false);
                    animator.SetBool("isSeki", false);
                    animator.SetBool("isSpin", false);
                    animator.SetBool("isStand", true);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalk2", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isYubi", false);
                    break;

                case "STOP":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isRibon", false);
                    animator.SetBool("isSeki", false);
                    animator.SetBool("isSpin", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isStop", true);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalk2", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isYubi", false);
                    break;

                case "TALK":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isRibon", false);
                    animator.SetBool("isSeki", false);
                    animator.SetBool("isSpin", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isTalk2", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isYubi", false);
                    break;

                case "TALK2":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isRibon", false);
                    animator.SetBool("isSeki", false);
                    animator.SetBool("isSpin", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalk2", true);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isYubi", false);
                    break;

                case "WALK":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isRibon", false);
                    animator.SetBool("isSeki", false);
                    animator.SetBool("isSpin", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalk2", false);
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isYubi", false);
                    break;

                case "YUBI":
                    animator.SetBool("isAngry", false);
                    animator.SetBool("isRibon", false);
                    animator.SetBool("isSeki", false);
                    animator.SetBool("isSpin", false);
                    animator.SetBool("isStand", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalk2", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isYubi", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
