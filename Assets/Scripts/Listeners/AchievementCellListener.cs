using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCellListener : BoxClickerElement
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonListener);
    }

    void ButtonListener()
    {
        app.view.achievementCellView.ClickListener(this.gameObject);
    }
}
