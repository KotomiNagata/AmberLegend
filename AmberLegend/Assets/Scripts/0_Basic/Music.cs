using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	void Update () {
        Invoke("MusicEnd", 10f);
    }

    void MusicEnd()
    {
        Destroy(this.gameObject);
    }
}
