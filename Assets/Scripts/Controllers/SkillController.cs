using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : BoxClickerElement
{
    private List<SkillData> skillList;

    public void Initialization()
    {
        app.model.skillModel.Instantiate();
        app.view.skillListPanelView.Instantiate();

        //execute loaded skills
        skillList = app.model.skillModel.GetSkillList();
        for (int i = 0; i < skillList.Count; i++)
        {
            switch (i)
            {
                case 0:
                    int currenClickDamage;
                    for (int n = 0; n < skillList[i].level; n++)
                    {
                        currenClickDamage = app.model.clickModel.GetClickDamage();
                        app.model.clickModel.UpgradeClickDamage(currenClickDamage);
                    }
                    app.view.boxView.UpdateClickDamage();
                    break;
                case 1:
                    // Upgrade Box
                    app.model.boxModel.UpgradeBox(skillList[i].level);

                    // Reset Box
                    app.model.boxModel.ResetBox();

                    // Update Box View
                    BoxData currentBoxState = app.model.boxModel.GetBox();
                    app.view.boxView.UpdateBoxView(currentBoxState);

                    // Reset Health Bar
                    app.view.boxHealthBarView.ResetHealth();

                    break;
                default:
                    //print("Default");
                    break;
            }
        }
    }

    public void Click(GameObject currentCell)
    {
        int cellId = Int32.Parse(currentCell.name);

        //money
        SkillData skill = app.model.skillModel.GetSkillDataById(cellId);

        if (GameManager.use.GetCoins() < skill.price) return;

        GameManager.use.RemoveCoins(skill.price);

        switch (cellId)
        {
            case 0:
                int currenClickDamage = app.model.clickModel.GetClickDamage();
                app.model.clickModel.UpgradeClickDamage(currenClickDamage);
                app.view.boxView.UpdateClickDamage();

                // Update skill
                app.model.skillModel.UpdateSkill(cellId);

                // Redraw skills
                app.view.skillListPanelView.Redraw();

                //UiManager.use.HideSkillListPanel();

                break;
            case 1:
                // Upgrade Box
                app.model.boxModel.UpgradeBox(1);

                // Reset Box
                app.model.boxModel.ResetBox();

                // Update Box View
                BoxData currentBoxState = app.model.boxModel.GetBox();
                app.view.boxView.UpdateBoxView(currentBoxState);

                // Reset Health Bar
                app.view.boxHealthBarView.ResetHealth();

                // Update skill
                app.model.skillModel.UpdateSkill(cellId);

                // Redraw skills
                app.view.skillListPanelView.Redraw();

                //UiManager.use.HideSkillListPanel();

                break;
            case 2:
                print("Execute upgrade 2");
                break;
            default:
                print("Default");
                break;
        }
    }

    public void UpdateSkillCells()
    {
        app.view.skillListPanelView.UpdateSkillCells();
    }
}
