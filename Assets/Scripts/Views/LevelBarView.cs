using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarView : BoxClickerElement
{
    [SerializeField]
    private Slider levelBar;
    [SerializeField]
    private Text levelTitle;
    [SerializeField]
    private Text experienceTitle;
    
    /*
    public void SetMaxLevel(float maxValue)
    {
        levelBar.maxValue = maxValue;
    }
    */
    public void UpdateLevelView(float experience, int level)
    {
        levelBar.value = experience;
        levelBar.maxValue = (level * 100);
        levelTitle.text = "Level " + level;
        experienceTitle.text = experience + " / " + (level * 100);
    }
}
