using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondStep : MonoBehaviour
{
    public Text study;
    // Start is called before the first frame update
    void Start()
    {
        study.text = "Watch where the car turns";
    }

   
    //in finish we change a scene
    void OnDisable()
    {
        //Set key if we finished a study, to not study more
        PlayerPrefs.SetString("Study", "Done");
        SceneManager.LoadScene("Game");
    }
}
