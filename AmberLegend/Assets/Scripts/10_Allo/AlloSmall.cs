using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlloSmall : MonoBehaviour {

    Animator animator;
    GameEvents_Allo events;

    public GameObject tama1Obj;
    public GameObject tama2Obj;
    public GameObject tama3Obj;
    public GameObject alloBigObj;

    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存
    bool attackON = false;     // 見た目の切り替え
    bool tamaON = false;       // 第１段階攻撃用
    bool tamaBool = true;      // 第２段階攻撃用
    bool Lv3Bool = false;      // 第３段階攻撃用
    bool alloBigBool = true;

    void Start () {
        this.animator = GetComponent<Animator>();
        state = "RUN";
        StartCoroutine("Moving");
    }
	
	void Update () {
        AlloAnimation();
        events = FindObjectOfType<GameEvents_Allo>();
        Vector3 scale = this.gameObject.transform.localScale;

        if (attackON)
        {
            state = "ATTACK";
        }
        if(!attackON)
        {
            state = "RUN";
        }

        if(tamaON)
        {
            if(events.posNumber == 1)
            {
                Instantiate(tama1Obj);
            }
            if (events.posNumber == 2)
            {
                Instantiate(tama2Obj);
            }
            if (events.posNumber == 3)
            {
                Instantiate(tama3Obj);
            }
            tamaON = false;
        }

        if(Lv3Bool)
        {
            // 拡大する
            gameObject.transform.localScale = new Vector3(
                scale.x + 0.1f,
                scale.y + 0.1f,
                scale.z
            );

            // もし大きさが5を超えたら拡大を止める
            // 複製する
            if (scale.x > 4)
            {
                gameObject.transform.localScale = new Vector3(
                scale.x,
                scale.y,
                scale.z
            );
                if (alloBigBool)
                {
                    Instantiate(alloBigObj);
                    alloBigBool = false;
                }
                Destroy(this.gameObject);
            }
        }

	}

    private IEnumerator Moving()
    {
        attackON = false;
        yield return new WaitForSeconds(2f);  // 第１段階へ
        // 攻撃用意アニメーション
        attackON = true;
        yield return new WaitForSeconds(1f);
        // 玉を発射
        tamaON = true; // 1回目の攻撃
        yield return new WaitForSeconds(1f);
        attackON = false;
        yield return new WaitForSeconds(2f);
        attackON = true;
        yield return new WaitForSeconds(1f);
        tamaON = true; // 2回目の攻撃
        yield return new WaitForSeconds(1f);
        attackON = false;
        yield return new WaitForSeconds(2f);
        attackON = true;
        yield return new WaitForSeconds(1f);
        tamaON = true; // 3回目の攻撃
        yield return new WaitForSeconds(1f);
        attackON = false;
        yield return new WaitForSeconds(2f);
        attackON = true;
        yield return new WaitForSeconds(1f);
        tamaON = true; // 4回目の攻撃
        yield return new WaitForSeconds(1f);
        attackON = false;
        yield return new WaitForSeconds(2f);
        attackON = true;
        yield return new WaitForSeconds(1f);  // 第２段階へ
        if(tamaBool)  // 5回目の攻撃
        {
            Instantiate(tama2Obj);
            Instantiate(tama3Obj);
            tamaBool = false;
        }
        yield return new WaitForSeconds(1f);
        attackON = false;
        yield return new WaitForSeconds(2f);
        attackON = true;
        tamaBool = true;
        yield return new WaitForSeconds(1f);
        if (tamaBool)  // 6回目の攻撃
        {
            Instantiate(tama1Obj);
            Instantiate(tama3Obj);
            tamaBool = false;
        }
        yield return new WaitForSeconds(1f);
        attackON = false;
        yield return new WaitForSeconds(2f);
        attackON = true;
        tamaBool = true;
        yield return new WaitForSeconds(1f);
        if (tamaBool)  // 7回目の攻撃
        {
            Instantiate(tama1Obj);
            Instantiate(tama2Obj);
            tamaBool = false;
        }
        yield return new WaitForSeconds(1f);
        attackON = false;
        yield return new WaitForSeconds(2f);
        attackON = true;
        tamaBool = true;
        yield return new WaitForSeconds(1f);
        if (tamaBool)  // 8回目の攻撃
        {
            Instantiate(tama2Obj);
            Instantiate(tama3Obj);
            tamaBool = false;
        }
        yield return new WaitForSeconds(1f);
        attackON = false;
        yield return new WaitForSeconds(1f);  // 第３段階へ(Clone)
        Lv3Bool = true;
    }

    void AlloAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "RUN":
                    animator.SetBool("isRun", true);
                    animator.SetBool("isAttack", false);
                    break;
                case "ATTACK":
                    animator.SetBool("isRun", false);
                    animator.SetBool("isAttack", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
