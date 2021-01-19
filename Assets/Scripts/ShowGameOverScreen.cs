
using UnityEngine;

public class ShowGameOverScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver, slowTime;
    private bool addOnce; //to open once time in our game

     void Start()
    {
        slowTime.SetActive(true);
    }
    void Update()
    {
        if(BumpCar.lose && !addOnce)
        {
            addOnce = true;
            slowTime.SetActive(false);
            gameOver.SetActive(true);
        }
    }

}
