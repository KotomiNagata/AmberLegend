using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlloBig : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;
    GameEvents_Allo events;

    public GameObject collider1;
    public GameObject collider2;
    public GameObject collider3;
    public GameObject soundObj;
    public GameObject soundGameCrear;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    float run = 0f;            // 移動方向
    float speed = 1f;          // 移動スピード
    bool biteBool = false;
    bool soundBool = true;
    bool posBool = true;       // 噛んだ後移動できるように
    bool gameEnd = false;      // ゲームクリア後
    bool one = true;
    bool find = true;         // Playerの場所を確認するときのエラーを避けるため
    int bitePos = 2;

    void Start () {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_Allo>();
        events.AlloBig = true;
        state = "RUN";
        StartCoroutine("Moving");
    }

    void Update()
    {
        AlloAnimation();
        Vector3 scale = this.gameObject.transform.localScale;
        Vector3 pos = this.gameObject.transform.position;
        rb.velocity = new Vector2(run * speed, rb.velocity.y);

        pos.y = 0.46f;
        pos.z = 2f;

        if (biteBool)
        {
            if (soundBool)
            {
                Instantiate(soundObj);
                soundBool = false;
            }

            if (bitePos == 1)
            {
                state = "BITE1";
                run = 1f;
                if (posBool)
                {
                    this.gameObject.transform.position = new Vector3(pos.x = -1.6f, pos.y, pos.z);
                    Instantiate(collider1);
                    posBool = false;
                }
            }
            if (bitePos == 2)
            {
                state = "BITE2";
                if(posBool)
                {
                    Instantiate(collider2);
                    posBool = false;
                }
            }
            if (bitePos == 3)
            {
                state = "BITE3";
                run = -1f;
                if (posBool)
                {
                    this.gameObject.transform.position = new Vector3(pos.x = 1.6f, pos.y, pos.z);
                    Instantiate(collider3);
                    posBool = false;
                }
            }

            // 縮小する
            gameObject.transform.localScale = new Vector3(
                scale.x - 0.02f,
                scale.y - 0.02f,
                scale.z
            );
        }

        if (!biteBool)
        {
            posBool = true;
            soundBool = true;
            this.gameObject.transform.position = new Vector3 (pos.x = 0, pos.y, pos.z);
            run = 0f;

            // 拡大する
            gameObject.transform.localScale = new Vector3(
                scale.x + 0.05f,
                scale.y + 0.05f,
                scale.z
            );
            // 値を超えたら拡大を停止
            if (scale.x > 2.5)
            {
                gameObject.transform.localScale = new Vector3(
                scale.x,
                scale.y,
                scale.z
            );
            }
        }

        if(gameEnd)
        {
            // 拡大する
            gameObject.transform.localScale = new Vector3(
                scale.x + 0.05f,
                scale.y + 0.05f,
                scale.z
            );
        }

    }

    private IEnumerator Moving()
    {
        yield return new WaitForSeconds(2f);
        state = "OPEN";
        yield return new WaitForSeconds(0.5f);
        if(find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;  // 1回目(1発)
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "RUN";

        yield return new WaitForSeconds(2f);
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;  // 2回目(1発)
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "RUN";

        yield return new WaitForSeconds(2f);
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;  // 3回目(2連発)
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "RUN";

        yield return new WaitForSeconds(2f);
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;  // 4回目(2連発)
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "RUN";

        yield return new WaitForSeconds(2f);
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;  // 5回目(3連発)
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "RUN";

        yield return new WaitForSeconds(2f);
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;  // 6回目(3連発)
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "OPEN";
        find = true;
        yield return new WaitForSeconds(0.5f);
        if (find)
        {
            bitePos = events.posNumber;
            find = false;
        }
        yield return new WaitForSeconds(0.5f);
        biteBool = true;
        yield return new WaitForSeconds(1f);
        biteBool = false;
        state = "RUN";

        // gameCrear
        yield return new WaitForSeconds(1f);
        gameEnd = true;
        events.gameCrearObj = true;
        if(one)
        {
            Instantiate(soundGameCrear);
            one = false;
        }
    }

    void AlloAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "RUN":
                    animator.SetBool("isRun", true);
                    animator.SetBool("isOpen", false);
                    animator.SetBool("isBite1", false);
                    animator.SetBool("isBite2", false);
                    animator.SetBool("isBite3", false);
                    break;
                case "OPEN":
                    animator.SetBool("isRun", false);
                    animator.SetBool("isOpen", true);
                    animator.SetBool("isBite1", false);
                    animator.SetBool("isBite2", false);
                    animator.SetBool("isBite3", false);
                    break;
                case "BITE1":
                    animator.SetBool("isRun", false);
                    animator.SetBool("isOpen", false);
                    animator.SetBool("isBite1", true);
                    animator.SetBool("isBite2", false);
                    animator.SetBool("isBite3", false);
                    break;
                case "BITE2":
                    animator.SetBool("isRun", false);
                    animator.SetBool("isOpen", false);
                    animator.SetBool("isBite1", false);
                    animator.SetBool("isBite2", true);
                    animator.SetBool("isBite3", false);
                    break;
                case "BITE3":
                    animator.SetBool("isRun", false);
                    animator.SetBool("isOpen", false);
                    animator.SetBool("isBite1", false);
                    animator.SetBool("isBite2", false);
                    animator.SetBool("isBite3", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
