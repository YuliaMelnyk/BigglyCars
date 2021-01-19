using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuySlowTime : MonoBehaviour
{
    public Text count, coins; //our coins

    // Start is called before the first frame update
    void Start()
    {
        count.text = PlayerPrefs.GetInt("Slow time").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetInt("Coins") > 1)
        {
            PlayerPrefs.SetInt("Slow time", PlayerPrefs.GetInt("Slow time") + 1);
            count.text = PlayerPrefs.GetInt("Slow time").ToString();
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1);
            coins.text = PlayerPrefs.GetInt("Coins").ToString();

        }
    }
}
