using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveCar))] //required to switch MoveCar script
[RequireComponent(typeof(CarLights))] //required to switch CarLight script

public class SouthTurnRight : MonoBehaviour
{
    private Rigidbody rb;
    private float angleSpeed; // speed of angle when the car turn

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //set Right light
        GetComponent<CarLights>().showObject = 0;

    }

    private void FixedUpdate()
    {
        RightTurn();
    }

    void RightTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        //check if position for z > -5.5 then we rotate the car to right
        if (transform.localPosition.z > -3.64f && carRotation != 270f)
        {
            //if speed so hight we need to stop car to prevent skid
            if (carRotation >= 269f && carRotation <= 274f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 270f, 0));
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
