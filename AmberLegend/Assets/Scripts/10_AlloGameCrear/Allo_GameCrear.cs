using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allo_GameCrear : MonoBehaviour {

    Animator animator;
    GameCrearEvent_Allo events;
    GameRule rule;

    public bool edmondAttack = false; // Edmondから指示
    public GameObject serifObj;   //ED
    public GameObject serifObj2;  //MON
    public GameObject alloCoolObj;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    float run = 1f;            // 移動方向
    float speed = 10f;         // 移動スピード
    bool talking = false;      // 話し始める
    bool serifBool = true;
    bool alloCoolBool = true;
    Vector2 startPos;
    Vector2 pos;

    void Start () {
        this.animator = GetComponent<Animator>();
        events = FindObjectOfType<GameCrearEvent_Allo>();
        rule = FindObjectOfType<GameRule>();
        startPos = this.transform.position;
        pos.x = -8f;
        state = "USUALLY";
    }
	
	void Update () {
        AlloAnimation();
        this.gameObject.transform.position = pos;
        pos = startPos;

        if (edmondAttack)
        {
            StartCoroutine("Moving");
        }

        if(talking)
        {
            state = "TALK";
            edmondAttack = false;
            events.serifMade = true;
            pos = startPos;
        }

        if (events.point == 2)
        {
            state = "USUALLY";
        }
        if (events.point == 3)
        {
            state = "TALK";
        }
        if (events.point == 4 || events.point == 9)
        {
            state = "USUALLY";
        }
        if (events.point == 10)
        {
            state = "TALK";
        }
        if (events.point == 11)
        {
            state = "USUALLY";
        }
        if (events.point == 12)
        {
            state = "CATCH";
            Invoke("SerifMake", 1f);
        }
        if (events.point == 13)
        {
            state = "TALKRIBON";
        }
        if (events.point == 14)
        {
            state = "STOPRIBON";
        }
        if (events.point == 15)
        {
            state = "TALKRIBON";
        }
        if (events.point == 18)
        {
            if(alloCoolBool)
            {
                Instantiate(alloCoolObj);
                alloCoolBool = false;
            }
            Destroy(this.gameObject);
        }

    }

    private IEnumerator Moving()
    {
        state = "CUTE";
        yield return new WaitForSeconds(1.5f);
        if(!talking)
        {
            state = "ATTACK";
        }
        yield return new WaitForSeconds(1f);
        talking = true;
    }

    void SerifMake()
    {
        if (serifBool)
        {
            if (rule.EdmondIsHuman)
            {
                Instantiate(serifObj);
                serifBool = false;
            }
            if (!rule.EdmondIsHuman)
            {
                Instantiate(serifObj2);
                serifBool = false;
            }
        }
    }

    void AlloAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "USUALLY":
                    animator.SetBool("isUsually", true);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isCute", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isCatch", false);
                    animator.SetBool("isTalkRibon", false);
                    animator.SetBool("isStopRibon", false);
                    break;

                case "TALK":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isTalk", true);
                    animator.SetBool("isCute", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isCatch", false);
                    animator.SetBool("isTalkRibon", false);
                    animator.SetBool("isStopRibon", false);
                    break;

                case "CUTE":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isCute", true);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isCatch", false);
                    animator.SetBool("isTalkRibon", false);
                    animator.SetBool("isStopRibon", false);
                    break;

                case "ATTACK":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isCute", false);
                    animator.SetBool("isAttack", true);
                    animator.SetBool("isCatch", false);
                    animator.SetBool("isTalkRibon", false);
                    animator.SetBool("isStopRibon", false);
                    break;

                case "CATCH":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isCute", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isCatch", true);
                    animator.SetBool("isTalkRibon", false);
                    animator.SetBool("isStopRibon", false);
                    break;

                case "TALKRIBON":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isCute", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isCatch", false);
                    animator.SetBool("isTalkRibon", true);
                    animator.SetBool("isStopRibon", false);
                    break;

                case "STOPRIBON":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isTalk", false);
                    animator.SetBool("isCute", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isCatch", false);
                    animator.SetBool("isTalkRibon", false);
                    animator.SetBool("isStopRibon", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
