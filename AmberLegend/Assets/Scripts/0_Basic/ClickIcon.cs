﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickIcon : MonoBehaviour {

	
	void Update ()
    {
        if(Input.GetMouseButton(0))
        {
            Destroy(this.gameObject);
        }
		
	}
}
