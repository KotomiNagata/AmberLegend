using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishButton : MonoBehaviour {

    public string sceneName;

    public void GameEnd()
    {
        // 押されると、最初の画面に戻る
        SceneManager.LoadScene(sceneName);


        //　ゲーム終了ボタンを押したら実行する
        /*
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        Application.OpenURL("http://www.yahoo.co.jp/");
        #else
        Application.Quit();
        #endif
        */
    }
}
