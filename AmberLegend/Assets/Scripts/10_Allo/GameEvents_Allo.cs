using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents_Allo : MonoBehaviour {

    FadeIn fadeIn;
    GameRule rule;

    public GameObject fadeInObj;
    public GameObject EdmondObj;
    public GameObject MonmonObj;
    public int posNumber = 2; // Buttonから命令
    public string SkipSceneName_gameOver;
    public string SkipSceneName_gameCrear;
    public bool moveOK = true;     // ボタンを連発して瞬間移動しないように
    public bool AlloBig = false;   // オクタヴィアンの死に方を分ける
    public bool gameOver = false;  // Playerから指示
    public bool gameCrear = false; // AlloBigから指示
    public bool gameCrearObj = false; // Playerが拡大するため
    bool monBool = true;

    bool fadeInBool = true;

    void Start () {
        rule = FindObjectOfType<GameRule>();
        if(monBool)
        {
            if(rule.EdmondIsHuman)
            {
                Instantiate(EdmondObj);
            }
            if (!rule.EdmondIsHuman)
            {
                Instantiate(MonmonObj);
            }
            monBool = false;
        }
	}
	
	void Update () {

        if (gameOver)
        {
            Invoke("GameOverStart", 1f);
        }

        if (gameCrear)
        {
            if (fadeInBool)
            {
                Instantiate(fadeInObj);
                fadeIn = FindObjectOfType<FadeIn>();
                fadeIn.sceneName = SkipSceneName_gameCrear;
                fadeInBool = false;
            }
        }

        if(gameCrearObj)
        {
            Invoke("GameCrear", 1f);
        }
    }

    void GameOverStart()
    {
        if (fadeInBool)
        {
            Instantiate(fadeInObj);
            fadeIn = FindObjectOfType<FadeIn>();
            fadeIn.sceneName = SkipSceneName_gameOver;
            fadeInBool = false;
        }
    }

    void GameCrear()
    {
        gameCrear = true;
    }
}
