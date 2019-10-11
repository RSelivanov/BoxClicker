using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillData
{
    public int id;
    public string title;
    public string description;
    public int price;
    public int level;

    public SkillData(int id, string title, string description, int price, int level)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.level = level;
        this.price = price;
    }
}
