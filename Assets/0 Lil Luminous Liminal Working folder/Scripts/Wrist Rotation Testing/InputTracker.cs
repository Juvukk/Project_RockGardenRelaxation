using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTracker : MonoBehaviour
{
    [SerializeField] private bool isFollowingMovement;
    [SerializeField] private bool startCounter;
    [SerializeField] private float counter;
    private float resetCounter;
    [SerializeField] private GameObject swril;
    public float thoughtfullness = 0;
    public float thoughtfullnessChange;

    // Start is called before the first frame update
    private void Start()
    {
        resetCounter = counter;
    }

    // Update is called once per frame;
    private void Update()
    {
        timer();
        GetThought();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Input"))
        {
            isFollowingMovement = true;
            startCounter = false;
            swril.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        startCounter = true;
        isFollowingMovement = false;
        swril.SetActive(true);
    }

    public void GetThought()
    {
        if (counter <= 0)
        {
            if (thoughtfullness > 0)
            {
                thoughtfullness -= thoughtfullnessChange * Time.deltaTime;
            }
        }
        else if (isFollowingMovement)
        {
            if (thoughtfullness < 100)
            {
                thoughtfullness += thoughtfullnessChange * Time.deltaTime;
            }
        }
    }

    private void timer()
    {
        if (startCounter)
        {
            counter -= Time.deltaTime;
        }
        else
        {
            counter = resetCounter;
        }
    }
}