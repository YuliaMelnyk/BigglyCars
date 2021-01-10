using UnityEngine;

public class DeleteCar : MonoBehaviour
{
    //when car is touch the block(trigger) we delete it
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
