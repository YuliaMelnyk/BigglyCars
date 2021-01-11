using UnityEngine;
using System.Collections;

public class CarLights : MonoBehaviour
{
    public int showObject; //value for right or left light
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenLight());
       
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
}
