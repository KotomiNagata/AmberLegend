using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apato_Rooftop : MonoBehaviour {

    Rigidbody2D rb;

    float run = 1f;            // 移動方向
    float speed = 2f;          // 移動スピード

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        rb.velocity = new Vector2(rb.velocity.x, run * speed);

        if(this.transform.position.y > 1.3)
        {
            run = 0f;
        }
    }
}
