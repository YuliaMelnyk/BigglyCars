using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingSound : MonoBehaviour
{
    public AudioClip[] audioclips;
    // Start is called before the first frame update
    void Start()
    {
        //if sound is off then we play it
        if (PlayerPrefs.GetString("Music") != "no")
        {
            GetComponent<AudioSource>().clip = audioclips[Random.Range(0, audioclips.Length)];
            GetComponent<AudioSource>().Play();
        }
    }

}
