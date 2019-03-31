using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCrearEvent_Allo : MonoBehaviour {

    GameRule rule;
    ModorukaTarget target;

    public GameObject edObj;
    public GameObject edObj2;
    public GameObject monObj;
    public GameObject monObj2;
    public GameObject serifBoyObj;
    public GameObject serifGirlObj;
    public GameObject button1Obj;
    public GameObject button2Obj;
    public int point = 0;     // セリフと動きを合わせるため
    public bool serifMade = false; // Alloから指示

    bool serifBool = true;
    bool buttonBool = true;
    bool Obj2Bool = true;

    void Start () {
        rule = FindObjectOfType<GameRule>();

        if(rule.EdmondIsHuman)
        {
            Instantiate(edObj);
        }
        if (!rule.EdmondIsHuman)
        {
            Instantiate(monObj);
        }
    }
	
	void Update () {
		
        if(serifMade)
        {
            if(serifBool)
            {
                if(rule.IamBoy)
                {
                    Instantiate(serifBoyObj);
                }
                if (!rule.IamBoy)
                {
                    Instantiate(serifGirlObj);
                }
                serifBool = false;
            }
        }

        if(point == 7)
        {
            if(buttonBool)
            {
                Instantiate(button1Obj);
                buttonBool = false;
            }
        }

        if(point == 11)
        {
            if (!buttonBool)
            {
                Instantiate(button2Obj);
                buttonBool = true;
            }
        }

        if(point == 14)
        {
            if(Obj2Bool)
            {
                if(rule.EdmondIsHuman)
                {
                    Instantiate(edObj2);
                }
                if(!rule.EdmondIsHuman)
                {
                    Instantiate(monObj2);
                }
                Obj2Bool = false;
            }
        }

        if(point == 19)
        {
            target = FindObjectOfType<ModorukaTarget>();
            target.selectOK = true;
        }

	}

    public void MoveAnimation(int a)
    {
        point = point + a;
    }
}
