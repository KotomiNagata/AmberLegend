using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlloBigCollider : MonoBehaviour {

	void Start () {
        Invoke("End", 0.5f);
    }
	
	void End () {
        Destroy(this.gameObject);
	}
}
