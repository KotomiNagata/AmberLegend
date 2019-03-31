using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octavian_Hole : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;
    GameEvents_Hole events;
    Serif_Hole serif;
    GameRule rule;
    EggSign egg;

    public GameObject serifObj1Boy;
    public GameObject serifObj1Girl;
    public GameObject button3Obj;
    public string numberSelect = "1_1";  // Button_Holeから指示
    public bool reset = false;           // 最後の質問の時にリセット

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    public float speed = 2f;   // 移動スピード
    float runX = 0f;           // 進む方向
    float runY = 0f;           // 進む方向

    bool follow = true;        // 落下中
    bool walking = false;      // 散歩中
    bool one = true;           // serif(Clone)用
    bool two = true;

    void Start () {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_Hole>();
        rule = FindObjectOfType<GameRule>();
        egg = FindObjectOfType<EggSign>();
        state = "STANDYOKO";
    }
	
	void Update () {

        if(!reset)
        {
            OctavianTalking();
        }
        if(reset)
        {
            OctavianEndQuestion();
        }

        SelectAnimation();

        if(follow)
        {
            rb.velocity = new Vector2(rb.velocity.x, runY * speed);
            runY = -1f;
            if(this.transform.position.y < -0.67)
            {
                runY = 0f;
                walking = true;
            }
        }

        if(walking)
        {
            rb.velocity = new Vector2(runX * speed, rb.velocity.y);
            runX = 1f;
            speed = 2f;
            state = "WALK";
            if (this.transform.position.x > 0)
            {
                runX = 0f;
                follow = false;
                if (one)
                {
                    if(rule.IamBoy)
                    {
                        Instantiate(serifObj1Boy);
                    }
                    if (!rule.IamBoy)
                    {
                        Instantiate(serifObj1Girl);
                    }
                    one = false;
                }
            }
        }
    }

    void OctavianTalking()
    {
        if(events.point == 1)
        {
            state = "TALK";
        }
        if(events.point == 2)
        {
            walking = false;
            state = "STANDFRONT";
        }
        if (events.point == 3)
        {
            if(numberSelect =="2_1")
            {
                state = "TALK";
            }
            if (numberSelect == "2_2")
            {
                state = "TALK";
            }
            if (numberSelect == "2_3")
            {
                state = "SURPRISED";
            }
        }
        if (events.point == 4)
        {
            if (numberSelect == "2_1")
            {
                state = "TALKYOKO";
            }
            if (numberSelect == "2_2")
            {
                state = "TALKYOKO";
            }
            if (numberSelect == "2_3")
            {
                if(rule.IamBoy)
                {
                    state = "TALK";
                }
                if(!rule.IamBoy)
                {
                    state = "SEKI";
                }
            }
        }
        if (events.point == 5)
        {
            if (numberSelect == "2_1")
            {
                state = "SEKI";
            }
            if (numberSelect == "2_2")
            {
                state = "TALK";
            }
            if (numberSelect == "2_3")
            {
                if (rule.IamBoy)
                {
                    state = "SEKI";
                }
                if (!rule.IamBoy)
                {
                    state = "TALK";
                }
            }
        }

        if (events.point == 7)
        {
            state = "TALKYOKO";
        }

        if (events.point == 8)
        {
            state = "TALK";
        }

        if (events.point == 9)
        {
            state = "SURPRISED";
        }

        if (events.point == 11)
        {
            state = "TALK";
        }

        if (events.point == 13)
        {
            state = "SEKI";
        }

        if (events.point == 14)
        {
            state = "TALKYOKO";
        }

        if (events.point == 15)
        {
            state = "TALK";
        }

    }

    void OctavianEndQuestion()
    {
        if (events.point == 0)
        {
            state = "STANDFRONT";
        }

        if (events.point == 1)
        {
            if(numberSelect == "4_1")
            {
                state = "TALK";
            }
            if (numberSelect == "4_2")
            {
                state = "SEKI";
                two = true;
            }
        }

        if (events.point == 2)
        {
            state = "TALKYOKO";
        }

        if (events.point == 3)
        {
            if (numberSelect == "4_1")
            {
                state = "TALK";
            }
            if (numberSelect == "4_2")
            {
                state = "STANDFRONT";
            }
        }

        if (events.point == 4)
        {
            state = "TALK";

            if (numberSelect == "4_1")
            {
                egg.clickOK = true;
            }
        }

        if (events.point == 5)
        {
            if (numberSelect == "4_2")
            {
                if(two)
                {
                    Instantiate(button3Obj);
                    two = false;
                }
            }
        }
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STANDYOKO":
                    animator.SetBool("isStandYoko", true);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalkYoko", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isSurprised", false);
                    animator.SetBool("isSeki", false);
                    break;

                case "WALK":
                    animator.SetBool("isStandYoko", false);
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalkYoko", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isSurprised", false);
                    animator.SetBool("isSeki", false);
                    break;

                case "TALK":
                    animator.SetBool("isStandYoko", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isTalkYoko", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isSurprised", false);
                    animator.SetBool("isSeki", false);
                    break;

                case "TALKYOKO":
                    animator.SetBool("isStandYoko", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalkYoko", true);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isSurprised", false);
                    animator.SetBool("isSeki", false);
                    break;

                case "STANDFRONT":
                    animator.SetBool("isStandYoko", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalkYoko", false);
                    animator.SetBool("isStandFront", true);
                    animator.SetBool("isSurprised", false);
                    animator.SetBool("isSeki", false);
                    break;

                case "SURPRISED":
                    animator.SetBool("isStandYoko", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalkYoko", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isSurprised", true);
                    animator.SetBool("isSeki", false);
                    break;

                case "SEKI":
                    animator.SetBool("isStandYoko", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isTalkYoko", false);
                    animator.SetBool("isStandFront", false);
                    animator.SetBool("isSurprised", false);
                    animator.SetBool("isSeki", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
