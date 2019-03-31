using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoMan_AlloGameCrar : MonoBehaviour {

    public GameObject octObj;
    public GameObject edObj;
    bool ObjBool = true;

	void Start () {
		
	}
	
	void Update () {
        if(!GameObject.FindGameObjectWithTag("Fade"))
        {
            if(ObjBool)
            {
                Instantiate(octObj);
                Instantiate(edObj);
                ObjBool = false;
            }

            Destroy(this.gameObject);
        }
	}
}
