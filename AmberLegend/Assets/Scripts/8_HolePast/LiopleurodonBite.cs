using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiopleurodonBite : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;
    GameEvents_HolePast events;

    public GameObject LiopleurodonObj;
    bool one = true;
    bool two = true; // BiteEvent用
    int a = 1;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    float run = 0f;            // 移動方向
    public float speedOpen = 4f;   // 移動スピード
    public float speedClose = 2f;

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        events = FindObjectOfType<GameEvents_HolePast>();
        run = 1f;
        state = "OPEN";
    }
	
	
	void Update () {
        rb.velocity = new Vector2(rb.velocity.x, run * speedOpen);

        SelectAnimation();

        if(this.transform.position.y > 0)
        {
            state = "BITE";
            speedOpen = speedClose;
            run = -1f;
            if(two)
            {
                events.BiteEvents(a);
                two = false;
            }
        }

        if(this.transform.position.y < -5.5)
        {
            if(one)
            {
                Instantiate(LiopleurodonObj);
                one = false;
            }
            Destroy(this.gameObject);
        }
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "OPEN":
                    animator.SetBool("isBite", false);
                    break;

                case "BITE":
                    animator.SetBool("isBite", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
