using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctavianAss_Hole : MonoBehaviour {

    public GameObject octavianObj;
    bool one = true;

    void OnMouseDown()
    {
        if(one)
        {
            Instantiate(octavianObj, this.transform.position, Quaternion.identity);
            one = false;
        }
        Destroy(this.gameObject);
    }
}
