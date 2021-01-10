
using UnityEngine;

[RequireComponent(typeof(MoveCar))]
public class BumpCar : MonoBehaviour
{
    public static bool lose = false; //if we lose or not
    private bool onceStop;

    private void OnCollisionEnter(Collision collision)
    {
        //if our object is car and collision at first time
        if(collision.gameObject.tag == "Player" && !onceStop)
        {
            lose = true;
            onceStop = true;
            gameObject.GetComponent<MoveCar>().speed = 0f; //stop the car
            collision.gameObject.GetComponent<MoveCar>().speed = 0f;//stop the other car
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * -1000); //add a hit 
        }
    }
}
    
