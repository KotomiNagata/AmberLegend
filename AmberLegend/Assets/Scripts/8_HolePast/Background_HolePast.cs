using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_HolePast : MonoBehaviour {

    Rigidbody2D rb;
    GameEvents_HolePast events;

    public bool thisIsLvy = false;
    public bool thisIsLine = false;
    public bool thisIsGround = false;
    public GameObject thisObj;
    bool one = true;

    public float speed = 3f;  // 現在のスピード
    float run = 0f;

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_HolePast>();
        run = -1;
    }
	
	void Update () {
        rb.velocity = new Vector2(rb.velocity.x, run * speed);

        if(thisIsLvy)
        {
            if (this.transform.position.y < 0)
            {
               if(one)
                {
                    events.LvyBool = true;
                    one = false;
                }
            }

            if (this.transform.position.y < -6.6)
            {
                Destroy(this.gameObject);
            }
        }

        if(thisIsLine)
        {
            if(this.transform.position.y < -3.4)
            {
                if(one)
                {
                    events.LineBool = true;
                    one = false;
                }
                Destroy(this.gameObject);
            }
        }

        if(thisIsGround)
        {
            if (this.transform.position.y < -3.3)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
