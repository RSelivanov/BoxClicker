using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementData
{
    public int id;
    public string title;
    public string description;
    public int coins;
    public bool isOpen;

    public AchievementData(int id, string title, string description, int coins, bool isOpen)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.coins = coins;
        this.isOpen = isOpen;
    }
}
