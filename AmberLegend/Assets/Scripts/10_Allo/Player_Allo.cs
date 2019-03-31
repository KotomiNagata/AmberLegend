using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オクタヴィアンとエドモン(モンモン)のScript
public class Player_Allo : MonoBehaviour {

    GameEvents_Allo events;

    public int PosNumber; // 1,2,3のどれか
    public GameObject moveRightObj;
    public GameObject moveLeftObj;
    public GameObject dieObj1;
    public GameObject dieObj2;
    bool one = true;

    void Start () {
        events = FindObjectOfType<GameEvents_Allo>();
        events.moveOK = true;
    }
	
	void Update () {

        Vector3 scale = this.gameObject.transform.localScale;

        if (PosNumber == 1)
        {
            if (events.posNumber == 2)
            {
                if (one)
                {
                    Instantiate(moveRightObj, this.transform.position, Quaternion.identity);
                    one = false;
                }
                Destroy(this.gameObject);
            }
        }

        if (PosNumber == 2)
        {
            if (events.posNumber == 1)
            {
                if (one)
                {
                    Instantiate(moveLeftObj, this.transform.position, Quaternion.identity);
                    one = false;
                }
                Destroy(this.gameObject);
            }
            if (events.posNumber == 3)
            {
                if (one)
                {
                    Instantiate(moveRightObj, this.transform.position, Quaternion.identity);
                    one = false;
                }
                Destroy(this.gameObject);
            }
        }

        if (PosNumber == 3)
        {
            if (events.posNumber == 2)
            {
                if (one)
                {
                    Instantiate(moveLeftObj, this.transform.position, Quaternion.identity);
                    one = false;
                }
                Destroy(this.gameObject);
            }
        }

        if(events.gameCrearObj)
        {
            // 拡大する
            gameObject.transform.localScale = new Vector3(
                scale.x + 0.05f,
                scale.y + 0.05f,
                scale.z
            );
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            events.gameOver = true;
            if(!events.AlloBig)
            {
                Instantiate(dieObj1, this.transform.position, Quaternion.identity);
            }
            if (events.AlloBig)
            {
                Instantiate(dieObj2, this.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }

}
