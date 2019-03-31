using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModorukaTarget : MonoBehaviour {

    Collider2D col;
    FadeIn fadeIn;
    Modoruka modoruka;

    public bool selectOK = false; // イベント後クリックできるようにする
    bool one = true;              // col.enabled用

    public GameObject fadeObj;
    bool fadeBool = true;
    public string nextScene;

	void Start () {
        modoruka = FindObjectOfType<Modoruka>();
        col = GetComponent<Collider2D>();
        col.enabled = !col.enabled;
    }

    void Update()
    {
        if (selectOK)
        {
            if (one)
            {
                col.enabled = !col.enabled;
                one = false;
            }
        }
    }
	
    void OnMouseOver()
    {
        modoruka.targetOver = true;
    }

    void OnMouseExit()
    {
        modoruka.targetOver = false;
    }

    public void OnMouseDown()
    {
        if(fadeBool)
        {
            Instantiate(fadeObj);
            fadeBool = false;
        }
        fadeIn = FindObjectOfType<FadeIn>();
        fadeIn.sceneName = nextScene;
    }
}
