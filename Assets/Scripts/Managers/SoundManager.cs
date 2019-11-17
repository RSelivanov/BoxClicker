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

    public void PlaySound(string name)
    {
        if (!GameManager.use.GetSoundSettings()) return;

        float volume = 1.0f;
        string filename = "";

        switch (name)
        {
            case "BreakBox_01": filename = "BreakBox_Paper"; volume = 0.25f; break;
            case "BreakBox_02": filename = "BreakBox_Paper"; volume = 0.25f; break;
            case "BreakBox_03": filename = "BreakBox_Wood"; volume = 0.25f; break;
            case "BreakBox_04": filename = "BreakBox_Wood"; volume = 0.25f; break;
            case "BreakBox_05": filename = "BreakBox_Wood"; volume = 0.25f; break;
            case "BreakBox_06": filename = "BreakBox_Metal"; volume = 0.25f; break;
            case "BreakBox_07": filename = "BreakBox_Metal"; volume = 0.25f; break;
            case "BreakBox_08": filename = "BreakBox_Metal"; volume = 0.25f; break;
            case "BreakBox_09": filename = "BreakBox_Stone"; volume = 0.25f; break;
            case "BreakBox_10": filename = "BreakBox_Stone"; volume = 0.25f; break;
            //----------------
            case "ClickBox_01": filename = "ClickBox_Paper"; volume = 1.0f; break;
            case "ClickBox_02": filename = "ClickBox_Paper"; volume = 1.0f; break;
            case "ClickBox_03": filename = "ClickBox_Wood"; volume = 1.0f; break;
            case "ClickBox_04": filename = "ClickBox_Wood"; volume = 1.0f; break;
            case "ClickBox_05": filename = "ClickBox_Wood"; volume = 1.0f; break;
            case "ClickBox_06": filename = "ClickBox_Metal"; volume = 1.0f; break;
            case "ClickBox_07": filename = "ClickBox_Metal"; volume = 1.0f; break;
            case "ClickBox_08": filename = "ClickBox_Metal"; volume = 1.0f; break;
            case "ClickBox_09": filename = "ClickBox_Stone"; volume = 1.0f; break;
            case "ClickBox_10": filename = "ClickBox_Stone"; volume = 1.0f; break;
            //----------------
            case "Coin_01": filename = "Coin_01"; volume = 0.3f; break;
            case "Coin_02": filename = "Coin_02"; volume = 0.3f; break;
            case "Coin_03": filename = "Coin_03"; volume = 0.3f; break;
            //----------------
            case "ShotGun_01": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_02": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_03": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_04": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_05": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_06": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_07": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_08": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_09": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_10": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_11": filename = "ShotGun_01"; volume = 1.0f; break;
            case "ShotGun_12": filename = "ShotGun_01"; volume = 1.0f; break;
        }




        AudioClip audioClip = Resources.Load("Sounds/" + filename) as AudioClip;

        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audionSource = soundGameObject.AddComponent<AudioSource>();

        audionSource.clip = audioClip;
        audionSource.volume = volume;
        audionSource.Play();

        Object.Destroy(soundGameObject, audioClip.length);
    }
}
