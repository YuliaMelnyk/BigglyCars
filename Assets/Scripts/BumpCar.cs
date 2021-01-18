
using UnityEngine;

[RequireComponent(typeof(MoveCar))]
public class BumpCar : MonoBehaviour
{
    public GameObject explode; //explode animation
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

            // explosion can make only one time
            if (gameObject.transform.position.x < collision.gameObject.transform.position.x)
            {
                //position of explode between two cars
                Vector3 pos = Vector3.Lerp(gameObject.transform.position, collision.transform.position, 0.5f);
                //create our explode
                Instantiate(explode, new Vector3(pos.x, 2.7f, pos.z), Quaternion.identity);
            }
            
        }
    }
}
    
