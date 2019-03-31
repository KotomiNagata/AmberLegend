using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Cave : MonoBehaviour {

    GameEvents_Cave events;

    public GameObject EdmondObj;
    bool EdmondBool = true;

    void Start () {
        events = FindObjectOfType<GameEvents_Cave>();
    }
	
	void Update () {
        if(!events.gate)
        {
            Destroy(this.gameObject);
        }
        if(events.gameOver)
        {
            Destroy(this.gameObject);
            if(EdmondBool)
            {
                Instantiate(EdmondObj);
                EdmondBool = false;
            }
        }
	}
}
