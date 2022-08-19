using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFloatingAnimation : MonoBehaviour
{
    public Animator rockAnimator;

    private void OnEnable()
    {
        EventManager.voEvent += AnimateRocks;
    }

    private void OnDisable()
    {
        EventManager.voEvent -= AnimateRocks;
    }

    public void AnimateRocks(int clipIndex)
    {

        switch (clipIndex)
        {
            default:
                //do nothing
                break;
            case 2: //make this a number set in the inspector 
                rockAnimator.SetBool("NeedsToMove", true);
                break;
            case 49: //make this a number set in the inspector
                rockAnimator.SetBool("NeedsToMove", false);
                break;
        }         

    }


}
