using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octavian_Cave : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;
    GameEvents_Cave events;
    Group_Cave group;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    private float timeElapsed;

    public GameObject signObj;
    public GameObject musicBintaObj;
    public float speed = 1f;   // 移動スピード
    float run = 0f;            // 進む方向
    float startPosition;
    public bool binta = false; // 部下へのビンタ
    bool one = true; // signObj(Clone)用
    bool musicBintaBool = true;

    void Start () {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_Cave>();
        group = FindObjectOfType<Group_Cave>();
        state = "WALKRIGHT";
        run = 0f;
        startPosition = this.transform.position.x;
    }
	
	void Update () {
        SelectAnimation();
        rb.velocity = new Vector2(run * speed, rb.velocity.y);

        if(state == "FEAR")
        {
            if(one && !events.gameOver)
            {
                Instantiate(signObj);
                one = false;
            }
        }else{
            one = true;
        }

        if (events.NP)
        {
            state = "FEAR";
        }

        if(events.sneeze)
        {
            run = -1f;
            state = "WALKLEFT";
            if(this.transform.position.x < -1.8)
            {
                run = 0f;
                state = "FACE";
                group.binta = true;
                if(musicBintaBool)
                {
                    Instantiate(musicBintaObj);
                    musicBintaBool = false;
                }
                timeElapsed += Time.deltaTime;
            }
            if (timeElapsed > 0.5)
            {
                state = "WALKRIGHT";
                run = 1f;
            }
        }

        if (this.transform.position.x > startPosition)
        {
            run = 0f;
            timeElapsed = 0f;
            group.binta = false;
            group.youWalk = true;
            events.bintaEnd = true;
            Destroy(this.gameObject);
        }

        if (!events.NP && !events.sneeze){
            state = "WALKRIGHT";
        }

        if (binta)
        {
            run = -1f;
        }

        if(events.gate || events.gameOver || events.gameCrear2)
        {
            Destroy(this.gameObject);
        }
	}

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STANDLEFT":
                    animator.SetBool("isStandLeft", true);
                    animator.SetBool("isWalkLeft", false);
                    animator.SetBool("isWalkRight", false);
                    animator.SetBool("isFear", false);
                    animator.SetBool("isFace", false);
                    break;

                case "WALKLEFT":
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isWalkLeft", true);
                    animator.SetBool("isWalkRight", false);
                    animator.SetBool("isFear", false);
                    animator.SetBool("isFace", false);
                    break;

                case "WALKRIGHT":
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isWalkLeft", false);
                    animator.SetBool("isWalkRight", true);
                    animator.SetBool("isFear", false);
                    animator.SetBool("isFace", false);
                    break;

                case "FEAR":
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isWalkLeft", false);
                    animator.SetBool("isWalkRight", false);
                    animator.SetBool("isFear", true);
                    animator.SetBool("isFace", false);
                    break;

                case "FACE":
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isWalkLeft", false);
                    animator.SetBool("isWalkRight", false);
                    animator.SetBool("isFear", false);
                    animator.SetBool("isFace", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
