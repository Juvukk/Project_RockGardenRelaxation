using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeditationScript : MonoBehaviour
{
    public Text changingText;
    public int timeBetween = 3;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MeditationText()
    {
        changingText.text = "Welcome to a Meditation Experience";
        int WaitForSeconds = timeBetween;
        changingText.text = "This is a Guided Experience";
    }





}
