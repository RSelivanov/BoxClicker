using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunData
{
    public int id;
    public string name;
    public string spriteName;
    public int price;
    public float damage;
    public float coolDown;

    public GunData(int id, string name, string spriteName, int price, float damage, float coolDown)
    {
        this.id = id;
        this.name = name;
        this.spriteName = spriteName;
        this.price = price;
        this.damage = damage;
        this.coolDown = coolDown;
    }
}