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

        app.controller.achievementController.OpenAchievement(0);

        UiManager.use.HideGunListPanel();

        //save
        SaveManager.use.SavePoints();

    }

    public void Sell()
    {
        PointData currentPointData = app.model.pointModel.GetCurrentPointData();
        int coinsBack = currentPointData.price / 2;
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
