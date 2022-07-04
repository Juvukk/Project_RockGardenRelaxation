using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeditationScript : MonoBehaviour
{
    public TextMeshProUGUI changingText;
    public Canvas canvas;

    // Update is called once per frame
    void Start()
    {

        Invoke("Welcome", 10);
        Invoke("StartOne", 20);
        Invoke("StartTwo", 30);
        Invoke("StartThree", 40);
        Invoke("StartFour", 50);
        Invoke("StartFive", 60);

    }


    public void Welcome()
    {
        changingText.text = "Welcome to a Meditation Experience";

    }

    public void StartOne()
    {
        changingText.text = "The rocks before you change";

    }
    public void StartTwo()
    {
        changingText.text = "Breathe in and squeeze the trigger";

    }

    public void StartThree()
    {
        changingText.text = "breathe out and release the trigger";

    }
    public void StartFour()
    {
        changingText.text = "Focus on your breathing";

    }
    public void StartFive()
    {
        changingText.text = "This Ends the Test";

    }
}