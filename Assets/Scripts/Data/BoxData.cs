using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxData
{
    public int id;
    public string spriteName;
    public double health;
    public long coins;
    public int experience;
    public float coolDown;

    public BoxData(int id, string spriteName, double health, long coins, int experience, float coolDown)
    {
        this.id = id;
        this.spriteName = spriteName;
        this.health = health;
        this.coins = coins;
        this.experience = experience;
        this.coolDown = coolDown;
    }
}
