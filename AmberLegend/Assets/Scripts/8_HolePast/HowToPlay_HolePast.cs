using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay_HolePast : MonoBehaviour {

    public bool gameEvents = false;
    public bool thisIsEndObj = false;
    public GameObject nextObj;
    bool nextBool = true;
    public string sceneName;

    void Update()
    {

        if(gameEvents)
        {
            if (!GameObject.FindGameObjectWithTag("Fade"))
            {
                if(nextBool)
                {
                    Instantiate(nextObj);
                    nextBool = false;
                }
                Destroy(this.gameObject);
            }
        }

        if(!gameEvents)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (!thisIsEndObj)
                {
                    if (nextBool)
                    {
                        Instantiate(nextObj);
                        nextBool = false;
                    }
                    Destroy(this.gameObject);
                }

                if (thisIsEndObj)
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }
}
