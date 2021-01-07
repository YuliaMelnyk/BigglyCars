﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveCar))] //required to switch MoveCar script
public class SouthTurnRight : MonoBehaviour
{
    private Rigidbody rb;
    private float angleSpeed; // speed of angle when the car turn

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        RightTurn();
    }

    void RightTurn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        //check if position for z > -5.5 then we rotate the car to right
        if (transform.localPosition.z > -5.5f && carRotation != 90f)
        {
            //if speed so hight we need to stop car to prevent skid
            if (carRotation >= 89f && carRotation <= 94f)
            {

                transform.localRotation = Quaternion.Euler(new Vector3(0, 90f, 0));
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
