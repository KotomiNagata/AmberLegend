using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_AlloGameCrear : MonoBehaviour {

    GameCrearEvent_Allo events;

    public bool first = false;
    public GameObject serifObj;
    bool serifBool = true;
    int a = 1;

    public void Click()
    {
        if(first)
        {
            if (serifBool)
            {
                Instantiate(serifObj);
                serifBool = false;
            }
        }

        if(!first)
        {
            events = FindObjectOfType<GameCrearEvent_Allo>();
            events.MoveAnimation(a);
        }

        Destroy(this.gameObject);
    }
}
