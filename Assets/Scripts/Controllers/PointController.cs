using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : BoxClickerElement
{
    public void Initialization()
    {
        app.model.pointModel.InitializationData();
    }

    public void Click(GameObject currentPoint)
    {
        app.model.pointModel.SetCurrentPointName(currentPoint.name);

        if (app.model.pointModel.IsCurrentPointEmpty())
        {
            //SetGunListPanel
            //app.view.gunListPanelView.Show();
            UiManager.use.ShowGunListPanel();
        }
        else
        {
            //SetGunPanel
            PointData pointData = app.model.pointModel.GetPointData(currentPoint.name);
            app.view.gunPanelView.SetPanel(pointData);
        }
    }
}
