using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAudio : MonoBehaviour
{
    public GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        //create object, if exist we dont create an object

        if (GameObject.Find("Audio Cntrl(Clone)") == null)
        {
            Instantiate(music, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }

  
}
