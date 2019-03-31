using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modoruka_GodRoom : MonoBehaviour
{

    Animator animator;

    public GameObject serif4_2Obj;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    bool start = true;
    bool one = true; //serif用

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (start)
        {
            Give();
        }

        if(!start)
        {
            SelectAnimation();
            if(one)
            {
                Instantiate(serif4_2Obj);
                one = false;
            }
        }
    }

    public void Give()
    {
        Vector3 scale = this.gameObject.transform.localScale;

        //拡大する
        gameObject.transform.localScale = new Vector3(
            scale.x + 0.1f,
            scale.y + 0.1f,
            scale.z
        );

        //もし大きさが5を超えたら拡大を止める
        if (scale.x > 5)
        {
            gameObject.transform.localScale = new Vector3(
            scale.x,
            scale.y,
            scale.z
                );

            start = false;
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
                    break;

                case "EYE":
                    animator.SetBool("isStop", false);
                    animator.SetBool("isEye", true);
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
