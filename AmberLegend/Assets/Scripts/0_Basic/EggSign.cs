using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSign : MonoBehaviour {

    Collider2D col;

    public GameObject eggSignRightObj;
    bool eggSignRightBool = true;
    public bool clickOK = false;  // クリックできるようにタイミングを教えてもらう
                                  // 初めからクリックできるならそのオブジェクトにチェック入れる
    bool one = true;              // col.enabled用

	void Start () {
        col = GetComponent<Collider2D>();
        col.enabled = !col.enabled;
    }
	
	void Update () {
        if(clickOK)
        {
            if(one)
            {
                col.enabled = !col.enabled;
                one = false;
            }
        }
	}

    void OnMouseDown()
    {
        if(eggSignRightBool)
        {
            Instantiate(eggSignRightObj, this.transform.position, Quaternion.identity);
            eggSignRightBool = false;
            Destroy(this.gameObject);
        }
    }
}
