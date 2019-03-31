using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Allo : MonoBehaviour {

	GameEvents_Allo events;

    bool one = true;

    void Start () {
        events = FindObjectOfType<GameEvents_Allo>();
	}

    void Update () {
        if(events.gameCrearObj)
        {
            Destroy(this.gameObject);
        }
    }

    public void MoveRight()
    {
        if (one && events.moveOK)
        {
            // 1から3に飛ばないように順番を置き換えた
            if (events.posNumber == 2)
            {
                events.posNumber = 3;
                events.moveOK = false;
                one = false;
            }
            if (events.posNumber == 1)
            {
                events.posNumber = 2;
                events.moveOK = false;
                one = false;
            }
            if (events.posNumber == 3)
            {
                events.posNumber = 3;
                events.moveOK = false;
                one = false;
            }
        }
    }

    public void MoveLeft()
    {
        if (one && events.moveOK)
        {
            if (events.posNumber == 1)
            {
                events.posNumber = 1;
                events.moveOK = false;
                one = false;
            }
            if (events.posNumber == 2)
            {
                events.posNumber = 1;
                events.moveOK = false;
                one = false;
            }
            if (events.posNumber == 3)
            {
                events.posNumber = 2;
                events.moveOK = false;
                one = false;
            }
        }
    }

    public void ButtonUp()
    {
        one = true;
    }
}
