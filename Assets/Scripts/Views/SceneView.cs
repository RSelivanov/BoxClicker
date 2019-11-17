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

    [SerializeField] private List<GameObject> buttonLanguagesList = new List<GameObject>();

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

    public void RedrawLanguages()
    {
        Dictionary<string, bool> languagesList = app.model.languageModel.GetLanguagesList();

        foreach (GameObject button in buttonLanguagesList)
        {
            if (languagesList.ContainsKey(button.name))
            {
                if(languagesList[button.name] == true)
                {
                    button.transform.GetChild(2).GetComponent<Image>().enabled = true;
                }
                else
                {
                    button.transform.GetChild(2).GetComponent<Image>().enabled = false;
                }
            }
        }

    }

}
