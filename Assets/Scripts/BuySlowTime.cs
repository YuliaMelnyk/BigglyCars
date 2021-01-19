using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuySlowTime : MonoBehaviour
{
    public AudioClip success, fail;
    public Text count, coins; //our coins

    // Start is called before the first frame update
    void Start()
    {
        count.text = PlayerPrefs.GetInt("Slow time").ToString();
    }

     void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetInt("Coins") > 100)
        {
            PlayerPrefs.SetInt("Slow time", PlayerPrefs.GetInt("Slow time") + 1);
            count.text = PlayerPrefs.GetInt("Slow time").ToString();
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 100);
            coins.text = PlayerPrefs.GetInt("Coins").ToString();

            //check if music off we start a play music
            if (PlayerPrefs.GetString("Music") != "no")
            {
                gameObject.transform.GetChild(0).GetComponent<AudioSource>().clip = success;
                gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
            }
            else
            {
                if (PlayerPrefs.GetString("Music") != "no")
                {
                    gameObject.transform.GetChild(0).GetComponent<AudioSource>().clip = fail;
                    gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
                }
            }

        }
    }
}
