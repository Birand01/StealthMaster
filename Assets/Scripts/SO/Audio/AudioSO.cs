using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfiguration", menuName = "ScriptableObjects/AudioConfiguration", order = 0)]
public class AudioSO : ScriptableObject
{
    [HideInInspector] public AudioSource audioSource;
    public AudioClip clip;
    public bool loop;
    public bool playOnAwake;
    [Range(0f, 1f)] public float volume;
    [Range(0f, 1f)] public float pitch;
    public SoundType soundType;

}