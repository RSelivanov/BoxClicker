using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillListPanelView : BoxClickerElement
{
    private List<SkillData> skillList;

    [SerializeField] private Sprite activeCell;
    [SerializeField] private Sprite deActiveCell;

    [SerializeField] private Sprite activeCoin;
    [SerializeField] private Sprite deActiveCoin;

    public void Instantiate()
    {
        GameObject content = app.model.skillModel.GetContent();
        skillList = app.model.skillModel.GetSkillList();

        activeCell = Resources.Load<Sprite>("Sprites/CellBg");
        deActiveCell = Resources.Load<Sprite>("Sprites/CellBg_Gray");

        activeCoin = Resources.Load<Sprite>("Sprites/Coin");
        deActiveCoin = Resources.Load<Sprite>("Sprites/Coin_Gray");

        foreach (SkillData skill in skillList)
        {
            //string[] cellNamesArray = { "SkillCell_01", "SkillCell_01" };

            GameObject skillCellPrefab = Resources.Load("Prefabs/SkillCell") as GameObject;
            GameObject skillCellInstantiate = Instantiate(skillCellPrefab, content.transform.position, content.transform.rotation) as GameObject;

            skillCellInstantiate.name = skill.id.ToString();

            skillCellInstantiate.transform.GetChild(0).GetComponent<Text>().text = skill.title; //Title
            skillCellInstantiate.transform.GetChild(1).GetComponent<Text>().text = skill.description; //Description            
            skillCellInstantiate.transform.GetChild(2).GetComponent<Text>().text = skill.level.ToString(); //Level
            skillCellInstantiate.transform.GetChild(3).GetComponent<Text>().text = skill.price.ToString(); //Price

            skillCellInstantiate.transform.SetParent(content.transform);
            skillCellInstantiate.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void UpdateSkillCell(SkillData skillData)
    {
        GameObject content = app.model.skillModel.GetContent();

        foreach (Transform skill in content.transform)
        {
            if (skill.name == skillData.id.ToString())
            {
                skill.transform.GetChild(0).GetComponent<Text>().text = skillData.title; //Title
                skill.transform.GetChild(1).GetComponent<Text>().text = skillData.description; //Description
                skill.transform.GetChild(2).GetComponent<Text>().text = skillData.level.ToString(); //Level
                skill.transform.GetChild(3).GetComponent<Text>().text = skillData.price.ToString(); //Price
            }
        }
    }
    public void Redraw()
    {
        skillList = app.model.skillModel.GetSkillList();
        GameObject content = app.model.skillModel.GetContent();

        for (int i = 0; i < content.transform.childCount; i++)
        {
            content.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = skillList[i].title; //Title
            content.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = skillList[i].description; //Description            
            content.transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = skillList[i].level.ToString(); //Level
            content.transform.GetChild(i).transform.GetChild(3).GetComponent<Text>().text = skillList[i].price.ToString(); //Price
        }
    }

    public void UpdateSkillCells()
    {
        GameObject content = app.model.skillModel.GetContent();
        skillList = app.model.skillModel.GetSkillList();

        for (int i = 0; i < skillList.Count; i++)
        {
            if (skillList[i].price <= GameManager.use.GetCoins())
            {
                content.transform.GetChild(i).GetComponent<Image>().sprite = activeCell;
                content.transform.GetChild(i).transform.GetChild(5).GetComponent<Image>().sprite = activeCoin;
            }
            else
            {
                content.transform.GetChild(i).GetComponent<Image>().sprite = deActiveCell;
                content.transform.GetChild(i).transform.GetChild(5).GetComponent<Image>().sprite = deActiveCoin;
            }
        }
    }
}
