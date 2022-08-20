using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotate : MonoBehaviour
{
    public Camera headset;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + headset.transform.rotation * Vector3.forward, headset.transform.rotation * Vector3.up);
    }
}
