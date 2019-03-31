using UnityEngine;

public class GamePoseButton : MonoBehaviour {

    public GameObject posePicture;
    public GameObject button;
    bool one = true;

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Pose") == false)
        {
            one = true;
        }
    }

    public void Pose()
    {
        if(one)
        {
            Instantiate(posePicture);
            Instantiate(button);
            one = false;
        }
    }

}
