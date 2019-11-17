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
            skillList.Add(new SkillData(0, "Click", "Increases clicking effect", 500, 0));
            skillList.Add(new SkillData(1, "Box", "Improve the box", 1000, 0));
            skillList.Add(new SkillData(2, "Extra Coins", "Gives extra coins", 300, 0));
            skillList.Add(new SkillData(3, "Сritical damage", "Increases chance of critical damage", 100, 0));
        }
    }

    public GameObject GetContent() { return this.сontent; }
    public List<SkillData> GetSkillList() { return this.skillList; }
    public SkillData GetSkillDataById(int id) { return this.skillList[id]; }

    public void UpdateSkill(int id)
    {
        this.skillList[id].price = this.skillList[id].price * 5;
        this.skillList[id].level ++;
        //this.skillList[id].price = CountManager.use.IncrementalOfNumber(this.skillList[id].price, this.skillList[id].level);
    }
}
