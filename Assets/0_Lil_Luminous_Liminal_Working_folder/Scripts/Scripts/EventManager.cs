using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void LoadScene(int index);

    public static LoadScene sceneLoad;

    public delegate void SFXEvent(int ClipIndex, int SourceIndex);

    public static SFXEvent sfxEvent;

    public delegate void VOEvent(int ClipIndex);

    public static VOEvent voEvent;
}