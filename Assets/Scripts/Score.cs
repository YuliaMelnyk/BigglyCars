using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text topRecord;

    private void OnEnable()
    {
        GetComponent<Text>().text = "Score: " + DeleteCar.countCars.ToString();
        //PlayerPrefs.SetInt("CarsPassed", PlayerPrefs.GetInt("CarsPassed") + DeleteCar.countCars);
        //if we do record we need to save it
        if (PlayerPrefs.GetInt("Score") < DeleteCar.countCars)
        {
            PlayerPrefs.SetInt("Score", DeleteCar.countCars);
            topRecord.text = "Record: "+ DeleteCar.countCars.ToString();
        }
        else
        {
            topRecord.text = "Record: " + PlayerPrefs.GetInt("Score").ToString();

        }
    }
}
