using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama_Allo : MonoBehaviour {

    Rigidbody2D rb;
    Collider2D col;
    GameEvents_Allo events;

    public string positionNumber;

    float runX = 0f;            // 移動方向
    float runY = 0f;            // 移動方向
    float speed = 5f;           // 移動スピード

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        events = FindObjectOfType<GameEvents_Allo>();
    }
	
	void Update () {

        Vector3 scale = this.gameObject.transform.localScale;

        if(events.gameOver)
        {
            Destroy(this.gameObject);
        }

        if (positionNumber == "1")
        {
            runX = -1f;
            runY = -1f;
            rb.velocity = new Vector2(runX * speed, runY * speed);
        }
        if (positionNumber == "2")
        {
            runY = -1f;
            rb.velocity = new Vector2(rb.velocity.x, runY * speed);
        }
        if (positionNumber == "3")
        {
            runX = 1f;
            runY = -1f;
            rb.velocity = new Vector2(runX * speed, runY * speed);
        }
        //1.8

        if(this.transform.position.y < -1.8 )
        {
            col.enabled = !col.enabled;
        }

        //拡大する
        gameObject.transform.localScale = new Vector3(
            scale.x + 0.1f,
            scale.y + 0.1f,
            scale.z
        );

        if (this.transform.position.y < -4)
        {
            Destroy(this.gameObject);
        }

    }
}
