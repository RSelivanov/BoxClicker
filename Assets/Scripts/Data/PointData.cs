﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PointData
{
    public int id;
    public string name;
    public string spriteName;
    public int price;
    public float damage;
    public float coolDown;
    public int level;
    public int upgradePrice;
    public float upgradeDamage;
    public float upgradeCoolDown;
    public int pow;
    public float percentDamage;
    public float percentCoolDown;

    public PointData(int id, string name, string spriteName, int price, float damage, float coolDown, int level, int upgradePrice, float upgradeDamage, float upgradeCoolDown, int pow, float percentDamage, float percentCoolDown)
    {
        this.id = id;
        this.name = name;
        this.spriteName = spriteName;
        this.price = price;
        this.damage = damage;
        this.coolDown = coolDown;
        this.level = level;
        this.upgradePrice = upgradePrice;
        this.upgradeDamage = upgradeDamage;
        this.upgradeCoolDown = upgradeCoolDown;
        this.pow = pow;
        this.percentDamage = percentDamage;
        this.percentCoolDown = percentCoolDown;

    }

    internal void SetGun(GunData gun)
    {
        this.id = gun.id;
        this.name = gun.name;
        this.spriteName = gun.spriteName;
        this.price = gun.price;
        this.damage = gun.damage;
        this.coolDown = gun.coolDown;
    }
}
