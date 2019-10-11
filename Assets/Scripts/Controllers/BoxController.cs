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
        app.model.boxModel.InitializationData();

        BoxData box = app.model.boxModel.GetBox();

        //Instantiate Box
        app.view.boxView.InstantiateBox();

        //UpdateBoxView
        app.view.boxView.UpdateBoxView(app.model.boxModel.GetBox());

        //Reset Health Bar
        app.view.boxHealthBarView.ResetHealth();

        //Update Click Damage
        app.view.boxView.UpdateClickDamage();

    }

    public void Click(float damage)
    {
        if (app.model.boxModel.GetBoxContainer().transform.childCount == 0) return;

        BoxData currentBoxState = app.model.boxModel.GetBox();

        if (app.model.boxModel.GetHealth() - damage > 0)
        {
            app.model.boxModel.RemoveHealth(damage);
            app.view.boxView.KickBox();
        }
        else
        { 
            app.model.boxModel.SetHealth(0);

            app.view.boxView.DrawCois(currentBoxState.coins);
            app.view.boxView.DrawText(currentBoxState.coins);

            GameManager.use.AddCoins(currentBoxState.coins);

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

            StartCoroutine(BoxCollDown());
        }

        // Update Box View
        app.view.boxView.UpdateBoxView(currentBoxState);

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
        app.view.boxView.UpdateBoxView(currentBoxState);

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
