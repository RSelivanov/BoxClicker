using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCellView : BoxClickerElement
{
    public void ClickListener(GameObject cell)
    {
        app.controller.achievementController.Click(cell);
    }
}
