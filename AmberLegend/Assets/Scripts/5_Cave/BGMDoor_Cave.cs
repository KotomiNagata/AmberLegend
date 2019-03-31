using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDoor_Cave : MonoBehaviour {

    private AudioSource sound01;
    public bool soundON = false;

    void Start () {
        sound01 = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        if(soundON)
        {
            sound01.PlayOneShot(sound01.clip);
        }
	}
}
