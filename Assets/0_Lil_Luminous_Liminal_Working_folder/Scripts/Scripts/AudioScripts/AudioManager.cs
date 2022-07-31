using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioMixerGroup mixerGroup;

    public SoundData[] sfxSounds;

    public SoundData[] voiceSounds;

    public SoundData[] musicSounds;


    public enum ArrayName
    {
        sfx,
        voice,
        music
    }

    //old content

    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioClip[] SfxClips;
    [SerializeField] private AudioClip[] voiceLines;
    [SerializeField] private AudioSource voSource;

    //TwentyThree,TwentyFour,TwentyFive,TwentySix,End
    //break

    public void Awake()
    {
       foreach (SoundData s in musicSounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}

        foreach (SoundData s in voiceSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;
        }

        foreach (SoundData s in sfxSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string sound, ArrayName arrayName)
    {
        SoundData s = new SoundData();
        switch (arrayName)
        {
            case ArrayName.sfx:
                s = Array.Find(sfxSounds, item => item.soundName == sound);
                break;
            case ArrayName.voice:
                s = Array.Find(voiceSounds, item => item.soundName == sound);
                break;
            case ArrayName.music:
                s = Array.Find(musicSounds, item => item.soundName == sound);
                break;
        }
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));  //this is randomising the volume/pitch by allocating a random number from the volume variance number -/+ 2
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();
    }

    //old content ask andrew about

    private void OnEnable() // B: are these enable/disables saying to reset the int in the sfx/voEvent variables? Is the Enable just parsing through the int from sfx/vo to the functions?
    {
        EventManager.sfxEvent += PlaySfx;
        EventManager.voEvent += PlayVoiceLines;
    }

    private void OnDisable()
    {
        EventManager.sfxEvent -= PlaySfx;
        EventManager.voEvent -= PlayVoiceLines;
    }

    public void PlayVoiceLines(int clipIndex)// this is called via the VOEvent in the eventManager, the ClipIndex is the section in the Gamemanager script.
    {
        if (voSource != null && !voSource.isPlaying) // check if the source is there and if the source is not already playing
        {
            voSource.PlayOneShot(voiceLines[clipIndex]); // play the voiceline.
        }
    }

    public void PlaySfx(int clipIndex, int SourceIndex)
    {
        if (!audioSources[SourceIndex].isPlaying)
        {
            audioSources[SourceIndex].PlayOneShot(SfxClips[clipIndex]);
        }
    }
    ///
    /// Updated code for the game manager/playing functionality
    /// 
    /// In the game manager, have the following lines of code:
    /// 
    /// For Voice Lines: FindObjectOfType<AudioManager>().Play("Voiceline" + clipIndex, AudioManager.ArrayName.voice); <-- be aware that this won't account for repeated lines yet. Will be accommodating that somehow in the next week or so.
    /// For SFX sounds: FindObjectOfType<AudioManager>().Play("insert sound name", AudioManager.ArrayName.sfx);
    /// 
    /// 
    ///
}