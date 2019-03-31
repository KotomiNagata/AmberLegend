using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Cave : MonoBehaviour {

    Rigidbody2D rb;
    GameEvents_Cave events;
    Octavian_Cave octavian;
    //BGMDoor_Cave bgm;

    float run = 0f;
    public float speed = 0.1f;         // 移動スピード
    public bool ThisIsDoorAnima = false;
    public GameObject gameCrearDoorObi;
    int a = 1;

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        events = FindObjectOfType<GameEvents_Cave>();
        //bgm = FindObjectOfType<BGMDoor_Cave>();
        run = -1f;

        if (ThisIsDoorAnima)
        {
            StartCoroutine("Opening");
        }
    }
	

	void Update () {
        if(!ThisIsDoorAnima)
        {
            rb.velocity = new Vector2(run * speed, rb.velocity.y);
        }

        if (GameObject.FindGameObjectWithTag("Pose"))
        {
            run = 0f;
        }else
        {
            run = -1f;

            if(events.gate ||
               events.NP ||
               events.gameOver ||
                events.sneeze)
            {
                run = 0f;
            }
        }

        if(this.transform.position.x < -6)
        {
            events.doorCreate = true;
            events.DoorMath(a);
            Destroy(this.gameObject);
        }

        if(events.gameCrear)
        {
            octavian = FindObjectOfType<Octavian_Cave>();
            if(octavian.transform.position.x > this.transform.position.x)
            {
                //bgm.soundON = true;
                events.gameCrear2 = true;
                run = 0;
                Instantiate(gameCrearDoorObi, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator Opening()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

}
