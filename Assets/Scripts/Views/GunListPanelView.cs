using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunListPanelView : BoxClickerElement
{
    private List<GunData> gunList;

    [SerializeField] private Sprite activeCell;
    [SerializeField] private Sprite deActiveCell;

    [SerializeField] private Sprite activeCoin;
    [SerializeField] private Sprite deActiveCoin;

    public void Instantiate()
    {
        GameObject content = app.model.gunModel.GetContent();
        gunList = app.model.gunModel.GetGunList();

        activeCell = Resources.Load<Sprite>("Sprites/CellBg");
        deActiveCell = Resources.Load<Sprite>("Sprites/CellBg_Gray");

        activeCoin = Resources.Load<Sprite>("Sprites/Coin");
        deActiveCoin = Resources.Load<Sprite>("Sprites/Coin_Gray");

        foreach (GunData gun in gunList)
        {
            //string[] cellNamesArray = { "GunCell_01", "GunCell_02" };

            GameObject gunCellPrefab = Resources.Load("Prefabs/Bit4/GunCell_01") as GameObject;
            GameObject gunCellInstantiate = Instantiate(gunCellPrefab, content.transform.position, content.transform.rotation) as GameObject;

            gunCellInstantiate.name = gun.id.ToString();

            //gunCellInstantiate.transform.GetChild(0).GetComponent<Image>().color = gun.color;
            gunCellInstantiate.transform.GetChild(0).GetComponent<Text>().text = gun.name; //Title
            gunCellInstantiate.transform.GetChild(1).GetComponent<Text>().text = gun.damage.ToString(); //Damage
            gunCellInstantiate.transform.GetChild(2).GetComponent<Text>().text = gun.coolDown.ToString(); //CoolDown
            gunCellInstantiate.transform.GetChild(3).GetComponent<Text>().text = gun.price.ToString(); //Price

            gunCellInstantiate.transform.SetParent(content.transform);
            gunCellInstantiate.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void UpdateGunCells()
    {
        GameObject content = app.model.gunModel.GetContent();
        gunList = app.model.gunModel.GetGunList();

        for (int i = 0; i < gunList.Count; i++)
        {
            if(gunList[i].price <= GameManager.use.GetCoins())
            {
                content.transform.GetChild(i).GetComponent<Image>().sprite = activeCell;
                content.transform.GetChild(i).transform.GetChild(4).GetComponent<Image>().sprite = activeCoin;
            }
            else
            {
                content.transform.GetChild(i).GetComponent<Image>().sprite = deActiveCell;
                content.transform.GetChild(i).transform.GetChild(4).GetComponent<Image>().sprite = deActiveCoin;
            }
        }
    }
}
