using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_Allo : MonoBehaviour {

    Rigidbody2D rb;
    GameEvents_Allo events;

    public bool JumpRight = false;
    public GameObject octavian1Obj;
    public GameObject octavian2Obj;
    public GameObject octavian3Obj;
    bool one = true;

    float run = 0f;
    float speed = 10f;
    float startX;

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_Allo>();

        if (JumpRight)
        {
            run = 1f;
            startX = this.transform.position.x + 2.7f;
        }

        if (!JumpRight)
        {
            run = -1f;
            startX = this.transform.position.x - 2.7f;
        }

    }
	
	void Update () {

        rb.velocity = new Vector2(run * speed, rb.velocity.y);

        if (JumpRight)
        {
            if (this.transform.position.x > startX)
            {
                if (one)
                {
                    if (events.posNumber == 1)
                    {
                        Instantiate(octavian1Obj);
                    }
                    if (events.posNumber == 2)
                    {
                        Instantiate(octavian2Obj);
                    }
                    if (events.posNumber == 3)
                    {
                        Instantiate(octavian3Obj);
                    }
                    one = false;
                }
                Destroy(this.gameObject);
            }
        }

        if (!JumpRight)
        {
            if (this.transform.position.x < startX)
            {
                if (one)
                {
                    if (events.posNumber == 1)
                    {
                        Instantiate(octavian1Obj);
                    }
                    if (events.posNumber == 2)
                    {
                        Instantiate(octavian2Obj);
                    }
                    if (events.posNumber == 3)
                    {
                        Instantiate(octavian3Obj);
                    }
                    one = false;
                }
                Destroy(this.gameObject);
            }
        }

    }
}
