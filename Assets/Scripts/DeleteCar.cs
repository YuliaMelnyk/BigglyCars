using UnityEngine;

public class DeleteCar : MonoBehaviour
{
    public static int countCars; //count Cars that finish the road sucsesfully

    private void Start()
    {
        countCars = 0;
    }
    //when car is touch the block(trigger) we delete it
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!BumpCar.lose)
            {
                countCars++;
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
                
            }
            Destroy(other.gameObject);
        }
    }
}
