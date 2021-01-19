using System.Collections;
using UnityEngine;

public class Transition : MonoBehaviour
{

    public Texture2D texture2D; //image fading

    private float speed = 0.8f; //speed of transition
    private int drawDepth = -1000;
    private float alpfa = 1.0f;
    private int direction = -1; //from black our screen fading

     void OnGUI()
    {
        //change alpfa
        alpfa += direction * speed * Time.deltaTime;
        alpfa = Mathf.Clamp01(alpfa);

        //set color to our Screen
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpfa);
        GUI.depth = drawDepth;

        //fill in all Screen
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture2D);

    }

    public float BeginFade (int dir)
    {
        direction = dir;
        return speed;
    }

    //when run our script change our screen from black to transparent
     void OnEnable()
    {
        BeginFade(-1);
    }

}
