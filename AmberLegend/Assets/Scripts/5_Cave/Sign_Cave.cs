using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign_Cave : MonoBehaviour {

    GameEvents_Cave events;
    Heart_Cave heart;

    int a = 2;

	void Start () {
        events = FindObjectOfType<GameEvents_Cave>();
        heart = FindObjectOfType<Heart_Cave>();
        StartCoroutine("Timer");
    }
	
	void Update () {

        if(!GameObject.FindGameObjectWithTag("Enemy") || events.gate)
        {
            Destroy(this.gameObject);
        }
	}

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        heart.Damage(a);
        yield return new WaitForSeconds(1f);
        heart.Damage(a);
        yield return new WaitForSeconds(1f);
        heart.Damage(a);
        yield return new WaitForSeconds(1f);
        heart.Damage(a);
        yield return new WaitForSeconds(1f);
        heart.Damage(a);
        yield return new WaitForSeconds(1f);
        heart.Damage(a);
        yield return new WaitForSeconds(1f);
        heart.Damage(a);
        yield return new WaitForSeconds(1f);
        heart.Damage(a);
    }
}
