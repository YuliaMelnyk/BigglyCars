using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewLocation : MonoBehaviour
{
    public GameObject checkedButton;
    public Sprite unchekedButton, checkedButtonSprite;
    public GameObject[] notCurrentLocationButtons;
    public GameObject[] buttonsToDisable; //to disable buttons
    public Text coins;
    [SerializeField]
    private int price;
    [SerializeField]
    private string nameOfLocation;

    void Awake()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins"));
        //check if location is open
        if (PlayerPrefs.GetString(nameOfLocation) == "Open")
        {
            for (int i = 0; i < buttonsToDisable.Length; i++)
            {
                buttonsToDisable[i].SetActive(false);
                checkedButton.SetActive(true);
            }
        }
    }
    void OnMouseUpAsButton()
    {
        // check if we have anouth coins to buy a location

        if (PlayerPrefs.GetInt("Coins") >= price)
        {
            PlayerPrefs.SetString("Location", nameOfLocation);
            PlayerPrefs.SetString(nameOfLocation, "Open");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - price);
            coins.text = PlayerPrefs.GetInt("Coins").ToString();

            for (int i = 0; i < buttonsToDisable.Length; i++)
            {
                buttonsToDisable[i].SetActive(false);
            }

            for (int i = 0; i < notCurrentLocationButtons.Length; i++)
            {
                notCurrentLocationButtons[i].GetComponent<Image>().sprite = unchekedButton;
                checkedButton.SetActive(true);
                checkedButton.transform.GetChild(0).GetComponent<Image>().sprite = checkedButtonSprite;
            }
        }
    }
}
