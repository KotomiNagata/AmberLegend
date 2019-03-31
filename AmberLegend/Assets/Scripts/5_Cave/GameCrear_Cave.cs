using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCrear_Cave : MonoBehaviour {

    FadeIn fadeIn;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public GameObject door6;
    public GameObject fadeInObj;
    public string nextScene;

    bool one = false;

    void Start () {
        StartCoroutine("Opening");
    }
	
	void Update () {
		if(one)
        {
            Instantiate(fadeInObj);
            fadeIn = FindObjectOfType<FadeIn>();
            fadeIn.sceneName = nextScene;
            one = false;
        }
	}

    private IEnumerator Opening()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(door1, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(door2, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(door3, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(door4, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(door5, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(door6, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        one = true;
    }
}
