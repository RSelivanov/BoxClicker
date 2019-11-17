using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointModel : BoxClickerElement
{
    [SerializeField] private GameObject points;
    [SerializeField] private string currentPointName;

    private Dictionary<string, PointData> pointList = new Dictionary<string, PointData>();
    public Dictionary<string, PointData> GetPointList() { return pointList; }

    public void InitializationData()
    {
        Dictionary<string, PointData> loadPointList = SaveManager.use.LoadPoints();
        if (loadPointList != null)
        {
            pointList = loadPointList;
            app.view.pointView.RedrawPoints();
        }
        else
        {
            foreach (Transform point in points.transform)
            {
                pointList.Add(point.name, new PointData(0, "", "spriteName", 0, 0, 0, 0, 0, 0, 0, 0, 50f, 15f));
            }
        }
    }

    public void SetCurrentPointName(string currentPointName)
    {
        this.currentPointName = currentPointName;
    }

    public string GetCurrentPointName()
    {
        return this.currentPointName;
    }

    //--------------
    public GameObject GetCurrentPointGameObject()
    {
        foreach (Transform point in points.transform)
        {
            if (point.name == currentPointName)
            {
                return point.gameObject;
            }
        }
        return null;
    }
    public bool IsCurrentPointEmpty()
    {
        if (pointList[currentPointName].name == "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void SetCurrentPointData(GunData gun)
    {
        pointList[currentPointName].id = gun.id;
        pointList[currentPointName].name = gun.name;
        pointList[currentPointName].spriteName = gun.spriteName;
        pointList[currentPointName].price = gun.price;
        pointList[currentPointName].upgradePrice = CountManager.use.IncrementalOfNumber(gun.price, 1);
        pointList[currentPointName].damage = gun.damage;
        pointList[currentPointName].percentDamage = 50;
        pointList[currentPointName].upgradeDamage = pointList[currentPointName].damage + (pointList[currentPointName].damage * pointList[currentPointName].percentDamage / 100);
        pointList[currentPointName].coolDown = gun.coolDown;
        pointList[currentPointName].percentCoolDown = 15;
        pointList[currentPointName].upgradeCoolDown = pointList[currentPointName].coolDown - (pointList[currentPointName].coolDown * pointList[currentPointName].percentCoolDown / 100);//- 0.1f;
        pointList[currentPointName].pow = 2;
    }

    public PointData GetPointData(string pointName)
    { 
        return pointList[pointName];
    }

    public PointData GetCurrentPointData()
    {
        if (currentPointName != "")
        {
            return pointList[currentPointName];
        }
        return null;
    }


    public void ResetCurrentPointData()
    {
        pointList[currentPointName].id = 0;
        pointList[currentPointName].name = "";
        pointList[currentPointName].spriteName = "";
        pointList[currentPointName].price = 0;
        pointList[currentPointName].damage = 0;
        pointList[currentPointName].level = 0;
        pointList[currentPointName].coolDown = 0;
        pointList[currentPointName].upgradePrice = 0;
        pointList[currentPointName].upgradeDamage = 0;
        pointList[currentPointName].upgradeCoolDown = 0;
        pointList[currentPointName].pow = 0;
        pointList[currentPointName].percentDamage = 50;
        pointList[currentPointName].percentCoolDown = 15;
    }

    // upgrade
    public void UpgradeCurrentPoint()
    {
        pointList[currentPointName].level += 1;
        pointList[currentPointName].pow++;

        
        pointList[currentPointName].price = pointList[currentPointName].price;
        pointList[currentPointName].damage = pointList[currentPointName].upgradeDamage;
        pointList[currentPointName].coolDown = pointList[currentPointName].upgradeCoolDown;

        foreach (Transform point in points.transform)
        {
            if(point.name == currentPointName)
            {
                GunDamageComponent gunDamageComponent = point.transform.GetChild(0).GetComponent<GunDamageComponent>();
                gunDamageComponent.SetDamage(pointList[currentPointName].damage);
            }
        }

        //new data
        pointList[currentPointName].upgradePrice = CountManager.use.IncrementalOfNumber(pointList[currentPointName].upgradePrice, pointList[currentPointName].pow);

        if (pointList[currentPointName].percentDamage > 2) pointList[currentPointName].percentDamage -= pointList[currentPointName].percentDamage / 2;
        pointList[currentPointName].upgradeDamage += (pointList[currentPointName].damage * pointList[currentPointName].percentDamage / 100);

        if (pointList[currentPointName].percentCoolDown > 2) pointList[currentPointName].percentCoolDown -= pointList[currentPointName].percentCoolDown / 2;
        if (pointList[currentPointName].upgradeCoolDown > 0.5) pointList[currentPointName].upgradeCoolDown -= (pointList[currentPointName].coolDown * pointList[currentPointName].percentCoolDown / 100);//-= 0.1f;
    }
}
