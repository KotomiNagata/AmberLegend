using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDay_End : MonoBehaviour {

    FadeIn fadeIn;

    public GameObject fadeObj;
    public string nextScene;
    bool fadeBool = true;

	void Start () {
        StartCoroutine("Opening");
    }

    private IEnumerator Opening()
    {
        yield return new WaitForSeconds(3f);

        if(fadeBool)
        {
            Instantiate(fadeObj);
            fadeBool = false;
        }
        fadeIn = FindObjectOfType<FadeIn>();
        fadeIn.sceneName = nextScene;
    }
}
