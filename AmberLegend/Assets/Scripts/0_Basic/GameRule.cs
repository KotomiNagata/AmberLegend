using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour {

    public bool IamBoy = true;
    public bool EdmondIsHuman = true;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL("http://www.yahoo.co.jp/");
#else
        Application.Quit();
#endif
        }
    }

}
