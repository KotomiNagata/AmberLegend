using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Title : MonoBehaviour {

    FadeIn fadeIn;

    public GameObject fadeInObj;
    public string nextScene;
    bool one = true;

    public void PlayStart()
    {
        if (one)
        {
            Instantiate(fadeInObj);
            one = false;
        }
        fadeIn = FindObjectOfType<FadeIn>();
        fadeIn.sceneName = nextScene;
        Destroy(this.gameObject);
    }

}
