using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveCar))] //required to switch MoveCar script
[RequireComponent(typeof(CarLights))] //required to switch CarLight script

public class EastTurnRight : MonoBehaviour
{
    private Rigidbody rb;
    private float angleSpeed; // speed of angle when the car turn

     void Start()
    {
        rb = GetComponent<Rigidbody>();
        //set Right light
        GetComponent<CarLights>().showObject = 0;

    }

     void FixedUpdate()
    {
        RightTurn();
    }

    void RightTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        //check if position for x < 6 then we rotate the car to right
        if (transform.localPosition.x < 6f && carRotation != 180f)
        {
            //if speed so hight we need to stop car to prevent skid
            if (carRotation >= 180f && carRotation <= 184f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 180f, 0));
                return;
            }
            //set speed turn for the car
            angleSpeed = GetComponent<MoveCar>().speed * 8.57f;
            //set vector of rotation for car
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, angleSpeed, 0) * Time.fixedDeltaTime);
            //move with turn
            rb.MoveRotation(rb.rotation * deltaRotation);

        }
    }
}
