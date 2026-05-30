using System;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [SerializeField] private StudioEventEmitter sfxEmmitter;
    [SerializeField] private StudioEventEmitter musicEmmiter;

    private void Awake()
    {
        Instance ??= this;
    }

    public void PlaySFX(EventReference newEvent)
    {
        sfxEmmitter.Stop();
        sfxEmmitter.ChangeEvent(newEvent);
        sfxEmmitter.Play();
    }
}
