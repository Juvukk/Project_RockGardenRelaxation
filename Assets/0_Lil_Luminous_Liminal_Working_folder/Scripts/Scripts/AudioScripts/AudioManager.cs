using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioClip[] SfxClips;
    [SerializeField] private AudioClip[] voiceLines;
    [SerializeField] private AudioSource voSource;

    //TwentyThree,TwentyFour,TwentyFive,TwentySix,End
    private void OnEnable() //
    {
        EventManager.sfxEvent += playSfx;
        EventManager.voEvent += playVoiceLines;
    }

    private void OnDisable()
    {
        EventManager.sfxEvent -= playSfx;
        EventManager.voEvent -= playVoiceLines;
    }

    public void playVoiceLines(int clipIndex)// this is called via the VOEvent in the eventManager, the ClipIndex is the section in the Gamemanager script.
    {
        if (voSource != null && !voSource.isPlaying) // check if the source is there and if the source is not already playing
        {
            voSource.PlayOneShot(voiceLines[clipIndex]); // play the voiceline.
        }
    }

    public void playSfx(int clipIndex, int SourceIndex)
    {
        if (!audioSources[SourceIndex].isPlaying)
        {
            audioSources[SourceIndex].PlayOneShot(SfxClips[clipIndex]);
        }
    }
}