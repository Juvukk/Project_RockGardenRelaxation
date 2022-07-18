using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRotation : MonoBehaviour
{
    [SerializeField] private Vector3 TargetRot;
    private float step;
    [SerializeField] private float speed;
    [SerializeField] private float RandomZ;

    [SerializeField] private float timer;
    private float resetTimer;

    // Start is called before the first frame update
    private void Start()
    {
        TargetRot = transform.position - GetRandomRotation();
    }

    // Update is called once per frame
    private void Update()
    {
        step = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, TargetRot, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private Vector3 GetRandomRotation()
    {
        float x = Random.Range(-180.0f, 180.0f);
        float y = Random.Range(-180.0f, 180.0f);
        float z = Random.Range(-180.0f, 180.0f);

        return new Vector3(x, y, z);
    }
}