using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertisementController : BoxClickerElement
{
    public void Initialization()
    {
        app.model.advertisementModel.Initialization();
        app.view.advertisementView.Initialization();
    }
}
