using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modoruka: MonoBehaviour {

    Animator animator;

    public bool targetOver = false;  // ModorukaTargetから指示

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    void Start () {
        this.animator = GetComponent<Animator>();
    }
	
	void Update () {
        SelectAnimation();

        if(targetOver)
        {
            state = "SIGN";
        }
        if(!targetOver)
        {
            state = "STOP";
        }
    }

    public void OnMouseDown()
    {
        StartCoroutine("Mabataki");
    }

    private IEnumerator Mabataki()
    {
        state = "EYE";
        yield return new WaitForSeconds(1f);
        state = "STOP";
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "STOP":
                    animator.SetBool("isStop", true);
                    animator.SetBool("isEye", false);
                    animator.SetBool("isSign", false);
                    break;

                case "EYE":
                    animator.SetBool("isStop", false);
                    animator.SetBool("isEye", true);
                    animator.SetBool("isSign", false);
                    break;

                case "SIGN":
                    animator.SetBool("isStop", false);
                    animator.SetBool("isEye", false);
                    animator.SetBool("isSign", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
