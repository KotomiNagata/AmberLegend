using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay_Cave : MonoBehaviour {

    Octavian2_Cave octavian;

    public bool thisIsObj1 = true;

	void Start () {
        octavian = FindObjectOfType<Octavian2_Cave>();
	}
	
	void Update () {

        if(Input.GetMouseButtonUp(0))
        {
            if(!thisIsObj1)
            {
                octavian.Obj2no = true;
            }

            Destroy(this.gameObject);
        }

    }
}
