using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundManager : MonoBehaviour
{

    // This script is to be placed on any UI behaviour/inspector trigger events that need to run sound (button clicks, etc)

    public AudioManager.ArrayName arrayName;



    public void PlaySound(string clipName)
    {
        AudioManager.instance.Play(clipName, arrayName); //the instance works only if there is an insteance variable in the monobehaviour, it has something to do with this one not being a singleton
    }

    //   the following code is what needs to be placed within other scripts to call the play function in the audio manager
    //
    //   public void TestSound()
    //   {
    //       FindObjectOfType<AudioManager>().Play("Insert clip name in inspector with quote marks", AudioManager.ArrayName."insert arrayname without quote marks");
    //   }
}