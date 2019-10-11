using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager use = null;

    void Awake()
    {
        use = this;
    }

    //---------------
    /*
    public AudioSource audioSource;

    public void Play( string name, float volume)
    {
        AudioClip click1 = Resources.Load("Sounds/" + name) as AudioClip;
        audioSource.volume = volume;
        audioSource.PlayOneShot(click1);
    }
    */

    public void PlaySound(string name, float volume)
    {
        if (!GameManager.use.GetSoundSettings()) return;

        AudioClip audioClip = Resources.Load("Sounds/" + name) as AudioClip;

        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audionSource = soundGameObject.AddComponent<AudioSource>();
        audionSource.clip = audioClip;
        audionSource.volume = volume;
        audionSource.Play();

        Object.Destroy(soundGameObject, audioClip.length);
    }










}
