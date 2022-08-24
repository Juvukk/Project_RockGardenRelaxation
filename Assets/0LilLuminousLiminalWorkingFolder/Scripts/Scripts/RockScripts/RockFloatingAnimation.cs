using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFloatingAnimation : MonoBehaviour
{
    public Animator rockAnimator;

    public AudioManager audioManager;

    public AudioManager.ArrayName breathingArrayName;

    public AudioManager.ArrayName sfxArrayName;

    private bool stopBreathingSound = false; //for some reason, after the animation halts, it continues to play the next inhale sound. this bool is a janky fix as I ran out of time

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
                stopBreathingSound = true;
                break;
        }         

    }

    public void PlayBreathingSound(string clipName)
    {
        if (!stopBreathingSound) // notif statement, says "if stopBreathingSound isn't true, do this"
        {
            audioManager.Play(clipName, breathingArrayName);
        }

    }

    //public void PlayLandingSound(string clipName)
    //{
    //    audioManager.Play(clipName, sfxArrayName);
    //}


}
