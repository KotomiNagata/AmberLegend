using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octavian_HolePast : MonoBehaviour {

    Rigidbody2D rb;
    GameEvents_HolePast events;

    public int PosNumber = 2;
    public GameObject JumpRightObj;
    public GameObject JumpLeftObj;
    bool one = true;

    float run = 0f;            // 移動方向
    public float speed = 2f;   // 移動スピード

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_HolePast>();
    }
	
	void Update () {

        if(PosNumber == 1)
        {
            if(events.PosNumber == 2)
            {
                if(one)
                {
                    Instantiate(JumpRightObj, this.transform.position, Quaternion.identity);
                    one = false;
                }
                Destroy(this.gameObject);
            }
        }

        if (PosNumber == 2)
        {
            if (events.PosNumber == 1)
            {
                if (one)
                {
                    Instantiate(JumpLeftObj, this.transform.position, Quaternion.identity);
                    one = false;
                }
                Destroy(this.gameObject);
            }
            if (events.PosNumber == 3)
            {
                if (one)
                {
                    Instantiate(JumpRightObj, this.transform.position, Quaternion.identity);
                    one = false;
                }
                Destroy(this.gameObject);
            }
        }

        if (PosNumber == 3)
        {
            if (events.PosNumber == 2)
            {
                if (one)
                {
                    Instantiate(JumpLeftObj, this.transform.position, Quaternion.identity);
                    one = false;
                }
                Destroy(this.gameObject);
            }
        }

        if(events.gameCrear)
        {
            rb.velocity = new Vector2(rb.velocity.x, run * speed);
            run = 1f;
            if(this.transform.position.y > 4.7)
            {
                events.gameCrearFade = true;
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            events.gameOver = true;
            Destroy(this.gameObject);
        }
    }

}
