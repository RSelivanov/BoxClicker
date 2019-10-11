using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementModel : BoxClickerElement
{
    [SerializeField]
    private GameObject сontent;
    [SerializeField]
    private List<AchievementData> achievementList = new List<AchievementData>();

    public void Instantiate()
    {
        List<AchievementData> loadAchievementList = SaveManager.use.LoadAchievements();
        if (loadAchievementList != null)
        {
            achievementList = loadAchievementList;
        }
        else
        {
            // [id] [name] [color] [price] [damage]        
            achievementList.Add(new AchievementData(0, "Title 1", "Description", 500, false));
            achievementList.Add(new AchievementData(1, "Title 2", "Description", 500, false));
            achievementList.Add(new AchievementData(2, "Title 3", "Description", 500, false));
            achievementList.Add(new AchievementData(3, "Title 4", "Description", 500, false));
            achievementList.Add(new AchievementData(4, "Title 5", "Description", 500, false));
            achievementList.Add(new AchievementData(5, "Title 6", "Description", 500, false));
        }
    }

    public GameObject GetContent() { return this.сontent; }
    public List<AchievementData> GetAchievementList() { return this.achievementList; }
    public AchievementData GetAchievementDataById(int id) { return this.achievementList[id]; }

    public void OpenAchievement(int id)
    {
        if (achievementList[id].isOpen) return;

        achievementList[id].isOpen = true;
        
    }

}
