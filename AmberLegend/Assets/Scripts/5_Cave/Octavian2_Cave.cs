using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Octavian2_Cave : MonoBehaviour {

    Animator animator;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    public bool ThisIsGameOver = true;

    public GameObject serifObj;
    bool one = true;

    public GameObject Obj1;
    public GameObject Obj2;
    public bool Obj2no = false;
    bool two = true;
    bool three = false;

    public string nextSceneName;

    void Start () {
        this.animator = GetComponent<Animator>();
        state = "STAND";
    }
	
	
	void Update () {
        SelectAnimation();

        if(ThisIsGameOver)
        {
            if (!GameObject.FindGameObjectWithTag("Fade"))
            {
                state = "TALK";
                if (one)
                {
                    Instantiate(serifObj);
                    one = false;
                }

                if (!one)
                {
                    if (!GameObject.FindGameObjectWithTag("Text"))
                    {
                        SceneManager.LoadScene(nextSceneName);
                    }
                }
            }
        }

        if(!ThisIsGameOver)
        {
            if (!GameObject.FindGameObjectWithTag("Fade"))
            {
                if(two)
                {
                    Instantiate(Obj1);
                    two = false;
                    three = true;
                }

                if(Input.GetMouseButtonUp(0))
                {
                    if(three)
                    {
                        Instantiate(Obj2);
                        three = false;
                    }
                }

                if(!three)
                {
                    if (Obj2no)
                    {
                        state = "TALK";
                        if (one)
                        {
                            Instantiate(serifObj);
                            one = false;
                        }
                    }

                    if (!one)
                    {
                        if (!GameObject.FindGameObjectWithTag("Text"))
                        {
                            SceneManager.LoadScene(nextSceneName);
                        }
                    }
                }

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
                    animator.SetBool("isStand", true);
                    animator.SetBool("isTalk", false);
                    break;

                case "TALK":
                    animator.SetBool("isStand", false);
                    animator.SetBool("isTalk", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
