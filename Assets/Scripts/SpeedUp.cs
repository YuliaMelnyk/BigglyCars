using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveCar))]
public class SpeedUp : MonoBehaviour
{
    private bool accelerate = false; //check if we accelerate car o not

    private void OnMouseDown()
    {
        if (!accelerate)
        {
            GetComponent<MoveCar>().speed *= 2f;
            accelerate = true;
        }
    }
}
