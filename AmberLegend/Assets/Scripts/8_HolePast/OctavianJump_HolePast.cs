using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctavianJump_HolePast : MonoBehaviour {

    Rigidbody2D rb;
    GameEvents_HolePast events;

    public bool JumpRight = false;
    public GameObject octavian1Obj;
    public GameObject octavian2Obj;
    public GameObject octavian3Obj;
    bool one = true;

    float runX = 0f;            // 移動方向
    float runY = 0f;
    float speedX = 6f;
    float speedY = 3f;          // 移動スピード
    float startX;

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_HolePast>();
        events.jumpNow = true;

        runY = 1f;

        if (JumpRight)
        {
            runX = 1f;
            startX = this.transform.position.x + 2.7f;
        }

        if (!JumpRight)
        {
            runX = -1f;
            startX = this.transform.position.x - 2.7f;
        }
    }
	

	void Update () {
        rb.velocity = new Vector2(runX * speedX, runY * speedY);

        if (this.transform.position.y > 2.6)
        {
            runY = -1f;
        }

        if (JumpRight)
        {
            if (this.transform.position.x > startX)
            {
                if(one)
                {
                    if (events.PosNumber == 1)
                    {
                        Instantiate(octavian1Obj);
                    }
                    if (events.PosNumber == 2)
                    {
                        Instantiate(octavian2Obj);
                    }
                    if (events.PosNumber == 3)
                    {
                        Instantiate(octavian3Obj);
                    }
                    one = false;
                }
                events.jumpNow = false;
                Destroy(this.gameObject);
            }
        }

        if (!JumpRight)
        {
            if (this.transform.position.x < startX)
            {
                if (one)
                {
                    if (events.PosNumber == 1)
                    {
                        Instantiate(octavian1Obj);
                    }
                    if (events.PosNumber == 2)
                    {
                        Instantiate(octavian2Obj);
                    }
                    if (events.PosNumber == 3)
                    {
                        Instantiate(octavian3Obj);
                    }
                    one = false;
                }
                events.jumpNow = false;
                Destroy(this.gameObject);
            }
        }
    }
}
