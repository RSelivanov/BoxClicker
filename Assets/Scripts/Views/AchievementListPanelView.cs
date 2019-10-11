using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementListPanelView : BoxClickerElement
{
    private List<AchievementData> achievementList;

    [SerializeField] private Sprite activeCell;
    [SerializeField] private Sprite deActiveCell;

    [SerializeField] private Sprite activeCoin;
    [SerializeField] private Sprite deActiveCoin;

    [SerializeField] private Sprite activeCheckBox;
    [SerializeField] private Sprite deActiveCheckBox;

    public void Instantiate()
    {
        GameObject content = app.model.achievementModel.GetContent();
        achievementList = app.model.achievementModel.GetAchievementList();

        activeCell = Resources.Load<Sprite>("Sprites/CellBg");
        deActiveCell = Resources.Load<Sprite>("Sprites/CellBg_Gray");

        activeCoin = Resources.Load<Sprite>("Sprites/Coin");
        deActiveCoin = Resources.Load<Sprite>("Sprites/Coin_Gray");

        activeCheckBox = Resources.Load<Sprite>("Sprites/ButtonCheckBox");
        deActiveCheckBox = Resources.Load<Sprite>("Sprites/ButtonCheckBox_Gray");

        foreach (AchievementData achievement in achievementList)
        {
            //string[] cellNamesArray = { "SkillCell_01", "SkillCell_01" };

            GameObject achievementCellPrefab = Resources.Load("Prefabs/Bit4/AchievementCell_01") as GameObject;
            GameObject achievementCellInstantiate = Instantiate(achievementCellPrefab, content.transform.position, content.transform.rotation) as GameObject;

            achievementCellInstantiate.name = achievement.id.ToString();

            achievementCellInstantiate.transform.GetChild(0).GetComponent<Text>().text = achievement.title; // Description
            achievementCellInstantiate.transform.GetChild(1).GetComponent<Text>().text = achievement.coins.ToString(); // Coins          

            if (achievement.isOpen)
            {
                achievementCellInstantiate.transform.GetChild(3).GetComponent<Image>().color = new Color(1,1,1,1);
                achievementCellInstantiate.GetComponent<Image>().sprite = activeCell;
                achievementCellInstantiate.transform.GetChild(4).GetComponent<Image>().sprite = activeCoin;
                achievementCellInstantiate.transform.GetChild(2).GetComponent<Image>().sprite = activeCheckBox;
            }
            else
            {
                achievementCellInstantiate.transform.GetChild(3).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                achievementCellInstantiate.GetComponent<Image>().sprite = deActiveCell;
                achievementCellInstantiate.transform.GetChild(4).GetComponent<Image>().sprite = deActiveCoin;
                achievementCellInstantiate.transform.GetChild(2).GetComponent<Image>().sprite = deActiveCheckBox;
            }

            achievementCellInstantiate.transform.SetParent(content.transform);
            achievementCellInstantiate.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void Redraw()
    {
        achievementList = app.model.achievementModel.GetAchievementList();
        GameObject content = app.model.achievementModel.GetContent();

        for (int i = 0; i < content.transform.childCount; i++)
        {
            if (achievementList[i].isOpen)
            {
                content.transform.GetChild(i).transform.GetChild(3).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                content.transform.GetChild(i).transform.GetChild(3).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void UpdateAchievementCells()
    {
        GameObject content = app.model.achievementModel.GetContent();
        achievementList = app.model.achievementModel.GetAchievementList();

        for (int i = 0; i < achievementList.Count; i++)
        {
            if (achievementList[i].isOpen)
            {
                content.transform.GetChild(i).GetComponent<Image>().sprite = activeCell;
                content.transform.GetChild(i).transform.GetChild(4).GetComponent<Image>().sprite = activeCoin;
                content.transform.GetChild(i).transform.GetChild(2).GetComponent<Image>().sprite = activeCheckBox;
            }
            else
            {
                content.transform.GetChild(i).GetComponent<Image>().sprite = deActiveCell;
                content.transform.GetChild(i).transform.GetChild(4).GetComponent<Image>().sprite = deActiveCoin;
                content.transform.GetChild(i).transform.GetChild(2).GetComponent<Image>().sprite = deActiveCheckBox;
            }
        }
    }

}
