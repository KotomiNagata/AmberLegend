using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStart_Allo : MonoBehaviour {

    GameEvents2_Allo events;
    Rigidbody2D rb;

    public bool gameover = false;

    float run = 0f;            // 移動方向
    float speed = 10f;          // 移動スピード
    int a = 1;

    void Start () {
        if(!gameover)
        {
            events = FindObjectOfType<GameEvents2_Allo>();
            this.rb = GetComponent<Rigidbody2D>();
        }
    }
	
	void Update () {
        if(!gameover)
        {
            rb.velocity = new Vector2(run * speed, rb.velocity.y);

            if (events.point == 3)
            {
                run = 1f;
            }

            if (this.transform.position.x > 7)
            {
                events.MoveAnimation(a);
                Destroy(this.gameObject);
            }
        }

    }
}
