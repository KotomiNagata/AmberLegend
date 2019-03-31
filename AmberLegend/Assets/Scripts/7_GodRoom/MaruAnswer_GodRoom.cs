using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaruAnswer_GodRoom : MonoBehaviour {

    public GameObject serif4Obj;
    public GameObject soundGameCrear;
    bool one = false;
    bool two = true;

    void OnMouseDown()
    {
        if(two)
        {
            var obj = GameObject.FindGameObjectWithTag("Text");
            Destroy(obj);
            one = true;
            two = false;
        }
        if (one)
        {
            Instantiate(serif4Obj);
            Instantiate(soundGameCrear);
            one = false;
        }
        Destroy(this.gameObject);
    }

}
