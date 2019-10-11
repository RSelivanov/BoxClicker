using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointView : BoxClickerElement
{
    private Dictionary<string, PointData> pointList = new Dictionary<string, PointData>();

    public void ClickListener(GameObject point)
    {
        app.controller.pointController.Click(point);
    }

    public void RedrawPoints()
    {
        GameObject points = app.model.boxModel.GetPoints();
        foreach (Transform point in points.transform)
        {
            pointList = app.model.pointModel.GetPointList();

            if (pointList[point.name].name != "")
            {
                if (point.childCount == 0)
                {
                    GameObject gunPrefab = Resources.Load("Prefabs/Bit4/" + pointList[point.name].spriteName) as GameObject;
                    GameObject gunInstantiate = Instantiate(gunPrefab, point.transform.position, point.transform.rotation) as GameObject;
                    gunInstantiate.transform.SetParent(point.transform);
                    gunInstantiate.transform.localPosition = gunPrefab.transform.position;
                    //gunInstantiate.GetComponent<SpriteRenderer>().color = currentGun.color;
                    gunInstantiate.GetComponent<GunDamageComponent>().SetDamage(pointList[point.name].damage);
                    gunInstantiate.GetComponent<GunDamageComponent>().SetCoolDown(pointList[point.name].coolDown);
                }
            }
            else
            {
                if (point.childCount > 0)
                {
                    Destroy(point.GetChild(0).gameObject);
                }
            }
        }
    }
}
