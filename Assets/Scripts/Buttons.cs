﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{


    public Sprite button, pressed;
    public bool music;

    private Image img;
    private float yPos; // default position of button
    private Transform child;

    // Start is called before the first frame update
     void Start()
    {
        //PlayerPrefs.DeleteAll();
        //change image when user pressed the button
        img = GetComponent<Image>();

        //get first element in button
        child = transform.GetChild(0).transform;

        //work only if this music button
        if (music)
        {
            if(PlayerPrefs.GetString("Music") != "no") //music now is playing, we can off
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                child = transform.GetChild(1).transform;
            }
        }
        
        
    }

    //when user pressed the mouse down image sprite change to imege pressed
     void OnMouseDown()
    {
        //check if music off we start a play music
        if (PlayerPrefs.GetString("Music") != "no")
        {
            GetComponent<AudioSource>().Play();

        }

        img.sprite = pressed;
        yPos = child.localPosition.y;
        //change position of button of Y
        child.localPosition = new Vector3(child.localPosition.x, 0, child.localPosition.z);
    }

    //change back for image button

     void OnMouseUp()
    {
        img.sprite = button;
        //return button on default position
        child.localPosition = new Vector3(child.localPosition.x, yPos, child.localPosition.z);

    }

     void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Play":
                //if we start the game for the first time we need to start with the study scene
                string scene = PlayerPrefs.HasKey("Study") ? "Game" : "Study";
                //change screne
                StartCoroutine(Loadscene(scene));
                break;
            case "Replay":
                //change screne
                StartCoroutine(Loadscene("Game"));
                break;
            case "Home":
                //change screne
                StartCoroutine(Loadscene("Main"));
                break;
            case "How To":
                //change screne
                StartCoroutine(Loadscene("Study"));
                break;
            case "Shop":
                //change screne
                StartCoroutine(Loadscene("Shop"));
                break;
            case "Close":
                //change screne
                StartCoroutine(Loadscene("Main"));
                break;
            case "Music":
                child.gameObject.SetActive(false);
                if (PlayerPrefs.GetString("Music") != "no") //music now is playing, we can off
                {
                    PlayerPrefs.SetString("Music", "no");
                    child = transform.GetChild(1).transform;
                }
                else
                {
                    PlayerPrefs.DeleteKey("Music");
                    child = transform.GetChild(0).transform;

                }
                child.gameObject.SetActive(true);
                break;
        }
    }

    //blackout the screen and load the game scene
    public IEnumerator Loadscene(string scene)
    {
        float time = Camera.main.GetComponent<Transition>().BeginFade(1);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }

}
