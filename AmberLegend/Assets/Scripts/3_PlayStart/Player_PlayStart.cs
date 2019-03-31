using UnityEngine;

public class Player_PlayStart : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;
    FadeIn fadeIn;

    public GameObject serif;
    public GameObject blackFadeIn;
    public GameObject doctor;
    public int point = 0;     // セリフと動きを合わせるため
    public string nextScene = "4_PlayStart2_Boy";

    string state;             // 見た目の切り替え
    string prevState;         // 前の状態を保存
    float run = 0f;
    float speed = 4f;         // 移動スピード
    bool one = true;          // serif(Clone)のため
    bool two = true;          // blackFadeIn(Clone)のため
    bool three = true;        // doctor(Clone)のため

    void Start () {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        state = "WALKUP";
        run = 1f;
    }
	
	
	void Update () {
        rb.velocity = new Vector2(rb.velocity.x, run * speed);
        SelectAnimation();

        // 立ち止まって話し始める
        if(this.transform.position.y > 0.1)
        {
            run = 0f;
            state = "TALKING";

            if (one)
            {
                Instantiate(serif);
                one = false;
            }
        }

        // pointの数ごとに動きを分ける
        if (point == 1)
        {
            state = "ENJOY";
        }
        if (point == 2)
        {
            state = "STOP";
        }
        if (point == 3)
        {
            state = "TALKING";
        }
        if (point >= 4 && point <= 9)
        {
            state = "STOP";
            if(three)
            {
                Instantiate(doctor);
                three = false;
            }
            if(point == 9)
            {
                var obj = GameObject.FindGameObjectWithTag("Doctor");
                Destroy(obj);
            }
        }
        if (point == 10)
        {
            state = "TALKING";
        }
        if (point == 11)
        {
            state = "STOP";
        }
        if (point == 12)
        {
            state = "TALKING";
        }
        if(point == 13)
        {
            state = "WALKUP";
            run = 1f;

            if(two)
            {
                Instantiate(blackFadeIn);
                two = false;
            }

            fadeIn = FindObjectOfType<FadeIn>();
            fadeIn.sceneName = nextScene;

            if (this.transform.position.y > 1.8)
            {
                run = 0f;
            }
        }
    }


    // Serif_PlayStartの流れとアニメを同期するため
    public void MoveAnimation(int a)
    {
        point = point + a;
    }

    void SelectAnimation()
    {

        if (prevState != state)
        {
            switch (state)
            {
                case "WALKUP":
                    animator.SetBool("isWalkUp", true);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalking", false);
                    animator.SetBool("isEnjoy", false);
                    break;

                case "STOP":
                    animator.SetBool("isWalkUp", false);
                    animator.SetBool("isStop", true);
                    animator.SetBool("isTalking", false);
                    animator.SetBool("isEnjoy", false);
                    break;

                case "TALKING":
                    animator.SetBool("isWalkUp", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalking", true);
                    animator.SetBool("isEnjoy", false);
                    break;

                case "ENJOY":
                    animator.SetBool("isWalkUp", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isTalking", false);
                    animator.SetBool("isEnjoy", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
