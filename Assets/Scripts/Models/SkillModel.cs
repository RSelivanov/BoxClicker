using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillModel : BoxClickerElement
{
    [SerializeField]
    private GameObject сontent;
    [SerializeField]
    private List<SkillData> skillList = new List<SkillData>();

    public void Instantiate()
    {
        List<SkillData> loadSkillList = SaveManager.use.LoadSkills();
        if (loadSkillList != null)
        {
            skillList = loadSkillList;
            app.view.pointView.RedrawPoints();
        }
        else
        {
            // [id] [name] [color] [price] [damage]   
            skillList.Add(new SkillData(0, "Double Bust (X2)", "Ad", 1, 0));
            skillList.Add(new SkillData(1, "Click", "Increases the effect of clicking twice", 500, 0));
            skillList.Add(new SkillData(2, "Upgrade Box", "Improve the box", 500, 0));
            skillList.Add(new SkillData(3, "Extra Coins", "Gives extra coins after destroying the box", 2500, 0));
            skillList.Add(new SkillData(4, "Сritical damage", "Increases chance of critical damage", 5000, 0));
            skillList.Add(new SkillData(5, "Element 1", "Discription", 500, 0));
            skillList.Add(new SkillData(6, "Element 2", "Discription", 500, 0));
            skillList.Add(new SkillData(7, "Element 3", "Discription", 500, 0));
            skillList.Add(new SkillData(8, "Element 4", "Discription", 500, 0));
        }
    }

    public GameObject GetContent() { return this.сontent; }
    public List<SkillData> GetSkillList() { return this.skillList; }
    public SkillData GetSkillDataById(int id) { return this.skillList[id]; }

    public void UpdateSkill(int id)
    {
        this.skillList[id].price = this.skillList[id].price * 2;
        this.skillList[id].level ++;
    }
}
