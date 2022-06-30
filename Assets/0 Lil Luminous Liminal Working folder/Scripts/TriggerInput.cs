using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class TriggerInput : MonoBehaviour
{
    [SerializeField] private float triggerReleaseThreshold;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") > 0) // left hand
        {
            Debug.Log("Trigger pulled L");
        }
        else if (Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") < triggerReleaseThreshold)
        {
            Debug.Log("Trigger released L");
        }

        if (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > 0) // right hand
        {
            Debug.Log("Trigger pulled R");
        }
        else if (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") < triggerReleaseThreshold)
        {
            Debug.Log("Trigger released R");
        }
    }
}