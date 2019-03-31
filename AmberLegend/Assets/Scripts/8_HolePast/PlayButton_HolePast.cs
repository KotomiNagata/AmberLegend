using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton_HolePast : MonoBehaviour {

    GameEvents_HolePast events;

    bool one = true;

	void Start () {
        events = FindObjectOfType<GameEvents_HolePast>();
	}
	
    public void MoveRight()
    {
        if(one && !events.jumpNow)
        {
            // 1から3に飛ばないように順番を置き換えた
            if (events.PosNumber == 2)
            {
                events.PosNumber = 3;
                one = false;
            }
            if (events.PosNumber == 1)
            {
                events.PosNumber = 2;
                one = false;
            }
            if (events.PosNumber == 3)
            {
                events.PosNumber = 3;
                one = false;
            }
        }
    }

    public void MoveLeft()
    {
        if (one && !events.jumpNow)
        {
            if (events.PosNumber == 1)
            {
                events.PosNumber = 1;
                one = false;
            }
            if (events.PosNumber == 2)
            {
                events.PosNumber = 1;
                one = false;
            }
            if (events.PosNumber == 3)
            {
                events.PosNumber = 2;
                one = false;
            }
        }
    }

    public void ButtonUp()
    {
        one = true;
    }
}
