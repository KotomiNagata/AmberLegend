using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodRoomHole : MonoBehaviour {

    GameRule rule;
    ModorukaTarget target;

    public int point = 0;     // セリフと動きを合わせるため

    public GameObject serifBoyObj;
    public GameObject serifGirlObj;
    bool serifBool = true;

    void Start () {
        rule = FindObjectOfType<GameRule>();
        target = FindObjectOfType<ModorukaTarget>();
	}
	
	void Update () {

        if(!GameObject.FindGameObjectWithTag("Fade"))
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
            target.selectOK = true;
        }
	}

    // Serif_PlayStart2の流れとアニメを同期するため
    public void MoveAnimation(int a)
    {
        point = point + a;
    }
}
