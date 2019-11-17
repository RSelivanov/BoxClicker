using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoxController : BoxClickerElement
{
    public void Initialization()
    {
        //UpdateBoxView
        app.view.boxView.UpdateBoxView(app.model.boxModel.GetBox());

        //Reset Health Bar
        app.view.boxHealthBarView.ResetHealth();

        //Update Click Damage
        app.view.boxView.UpdateClickDamage();
    }

    public void Click(double damage)
    {
        if (app.model.boxModel.GetBoxContainer().transform.childCount == 0) return;

        BoxData currentBoxState = app.model.boxModel.GetBox();

        int random = Random.Range(1, 100);
        int criticalChance = app.model.criticalDamageModel.GetLevel();

        if (random <= criticalChance * 5)
        {
            damage = damage * 2;
        }

        if (app.model.boxModel.GetHealth() - damage > 0)
        {
            app.model.boxModel.RemoveHealth(damage);
            app.view.boxView.KickBox();
        }
        else
        { 
            app.model.boxModel.SetHealth(0);

            int extraCoinsLevel = app.model.extraCoinsModel.GetLevel();
            long extraCoins = Convert.ToInt64(Math.Ceiling(CountManager.use.PercentageOfNumber(extraCoinsLevel, currentBoxState.coins)));
            long coins = currentBoxState.coins + extraCoins;

            app.view.boxView.DrawCois(coins);
            app.view.boxView.DrawText(coins);

            GameManager.use.AddCoins(coins);

            //all guns on cool down
            GameObject points = app.model.boxModel.GetPoints();
            foreach (Transform point in points.transform)
            {
                if (point.childCount > 0)
                {
                    point.GetChild(0).GetComponent<GunDamageComponent>().SetBlock();
                }
            }

            app.view.boxView.RemoveBox();

            app.view.boxView.InstantiateBoxParts();

            app.controller.achievementController.AddLevel(0, 1); // destroy first box
            app.controller.achievementController.AddLevel(4, 1); // destroy 500 boxes
            app.controller.achievementController.AddLevel(8, 1); // destroy 500 boxes
            app.controller.achievementController.AddLevel(12, 1); // destroy 1000 boxes
            app.controller.achievementController.AddLevel(16, 1); // destroy 10000 boxes
            app.controller.achievementController.AddLevel(20, 1); // destroy 100000 boxes
            app.controller.achievementController.AddLevel(24, 1); // destroy 1000000 boxes
            app.controller.achievementController.AddLevel(28, 1); // destroy 10000000 boxes
            app.controller.achievementController.AddLevel(32, 1); // destroy 100000000 boxes
            app.controller.achievementController.AddLevel(36, 1); // destroy 1000000000 boxes

            StartCoroutine(BoxCollDown());
        }

        // Update Box View
        //app.view.boxView.UpdateBoxView(currentBoxState);

        // Update Health Bar
        app.view.boxHealthBarView.UpdateHealthView();
    }

    IEnumerator BoxCollDown()
    {
        BoxData currentBoxState = app.model.boxModel.GetBox();

        yield return new WaitForSeconds(currentBoxState.coolDown);

        // Instantiate Box
        app.view.boxView.InstantiateBox();

        //ResetBox
        app.model.boxModel.ResetBox();

        // Update Box View
        //app.view.boxView.UpdateBoxView(currentBoxState);

        // Reset Health Bar
        app.view.boxHealthBarView.ResetHealth();

        yield return new WaitForSeconds(currentBoxState.coolDown + 0.5f);

        //all guns to off cool down
        GameObject points = app.model.boxModel.GetPoints();
        foreach (Transform point in points.transform)
        {
            if (point.childCount > 0)
            {
                point.GetChild(0).GetComponent<GunDamageComponent>().UnSetBlock();
            }
        }
    }
}
