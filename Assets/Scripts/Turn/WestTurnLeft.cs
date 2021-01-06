using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveCar))] //required to switch MoveCar script
public class WestTurnLeft : MonoBehaviour
{
    private Rigidbody rb;
    private float angleSpeed; // speed of angle when the car turn

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        LeftTurn();
    }

    void LeftTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        //check if position for x > -7 then we rotate the car to left
        if (transform.localPosition.x > -7f && carRotation != 0f)
        {
            //if speed so hight we need to stop car to prevent skid
            if(carRotation >= -20f && carRotation <= 20f)
            {
         
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0f, 0));
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
