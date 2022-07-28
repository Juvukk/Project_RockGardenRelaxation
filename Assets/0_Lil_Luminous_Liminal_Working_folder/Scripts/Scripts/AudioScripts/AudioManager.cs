using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SFXSound[] sfxSounds;
    public AudioMixerGroup mixerGroup;


    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioClip[] SfxClips;
    [SerializeField] private AudioClip[] voiceLines;
    [SerializeField] private AudioSource voSource;

    //TwentyThree,TwentyFour,TwentyFive,TwentySix,End

    public void Awake()
    {
       foreach (SFXSound s in sfxSounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}  
    }


    public void PlayEnter()
    {
        Play("ButtonEnter");
    }





    public void Play(string sound)
    {
        SFXSound s = Array.Find(sfxSounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));  //I believe this is randomising the volume/pitch by allocating a random number from the volume variance number -/+ 2
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();
    }












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