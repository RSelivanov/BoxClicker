using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCoinsModel : BoxClickerElement
{
    [SerializeField] private int level;

    public void AddLevel(int level) { this.level += level; }
    public int GetLevel() { return this.level; }
}
