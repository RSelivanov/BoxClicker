using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageView : BoxClickerElement
{
    public void ClickListener(GameObject languageCell)
    {
        app.controller.languageController.Click(languageCell.name);
    }
}
