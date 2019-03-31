using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octavian2_Rooftop : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;
    GameCrear_Rooftop crear;
    GameRule rule;

    float run = 0f;            // 移動方向
    float speed = 2f;          // 移動スピード
    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    public bool fall = false; // GameCrearから指示

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        crear = FindObjectOfType<GameCrear_Rooftop>();
        rule = FindObjectOfType<GameRule>();

        state = "STOP";
    }
	
	void Update () {

        Animation();

        if(crear.point == 1)
        {
            state = "TALK";
        }
        if (crear.point == 2)
        {
            state = "STOP";
        }
        if (crear.point == 3)
        {
            if(!rule.EdmondIsHuman)
            {
                state = "TALK";
            }
        }

        if(fall)
        {
            state = "FALL";
            rb.velocity = new Vector2(rb.velocity.x, run * speed);
            run = -1f;
            speed = 10f;
            if (this.transform.position.y < -6)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Animation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STOP":
                    animator.SetBool("isStop", true);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isFall", false);
                    break;
                case "TALK":
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isFall", false);
                    break;
                case "FALL":
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isFall", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
