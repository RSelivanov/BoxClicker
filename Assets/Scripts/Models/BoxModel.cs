using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxModel : MonoBehaviour
{
    [SerializeField] private GameObject boxContainer;
    [SerializeField] private GameObject points;
    [SerializeField] private bool coolDown;
    [SerializeField] private int id;
    [SerializeField] private Color color;
    [SerializeField] private float health;
    [SerializeField] private int coins;
    [SerializeField] private List<BoxData> boxList = new List<BoxData>();

    public void InitializationData()
    {
        id = 0;

        // [id] [color] [health] [coins] [experience]
        boxList.Add(new BoxData(0, "spriteName", 5, 5, 1, 0.5f));
        boxList.Add(new BoxData(1, "spriteName", 25, 25, 1, 0.5f));
        boxList.Add(new BoxData(2, "spriteName", 125, 125, 1, 0.5f));
        boxList.Add(new BoxData(3, "spriteName", 625, 625, 1, 0.5f));
        boxList.Add(new BoxData(4, "spriteName", 3125, 3125, 1, 0.5f));
        boxList.Add(new BoxData(4, "spriteName", 15625, 15625, 1, 0.5f));

        ResetBox();
    }

    public GameObject GetBoxContainer() { return this.boxContainer; }
    public GameObject GetPoints() { return this.points; }
    public BoxData GetBox(){ return this.boxList[id]; }
    public float GetHealth(){ return health; }
    public float GetDefaultHealth(){ return boxList[id].health; }
    public void RemoveHealth(float health){ this.health -= health; }
    public void SetHealth(float health){ this.health = health; }
    public void UpgradeBox(int level){ this.id += level; }

    public void ResetBox()
    {
        BoxData box = boxList[id];

        //this.color = box.color;
        this.health = box.health;
        this.coins = box.coins;
    }

    
}
