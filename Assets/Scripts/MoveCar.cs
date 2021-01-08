using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //car always need to have RigitBody, if we forget to put, then aut.
//switch this element
public class MoveCar : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 9f; //speed of car

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //move position forward of car
        rb.MovePosition(transform.position -transform.forward * speed * Time.fixedDeltaTime);
    }
}
