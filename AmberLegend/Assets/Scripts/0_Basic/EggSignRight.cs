using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSignRight : MonoBehaviour {

    FadeIn fadeIn;

    public GameObject fadeObj;
    bool fadeBool = true;

    public string nextScene;
    bool rightEndOK = false;

	void Update () {
        if(rightEndOK)
        {
            if(fadeBool)
            {
                Instantiate(fadeObj);
                fadeBool = false;
            }
            fadeIn = FindObjectOfType<FadeIn>();
            fadeIn.sceneName = nextScene;
        }
	}

    public void RightEnd()
    {
        rightEndOK = true;
    }
}
