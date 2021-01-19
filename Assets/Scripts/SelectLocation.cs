using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLocation : MonoBehaviour
{
    public GameObject[] notCurrentLocationButtons;
    public Sprite thisOne, otherOne;
    [SerializeField]
    private string nameOfLocation;

    // Start is called before the first frame update
    void Start()
    {
        //for defaul location
        if (PlayerPrefs.HasKey("Location"))
        {
            PlayerPrefs.SetString("Location", "Malaga");
        }
        //if this location is our
        if(PlayerPrefs.GetString("Location") == nameOfLocation)
        {
            gameObject.transform.GetChild(0).transform.GetComponent<Image>().sprite = thisOne;
        }
        else
        {
            gameObject.transform.GetChild(0).transform.GetComponent<Image>().sprite = otherOne;
        }
    }
    //to change the location
     void OnMouseUpAsButton()
    {
        PlayerPrefs.SetString("Location", nameOfLocation);
        for (int i = 0; i < notCurrentLocationButtons.Length; i++)
        {
            notCurrentLocationButtons[i].GetComponent<Image>().sprite = otherOne;
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = thisOne;
        }
    }

}
