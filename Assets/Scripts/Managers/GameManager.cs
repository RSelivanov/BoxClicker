using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager use = null;

    void Awake()
    {
        use = this;
    }

    //---------------------------------

    [SerializeField] private long coins;
    [SerializeField] private TextMeshProUGUI coinsText;
    private string coinSprite = "<sprite index=0>";

    private bool music;
    private bool sound;

    void Update()
    {
        coinsText.text = coinSprite + coins;
    }

    public long GetCoins()
    {
        return coins;
    }

    public void SetCoins(long c)
    {
        coins = c;
    }

    public void AddCoins(long c)
    {
        coins += c;

       // SaveManager.use.SaveCoins(this.coins);
    }

    public void RemoveCoins(long c)
    {
        coins -= c;
    }

    public void SetMusicSettings(bool music)
    {
        this.music = music;
    }
    public bool GetMusicSettings()
    {
        return this.music;
    }

    public void SetSoundSettings(bool sound)
    {
        this.sound = sound;
    }
    public bool GetSoundSettings()
    {
        return this.sound;
    }
}
