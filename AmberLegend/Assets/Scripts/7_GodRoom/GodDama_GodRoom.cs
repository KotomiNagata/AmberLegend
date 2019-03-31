using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodDama_GodRoom : MonoBehaviour {

    Animator animator;
    God_GodRoom god;
    Renderer rend;
    Color color;
    float alpha;

    public bool give = false;
    public GameObject modorukaObj;
    bool one = true;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    void Start () {
        this.animator = GetComponent<Animator>();
        god = FindObjectOfType<God_GodRoom>();
        rend = GetComponent<Renderer>();
        alpha = 1;
    }
	
	void Update () {
        SelectAnimation();

        if(god.moving == 1)
        {
            state = "USUALLY";
        }
        if (god.moving == 2)
        {
            state = "STOP";
        }

        if(give)
        {
            UnAppean();
        }
    }

    void UnAppean()
    {
        alpha = alpha - Time.deltaTime * 3f;
        rend.material.color = new Color(1f, 1f, 1f, alpha);

        //もし完全に消えたらオブジェクトを消す
        if (alpha <= 0)
        {
            if(one)
            {
                Instantiate(modorukaObj);
                one = false;
            }
            Destroy(gameObject);
        }
    }

    void SelectAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "USUALLY":
                    animator.SetBool("isUsually", true);
                    animator.SetBool("isStop", false);
                    break;

                case "STOP":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isStop", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
