using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_HolePast : MonoBehaviour {

    FadeIn fadeIn;

    public GameObject serifObj;
    public GameObject lioObj;
    public GameObject fadeObj;
    public string nextScene;
    public bool runEnd = false;        // Octavianが逃げ切ったか
    bool serifBool = true;
    bool lioBool = true;
    bool fadeBool = true;
    public int point = 0;     // セリフと動きを合わせるため

    void Start () {
		
	}
	
	void Update () {

        if (!GameObject.FindGameObjectWithTag("Fade"))
        {
            if(serifBool)
            {
                Instantiate(serifObj);
                serifBool = false;
            }
        }

        if(point == 4)
        {
            if(lioBool)
            {
                Instantiate(lioObj);
                lioBool = false;
            }
        }

        if(runEnd)
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

    // Serif_PlayStart2の流れとアニメを同期するため
    public void MoveAnimation(int a)
    {
        point = point + a;
    }

}
