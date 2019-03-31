using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape_Cave : MonoBehaviour {

    Rigidbody2D rb;
    GameEvents_Cave events;

    public float speed = 2f;   // 移動スピード
    float run = 0f;            // 進む方向

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_Cave>();
    }
	

	void Update () {
        rb.velocity = new Vector2(run * speed, rb.velocity.y);
        run = -1f;

        if(this.transform.position.x < -7)
        {
            events.escapeOFF = true;
            Destroy(this.gameObject);
        }
    }
}
