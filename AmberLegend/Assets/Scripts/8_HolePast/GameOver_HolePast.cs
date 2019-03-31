using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_HolePast : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;

    public GameObject serifObj;
    public string sceneName;

    bool serifMade = false;
    public bool serifEnd = false;
    bool one = true;       // serifObj(Cline)用

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    float run = 0f;            // 移動方向
    public float speed = 2f;   // 移動スピード

    void Start () {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        state = "STAND";
    }
	
	void Update () {

        SelectAnimation();

        if (!GameObject.FindGameObjectWithTag("Text") && serifMade)
        {
            serifEnd = true;
        }

        if (!GameObject.FindGameObjectWithTag("Fade"))
        {
            state = "TALK";
            if (one)
            {
                Instantiate(serifObj);
                serifMade = true;
                one = false;
            }
        }

        if (serifEnd)
        {
            rb.velocity = new Vector2(rb.velocity.x, run * speed);
            run = 1f;
            state = "CLIMB";

            if (this.transform.position.y > 1.93)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STAND":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isClimb", false);
                    break;

                case "TALK":
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isClimb", false);
                    break;

                case "CLIMB":
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isClimb", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
