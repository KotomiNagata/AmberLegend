using UnityEngine;

public class Background_Cave : MonoBehaviour
{
    Rigidbody2D rb;
    GameEvents_Cave events;

    public bool ThisIsBack = false;
    public float speed = 1f;  // 現在のスピード
    float run = 0f;
    bool one = true; // BG_obj(Clone)用

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_Cave>();
    }

    void Update()
    {
        rb.velocity = new Vector2(run * speed, rb.velocity.y);


        if(this.transform.position.x < 0)
        {
            if(ThisIsBack)
            {
                if(one)
                {
                    events.BG_B_Create = true;
                    one = false;
                }
            }
            if (!ThisIsBack)
            {
                if (one)
                {
                    events.BG_F_Create = true;
                    one = false;
                }
            }
        }

        if (this.transform.position.x < -9)
        {
            Destroy(this.gameObject);
        }

        if (GameObject.FindGameObjectWithTag("Pose"))
        {
            run = 0f;
        }
        if(!GameObject.FindGameObjectWithTag("Pose"))
        {
            run = -1f;

            if (events.gate ||
                events.NP ||
                events.gameOver ||
                events.gameCrear2 ||
                events.sneeze)
            {
                run = 0f;
            }
        }

    }
}
