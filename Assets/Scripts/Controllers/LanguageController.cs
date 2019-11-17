using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : BoxClickerElement
{
    public void Initialization()
    {
        app.model.languageModel.Initialization();
        app.view.sceneView.RedrawLanguages();
    }

    public void Click(string language)
    {
        app.model.languageModel.SetCurrentLanguage(language);
        app.view.sceneView.RedrawLanguages();
    }
}
