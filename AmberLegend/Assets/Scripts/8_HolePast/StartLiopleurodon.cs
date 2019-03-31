using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLiopleurodon : MonoBehaviour {

    Rigidbody2D rb;

    float run = 0f;            // 移動方向
    public float speed = 3f;   // 移動スピード

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        run = -1f;
    }
	
	void Update () {
        rb.velocity = new Vector2(run * speed, rb.velocity.y);
    }
}
