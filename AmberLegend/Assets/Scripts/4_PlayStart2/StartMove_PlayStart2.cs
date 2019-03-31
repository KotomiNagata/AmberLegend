using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ここはセリフのアニメーションのためpointをまとめる場所
public class StartMove_PlayStart2 : MonoBehaviour {

    FadeIn fadeIn;

    public GameObject FadeInObj; // 画面が暗くなる
    public string SkipSceneName; // ここの次のシーン名
    public int point = 0;     // セリフと動きを合わせるため

    bool one = true;          // FadeIn(Clone)のため

    void Update () {

        if (point == 26)
        {
            if (one)
            {
                Instantiate(FadeInObj);
                one = false;
            }
            fadeIn = FindObjectOfType<FadeIn>();
            // 次のシーン名
            fadeIn.sceneName = SkipSceneName;
        }
	}

    // Serif_PlayStart2の流れとアニメを同期するため
    public void MoveAnimation(int a)
    {
        point = point + a;
    }

}
