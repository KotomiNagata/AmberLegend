using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octavian_Rooftop : MonoBehaviour {

    GameRule rule;
    Rigidbody2D rb;
    Animator animator;
    GameEvents_Rooftop events;

    public bool gamePlay = false;
    public bool currentStart = false;

    public GameObject serifObj;
    public GameObject serifObjGirl;
    bool serifBool = true;

    float run = 0f;            // 移動方向
    float speed = 2f;          // 移動スピード
    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    void Start () {

        this.animator = GetComponent<Animator>();
        events = FindObjectOfType<GameEvents_Rooftop>();

        if (gamePlay)
        {
            this.rb = GetComponent<Rigidbody2D>();
            state = "WALK";
        }
        if(!gamePlay && !currentStart)
        {
            this.rb = GetComponent<Rigidbody2D>();
            state = "CLIMB";
        }
        if(currentStart)
        {
            state = "STAND";
            rule = FindObjectOfType<GameRule>();
        }
	}
	
	void Update () {
		
        if(gamePlay)
        {
            SelectAnimation1();
            GamePlay();
        }

        if(!gamePlay && !currentStart)
        {
            SelectAnimation2();
            StartMove(); 
        }

        if(currentStart)
        {
            SelectAnimation3();
            CurrentStartMove();
        }
	}

    void GamePlay()
    {
        if(events.backgroundStop)
        {
            rb.velocity = new Vector2(run * speed, rb.velocity.y);
            run = 1f;

            if(this.transform.position.x > 0)
            {
                run = 0f;
                state = "TALK";
                if(serifBool)
                {
                    Instantiate(serifObj);
                    serifBool = false;
                }
            }
        }
        if (events.finding)
        {
            state = "STOP";
            run = 0f;
        }
    }

    void StartMove()
    {
        rb.velocity = new Vector2(rb.velocity.x, run * speed);
        run = 1f;

        if (this.transform.position.y > -0.48)
        {
            run = 0f;
            if (serifBool)
            {
                Instantiate(serifObj);
                serifBool = false;
            }
        }

        if(events.point == 1)
        {
            state = "SEKI";
        }
        if (events.point == 2)
        {
            state = "LEFT";
        }
        if (events.point == 3)
        {
            state = "RIGHT";
        }
        if (events.point == 4)
        {
            state = "FRONT";
        }
    }

    void CurrentStartMove()
    {
        if(!GameObject.FindGameObjectWithTag("Fade"))
        {
            state = "RIGHT";
            if(serifBool)
            {
                if(rule.IamBoy)
                {
                    Instantiate(serifObj);
                }
                if (!rule.IamBoy)
                {
                    Instantiate(serifObjGirl);
                }
                serifBool = false;
            }
        }
        if(events.point == 2)
        {
            state = "FRONT";
        }
        if (events.point == 3)
        {
            state = "RIGHT";
        }
        if (events.point == 4)
        {
            state = "FRONT";
        }
    }

    void SelectAnimation1()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "WALK":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isStop", false);
                    break;
                case "TALK":
                    animator.SetBool("isTalk", true);
                    break;
                case"STOP":
                    animator.SetBool("isStop", true);
                    break;
                            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

    void SelectAnimation2()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "CLIMB":
                    animator.SetBool("isSeki", false);
                    break;
                case "SEKI":
                    animator.SetBool("isSeki", true);
                    animator.SetBool("isLeft", false);
                    break;
                case "LEFT":
                    animator.SetBool("isLeft", true);
                    animator.SetBool("isRight", false);
                    break;
                case "RIGHT":
                    animator.SetBool("isRight", true);
                    animator.SetBool("isFront", false);
                    break;
                case "FRONT":
                    animator.SetBool("isFront", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

    void SelectAnimation3()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STAND":
                    animator.SetBool("isRight", false);
                    break;
                case "RIGHT":
                    animator.SetBool("isRight", true);
                    animator.SetBool("isFront", false);
                    break;
                case "FRONT":
                    animator.SetBool("isRight", false);
                    animator.SetBool("isFront", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
