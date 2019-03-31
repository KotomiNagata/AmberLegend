using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents_Rooftop : MonoBehaviour {

    FadeIn fadein;
    ModorukaTarget target;

    public bool playScene = true;
    public bool currentStart = false;
    public bool gameover = false;
    public bool gamecrear = false;
    public bool finding = false;       //EDまたはMONを見つけたか

    public bool backgroundStop = false;  // Background・ClickObjから合図
    public string nextScene;
    public string crearScene;
    public GameObject fadeObj;
    bool fadeBool = true;

    // playSceneのとき使う
    bool text = false;

    // playSceneではないときに使う
    public int point = 0;
    public GameObject apatoObj;
    bool apatoBool = true;

	void Update () {
       
        if(playScene)
        {
            PlayEvents();
        }

        if(!playScene && !currentStart && !gameover)
        {
            StartScene();
        }

        if(currentStart)
        {
            StartScene2();
        }

        if(gameover)
        {
            if(!GameObject.FindGameObjectWithTag("Fade"))
            {
                SceneManager.LoadScene(nextScene);
            }
        }

        if(gamecrear)
        {
            if (fadeBool)
            {
                Instantiate(fadeObj);
                fadeBool = false;
            }

            fadein = FindObjectOfType<FadeIn>();
            fadein.sceneName = crearScene;
        }
    }

    void PlayEvents()
    {
        if (GameObject.FindGameObjectWithTag("Text"))
        {
            text = true;
        }

        if (!GameObject.FindGameObjectWithTag("Text") && text)
        {
            if (fadeBool)
            {
                Instantiate(fadeObj);
                fadeBool = false;
            }

            fadein = FindObjectOfType<FadeIn>();
            fadein.sceneName = nextScene;
        }
    }

    void StartScene()
    {
        if(point == 3)
        {
            if(apatoBool)
            {
                Instantiate(apatoObj);
                apatoBool = false;
            }
        }
        if(point == 5)
        {
            target = FindObjectOfType<ModorukaTarget>();
            target.selectOK = true;
        }
    }

    void StartScene2()
    {
        if(point == 5)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    // Serif_PlayStart2の流れとアニメを同期するため
    public void MoveAnimation(int a)
    {
        point = point + a;
    }

}
