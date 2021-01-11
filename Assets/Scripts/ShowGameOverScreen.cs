
using UnityEngine;

public class ShowGameOverScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;
    private bool addOnce; //to open once time in our game

    private void Update()
    {
        if(BumpCar.lose && !addOnce)
        {
            addOnce = true;
            gameObject.SetActive(true);
        }
    }

}
