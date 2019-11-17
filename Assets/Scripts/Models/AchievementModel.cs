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
            achievementList.Add(new AchievementData(0, "Destroy your first box", "", 25, false, 0, 1));
            achievementList.Add(new AchievementData(1, "Plase your first laser", "", 30, false, 0, 1));
            achievementList.Add(new AchievementData(2, "Upgrade your first laser", "", 35, false, 0, 1));

            achievementList.Add(new AchievementData(3, "Make 10 clicks", "", 40, false, 0, 10));
            achievementList.Add(new AchievementData(4, "Destroy 100 boxes", "", 50, false, 0, 100));

            achievementList.Add(new AchievementData(5, "Plase Tiny Plasma Laser", "", 60, false, 0, 1));
            achievementList.Add(new AchievementData(6, "Upgrade Plasma Ray Laser", "", 90, false, 0, 1));

            achievementList.Add(new AchievementData(7, "Make 50 clicks", "", 150, false, 0, 50));
            achievementList.Add(new AchievementData(8, "Destroy 500 boxes", "", 200, false, 0, 500));

            achievementList.Add(new AchievementData(9, "Plase Plasma Ray Laser", "", 300, false, 0, 1));
            achievementList.Add(new AchievementData(10, "Upgrade Plasma Ray Laser", "", 450, false, 0, 1));

            achievementList.Add(new AchievementData(11, "Make 100 clicks", "", 800, false, 0, 100));
            achievementList.Add(new AchievementData(12, "Destroy 1000 boxes", "", 1100, false, 0, 1000));

            achievementList.Add(new AchievementData(13, "Plase Fat Red Laser", "", 1500, false, 0, 1));
            achievementList.Add(new AchievementData(14, "Upgrade Fat Red Laser", "", 2200, false, 0, 1));

            achievementList.Add(new AchievementData(15, "Make 1000 clicks", "", 4000, false, 0, 1000));
            achievementList.Add(new AchievementData(16, "Destroy 10000 boxes", "", 6000, false, 0, 10000));

            achievementList.Add(new AchievementData(17, "Plase Tiny Wave Laser", "", 7000, false, 0, 1));
            achievementList.Add(new AchievementData(18, "Upgrade Tiny Wave Laser", "", 10000, false, 0, 1));

            achievementList.Add(new AchievementData(19, "Make 10000 clicks", "", 20000, false, 0, 10000));
            achievementList.Add(new AchievementData(20, "Destroy 100000 boxes", "", 30000, false, 0, 100000));

            achievementList.Add(new AchievementData(21, "Plase Double Red Laser", "", 40000, false, 0, 1));
            achievementList.Add(new AchievementData(22, "Upgrade Double Red Laser", "", 60000, false, 0, 1));

            achievementList.Add(new AchievementData(23, "Make 100000 clicks", "", 90000, false, 0, 100000));
            achievementList.Add(new AchievementData(24, "Destroy 1000000 boxes", "", 110000, false, 0, 1000000));

            achievementList.Add(new AchievementData(25, "Plase Fat Wave Laser", "", 200000, false, 0, 1));
            achievementList.Add(new AchievementData(26, "Upgrade Fat Wave Laser", "", 250000, false, 0, 1));

            achievementList.Add(new AchievementData(27, "Make 1000000 clicks", "", 600000, false, 0, 1000000));
            achievementList.Add(new AchievementData(28, "Destroy 10000000 boxes", "", 700000, false, 0, 10000000));

            achievementList.Add(new AchievementData(29, "Plase Fat Plasma Laser", "", 1000000, false, 0, 1));
            achievementList.Add(new AchievementData(30, "Upgrade Fat Plasma Laser", "", 1500000, false, 0, 1));

            achievementList.Add(new AchievementData(31, "Make 10000000 clicks", "", 3000000, false, 0, 10000000));
            achievementList.Add(new AchievementData(32, "Destroy 100000000 boxes", "", 4000000, false, 0, 100000000));

            achievementList.Add(new AchievementData(33, "Plase Microwave Blue Laser", "", 5000000, false, 0, 1));
            achievementList.Add(new AchievementData(34, "Upgrade Microwave Blue Laser", "", 7500000, false, 0, 1));

            achievementList.Add(new AchievementData(35, "Make 100000000 clicks", "", 12000000, false, 0, 100000000));
            achievementList.Add(new AchievementData(36, "Destroy 1000000000 boxes", "", 15000000, false, 0, 1000000000));

            achievementList.Add(new AchievementData(37, "Plase Point Ray Laser", "", 25000000, false, 0, 1));
            achievementList.Add(new AchievementData(38, "Upgrade Point Ray Laser", "", 37000000, false, 0, 1));

            achievementList.Add(new AchievementData(39, "Plase Electric Red Laser", "", 125000000, false, 0, 1));
            achievementList.Add(new AchievementData(40, "Upgrade Electric Red Laser", "", 190000000, false, 0, 1));

            achievementList.Add(new AchievementData(41, "Plase Yellow Ray Laser", "", 500000000, false, 0, 1));
            achievementList.Add(new AchievementData(42, "Upgrade Yellow Ray Laser", "", 750000000, false, 0, 1));
        }
    }

    public GameObject GetContent() { return this.сontent; }
    public List<AchievementData> GetAchievementList() { return this.achievementList; }
    public AchievementData GetAchievementDataById(int id) { return this.achievementList[id]; }
}
