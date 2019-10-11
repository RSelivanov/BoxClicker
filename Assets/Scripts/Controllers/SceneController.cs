using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : BoxClickerElement
{
    public void Initialization()
    {
        app.view.sceneView.Initialization();

        bool? music = SaveManager.use.LoadMusicSettings();

        if (music != null)
        {
            GameManager.use.SetMusicSettings((bool)music);
        }
        else
        {
            GameManager.use.SetMusicSettings(true);
        }

        bool? sound = SaveManager.use.LoadSoundSettings();

        if (sound != null)
        {
            GameManager.use.SetSoundSettings((bool)sound);
        }
        else
        {
            GameManager.use.SetSoundSettings(true);
        }

        app.view.sceneView.Redraw();

        if (GameManager.use.GetMusicSettings())
        {
            MusicManager.use.PlayMusic("Piano_Background_Loop", 0.05f);
        }
        else
        {
            MusicManager.use.StopMusic();
        }
    }

    public void ResetScene()
    {
        SaveManager.use.RemovePoints();
        SaveManager.use.RemoveSkills();
        SaveManager.use.RemoveAchievements();
        SaveManager.use.RemoveCoins();
        SaveManager.use.RemoveMusicSettings();
        SaveManager.use.RemoveSoundSettings();

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ChangeMusic()
    {
        GameManager.use.SetMusicSettings(!GameManager.use.GetMusicSettings());
        app.view.sceneView.Redraw();
        SaveManager.use.SaveMusicSettings(GameManager.use.GetMusicSettings());

        if (GameManager.use.GetMusicSettings())
        {
            MusicManager.use.PlayMusic("Piano_Background_Loop", 0.05f);
        }
        else
        {
            MusicManager.use.StopMusic();
        }
    }

    public void ChangeSound()
    {
        GameManager.use.SetSoundSettings(!GameManager.use.GetSoundSettings());
        app.view.sceneView.Redraw();
        SaveManager.use.SaveSoundSettings(GameManager.use.GetSoundSettings());
    }
}
