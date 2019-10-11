using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : BoxClickerElement
{

    public void Initialization()
    {
        app.model.achievementModel.Instantiate();
        app.view.achievementListPanelView.Instantiate();
    }

    public void Click(GameObject cell)
    {
        print(cell.name);
    }

    public void OpenAchievement(int id)
    {
        AchievementData currentAchievement = app.model.achievementModel.GetAchievementDataById(id);

        if (!currentAchievement.isOpen)
        {
            GameManager.use.AddCoins(currentAchievement.coins);
            NotificationManager.use.ShowAchievement(id);
        }

        app.model.achievementModel.OpenAchievement(id);
        app.view.achievementListPanelView.Redraw();
        app.view.achievementListPanelView.UpdateAchievementCells();
        SaveManager.use.SaveAchievements();
    }
}
