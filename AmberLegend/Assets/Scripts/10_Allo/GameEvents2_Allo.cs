using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents2_Allo : MonoBehaviour {

    FadeIn fadeIn;
    GameRule rule;

    public GameObject edObj;
    public GameObject monObj;
    public GameObject serifObj;
    public GameObject fadeObj;
    public string nextScene;
    public int point = 0;     // セリフと動きを合わせるため

    bool serifBool = true;
    bool fadeBool = true;

	void Start () {
        rule = FindObjectOfType<GameRule>();

        if (rule.EdmondIsHuman)
        {
            Instantiate(edObj);
        }
        if (!rule.EdmondIsHuman)
        {
            Instantiate(monObj);
        }
    }
	
	void Update () {
        if(!GameObject.FindGameObjectWithTag("Fade"))
        {
            if(serifBool)
            {
                Instantiate(serifObj);
                serifBool = false;
            }
        }

        // edObjまたはmonObjからpoint追加
        if(point == 4)
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

    // Serif
    public void MoveAnimation(int a)
    {
        point = point + a;
    }
}
