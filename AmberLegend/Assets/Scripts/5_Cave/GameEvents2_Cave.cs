using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents2_Cave : MonoBehaviour {

    GameEvents_Cave events;
    Group_Cave group;

    public GameObject batsObj;
    public GameObject mousesObj;

    bool bats = false;
    bool mouses = false;
    bool returnOpening = false;
    bool one = true;

    private AudioSource sound_sneeze;

    void Start () {
        StartCoroutine("Opening");
        events = FindObjectOfType<GameEvents_Cave>();
        group = FindObjectOfType<Group_Cave>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound_sneeze = audioSources[1]; // ２つめの音楽
    }

    void Update()
    {
        if(events.gameCrear2)
        {
            if(one)
            {
                bats = true;
                mouses = true;
                one = false;
            }
        }

        if(bats)
        {
            Instantiate(batsObj);
            bats = false;
        }
        if (mouses)
        {
            Instantiate(mousesObj);
            mouses = false;
        }

        if(returnOpening)
        {
            StartCoroutine("Opening");
            returnOpening = false;
        }
    }

    private IEnumerator Opening()
    {
        yield return new WaitForSeconds(4f);
        mouses = true;
        yield return new WaitForSeconds(6f);
        bats = true;
        yield return new WaitForSeconds(6f);
        bats = true;
        yield return new WaitForSeconds(6f);
        mouses = false;
        yield return new WaitForSeconds(5f);
        mouses = true;
        bats = true;
        yield return new WaitForSeconds(5f);
        mouses = true;
        yield return new WaitForSeconds(4f);
        bats = true;
        yield return new WaitForSeconds(6f);
        group.sneezeOK = true;
        sound_sneeze.PlayOneShot(sound_sneeze.clip);

        yield return new WaitForSeconds(1.5f);
        if (group.sneezeEND)
        {
            events.sneeze = true;
        }
        yield return new WaitForSeconds(4f);
        returnOpening = true;
    }

}
