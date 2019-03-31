using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResumptionButton : MonoBehaviour {

    public void PlayStart()
    {
        var poseON = GameObject.FindGameObjectWithTag("Pose");
        var poseON2 = GameObject.FindGameObjectWithTag("Pose2");
        Destroy(poseON);
        Destroy(poseON2);
        Destroy(this.gameObject);
    }
}
