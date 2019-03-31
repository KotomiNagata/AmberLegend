using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Allo : MonoBehaviour {

    GameRule rule;
    RunStart_Allo player;

    public GameObject edObj;
    public GameObject monObj;
    public GameObject serifObj;
    public string nextScene;
    public int point = 0;     // セリフと動きを合わせるため

    bool serifBool = true;
    bool serifMade = false;

    void Start () {
        rule = FindObjectOfType<GameRule>();

        if (rule.EdmondIsHuman)
        {
            Instantiate(edObj, this.transform.position, Quaternion.identity);
        }
        if (!rule.EdmondIsHuman)
        {
            Instantiate(monObj, this.transform.position, Quaternion.identity);
        }

        player = FindObjectOfType<RunStart_Allo>();
        player.gameover = true;
    }
	
	void Update () {

        if (!GameObject.FindGameObjectWithTag("Fade"))
        {
            if (serifBool)
            {
                Instantiate(serifObj);
                serifMade = true;
                serifBool = false;
            }
        }

        if (!GameObject.FindGameObjectWithTag("Text") && serifMade)
        {
            SceneManager.LoadScene(nextScene);
        }

    }
}
