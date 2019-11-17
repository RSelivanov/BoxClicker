using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : BoxClickerElement
{

    public void Initialization()
    {
        app.model.gunModel.Instantiate();
        app.view.gunListPanelView.Instantiate();
    }

    public void Click(GameObject cell)
    {
        int id = Int32.Parse(cell.name);

        GunData currentGun = app.model.gunModel.GetGunDataById(id);

        if (GameManager.use.GetCoins() < currentGun.price) return;
        GameManager.use.RemoveCoins(currentGun.price);
        
        app.model.pointModel.SetCurrentPointData(currentGun);

        PointData currentPointData = app.model.pointModel.GetCurrentPointData();
        GameObject currentPointGameObject = app.model.pointModel.GetCurrentPointGameObject();

        app.view.pointView.RedrawPoints();

        //GameObject gunPrefab = Resources.Load("Prefabs/Bit2/Laser") as GameObject;
        //GameObject gunInstantiate = Instantiate(gunPrefab, currentPointGameObject.transform.position, currentPointGameObject.transform.rotation) as GameObject;


        //gunInstantiate.transform.SetParent(currentPointGameObject.transform);
        //gunInstantiate.transform.localPosition = gunPrefab.transform.position;//new Vector3(0.31f, 0f, 0f);
        //gunInstantiate.GetComponent<SpriteRenderer>().color = currentGun.color;

        //gunInstantiate.GetComponent<GunDamageComponent>().SetDamage(currentPointData.damage);

        app.controller.achievementController.AddLevel(1, 1);// first laser
        app.controller.achievementController.AddLevel(4, 1);// 6 lasers

        if (currentPointData.name.Equals("Tiny Plasma Laser"))
        {
            app.controller.achievementController.AddLevel(5, 1);
        }
        if (currentPointData.name.Equals("Plasma Ray Laser"))
        {
            app.controller.achievementController.AddLevel(9, 1);
        }
        if (currentPointData.name.Equals("Fat Red Laser"))
        {
            app.controller.achievementController.AddLevel(13, 1);
        }
        if (currentPointData.name.Equals("Tiny Wave Laser"))
        {
            app.controller.achievementController.AddLevel(17, 1);
        }
        if (currentPointData.name.Equals("Double Red Laser"))
        {
            app.controller.achievementController.AddLevel(21, 1);
        }
        if (currentPointData.name.Equals("Fat Wave Laser"))
        {
            app.controller.achievementController.AddLevel(25, 1);
        }
        if (currentPointData.name.Equals("Fat Plasma Laser"))
        {
            app.controller.achievementController.AddLevel(29, 1);
        }
        if (currentPointData.name.Equals("Microwave Blue Laser"))
        {
            app.controller.achievementController.AddLevel(33, 1);
        }
        if (currentPointData.name.Equals("Point Ray Laser"))
        {
            app.controller.achievementController.AddLevel(37, 1);
        }
        if (currentPointData.name.Equals("Electric Red Laser"))
        {
            app.controller.achievementController.AddLevel(39, 1);
        }
        if (currentPointData.name.Equals("Yellow Ray Laser"))
        {
            app.controller.achievementController.AddLevel(41, 1);
        }

        UiManager.use.HideGunListPanel();

        //save
        SaveManager.use.SavePoints();

    }

    public void Sell()
    {
        PointData currentPointData = app.model.pointModel.GetCurrentPointData();
        long coinsBack = currentPointData.price / 2;
        GameManager.use.AddCoins(coinsBack);

        //Destroy(app.model.pointModel.GetCurrentPointGameObject());

        app.model.pointModel.ResetCurrentPointData();

        app.view.pointView.RedrawPoints();

        UiManager.use.HideGunPanel();
    }

    public void Upgrade()
    {
        PointData currentPointData = app.model.pointModel.GetCurrentPointData();

        if (GameManager.use.GetCoins() < currentPointData.upgradePrice) return;

        GameManager.use.RemoveCoins(currentPointData.upgradePrice);

        app.model.pointModel.UpgradeCurrentPoint();
        app.view.pointView.RedrawPoints();

        app.controller.achievementController.AddLevel(2, 1); // upgrade first laser

        if (currentPointData.name.Equals("Tiny Plasma Laser"))
        {
            app.controller.achievementController.AddLevel(6, 1);
        }
        if (currentPointData.name.Equals("Plasma Ray Laser"))
        {
            app.controller.achievementController.AddLevel(10, 1);
        }
        if (currentPointData.name.Equals("Fat Red Laser"))
        {
            app.controller.achievementController.AddLevel(14, 1);
        }
        if (currentPointData.name.Equals("Tiny Wave Laser"))
        {
            app.controller.achievementController.AddLevel(18, 1);
        }
        if (currentPointData.name.Equals("Double Red Laser"))
        {
            app.controller.achievementController.AddLevel(22, 1);
        }
        if (currentPointData.name.Equals("Fat Wave Laser"))
        {
            app.controller.achievementController.AddLevel(26, 1);
        }
        if (currentPointData.name.Equals("Fat Plasma Laser"))
        {
            app.controller.achievementController.AddLevel(30, 1);
        }
        if (currentPointData.name.Equals("Microwave Blue Laser"))
        {
            app.controller.achievementController.AddLevel(34, 1);
        }
        if (currentPointData.name.Equals("Point Ray Laser"))
        {
            app.controller.achievementController.AddLevel(38, 1);
        }
        if (currentPointData.name.Equals("Electric Red Laser"))
        {
            app.controller.achievementController.AddLevel(40, 1);
        }
        if (currentPointData.name.Equals("Yellow Ray Laser"))
        {
            app.controller.achievementController.AddLevel(42, 1);
        }

        UiManager.use.HideGunPanel();

        SaveManager.use.SavePoints();
    }

    public void UpdateGunCells()
    {
        app.view.gunListPanelView.UpdateGunCells();
    }

    public void UpdateUpgradeButton()
    {
        app.view.gunPanelView.UpdateUpgradeButton();
    }
}
