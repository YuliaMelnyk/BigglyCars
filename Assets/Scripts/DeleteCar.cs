using UnityEngine;

public class DeleteCar : MonoBehaviour
{
    public static int countCars; //count Cars that finish the road sucsesfully

     void Start()
    {
        countCars = 0;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins"));
    }
    //when car is touch the block(trigger) we delete it
     void OnTriggerEnter(Collider other)
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
