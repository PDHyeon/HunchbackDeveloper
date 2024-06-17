using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Click,
    Moster_Death,
    Upgrade_Success,
    Upgrade_Failure,
    COUNT
}
public class SoundManager : MonoBehaviour
{
    SFXPlayer sfxPlayer;

    public AudioClip[] audioClips;
    AudioSource audioSource;


    private void Awake()
    {
        sfxPlayer = GetComponentInChildren<SFXPlayer>();

        audioSource = sfxPlayer.GetComponent<AudioSource>();
    }

    private void Start()
    { 
        GameManager.Instance.monster.monsterHelthSystem.OnDamage += ClickSoundEffect;
    }
    private void ClickSoundEffect()
    {
        audioSource.clip = audioClips[(int)SoundType.Click];
        audioSource.Play();
    }
}
