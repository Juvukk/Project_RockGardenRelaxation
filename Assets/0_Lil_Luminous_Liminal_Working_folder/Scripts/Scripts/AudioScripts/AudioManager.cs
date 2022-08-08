using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioMixerGroup mixerGroup;

    public SoundData[] sfxSounds;

    public SoundData[] voiceSounds;

    public SoundData[] musicSounds;

    public SoundData[] breathingSounds;

   // public AudioSource voiceAudioSource;

    public enum ArrayName
    {
        sfx,
        voice,
        music,
        breathing
    }

    private int addToClipNumber = 1;

    // [SerializeField] private AudioClip[] voiceLines;

    private bool isGoingDown = false;
    private int indexNumber = 0;


    public void Awake()
    {
       foreach (SoundData s in musicSounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;

			s.source.outputAudioMixerGroup = mixerGroup;
		}

        foreach (SoundData s in voiceSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.outputAudioMixerGroup = mixerGroup;
        }

        foreach (SoundData s in sfxSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;

            s.source.outputAudioMixerGroup = mixerGroup;
        }

        foreach (SoundData s in breathingSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;

            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }
    private void OnEnable()
    {
        EventManager.voEvent += PlayVoiceLines;
    }

    private void OnDisable()
    {
        EventManager.voEvent -= PlayVoiceLines;
    }

    public void Start()
    {
        Play("BackgroundMusic", ArrayName.music);
        Play("WaterLoop", ArrayName.sfx);
        PlayBreathingGuide();
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
            case ArrayName.breathing:
                s = Array.Find(breathingSounds, item => item.soundName == sound);
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


    public void PlayVoiceLines(int clipIndex)// this is called via the VOEvent in the eventManager, the ClipIndex is the section in the Gamemanager script.
    {
        string clipName;
        ArrayName arrayName = ArrayName.voice;

        int clipNumber = clipIndex + addToClipNumber;

        switch (clipIndex)
        {
            default:
                clipName = "Voiceline" + clipNumber;
                break;
            case 13:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 14:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 16:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 17:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 19:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 20:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 21:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 22:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 25:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 26:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 28:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 29:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 31:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 32:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 34:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 35:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 37:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 38:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 40:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 41:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
            case 43:
                clipName = "Voiceline" + 28;
                addToClipNumber--;
                break;
            case 44:
                clipName = "Voiceline" + 29;
                addToClipNumber--;
                break;
        }

        Play(clipName, arrayName);

        //if (voiceAudioSource != null && !voiceAudioSource.isPlaying) // check if the source is there and if the source is not already playing
        //{
        //    voiceAudioSource.PlayOneShot(voiceLines[clipIndex]); // play the voiceline. this grabs the number (clipindex) from the voicelines field, and shoves it into the audio source and plays
        //}
    }




    IEnumerator BreathingGuideCoroutine()
    {
        // this function is for running the breathing guide. currently THIS IS JANKY. IT IS ONLY TO TEST THE SOUNDS. it is run on awake, runs a hard coded few seconds for the wait, then triggers the below function which triggers this function again. As I said. Janky.
        switch (isGoingDown)
        {
            case true:
                yield return new WaitForSeconds(7);
                isGoingDown = false;
            break;
            case false:
                yield return new WaitForSeconds(3);
                isGoingDown = true;
                break;
        }

        PlayBreathingGuide();

        yield return null;
    }

    public void PlayBreathingGuide()
    {
        ArrayName arrayName = ArrayName.breathing;

        string clipName = breathingSounds[indexNumber].soundName;

        Play(clipName, arrayName);
        indexNumber++;
        if (indexNumber > 4)
        {
            indexNumber = 0;
        }

        StartCoroutine(BreathingGuideCoroutine());
    }


    // For SFX sounds: FindObjectOfType<AudioManager>().Play("insert sound name", AudioManager.ArrayName.sfx);
}