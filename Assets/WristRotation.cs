using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristRotation : MonoBehaviour
{
    public Transform hand;
    public int frames = 10;

    private Vector3 rotationLast; //The value of the rotation at the previous update
    private Vector3 rotationDelta; //The difference in rotation between now and the previous update

    private Vector3 avgAngularVelocity;

    public Vector3 handRotation;
    public Vector3 angularVelocity;

    private int counter; // count frames

    private void Start()
    {
        rotationLast = hand.rotation.eulerAngles;

        counter = 0;
        avgAngularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        rotationDelta = hand.rotation.eulerAngles - rotationLast;
        rotationLast = hand.rotation.eulerAngles;

        avgAngularVelocity += AngularVelocity;

        counter++;
        if (counter == frames)
        {
            handRotation = hand.rotation.eulerAngles;
            angularVelocity = avgAngularVelocity / (float)frames;

            counter = 0;
            avgAngularVelocity = Vector3.zero;
        }
    }

    public Vector3 AngularVelocity
    {
        get
        {
            return rotationDelta;
        }
    }
}
}