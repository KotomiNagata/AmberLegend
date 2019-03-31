using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea_HolePast : MonoBehaviour {

    Rigidbody2D rb;
    GameOver_HolePast game;
    GameEvents_HolePast events;

    public bool gameOverScene = true;

    float run = 0f;            // 移動方向
    public float speed = 2f;   // 移動スピード

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();

        if(!gameOverScene)
        {
            events = FindObjectOfType<GameEvents_HolePast>();
        }
        if(gameOverScene)
        {
            game = FindObjectOfType<GameOver_HolePast>();
        }
    }
	
	
	void Update () {

        if(!gameOverScene)
        {
            if(events.gameCrear)
            {
                rb.velocity = new Vector2(rb.velocity.x, run * speed);
                run = 1f;

                if (this.transform.position.y > 0.5)
                {
                    run = 0f;
                }
            }
        }

        if(gameOverScene)
        {
            if (game.serifEnd)
            {
                rb.velocity = new Vector2(rb.velocity.x, run * speed);
                run = 1f;

                if (this.transform.position.y > -1)
                {
                    run = 0f;
                }
            }
        }
    }
}
