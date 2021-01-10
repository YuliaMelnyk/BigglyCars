using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveCar))] //required to switch MoveCar script
[RequireComponent(typeof(CarLights))] //required to switch CarLight script
public class NorthTurnLeft : MonoBehaviour
{
    private Rigidbody rb;
    private float angleSpeed; // speed of angle when the car turn

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //set Left light
        GetComponent<CarLights>().showObject = 1;
    }

    private void FixedUpdate()
    {
        LeftTurn();
    }

    void LeftTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        //check if position for z < 9 then we rotate the car to left
        if (transform.localPosition.z < 9f && carRotation != 270f)
        {
            //if speed so hight we need to stop car to prevent skid
            if (carRotation >= 269f && carRotation <= 274f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 270f, 0));
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
