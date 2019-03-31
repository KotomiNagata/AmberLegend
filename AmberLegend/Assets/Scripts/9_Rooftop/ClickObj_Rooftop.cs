using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj_Rooftop : MonoBehaviour {

    Rigidbody2D rb;
    Collider2D col;
    GameEvents_Rooftop events;
    GameRule rule;
    Animator animator;

    public bool mouse = false;
    public bool UFO = false;
    public bool grass = false;
    public bool snake = false;
    public bool sun = false;
    public bool fly = false;
    public bool door = false;

    public GameObject cloneObj;
    public GameObject soundGameCrear;
    bool one = true;
    bool two = true;

    float run = 0f;            // 移動方向
    public float speed = 1f;   // 移動スピード
    string state;              // 見た目の切り替え
    string prevState;          // 前の状態を保存

    bool clickOK = false;

    void Start () {

        col = GetComponent<Collider2D>();

        if (mouse ||
            UFO ||
            fly)
        {
            this.rb = GetComponent<Rigidbody2D>();
        }

        if(door)
        {
            events = FindObjectOfType<GameEvents_Rooftop>();
            rule = FindObjectOfType<GameRule>();
            this.animator = GetComponent<Animator>();
            state = "USUALLY";
        }
    }

    void Update()
    {
        if(clickOK)
        {
            col.enabled = !col.enabled;

            if (mouse)
            {
                MouseClick();
            }
            if(UFO)
            {
                UFOClick();
            }
            if(grass)
            {
                GrassClick();
            }
            if(snake)
            {
                SnakeClick();
            }
            if(sun)
            {
                SunClick();
            }
            if(fly)
            {
                FlyClick();
            }
            if(door)
            {
                DoorClick();
                DoorAnimation();
                if(two)
                {
                    Instantiate(soundGameCrear);
                    two = false;
                }
            }
        }
    }

    void OnMouseDown()
    {
        clickOK = true;
    }

    void MouseClick()
    {
        rb.velocity = new Vector2(rb.velocity.x, run * speed);
        run = 1f;
        speed = 3f;

        if(this.transform.position.y > 1)
        {
            run = 0f;
        }
    }

    void UFOClick()
    {
        rb.velocity = new Vector2(run * speed, run * speed);
        run = 1f;
        speed = 3f;

        if(this.transform.position.y > 4.4)
        {
            Destroy(this.gameObject);
        }
    }

    void GrassClick()
    {
        if(one)
        {
            Instantiate(cloneObj, this.transform.position, Quaternion.identity);
            one = false;
        }
        Destroy(this.gameObject);
    }

    void SnakeClick()
    {
        if (one)
        {
            Instantiate(cloneObj, this.transform.position, Quaternion.identity);
            one = false;
        }
        Destroy(this.gameObject);
    }

    void SunClick()
    {
        if (one)
        {
            Instantiate(cloneObj, this.transform.position, Quaternion.identity);
            one = false;
        }
        Destroy(this.gameObject);
    }

    void FlyClick()
    {
        float speedFly = 2f;
        float width = 5f;
        float height = 2f;

        float x = Mathf.Cos(Time.time * speedFly) * width;
        float y = Mathf.Sin(Time.time * speedFly) * height;
        float z = 0f;
        transform.position = new Vector3(x, y, z);

        if(this.transform.position.x < -4)
        {
            Destroy(this.gameObject);
        }
    }

    void DoorClick()
    {
        events.backgroundStop = true;
        events.finding = true;
        if(rule.EdmondIsHuman)
        {
            state = "ED";
        }
        if (!rule.EdmondIsHuman)
        {
            state = "MON";
        }

        Invoke("AnimationEnd", 2f);
    }

    void AnimationEnd()
    {
        events.gamecrear = true;
    }

    void DoorAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "USUALLY":
                    animator.SetBool("isED", false);
                    animator.SetBool("isMON", false);
                    break;
                case "ED":
                    animator.SetBool("isED", true);
                    break;
                case "MON":
                    animator.SetBool("isMON", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
