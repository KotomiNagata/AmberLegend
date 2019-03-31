using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edmond_Cave : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;
    GameEvents_Cave events;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    public float speed = 2f;   // 移動スピード
    float run = 0f;            // 進む方向

    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_Cave>();
        Vector3 scale = transform.localScale;
        scale.x = -2f;
        run = 0f;
    }

    void Update()
    {
        SelectAnimation();
        Vector3 scale = transform.localScale;

        if (events.gate || events.gameCrear2 || events.bintaEnd)
        {
            Destroy(this.gameObject);
        }

        if(events.NP)
        {
            state = "STAND";
        }
        if(!events.NP && !events.sneeze)
        {
            state = "WALK";
            scale.x = -2f;
        }

        if(events.sneeze)
        {
            state = "STAND";
            scale.x = 2f;
        }

        if(events.gameOver)
        {
            rb.velocity = new Vector2(run * speed, rb.velocity.y);
            run = -1f;
            scale.x = 2f;

            if(this.transform.position.x < -6)
            {
                Destroy(this.gameObject);
            }
        }
        transform.localScale = scale;   // 左右方向を代入しなおす(超重要)
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STAND":
                    animator.SetBool("isStand", true);
                    animator.SetBool("isWalk", false);
                    break;

                case "WALK":
                    animator.SetBool("isStand", false);
                    animator.SetBool("isWalk", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
