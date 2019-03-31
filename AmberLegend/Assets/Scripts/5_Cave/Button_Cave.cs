using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Cave : MonoBehaviour {

    GameEvents_Cave events;

    void Start()
    {
        events = FindObjectOfType<GameEvents_Cave>();
    }

    void Update()
    {
        if(events.gameOver || events.gameCrear2)
        {
            Destroy(this.gameObject);
        }
    }

    public void StopPushDown()
    {
        events.gate = true;
    }

    public void StopPushUp()
    {
        events.gate = false;
    }

}
