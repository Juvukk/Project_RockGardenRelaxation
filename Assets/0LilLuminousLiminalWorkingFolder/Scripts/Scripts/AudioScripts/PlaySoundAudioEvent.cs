using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAudioEvent : MonoBehaviour
{

    // This script is to be placed on any objects in the scene that need to run sound (button clicks, etc)

    private AudioManager.ArrayName arrayName = AudioManager.ArrayName.sfx;

    public string clipName;


    public void PlaySound()
    {
        AudioManager.instance.Play(clipName, arrayName); //the instance works only if there is an instance variable in the monobehaviour, it has something to do with this one not being a singleton
    }
}