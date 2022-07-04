using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void LoadScene(int index);

    public static LoadScene sceneLoad;

    public delegate void AudioEvent(int ClipIndex, int SourceIndex);

    public static AudioEvent audioEvent;
}