using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvertisementListener : BoxClickerElement
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonListener);
    }

    void ButtonListener()
    {
        app.view.advertisementView.ClickListener();
    }
}
