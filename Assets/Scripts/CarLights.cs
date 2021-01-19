using UnityEngine;
using System.Collections;

public class CarLights : MonoBehaviour
{
    
    public int showObject; //value for right or left light
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenLight());
        if (PlayerPrefs.GetString("Music") != "no")
        {
            StartCoroutine(sound());
        }
    }

    IEnumerator OpenLight()
    {
        yield return new WaitForSeconds(0.2f);
        //set active a light
        GameObject light = gameObject.transform.GetChild(showObject).gameObject;

        //blink the light
        while (true)
        {
            light.SetActive(!light.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }
    }
    //we play sound 2 sec and then we destoy it
    IEnumerator sound()
    {
        GameObject s = Instantiate(GetComponent<MoveCar>().turnSignal, new Vector3(0,0,0), Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(2f);
        Destroy(s.gameObject);
    }
}
