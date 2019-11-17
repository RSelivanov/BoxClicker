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
        // [id] [name] [color] [price] [damage] //x5
        gunList.Add(new GunData(0, "Tiny Red Laser", "Gun_01", 25, 1, 5f)); //25 / 1
        gunList.Add(new GunData(1, "Tiny Plasma Laser", "Gun_02", 125, 5, 5f)); // 125 / 5
        gunList.Add(new GunData(2, "Plasma Ray Laser", "Gun_03", 625, 25, 5f)); // 625 / 25
        gunList.Add(new GunData(3, "Fat Red Laser", "Gun_04", 3000, 150, 5f)); // 3125 / 150
        gunList.Add(new GunData(4, "Tiny Wave Laser", "Gun_05", 15000, 625, 5f)); // 15625 / 625
        gunList.Add(new GunData(5, "Double Red Laser", "Gun_06", 80000, 3125, 5f)); // 78125 / 3125
        gunList.Add(new GunData(6, "Fat Wave Laser", "Gun_07", 400000, 15625, 5f)); // 390625 / 15625
        gunList.Add(new GunData(7, "Fat Plasma Laser", "Gun_08", 2000000, 78125, 5f)); // 1953125 / 78125 
        gunList.Add(new GunData(8, "Microwave Blue Laser", "Gun_09", 10000000, 390625, 5f)); // 9765625 / 390625
        gunList.Add(new GunData(9, "Point Ray Laser", "Gun_10", 50000000, 1953125, 5f)); // 48828125 / 1953125
        gunList.Add(new GunData(10, "Electric Red Laser", "Gun_11", 250000000, 9765625, 5f)); // 244140625 / 9765625
        gunList.Add(new GunData(11, "Yellow Ray Laser", "Gun_12", 1000000000, 48828125, 5f)); // 1220703125 / 48828125
    }

    public List<GunData> GetGunList() { return gunList; }
    public GameObject GetContent() { return content; }

    public GunData GetGunDataById(int id)
    {
        return gunList[id];
    }
}
