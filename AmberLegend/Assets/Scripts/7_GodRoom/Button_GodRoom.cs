using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_GodRoom : MonoBehaviour {

    GameRule rule;
    Octavian_GodRoom octavian;

    public GameObject serifObj;
    public bool edmondIsDinosaur = false;
    public string serifNumber = "1_1";
    bool one = true;

    void Start () {
        rule = FindObjectOfType<GameRule>();
        octavian = FindObjectOfType<Octavian_GodRoom>();
	}
	
	void Update () {
		
	}

    public void ClickOn()
    {
        if (one)
        {
            Instantiate(serifObj);

            if(edmondIsDinosaur)
            {
                rule.EdmondIsHuman = false;
            }
            one = false;
        }
        octavian.serifNumber = serifNumber;
        var obj = GameObject.FindGameObjectWithTag("HowAreYouOK?");
        Destroy(obj);
    }
}
