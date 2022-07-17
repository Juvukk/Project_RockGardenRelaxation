using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioClip[] SfxClips;
    [SerializeField] private AudioClip[] voiceLines;
    [SerializeField] private AudioSource voSource;

    private void OnEnable()
    {
        EventManager.sfxEvent += playSfx;
        EventManager.voEvent += playVoiceLines;
    }

    private void OnDisable()
    {
        EventManager.sfxEvent -= playSfx;
        EventManager.voEvent -= playVoiceLines;
    }

    public void playVoiceLines(int clipIndex)
    {
        if (voSource != null && !voSource.isPlaying)
        {
            voSource.PlayOneShot(voiceLines[clipIndex]);
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