using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart_Allo : MonoBehaviour {

    GameRule rule;
    ModorukaTarget target;

    public GameObject edmondObj;
    public GameObject monmonObj;
    public GameObject EDrideObj;
    public GameObject MONrideObj;
    public GameObject edmondBoyText;
    public GameObject monmonBoyText;
    public GameObject edmondGirlText;
    public GameObject monmonGirlText;
    bool textBool = true;
    bool rideBool = true;

    public int point = 0;

    void Start () {
        rule = FindObjectOfType<GameRule>();
        target = FindObjectOfType<ModorukaTarget>();

        if(rule.EdmondIsHuman)
        {
            Instantiate(edmondObj);
        }
        if(!rule.EdmondIsHuman)
        {
            Instantiate(monmonObj);
        }
	}
	
	void Update () {
        if (!GameObject.FindGameObjectWithTag("Fade"))
        {
            if (textBool)
            {
                if (rule.EdmondIsHuman && rule.IamBoy)
                {
                    Instantiate(edmondBoyText);
                }
                if (!rule.EdmondIsHuman && rule.IamBoy)
                {
                    Instantiate(monmonBoyText);
                }
                if (rule.EdmondIsHuman && !rule.IamBoy)
                {
                    Instantiate(edmondGirlText);
                }
                if (!rule.EdmondIsHuman && !rule.IamBoy)
                {
                    Instantiate(monmonGirlText);
                }
                textBool = false;
            }
            if (point == 7 && rule.EdmondIsHuman)
            {
                if(rideBool)
                {
                    Instantiate(EDrideObj);
                    rideBool = false;
                }
            }
            if (point == 8 && rule.EdmondIsHuman)
            {
                target.selectOK = true;
            }

            if (point == 8 && !rule.EdmondIsHuman)
            {
                if (rideBool)
                {
                    Instantiate(MONrideObj);
                    rideBool = false;
                }
            }
            if (point == 9 && !rule.EdmondIsHuman)
            {
                target.selectOK = true;
            }
        }
    }

    // Serif_PlayStart2の流れとアニメを同期するため
    public void MoveAnimation(int a)
    {
        point = point + a;
    }
}
