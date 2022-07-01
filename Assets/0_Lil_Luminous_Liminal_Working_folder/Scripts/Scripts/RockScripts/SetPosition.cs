using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    [SerializeField] private Transform getPositionFrom;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 followHandPos = new Vector3(getPositionFrom.transform.position.x + offsetX, getPositionFrom.transform.position.y + offsetY, getPositionFrom.transform.position.z + offsetZ);
        transform.position = followHandPos;
    }
}