using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Hole : MonoBehaviour {

    GameRule rule;
    Octavian_Hole octavian;
    GameEvents_Hole events;

    public string thisNumber = "1_1";
    public GameObject serifObj;
    public bool changeGender = false;
    public bool reset = false;
    bool one = true;

    void Start()
    {
        rule = FindObjectOfType<GameRule>();
        octavian = FindObjectOfType<Octavian_Hole>();
        events = FindObjectOfType<GameEvents_Hole>();
        if(reset)
        {
            events.point = 0;
        }
    }

    public void ClickOn()
    {
        if(one)
        {
            Instantiate(serifObj);
            if (changeGender)
            {
                rule.IamBoy = !rule.IamBoy;
            }
            if(reset)
            {
                octavian.reset = true;
            }
            one = false;
        }
        octavian.numberSelect = thisNumber;
        var obj = GameObject.FindGameObjectWithTag("HowAreYouOK?");
        Destroy(obj);
    }
	
}
