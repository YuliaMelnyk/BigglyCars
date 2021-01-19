using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowTime : MonoBehaviour
{
    private Text countSlow;
    public Sprite active, inactive;

     void Start()
    {
        countSlow = gameObject.transform.GetChild(0).transform.GetComponent<Text>();

        //check if exist SlowTime
        if (!PlayerPrefs.HasKey("Slow time")){
            PlayerPrefs.SetInt("Slow time", 2);
            countSlow.text = "2";
        }
        else
        {
            countSlow.text = PlayerPrefs.GetInt("Slow time").ToString();
        }
        if (PlayerPrefs.GetInt("Slow time") == 0)
        {
            GetComponent<Image>().sprite = inactive;
        }
        else
        {
            GetComponent<Image>().sprite = active;
        }
    }
     void OnMouseDown()
    {
        //play the sound
        if (PlayerPrefs.GetString("Music") != "no")
        {
            GetComponent<AudioSource>().Play();
        }
        //if we touch the slowTime we cant slow more then 0.5f
        if (PlayerPrefs.GetInt("Slow time") > 0 && Time.timeScale != 0.5f)
        {
            //if we touch the button Slow time we need to decrement the value
            PlayerPrefs.SetInt("Slow time", PlayerPrefs.GetInt("Slow time") - 1);
            countSlow.text = PlayerPrefs.GetInt("Slow time").ToString();
            if (PlayerPrefs.GetInt("Slow time") == 0)
            {
                GetComponent<Image>().sprite = inactive;
            }
            StartCoroutine(Slow());
        }

    }

    IEnumerator Slow()
    {
        //set time to 2x slower
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
    }
    //when the sceen Reset
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
