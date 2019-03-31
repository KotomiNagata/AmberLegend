using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// マウスの動きを検出して時間をリセットします
// これを何かのgameObjectに追加してください
public class BackToTitle: MonoBehaviour {
    public float waitTime;
    float timeFromStart = 0.0f;
    Vector3 lastMousePos;
    public string title;

	// Use this for initialization
	void Start () {
        lastMousePos = Input.mousePosition;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 diff = Input.mousePosition - lastMousePos;
        timeFromStart += Time.deltaTime;

        // マウスが動いたら時間をリセットする
        if ( diff.magnitude > 3.0 || Input.GetMouseButton(0))
        {
            timeFromStart = 0.0f;
        }
        if ( timeFromStart > waitTime ){
            // ここでタイトルへ
            SceneManager.LoadScene(title);
        }
        lastMousePos = Input.mousePosition;
    }
}
