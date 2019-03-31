using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group_Cave : MonoBehaviour {

    Animator animator;
    GameEvents_Cave events;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    public bool sneezeOK = false;      // GameEvents2_Caveから指示
    public bool sneezeEND = false;     // くしゃみし終わったか
    public bool binta = false;         // Octavian_Caveから指示
    public bool youWalk = false;       // Octavian_Caveから指示

    void Start () {
        this.animator = GetComponent<Animator>();
        events = FindObjectOfType<GameEvents_Cave>();
        state = "WALK";
    }
	
	
	void Update () {
        SelectAnimation();

        if(sneezeOK)
        {
            state = "SNEEZE";
            sneezeEND = true;
        }

        if(events.gate)
        {
            if(state == "WALK" || state == "STOP")
            {
                state = "STOP";
                sneezeEND = false;
            }
            if (state == "SNEEZE")
            {
                state = "BEQUIET";
                sneezeOK = false;
                sneezeEND = false;
            }
        }

        if(binta)
        {
            state = "FACE";
        }

        if(youWalk)
        {
            state = "WALK";
        }

        if(!events.gate && !sneezeOK && !binta)
        {
            state = "WALK";
            sneezeEND = false;
            binta = false;
        }

        if(events.gameOver)
        {
            Destroy(this.gameObject);
        }

        if (events.NP || events.gameCrear2)
        {
            state = "STOP";
        }
    }

    public void SneezeAnimationEnd()
    {
        events.sneeze = true;
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "WALK":
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isSneeze", false);
                    animator.SetBool("isFace", false);
                    animator.SetBool("isBeQuiet", false);
                    break;

                case "STOP":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isStop", true);
                    animator.SetBool("isSneeze", false);
                    animator.SetBool("isFace", false);
                    animator.SetBool("isBeQuiet", false);
                    break;

                case "SNEEZE":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isSneeze", true);
                    animator.SetBool("isFace", false);
                    animator.SetBool("isBeQuiet", false);
                    break;

                case "FACE":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isSneeze", false);
                    animator.SetBool("isFace", true);
                    animator.SetBool("isBeQuiet", false);
                    break;

                case "BEQUIET":
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isStop", false);
                    animator.SetBool("isSneeze", false);
                    animator.SetBool("isFace", false);
                    animator.SetBool("isBeQuiet", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
