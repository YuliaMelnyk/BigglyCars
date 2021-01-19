using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //car always need to have RigitBody, if we forget to put, then aut.
//switch this element
public class MoveCar : MonoBehaviour
{
    public GameObject turnSignal;
    private Rigidbody rb;
    public float speed = 12f; //speed of car

     void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
     void FixedUpdate()
    {
        //move position forward of car
        rb.MovePosition(transform.position -transform.forward * speed * Time.fixedDeltaTime);
    }
}
