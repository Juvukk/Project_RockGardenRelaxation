using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRotation : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float targetX;
    [SerializeField] private float targetY = 10f;
    [SerializeField] private float targetZ;
    [SerializeField] private float minHieght = 1;

    // Start is called before the first frame update
    private void Start()
    {
        targetX = Random.Range(1, 10);

        targetZ = Random.Range(1, 10);
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y > minHieght)
        {
            transform.Rotate(Time.deltaTime * speed * targetX, Time.deltaTime * speed * targetY, Time.deltaTime * speed * targetZ);
        }
    }
}