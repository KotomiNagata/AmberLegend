using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Rooftop : MonoBehaviour {

    Rigidbody2D rb;
    GameEvents_Rooftop events;

    float run = 0f;            // 移動方向
    public float speed = 1f;   // 移動スピード
    public bool BG = false;

    // GameCrearのときに使う
    public bool gameCrear = false;
    public bool des = false;

    void Start () {

        if (!gameCrear)
        {
            this.rb = GetComponent<Rigidbody2D>();
            events = FindObjectOfType<GameEvents_Rooftop>();
            run = -1f;
        }
    }
	
	void Update () {
        if(!gameCrear)
        {
            Usually();
        }

        if(gameCrear)
        {
            if(des)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Usually()
    {
        rb.velocity = new Vector2(run * speed, rb.velocity.y);

        if (this.transform.position.x < -16.7 && BG)
        {
            run = 0f;
            events.backgroundStop = true;
        }
        if (this.transform.position.x < -18 && !BG)
        {
            Destroy(this.gameObject);
        }
        if (events.backgroundStop)
        {
            run = 0f;
        }
    }

}
