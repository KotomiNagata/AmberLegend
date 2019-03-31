using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSelectButton : MonoBehaviour {

    FadeIn fadeIn;
    GameRule bg;

    public bool thisIsBoy;
    public string nextSceneName;
    public GameObject FadeIn;
    bool one = true;

    public void Start()
    {
        bg = FindObjectOfType<GameRule>();
    }

    public void Yes()
    {
        if (thisIsBoy)
        {
            bg.IamBoy = true;
        }
        if (!thisIsBoy)
        {
            bg.IamBoy = false;
        }
        if (one)
        {
            Instantiate(FadeIn);
            one = true;
        }
        fadeIn = FindObjectOfType<FadeIn>();
        fadeIn.sceneName = nextSceneName;
    }

    public void No()
    {
        var obj = GameObject.FindGameObjectWithTag("HowAreYouOK?");
        Destroy(obj);
    }

}
