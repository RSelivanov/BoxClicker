using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxClickerApplication : MonoBehaviour
{
    public BoxClickerModel model;
    public BoxClickerView view;
    public BoxClickerController controller;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 2);
        //Screen.SetResolution(600, 1024, true);

        controller.advertisementController.Initialization();
        controller.coinController.Initialization();
        controller.pointController.Initialization();
        model.boxModel.InitializationData();
        controller.boxController.Initialization();
        controller.skillController.Initialization();
        controller.gunController.Initialization();
        view.boxView.InstantiateBox();
        controller.achievementController.Initialization();
        controller.sceneController.Initialization();
        controller.languageController.Initialization();

        StartCoroutine(AutoSaveCoroutine());
    }

    void Update()
    {
        controller.gunController.UpdateGunCells();
        controller.skillController.UpdateSkillCells();
        controller.gunController.UpdateUpgradeButton();
    }

    public void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            int curentTime = CountManager.use.getCurrentTime();
            SaveManager.use.SaveTime(curentTime);
            AutoSave();
        }
        else
        {
            StartCoroutine(ApplicationPause());
        }
    }

    void OnApplicationQuit()
    {
        int curentTime = CountManager.use.getCurrentTime();
        SaveManager.use.SaveTime(curentTime);
        AutoSave();
    }

    IEnumerator ApplicationPause()
    {
        yield return new WaitForSeconds(3f);
        controller.sceneController.ConvertPassedTimeToCoins();
    }

    IEnumerator AutoSaveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            AutoSave();
            print("AutoSave");
        }
    }

    void AutoSave()
    {
        SaveManager.use.SaveAchievements();
        SaveManager.use.SaveCoins(GameManager.use.GetCoins());
    }
}
