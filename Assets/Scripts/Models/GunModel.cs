using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunModel : BoxClickerElement
{
    [SerializeField] private GameObject content;

    private List<GunData> gunList = new List<GunData>();

    public void Instantiate()
    {
        // [id] [name] [color] [price] [damage]  //x5 (price)
        gunList.Add(new GunData(0, "Light Laser I", "Gun_01", 25, 1, 5f)); 
        gunList.Add(new GunData(1, "Light Laser II", "Gun_01", 125, 5, 5f));
        gunList.Add(new GunData(2, "Light Laser III", "Gun_01", 625, 25, 5f));
        gunList.Add(new GunData(3, "Hard Laser I", "Gun_01", 3125, 150, 5f));
        gunList.Add(new GunData(4, "Hard Laser II", "Gun_01", 15625, 625, 5f));
        gunList.Add(new GunData(5, "Hard Laser III", "Gun_01", 78125, 3125, 5f));
    }

    public List<GunData> GetGunList() { return gunList; }
    public GameObject GetContent() { return content; }

    public GunData GetGunDataById(int id)
    {
        return gunList[id];
    }
}
