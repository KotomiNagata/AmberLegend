using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour {

    Rigidbody2D rb;

    public float speed = 1f;   // 移動スピード
    float run = 1f;            // 進む方向

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
    }

	void Update () {
        rb.velocity = new Vector2(run * speed, rb.velocity.y);

        if(this.transform.position.x > 6)
        {
            Destroy(this.gameObject);
        }
    }
}
