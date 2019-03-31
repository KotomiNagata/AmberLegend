using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liopleurodon : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;
    GameEvents_HolePast events;

    public GameObject LiopleurodonBite1Obj;
    public GameObject LiopleurodonBite2Obj;
    public GameObject LiopleurodonBite3Obj;
    bool one = true;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    float run = 0f;            // 移動方向
    public float speed = 5f;   // 移動スピード
    int attackTurn = 1;        // 攻撃する時のターン(余りが0になったら攻撃)
    bool isTurn = true;        // 往復した回数を正確に入力するための準備
    bool swimming = true;      // 泳ぐ
    bool diving = false;       // 潜る（攻撃準備）
    bool right;                // 左右管理

    void Start () {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_HolePast>();

        Vector3 scale = transform.localScale;
        scale.x = 3f;
        run = -1f;
        swimming = true;
    }
	
	
	void Update () {
        SelectAnimation();
        Vector3 scale = transform.localScale;

        attackTurn = events.turn % 3;

        // 泳いでいる時・・・
        if(swimming)
        {
            state = "SWIM";
            rb.velocity = new Vector2(run * speed, rb.velocity.y);

            if (this.transform.position.x > 7.8)
            {
                run = -1f;
                right = false;
                scale.x = 3f;
                if (isTurn)
                {
                    events.turn = events.turn + 1;
                    isTurn = false;
                }
                if(events.gameCrear)
                {
                    Destroy(this.gameObject);
                }
            }
            if (this.transform.position.x < -7.8)
            {
                run = 1f;
                right = true;
                scale.x = -3f;
                if (!isTurn)
                {
                    events.turn = events.turn + 1;
                    isTurn = true;
                }
                if (events.gameCrear)
                {
                    Destroy(this.gameObject);
                }
            }
        }


        // 余りが0になったら潜り始める
        if (attackTurn == 0 && this.transform.position.x < 0 && !right ||
            attackTurn == 0 && this.transform.position.x > 0 && right)
        {
            swimming = false;
            diving = true;
        }

        // 潜り始める
        if(diving)
        {
            state = "DIVE";

            if (right)
            {
                rb.velocity = new Vector2(run * speed, run * speed * -1);
            }

            if (!right)
            {
                rb.velocity = new Vector2(run * speed, run * speed);
            }
        }

        // 深く潜ったら・・・
        if (this.transform.position.y < -4.8)
        {
            if (one)
            {
                if (events.PosNumber == 1)
                {
                    Instantiate(LiopleurodonBite1Obj);
                }
                if (events.PosNumber == 2)
                {
                    Instantiate(LiopleurodonBite2Obj);
                }
                if (events.PosNumber == 3)
                {
                    Instantiate(LiopleurodonBite3Obj);
                }

                one = false;
            }

            Destroy(this.gameObject);
        }

        transform.localScale = scale;   // 左右方向を代入しなおす(超重要)

    }


    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "SWIM":
                    animator.SetBool("isSwim", true);
                    animator.SetBool("isDive", false);
                    break;

                case "DIVE":
                    animator.SetBool("isSwim", false);
                    animator.SetBool("isDive", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
