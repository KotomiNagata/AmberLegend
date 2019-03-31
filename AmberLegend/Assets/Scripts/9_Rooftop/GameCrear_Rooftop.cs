using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCrear_Rooftop : MonoBehaviour {

    GameRule rule;
    Edmond_Rooftop edmond;
    Octavian2_Rooftop oct;
    Background_Rooftop bg;
    FadeIn fadein;

    public GameObject edmondObj;
    public GameObject monmonObj;
    public GameObject edmondText;
    public GameObject monmonText;
    public GameObject breakGroundObj;
    public GameObject fadeObj;
    public string nextScene;
    bool edmondBool = true;
    bool octBool = true;
    bool one = true;
    bool fadeBool = true;
    bool breakGroundBool = true;

    public int point = 0;

    void Start () {
        rule = FindObjectOfType<GameRule>();
        bg = FindObjectOfType<Background_Rooftop>();

        if (rule.EdmondIsHuman)
        {
            Instantiate(edmondObj);
        }
        if (!rule.EdmondIsHuman)
        {
            Instantiate(monmonObj);
        }
    }
	
	void Update () {

        if(!GameObject.FindGameObjectWithTag("Fade"))
        {
            if(one)
            {
                if(rule.EdmondIsHuman)
                {
                    Instantiate(edmondText);
                }
                if(!rule.EdmondIsHuman)
                {
                    Instantiate(monmonText);
                }
                one = false;
            }
        }

        if(point == 5)
        {
            StartCoroutine("Movement");
        }
	}

    public void MoveAnimation(int a)
    {
        point = point + a;
    }

    private IEnumerator Movement()
    {
        if(edmondBool)
        {
            edmond = FindObjectOfType<Edmond_Rooftop>();
            edmond.fall = true;
            edmondBool = false;
        }

        yield return new WaitForSeconds(0.1f);

        // 地面破壊
        if(breakGroundBool)
        {
            bg.des = true;
            Instantiate(breakGroundObj);
            breakGroundBool = false;
        }

        yield return new WaitForSeconds(1f);

        if(octBool)
        {
            oct = FindObjectOfType<Octavian2_Rooftop>();
            oct.fall = true;
            octBool = false;
        }

        yield return new WaitForSeconds(1f);

        if (fadeBool)
        {
            Instantiate(fadeObj);
            fadeBool = false;
        }

        fadein = FindObjectOfType<FadeIn>();
        fadein.sceneName = nextScene;

    }

}
