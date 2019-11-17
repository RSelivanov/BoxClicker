using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalDamageModel : BoxClickerElement
{
    [SerializeField] private int level;

    public void AddLevel(int level) { this.level += level; }
    public int GetLevel() { return this.level; }
}
