using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalPredator_Cave : MonoBehaviour {

    Rigidbody2D rb;
    GameEvents_Cave events;

    public bool thisIsBat = false;
    float runX = 0f;
    float runY = 0f;
    public float speed = 1f;     // 移動スピード

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_Cave>();
        events.NP = true;
    }
	

	void Update () {

        if (thisIsBat)
        {
            rb.velocity = new Vector2(runX * speed, runY * speed);
            runX = -1f;
            runY = 1f;
            if(this.transform.position.y > 8)
            {
                events.NP = false;
                Destroy(this.gameObject);
            }
        }

        if (!thisIsBat)
        {
            rb.velocity = new Vector2(runX * speed, rb.velocity.y);
            runX = -1f;
            if(this.transform.position.x < -8)
            {
                events.NP = false;
                Destroy(this.gameObject);
            }
        }


    }
}
