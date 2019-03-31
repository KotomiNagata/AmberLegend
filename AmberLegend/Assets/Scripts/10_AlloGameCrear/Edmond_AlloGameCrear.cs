using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edmond_AlloGameCrear : MonoBehaviour {

    Animator animator;
    GameCrearEvent_Allo events;
    Allo_GameCrear allo;
    Rigidbody2D rb;

    public bool No1 = false;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    float run = 0f;            // 移動方向
    float speed = 3f;         // 移動スピード
    bool losed = false;

    void Start () {
        this.animator = GetComponent<Animator>();
        events = FindObjectOfType<GameCrearEvent_Allo>();
        allo = FindObjectOfType<Allo_GameCrear>();
        this.rb = GetComponent<Rigidbody2D>();

        state = "WALK";
        run = -1f;
    }
	
	void Update () {
        rb.velocity = new Vector2(run * speed, rb.velocity.y);

        if (No1)
        {
            EdmondAnimation();

            if (!losed)
            {
                if (this.transform.position.x < -1.3f)
                {
                    run = 0f;
                    allo.edmondAttack = true;
                    StartCoroutine("Moving");
                }
            }

            if (losed)
            {
                state = "LOSE";
                run = 1f;
                speed = 20f;

                if (this.transform.position.x > 6.5f)
                {
                    Destroy(this.gameObject);
                }
            }
        }


        if(!No1)
        {
            if(this.transform.position.x <  3.9f)
            {
                run = 0f;
            }
        }
	}

    private IEnumerator Moving()
    {
        state = "ATTACK1";
        yield return new WaitForSeconds(0.5f);
        if(!losed)
        {
            state = "ATTACK2";
        }
        yield return new WaitForSeconds(1f);
        losed = true;
    }

    void EdmondAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "WALK":
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isAttack1", false);
                    animator.SetBool("isAttack2", false);
                    animator.SetBool("isLose", false);
                    animator.SetBool("isTalk", false);
                    break;

                case "ATTACK1":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isAttack1", true);
                    animator.SetBool("isAttack2", false);
                    animator.SetBool("isLose", false);
                    animator.SetBool("isTalk", false);
                    break;

                case "ATTACK2":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isAttack1", false);
                    animator.SetBool("isAttack2", true);
                    animator.SetBool("isLose", false);
                    animator.SetBool("isTalk", false);
                    break;

                case "LOSE":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isAttack1", false);
                    animator.SetBool("isAttack2", false);
                    animator.SetBool("isLose", true);
                    animator.SetBool("isTalk", false);
                    break;

                case "TALK":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isAttack1", false);
                    animator.SetBool("isAttack2", false);
                    animator.SetBool("isLose", false);
                    animator.SetBool("isTalk", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
