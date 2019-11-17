using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : BoxClickerElement
{
    private Dictionary<string, PointData> pointList;

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
        SaveManager.use.RemoveTime();
        SaveManager.use.RemoveLanguages();

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

    public void ConvertPassedTimeToCoins()
    {
        int curentTime = CountManager.use.getCurrentTime();

        int? getPassedTime = SaveManager.use.LoadTime();

        if (getPassedTime.Equals(null)) return;
        int passedTime = Convert.ToInt32(getPassedTime);

        double pointsDamage = 0;
        float pointsCoolDown = 0;

        pointList = app.model.pointModel.GetPointList();

        foreach (var point in pointList)
        {
            pointsDamage += point.Value.damage;
            pointsCoolDown += point.Value.coolDown;
        }

        if (pointsDamage == 0) return;

        double boxHealth = app.model.boxModel.GetDefaultHealth();

        //float boxCoolDown = app.model.boxModel.GetDefaultCoolDown();

        long boxCoins = app.model.boxModel.GetDefaultCoins();

        int passedSeconds = curentTime - passedTime;

        float numberOfTakenDamage = passedSeconds / pointsCoolDown;
        //print("numberOfTakenDamage: passedSeconds " + passedSeconds + " / " + " pointsCoolDown " + pointsCoolDown + " = " + numberOfTakenDamage);

        double totalDamage = numberOfTakenDamage * pointsDamage;
        //print("totalDamage: numberOfTakenDamage " + numberOfTakenDamage + " * " + " pointsDamage " + pointsDamage + " = " + totalDamage);

        int destroyedBoxes = Convert.ToInt32(Math.Floor(totalDamage / boxHealth));
        //print("destroyedBoxes: totalDamage " + totalDamage + " / " + " boxHealth " + boxHealth + " = " + destroyedBoxes);

        app.controller.achievementController.AddLevel(0, destroyedBoxes); // destroy first box
        app.controller.achievementController.AddLevel(4, destroyedBoxes); // destroy 500 boxes
        app.controller.achievementController.AddLevel(8, destroyedBoxes); // destroy 500 boxes
        app.controller.achievementController.AddLevel(12, destroyedBoxes); // destroy 1000 boxes
        app.controller.achievementController.AddLevel(16, destroyedBoxes); // destroy 10000 boxes
        app.controller.achievementController.AddLevel(20, destroyedBoxes); // destroy 100000 boxes
        app.controller.achievementController.AddLevel(24, destroyedBoxes); // destroy 1000000 boxes
        app.controller.achievementController.AddLevel(28, destroyedBoxes); // destroy 10000000 boxes
        app.controller.achievementController.AddLevel(32, destroyedBoxes); // destroy 100000000 boxes
        app.controller.achievementController.AddLevel(36, destroyedBoxes); // destroy 1000000000 boxes

        long passedCoins = Convert.ToInt64(destroyedBoxes * boxCoins);

        print("coins " + passedCoins);

        GameManager.use.AddCoins(passedCoins);

        NotificationManager.use.ShowCoins(passedCoins);

        SaveManager.use.RemoveTime();
    }
}
