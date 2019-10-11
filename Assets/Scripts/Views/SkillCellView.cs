using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCellView : BoxClickerElement
{
    public void ClickListener(GameObject cell)
    {
        app.controller.skillController.Click(cell);
    }
}
