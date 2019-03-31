using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay_Allo : MonoBehaviour {

    public bool events = true;
    public GameObject obj;
    public string nextScene;

    bool objBool = true;
	
	void Update () {

        if(events)
        {
            if (!GameObject.FindGameObjectWithTag("Fade"))
            {
                if (objBool)
                {
                    Instantiate(obj);
                    objBool = false;
                }
            }
        }

        if(!events)
        {
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
