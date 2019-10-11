using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxListener : BoxClickerElement
{
    void OnMouseDown()
    {
        if (UiManager.use.IsUiOpen()) return;
        app.view.boxView.ClickListener(this.gameObject);
    }
}
