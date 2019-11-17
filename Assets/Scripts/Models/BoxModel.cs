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
    [SerializeField] private double health;
    [SerializeField] private long coins;
    [SerializeField] private List<BoxData> boxList = new List<BoxData>();

    public void InitializationData()
    {
        id = 0;

        long[] countCoins = new long[12];
        long currentCountCoins = 3;

        for (int i = 2; i < 12; i++)
        {

            currentCountCoins = CountManager.use.IncrementalOfNumber(currentCountCoins, i);
            countCoins[i] = currentCountCoins;
        }

        // [id] [color] [health] [coins] [experience]
        // coins = coins * 5 - price
        boxList.Add(new BoxData(0, "Box_01", 5, 6, 1, 0.5f));
        boxList.Add(new BoxData(1, "Box_02", 25, 20, 1, 0.5f));
        boxList.Add(new BoxData(2, "Box_03", 125, 60, 1, 0.5f));
        boxList.Add(new BoxData(3, "Box_04", 625, 160, 1, 0.5f));
        boxList.Add(new BoxData(4, "Box_05", 3125, 640, 1, 0.5f));
        boxList.Add(new BoxData(5, "Box_06", 15625, 2500, 1, 0.5f));
        boxList.Add(new BoxData(6, "Box_07", 78128, 10000, 1, 0.5f));
        boxList.Add(new BoxData(7, "Box_08", 390625, 40000, 1, 0.5f));
        boxList.Add(new BoxData(8, "Box_09", 1953125, 150000, 1, 0.5f));
        boxList.Add(new BoxData(9, "Box_10", 9765625, 600000, 1, 0.5f));
        boxList.Add(new BoxData(10, "Box_10", 48828125, 2500000, 1, 0.5f));
        boxList.Add(new BoxData(11, "Box_10", 244140625, 10000000, 1, 0.5f));
        boxList.Add(new BoxData(12, "Box_10", 1220703125, 40000000, 1, 0.5f));
        ResetBox();
    }

    public GameObject GetBoxContainer() { return this.boxContainer; }
    public GameObject GetPoints() { return this.points; }
    public BoxData GetBox(){ return this.boxList[id]; }
    public double GetHealth(){ return health; }
    public double GetDefaultHealth(){ return boxList[id].health; }
    public float GetDefaultCoolDown() { return boxList[id].coolDown; }
    public long GetDefaultCoins() { return boxList[id].coins; }
    public void RemoveHealth(double health){ this.health -= health; }
    public void SetHealth(long health){ this.health = health; }
    public bool IsUpgradable(int level)
    {
        if(id+level < boxList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void UpgradeBox(int level){ this.id += level; }

    public void ResetBox()
    {
        BoxData box = boxList[id];

        //this.color = box.color;
        this.health = box.health;
        this.coins = box.coins;
    }

    
}
