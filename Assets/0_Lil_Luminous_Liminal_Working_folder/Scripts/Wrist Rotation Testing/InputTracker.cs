using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTracker : MonoBehaviour
{
    [SerializeField] private bool TriggerPulled;
    [SerializeField] private bool breathingIN = true;
    [SerializeField] private float inBreathcounter = 3;
    [SerializeField] private float outBreathcounter = 7;
    private float resetIN;
    private float resetOut;
    [SerializeField] private Text debugtext;

    public float thoughtfullness = 0;
    public float thoughtfullnessChange;

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
        GetTriggerInteraction();
        DetermineMovementFollowed();
    }

    private void timer()
    {
        if (breathingIN)
        {
            debugtext.text = "pull trigger in";
            inBreathcounter -= Time.deltaTime;
        }
        if (inBreathcounter <= 0)
        {
            breathingIN = false;
            inBreathcounter = resetIN;
        }

        if (!breathingIN)
        {
            debugtext.text = "release Trigger";
            outBreathcounter -= Time.deltaTime;
        }
        if (outBreathcounter <= 0)
        {
            breathingIN = true;
            outBreathcounter = resetOut;
        }
    }

    private void GetTriggerInteraction()
    {
        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") > 0) // left hand
        {
            Debug.Log("Trigger pulled L");
            TriggerPulled = true;
        }
        else if (Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") < triggerReleaseThreshold)
        {
            Debug.Log("Trigger released L");
            TriggerPulled = false;
        }

        if (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > 0) // right hand
        {
            Debug.Log("Trigger pulled R");
            TriggerPulled = true;
        }
        else if (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") < triggerReleaseThreshold)
        {
            Debug.Log("Trigger released R");
            TriggerPulled = false;
        }
    }

    public void DecreaseThoughtfullness()
    {
        if (thoughtfullness > 0)
        {
            thoughtfullness -= thoughtfullnessChange * Time.deltaTime;
        }
    }

    public void IncreaseThoughtfullness()
    {
        if (thoughtfullness < 100)
        {
            thoughtfullness += thoughtfullnessChange * Time.deltaTime;
        }
    }

    public void DetermineMovementFollowed()
    {
        if (breathingIN && TriggerPulled)
        {
            IncreaseThoughtfullness();
        }
        else if (!breathingIN && !TriggerPulled)
        {
            IncreaseThoughtfullness();
        }
        else
        {
            DecreaseThoughtfullness();
        }
    }
}