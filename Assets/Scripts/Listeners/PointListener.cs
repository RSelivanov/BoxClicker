using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointListener : BoxClickerElement
{
    void OnMouseDown()
    {
        if (UiManager.use.IsUiOpen()) return;
        app.view.pointView.ClickListener(this.gameObject);
    }
}
