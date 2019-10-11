using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunCellView : BoxClickerElement
{
    public void ClickListener(GameObject cell)
    {
        app.controller.gunController.Click(cell);
    }
}
