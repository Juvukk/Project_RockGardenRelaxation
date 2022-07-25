using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatRock : MonoBehaviour
{
    private Vector3 startPos;

    [SerializeField] private float frequency;
    [SerializeField] private float amplitutude;
    [SerializeField] private float inCounter = 7;
    [SerializeField] private float outCounter = 10;
    [SerializeField] private bool breathingIN = true;
    [SerializeField] private float breathcounter = 0;

    [SerializeField] private float maxThought;
    [SerializeField] private float minThought;

    public float thoughtfullness = 0;
    public float lowerThoughtMulitplier;
    public float raiseThoughtMulitplier;
    [SerializeField] private float minHieght;

    private float resetAmp;

    public float floatHieght = 0;

    // Start is called before the first frame update
    private void Start()
    {
        amplitutude = Random.Range(0.25f, 0.5f);
        startPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // timer();

        MovementSin();
        // MovementFloat();
    }

    public void DecreaseThoughtfullness()
    {
        if (thoughtfullness > minThought)
        {
            thoughtfullness -= lowerThoughtMulitplier * Time.deltaTime;
        }
    }

    public void IncreaseThoughtfullness()
    {
        if (thoughtfullness < maxThought)
        {
            thoughtfullness += raiseThoughtMulitplier * Time.deltaTime;
        }
    }

    private void timer()
    {
        breathcounter += Time.deltaTime;

        if (breathingIN && breathcounter <= inCounter) // less than 7 so we breathing in
        {
            IncreaseThoughtfullness();
        }
        else if (breathingIN && breathcounter > inCounter)
        {
            breathingIN = false;
        }
        else if (!breathingIN && breathcounter <= outCounter)
        {
            DecreaseThoughtfullness();
        }

        if (!breathingIN && breathcounter >= outCounter)
        {
            breathcounter = 0;
            breathingIN = true;
        }
    }

    private void MovementSin()
    {
        Vector3 tempPos = startPos;

        Debug.Log("sin");
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitutude;

        transform.position = tempPos;
    }

    private void MovementFloat()
    {
        floatHieght = 1 + (thoughtfullness / 100);
        transform.position = new Vector3(transform.position.x, floatHieght, transform.position.z);
    }
}