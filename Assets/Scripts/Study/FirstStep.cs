using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MoveCar))]
public class FirstStep : MonoBehaviour
{
    public GameObject secondCar, exhaust; //default second car is inactive
    public Text study;
    private bool firstStep;

    // Start is called before the first frame update
    void Start()
    {
        //the first start the scene the car will not move
        GetComponent<MoveCar>().speed = 0f;
        //let move car in 1 second
        Invoke("MoveCar", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //we will stop the car before the turn
        if(transform.position.x<15f && !firstStep)
        {
            firstStep = true;
            GetComponent<MoveCar>().speed = 2f;
            study.text = "Tap the car to accelerate it";
        }
    }
    void MoveCar()
    {
        GetComponent<MoveCar>().speed = 12f;
    }

     void OnMouseDown()
    {
        if (firstStep)
        {
            GetComponent<MoveCar>().speed = 30f;
            study.text = "";

            GameObject ex = Instantiate(exhaust,
                new Vector3(gameObject.transform.position.x, 0.2f, gameObject.transform.position.z),
                Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
            Destroy(ex, 1f);
        }
    }
    //we need to make active the second car
     void OnDisable()
    {
        secondCar.SetActive(true);
    }
}
