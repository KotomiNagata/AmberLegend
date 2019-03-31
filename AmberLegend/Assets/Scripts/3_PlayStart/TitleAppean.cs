using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAppean : MonoBehaviour {

    StartMove startScript;
    Renderer rend;
    Color color;
    float alpha;

    void Start () {
        startScript = FindObjectOfType<StartMove>();
        rend = GetComponent<Renderer>();
        alpha = 1;
    }
	
	void Update () {

        StartCoroutine("Opening");
    }

    private IEnumerator Opening()
    {
        Vector3 scale = this.gameObject.transform.localScale;

        //拡大する
        gameObject.transform.localScale = new Vector3(
            scale.x + 0.1f,
            scale.y + 0.1f,
            scale.z
        );

        //もし大きさが1.3を超えたら拡大を止める
        if (scale.x > 3)
        {
            gameObject.transform.localScale = new Vector3(
            scale.x,
            scale.y,
            scale.z
        );
        }

        yield return new WaitForSeconds(2.5f);

        alpha = alpha - Time.deltaTime * 3f;
        rend.material.color = new Color(1f, 1f, 1f, alpha);

        //もし完全に消えたらオブジェクトを消す
        if (alpha <= 0)
        {
            startScript.titleNone = true;
            Destroy(gameObject);
        }
    }
}
