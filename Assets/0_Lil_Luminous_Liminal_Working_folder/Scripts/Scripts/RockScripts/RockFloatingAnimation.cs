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
            case 2:
                rockAnimator.SetBool("NeedsToMove", true);
                break;
            case 49:
                rockAnimator.SetBool("NeedsToMove", false);
                break;
        }         

    }


}
