using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlayer : MonoBehaviour {

    Rigidbody2D rb;
    Player_PlayStart2 player;
    Octavian_PlayStart2 octavian;

    float run = 0f;
    float speed = 4f;         // 移動スピード

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player_PlayStart2>();
        octavian = FindObjectOfType<Octavian_PlayStart2>();
        run = 1f;
    }
	
	
	void Update () {
        rb.velocity = new Vector2(rb.velocity.x, run * speed);

        if (this.transform.position.y > 0)
        {
            player.catch1 = true;
            run = -1f;
            speed = 2f;
        }

        if (this.transform.position.y < -7)
        {
            octavian.catchOK = true;
            Destroy(this.gameObject);
        }

    }
}
