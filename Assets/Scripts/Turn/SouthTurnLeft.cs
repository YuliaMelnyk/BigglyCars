using System.Collections;
using UnityEngine;


[RequireComponent(typeof(MoveCar))] //required to switch MoveCar script
[RequireComponent(typeof(CarLights))] //required to switch CarLight script
public class SouthTurnLeft : MonoBehaviour
{
    private Rigidbody rb;
    private float angleSpeed; // speed of angle when the car turn

     void Start()
    {
        rb = GetComponent<Rigidbody>();
        //set Left light
        GetComponent<CarLights>().showObject = 1;

    }

     void FixedUpdate()
    {
        LeftTurn();
    }

    void LeftTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        //check if position for z > 3.9 then we rotate the car to left
        if (transform.localPosition.z > 3.9f && carRotation != 90f)
        {
            //if speed so hight we need to stop car to prevent skid
            if (carRotation >= 89f && carRotation <= 94f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 90f, 0));
                return;
            }
            //set speed turn for the car
            angleSpeed = GetComponent<MoveCar>().speed * -8.57f;
            //set vector of rotation for car
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, angleSpeed, 0) * Time.fixedDeltaTime);
            //move with turn
            rb.MoveRotation(rb.rotation * deltaRotation);

        }
    }
}
