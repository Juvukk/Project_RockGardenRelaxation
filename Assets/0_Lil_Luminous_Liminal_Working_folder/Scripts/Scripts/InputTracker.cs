using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTracker : MonoBehaviour
{
    [SerializeField] public bool TriggerPulled;
    [SerializeField] private bool breathingIN = true;
    [SerializeField] private float breathcounter = 0;

    private float buffer = 0.3f;

    private float resetOut;
    [SerializeField] private Text debugtext;

    public float thoughtfullness = 0;
    public float lowerThoughtMulitplier;
    public float raiseThoughtMulitplier;

    [SerializeField] private float triggerReleaseThreshold;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame;
    private void Update()
    {
        timer();
    }

    private void timer()
    {
        breathcounter += Time.deltaTime;
        if (breathingIN && breathcounter <= 7)
        {
            IncreaseThoughtfullness();
        }
        else if (breathingIN && breathcounter > 7)
        {
            breathingIN = false;
        }
        else if (!breathingIN && breathcounter <= 10)
        {
            DecreaseThoughtfullness();
        }

        if (!breathingIN && breathcounter > 10)
        {
            breathcounter = 0;
            breathingIN = true;
        }
    }

    private void GetTriggerInteraction()
    {
        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") > 0 || (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > 0))
        {
            //Debug.Log("Trigger pulled");
            TriggerPulled = true;
        }
        else if (Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") < triggerReleaseThreshold || (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") < triggerReleaseThreshold))
        {
            // Debug.Log("Trigger released L");
            TriggerPulled = false;
        }
    }

    public void DecreaseThoughtfullness()
    {
        if (thoughtfullness > 0)
        {
            thoughtfullness -= lowerThoughtMulitplier * Time.deltaTime;
        }
    }

    public void IncreaseThoughtfullness()
    {
        if (thoughtfullness < 200)
        {
            thoughtfullness += raiseThoughtMulitplier * Time.deltaTime;
        }
        else
        {
        }
    }

    public void DetermineMovementFollowed()
    {
        //buffer -= Time.deltaTime;
        //if (buffer <= 0)
        //{
        if (breathingIN && TriggerPulled)
        {
            IncreaseThoughtfullness();
        }
        else if (!breathingIN && !TriggerPulled)
        {
            DecreaseThoughtfullness();
        }

        buffer = 0.3f;
    }
}