using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneView : BoxClickerElement
{
    [SerializeField] private Button MusicButton;
    [SerializeField] private Button SoundButton;

    [SerializeField] private Sprite SettingsMusicOn;
    [SerializeField] private Sprite SettingsMusicOff;
    [SerializeField] private Sprite SettingsSoundOn;
    [SerializeField] private Sprite SettingsSoundOff;

    public void Initialization()
    {
        SettingsMusicOn = Resources.Load<Sprite>("Sprites/SettingsMusic");
        SettingsMusicOff = Resources.Load<Sprite>("Sprites/SettingsMusicBlock");
        SettingsSoundOn = Resources.Load<Sprite>("Sprites/SettingsSounds");
        SettingsSoundOff = Resources.Load<Sprite>("Sprites/SettingsSoundsBlock");
    }

    public void ClickReset()
    {
        app.controller.sceneController.ResetScene();
    }

    public void ClickMusic()
    {
        app.controller.sceneController.ChangeMusic();
    }

    public void ClickSound()
    {
        app.controller.sceneController.ChangeSound();
    }

    public void Redraw()
    {
        if (GameManager.use.GetMusicSettings())
        {
            MusicButton.GetComponent<Image>().sprite = SettingsMusicOn;
        }
        else
        {
            MusicButton.GetComponent<Image>().sprite = SettingsMusicOff;
        }

        if (GameManager.use.GetSoundSettings())
        {
            SoundButton.GetComponent<Image>().sprite = SettingsSoundOn;
        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = SettingsSoundOff;
        }
    }

}
