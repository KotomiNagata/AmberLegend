using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents_Hole : MonoBehaviour {

    GameRule rule;

    public int point = 0;     // セリフと動きを合わせるため

    public GameObject button1Obj_Boy;
    public GameObject button1Obj_Girl;
    public GameObject button2Obj;
    public GameObject button3Obj;
    public GameObject serif2_4Obj;
    public GameObject serif3_3Obj;

    bool one = true; //button
    bool two = true; //serif

    void Start () {
        rule = FindObjectOfType<GameRule>();
	}
	
	void Update () {
        if(point == 2)
        {
            if(one)
            {
                if(rule.IamBoy)
                {
                    Instantiate(button1Obj_Boy);
                }
                if (!rule.IamBoy)
                {
                    Instantiate(button1Obj_Girl);
                }
                one = false;
            }
        }

        if(point == 6)
        {
            if (two)
            {
                Instantiate(serif2_4Obj);
                two = false;
            }
        }

        if (point == 10)
        {
            if (!one)
            {
                Instantiate(button2Obj);
                one = true;
            }
        }

        if (point == 12)
        {
            if(!two)
            {
                Instantiate(serif3_3Obj);
                two = true;
            }
        }

        if(point == 16)
        {
            if(one)
            {
                Instantiate(button3Obj);
                one = false;
            }
        }

    }

    // Serif_PlayStart2の流れとアニメを同期するため
    public void MoveAnimation(int a)
    {
        point = point + a;
    }
}
