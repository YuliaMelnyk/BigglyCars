using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceCars : MonoBehaviour
{
    [SerializeField]
    private bool mainScene;
    public GameObject[] cars;
    private float startProduce = 0.5f; //speed whitch apearse the car
    private float waitProduce;
    private int countCars = 0; // to delete cars

    private bool onceStop; //to finish a game

    

     void Start()
    {
        StartCoroutine(westCars());
        StartCoroutine(eastCars());
        StartCoroutine(northCars());
        StartCoroutine(southCars());

        //time to produce new car
        waitProduce = mainScene ? 7f : 3f;

        BumpCar.lose = false; //when we start or restart a game all values set by default

    }

     void Update()
    {
        if (!mainScene)
        {
            //when we have more cars, we produce cars not so frequenly
            if (countCars > 40)
            {
                waitProduce = 1f;
            }
            else if (countCars > 30)
            {
                waitProduce = 1.5f;
            }
            else if (countCars > 20)
            {
                waitProduce = 2f;
            }
        }
       
        //if we lose we don't need to generate cars
        if (BumpCar.lose && !onceStop)
        {
            StopAllCoroutines();
            onceStop = true;
        }
    }

    //west car
    IEnumerator westCars()
    {
        //waiting to generate a car from 0 to 5 sec
        yield return new WaitForSeconds(Random.Range(startProduce, startProduce + 4.5f));
        //generate cars infinity
        while (true)
        {
            //get random car whith the position in the west
            GameObject carInstance = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-80f, 0, 2.1f),
                Quaternion.Euler(new Vector3(0,-90f,0))) as GameObject;
            countCars++;
            //random option for turn or left or right (if this a mainScene - we turn to right)
            int rand = mainScene ? 2: Random.Range(0,4);
            switch (rand)
            {
                case 1:
                    carInstance.AddComponent<WestTurnLeft>();
                    break;
                case 2:
                    carInstance.AddComponent<WestTurnRight>();
                    break;
            }
            //speed to generate new car from 7 to 12 sec
            yield return new WaitForSeconds(Random.Range(waitProduce, waitProduce + 5f));
        }

    }

    //east car
    IEnumerator eastCars()
    {
        //waiting to generate a car from 0 to 5 sec
        yield return new WaitForSeconds(Random.Range(startProduce, startProduce + 4.5f));
        //generate cars infinity
        while (true)
        {
            //get random car whith the position in the east
            GameObject carInstance = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(27f, 0, 10.5f),
                Quaternion.Euler(new Vector3(0, 90f, 0))) as GameObject;
            countCars++;
            //random option for turn or left or right (if this a mainScene - we turn to right)
            int rand = mainScene ? 2 : Random.Range(0, 4);
            switch (rand)
            {
                case 1:
                    carInstance.AddComponent<EastTurnLeft>();
                    break;
                case 2:
                    carInstance.AddComponent<EastTurnRight>();
                    break;
            }
            //speed to generate new car from 7 to 12 sec
            yield return new WaitForSeconds(Random.Range(waitProduce, waitProduce + 5f));
        }

    }
    //north car
    IEnumerator northCars()
    {
        //waiting to generate a car from 0 to 5 sec
        yield return new WaitForSeconds(Random.Range(startProduce, startProduce + 4.5f));
        //generate cars infinity
        while (true)
        {
            //get random car whith the position in the east
            GameObject carInstance = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-6.9f, 0, 70f),
                Quaternion.Euler(new Vector3(0, 0f, 0))) as GameObject;
            countCars++;
            //random option for turn or left or right (if this a mainScene - we turn to right)
            int rand = mainScene ? 2 : Random.Range(0, 4);
            switch (rand)
            {
                case 1:
                    carInstance.AddComponent<NorthTurnLeft>();
                    break;
                case 2:
                    carInstance.AddComponent<NorthTurnRight>();
                    break;
            }
            //speed to generate new car from 7 to 12 sec
            yield return new WaitForSeconds(Random.Range(waitProduce, waitProduce + 5f));
        }
    }

    //south car
    IEnumerator southCars()
    {
        //waiting to generate a car from 0 to 5 sec
        yield return new WaitForSeconds(Random.Range(startProduce, startProduce + 4.5f));
        //generate cars infinity
        while (true)
        {
            //get random car whith the position in the east
            GameObject carInstance = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-0.3f, 0, -30f),
                Quaternion.Euler(new Vector3(0, 180f, 0))) as GameObject;
            countCars++;
            //random option for turn or left or right (if this a mainScene - we turn to right)
            int rand = mainScene ? 2 : Random.Range(0, 4);
            switch (rand)
            {
                case 1:
                    carInstance.AddComponent<SouthTurnLeft>();
                    break;
                case 2:
                    carInstance.AddComponent<SouthTurnRight>();
                    break;
            }
            //speed to generate new car from 7 to 12 sec
            yield return new WaitForSeconds(Random.Range(waitProduce, waitProduce + 5f));
        }
    }
}
