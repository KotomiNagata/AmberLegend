using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEnd : MonoBehaviour {

    Rigidbody2D rb;
    FadeIn fadeIn;

    public float endPosY;
    public GameObject fadeObj;
    public string nextScene;

    float run = 1f;
    float speed = 1.5f;         // 移動スピード
    bool fadeBool = true;

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();

    }
	
	void Update () {
        rb.velocity = new Vector2(rb.velocity.x, run * speed);

        if(this.transform.position.y > endPosY)
        {
            if(fadeBool)
            {
                Instantiate(fadeObj);
                fadeBool = false;
            }
            fadeIn = FindObjectOfType<FadeIn>();
            fadeIn.sceneName = nextScene;
            Destroy(this.gameObject);
        }

    }
}
