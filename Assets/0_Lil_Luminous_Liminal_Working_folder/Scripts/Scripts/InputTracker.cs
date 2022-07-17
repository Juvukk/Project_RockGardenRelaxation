using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTracker : MonoBehaviour
{
    [SerializeField] public bool TriggerPulled;
    [SerializeField] private bool breathingIN = true;
    [SerializeField] private float inBreathcounter = 3;
    [SerializeField] private float outBreathcounter = 7;
    private float buffer = 0.3f;
    private float resetIN;
    private float resetOut;
    [SerializeField] private Text debugtext;

    public float thoughtfullness = 0;
    public float lowerThoughtMulitplier;
    public float raiseThoughtMulitplier;

    [SerializeField] private float triggerReleaseThreshold;

    // Start is called before the first frame update
    private void Start()
    {
        resetIN = inBreathcounter;
        resetOut = outBreathcounter;
    }

    // Update is called once per frame;
    private void Update()
    {
        timer();
        //   GetTriggerInteraction();
        DetermineMovementFollowed();
    }

    private void timer()
    {
        if (breathingIN)
        {
            Debug.Log("pull trigger in");
            inBreathcounter -= Time.deltaTime;
            IncreaseThoughtfullness();
        }
        if (inBreathcounter <= 0)
        {
            breathingIN = false;
            inBreathcounter = resetIN;
        }

        if (!breathingIN)
        {
            Debug.Log("release trigger ");
            outBreathcounter -= Time.deltaTime;
            DecreaseThoughtfullness();
        }
        if (outBreathcounter <= 0)
        {
            breathingIN = true;
            outBreathcounter = resetOut;
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
        if (thoughtfullness < 100)
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