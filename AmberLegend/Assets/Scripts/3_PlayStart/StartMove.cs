using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour {

    Background_PlayStart background;

    public GameObject titlePicture;
    public GameObject playerPicture;

    public bool titleNone = false;  // タイトルが出ているか (TitleAppeanから命令)
    public bool backgroundEnd = false;      // 背景が動き終わったか (Backgroundから命令)
    bool one = true;                // Title(Clone)用
    bool two = true;                // Player(Clone)用
    bool three = true;              // Backgroundへの命令用

    void Start()
    {
        background = FindObjectOfType<Background_PlayStart>();
    }

    void Update () {
		
        // 白い画面が消えてからタイトル出現
        if(GameObject.FindGameObjectWithTag("Fade")== false)
        {
            if(one)
            {
                Instantiate(titlePicture);
                one = false;
            }
        }

        // タイトルが消えたら背景のboolに命令して動かす
        if(titleNone)
        {
            if(three)
            {
                background.moveON = true;
                three = false;
            }
        }

        // 背景が動き終わったらプレイヤーを登場させる
        if(backgroundEnd)
        {
            if(two)
            {
                Instantiate(playerPicture);
                two = false;
            }
        }

	}
}
