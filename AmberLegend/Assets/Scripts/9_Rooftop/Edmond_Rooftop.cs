using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edmond_Rooftop : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;
    GameCrear_Rooftop crear;

    float run = 0f;            // 移動方向
    float speed = 4f;          // 移動スピード
    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    public bool human = true;
    public bool fall = false;  // GameCrearから指示

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        crear = FindObjectOfType<GameCrear_Rooftop>();

        if(human)
        {
            state = "STOP";
        }
        if (!human)
        {
            state = "STOP";
        }
    }
	
	void Update () {

        if(human)
        {
            HumanMove();
            HumanAnimation();
        }
        if (!human)
        {
            DinasourMove();
            DinasourAnimation();
        }

        if(fall)
        {
            rb.velocity = new Vector2(rb.velocity.x, run * speed);
            run = -1f;
            speed = 20f;
            if (this.transform.position.y < -4.3)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void HumanMove()
    {
        if (crear.point == 2)
        {
            state = "TALK";
        }
        if (crear.point == 3)
        {
            state = "EAT";
        }
        if (crear.point == 4)
        {
            state = "ENJOY";
            rb.velocity = new Vector2(rb.velocity.x, run * speed);
            run = 1f;
            if (this.transform.position.y > 2)
            {
                run = 0f;
            }
        }
    }

    void DinasourMove()
    {
        if(crear.point == 2)
        {
            state = "TALK";
        }
        if (crear.point == 4)
        {
            state = "ENJOY";
            rb.velocity = new Vector2(rb.velocity.x, run * speed);
            run = 1f;
            if(this.transform.position.y > 2)
            {
                run = 0f;
            }
        }
    }

    void HumanAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STOP":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isEat", false);
                    animator.SetBool("isEnjoy", false);
                    break;
                case "TALK":
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isEat", false);
                    animator.SetBool("isEnjoy", false);
                    break;
                case "EAT":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isEat", true);
                    animator.SetBool("isEnjoy", false);
                    break;
                case "ENJOY":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isEat", false);
                    animator.SetBool("isEnjoy", true);
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
                    break;
                case "TALK":
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isEnjoy", false);
                    break;
                case "ENJOY":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isEnjoy", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
