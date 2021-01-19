using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if sound is off then we play it
        if (PlayerPrefs.GetString("Music") != "no")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
