using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_PlayStart : MonoBehaviour {

    StartMove startScript;
    Rigidbody2D rb;

    public float endPosition;
    public bool moveON = false;  // StartMoveから命令
    float speed = 3f;     // 移動スピード
    float run = 0f;

    void Start () {
        startScript = FindObjectOfType<StartMove>();
        this.rb = GetComponent<Rigidbody2D>();
    }
	
	
	void Update () {
		
        // StartMoveから移動許可をもらったら
        if(moveON)
        {
            run = 1f;
        }

        if(this.transform.position.y > endPosition)
        {
            moveON = false;
            run = 0f;
            startScript.backgroundEnd = true;
        }

        rb.velocity = new Vector2(rb.velocity.x, run * speed);
    }
}
