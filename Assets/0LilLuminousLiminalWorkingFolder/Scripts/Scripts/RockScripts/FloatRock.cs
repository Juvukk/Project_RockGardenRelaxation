using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatRock : MonoBehaviour
{
    private Vector3 startPos;

    // [SerializeField] private float frequency;
    //  [SerializeField] private float amplitutude;
    //  [SerializeField] private float inCounter = 7;
    //  [SerializeField] private float outCounter = 10;
    //   [SerializeField] private bool breathingIN = true;
    //   [SerializeField] private float breathcounter = 0;

    //   [SerializeField] private float maxThought;
    //   [SerializeField] private float minThought;

    //    public float thoughtfullness = 0;
    //   public float lowerThoughtMulitplier;
    //    public float raiseThoughtMulitplier;
    //    [SerializeField] private float minHieght;

    //   private float resetAmp;

    //  public float floatHieght = 0;

    [SerializeField] [Range(0f, 4f)] private float lerpTime;
    [SerializeField] private Vector3[] myPos;

    private int posIndex = 0;
    private int length;

    private float time = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        //amplitutude = Random.Range(0.25f, 0.5f);
        startPos = transform.position;
        length = myPos.Length;
    }

    // Update is called once per frame
    private void Update()
    {
        // timer();
        movementLerp();
        //MovementSin();
        // MovementFloat();
    }

    //public void DecreaseThoughtfullness()
    //{
    //    if (thoughtfullness > minThought)
    //    {
    //        thoughtfullness -= lowerThoughtMulitplier * Time.deltaTime;
    //    }
    //}

    //public void IncreaseThoughtfullness()
    //{
    //    if (thoughtfullness < maxThought)
    //    {
    //        thoughtfullness += raiseThoughtMulitplier * Time.deltaTime;
    //    }
    //}

    //private void timer()
    //{
    //    breathcounter += Time.deltaTime;

    //    if (breathingIN && breathcounter <= inCounter) // less than 7 so we breathing in
    //    {
    //        //IncreaseThoughtfullness();
    //        lerpTime = .25f;
    //    }
    //    else if (breathingIN && breathcounter > inCounter)
    //    {
    //        breathingIN = false;
    //    }
    //    else if (!breathingIN && breathcounter <= outCounter)
    //    {
    //        // DecreaseThoughtfullness();

    //        lerpTime = 0.5f;
    //    }

    //    if (!breathingIN && breathcounter >= outCounter)
    //    {
    //        breathcounter = 0;
    //        breathingIN = true;
    //    }
    //}

    //private void MovementSin()
    //{
    //    Vector3 tempPos = startPos;

    //    Debug.Log("sin");
    //    tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitutude;

    //    transform.position = tempPos;
    //}

    //private void MovementFloat()
    //{
    //    floatHieght = 1 + (thoughtfullness / 100);
    //    transform.position = new Vector3(transform.position.x, floatHieght, transform.position.z);
    //}

    private void movementLerp()
    {
        myPos[posIndex].x = transform.position.x;
        myPos[posIndex].z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, myPos[posIndex], lerpTime * Time.deltaTime);

        time = Mathf.Lerp(time, 1f, lerpTime * Time.deltaTime);

        if (time > 0.9f)
        {
            time = 0f;
            posIndex++;
            posIndex = (posIndex >= length) ? 0 : posIndex;
        }
    }
}