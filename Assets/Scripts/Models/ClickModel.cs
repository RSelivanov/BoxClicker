using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickModel : MonoBehaviour
{
    [SerializeField]private int damage;

    public void UpgradeClickDamage(int damage) { this.damage += damage; }
    public int GetClickDamage() { return this.damage; }
}
