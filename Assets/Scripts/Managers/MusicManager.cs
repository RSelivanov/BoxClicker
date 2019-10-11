using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager use = null;

    void Awake()
    {
        use = this;
    }

    [SerializeField] private GameObject musicGameObject;

    public void PlayMusic(string name, float volume)
    {
        if (musicGameObject != null) StopMusic();

        AudioClip audioClip = Resources.Load("Music/" + name) as AudioClip;

        musicGameObject = new GameObject("Music");
        AudioSource audionSource = musicGameObject.AddComponent<AudioSource>();
        audionSource.clip = audioClip;
        audionSource.volume = volume;
        audionSource.loop = true;
        audionSource.Play();
    }

    public void StopMusic()
    {
        Object.Destroy(musicGameObject);
    }









}
