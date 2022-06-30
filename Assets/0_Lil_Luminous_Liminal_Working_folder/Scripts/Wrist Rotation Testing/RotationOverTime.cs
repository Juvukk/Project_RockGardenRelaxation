using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOverTime : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), speed * Time.deltaTime);
    }
}