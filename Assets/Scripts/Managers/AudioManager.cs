using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    ElevatorSound,
    BulletSound,
    PasswordCorrectSound,
    PasswordIncorrectSound,
    ElectricGateSound,
    DoorSound,
    KeySound,
    SamuraHitSound,
    BombPickUp,
    BombExplode
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSO[] soundsSoArray;
    [SerializeField] private AudioClip[] backgroudMusics;
    private AudioSource source;

    private void OnEnable()
    {
        BombInteraction.OnBombPickUpSound += PlaySound;
        BombExplode.OnBombExplodeSound += PlaySound;
        ElevatorInteraction.OnElevatorSound += PlaySound;
        VerifyButton.OnPasswordCorrectSound += PlaySound;
        VerifyButton.OnPasswordInCorrectSound += PlaySound;
        ElectricButtonInteraction.OnElectricGateSound += PlaySound;
        DoorInteraction.OnDoorSound += PlaySound;
        KeyInteraction.OnKeySound += PlaySound;
        Gun.OnBulletSound += PlaySound;
        AttackInteraction.OnSamuraiHitSound += PlaySound;
    }
    private void OnDisable() 
    {
        BombInteraction.OnBombPickUpSound -= PlaySound;
        BombExplode.OnBombExplodeSound -= PlaySound;
        ElevatorInteraction.OnElevatorSound -= PlaySound;
        VerifyButton.OnPasswordCorrectSound -= PlaySound;
        VerifyButton.OnPasswordInCorrectSound -= PlaySound;
        ElectricButtonInteraction.OnElectricGateSound -= PlaySound;
        DoorInteraction.OnDoorSound -= PlaySound;
        KeyInteraction.OnKeySound -= PlaySound;
        Gun.OnBulletSound -= PlaySound;
        AttackInteraction.OnSamuraiHitSound -= PlaySound;

    }
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        SoundConfiguration();
    }
    private void Start()
    {
        //PlayRandomBackgroundMusic();
    }
    private void PlayRandomBackgroundMusic()
    {
        AudioClip clip = backgroudMusics[UnityEngine.Random.Range(0, backgroudMusics.Length)];
        source.clip = clip;
        source.Play();
    }

    private void SoundConfiguration()
    {
        foreach (var sound in soundsSoArray)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.loop = sound.loop;
        }
    }
    public void PlaySound(SoundType soundType, bool state)
    {
        AudioSO audio = Array.Find(soundsSoArray, sound => sound.soundType == soundType);

        if (state)
        {
            if (audio == null)
                return;
            audio.audioSource.Play();
        }
        else
            audio.audioSource.Stop();

    }
}
