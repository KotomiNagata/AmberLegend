using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSelect : MonoBehaviour {

    Animator animator;

    public GameObject SelectText;
    bool one = true;

    string state;             // 見た目の切り替え
    string prevState;         // 前の状態を保存
    bool click = false;

    void Start () {
        this.animator = GetComponent<Animator>();
        state = "SELECToff";
    }
	
	void Update () {
        SelectAnimation();

        if(GameObject.FindGameObjectWithTag("HowAreYouOK?") == true)
        {
            one = false;
        }else{
            one = true;
        }

        if (one)
        {
            click = false;
        }

    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "SELECTon":
                    animator.SetBool("selectON", true);
                    animator.SetBool("selectOFF", false);
                    break;

                case "SELECToff":
                    animator.SetBool("selectON", false);
                    animator.SetBool("selectOFF", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }


    // マウスボタンが押された時にコールされる
    void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("HowAreYouOK?") == false)
        {
            Instantiate(SelectText);
            one = false;
            click = true;
        }
    }

    // マウスカーソルが対象オブジェクトに進入した時にコールされる
    void OnMouseEnter()
    {
        if(!click)
        {
            state = "SELECTon";
        }
        if(click)
        {
            state = "SELECTon";
        }
        if(!one && !click)
        {
            state = "SELECToff";
        }
    }

    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    void OnMouseExit()
    {
        if(!click)
        {
            state = "SELECToff";
        }
        if(click)
        {
            state = "SELECTon";
        }
    }
}
