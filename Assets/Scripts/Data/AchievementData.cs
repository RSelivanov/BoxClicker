using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementData
{
    public int id;
    public string title;
    public string description;
    public long coins;
    public bool open;
    public int level;
    public int finalLevel;

    public AchievementData(int id, string title, string description, long coins, bool open, int level, int finalLevel)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.coins = coins;
        this.open = open;
        this.level = level;
        this.finalLevel = finalLevel;
    }
}
