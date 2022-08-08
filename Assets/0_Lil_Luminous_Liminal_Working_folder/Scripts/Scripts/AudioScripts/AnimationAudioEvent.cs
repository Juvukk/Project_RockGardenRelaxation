using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioEvent : MonoBehaviour
{
    // this script is for attaching to any object that has an animation that requires a sound

    private AudioManager.ArrayName arrayName = AudioManager.ArrayName.sfx;

    public void PlaySound(string clipName)
    {
        AudioManager.instance.Play(clipName, arrayName); //the instance works only if there is an instance variable in the monobehaviour, it has something to do with this one not being a singleton
    }
}