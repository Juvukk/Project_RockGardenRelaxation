using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatRock : MonoBehaviour
{
    [SerializeField] private InputTracker getValue;

    // 2 = 100
    public float floatHieght = 0;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        floatHieght = 1 + (getValue.thoughtfullness / 100);

        transform.position = new Vector3(transform.position.x, floatHieght, transform.position.z);
    }
}