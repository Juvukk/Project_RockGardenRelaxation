using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] AudioSources;
    [SerializeField] private AudioClip[] AudioClips;

    private void OnEnable()
    {
        EventManager.audioEvent += playSfx;
    }

    private void OnDisable()
    {
        EventManager.audioEvent -= playSfx;
    }

    public void playSfx(int clipIndex, int SourceIndex)
    {
        if (!AudioSources[SourceIndex].isPlaying)
        {
            AudioSources[SourceIndex].PlayOneShot(AudioClips[clipIndex]);
        }
    }
}