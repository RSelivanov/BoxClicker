using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxHealthBarView : BoxClickerElement
{
    [SerializeField]
    private Slider healthBar;


    public void ResetHealth()
    {
        healthBar.maxValue = (float)app.model.boxModel.GetDefaultHealth();
        healthBar.value = (float)app.model.boxModel.GetDefaultHealth();
    }

    public void UpdateHealthView()
    {
        healthBar.value = (float)app.model.boxModel.GetHealth();
    }
}
