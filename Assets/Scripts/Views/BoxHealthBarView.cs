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
        healthBar.maxValue = app.model.boxModel.GetDefaultHealth();
        healthBar.value = app.model.boxModel.GetDefaultHealth();
    }

    public void UpdateHealthView()
    {
        healthBar.value = app.model.boxModel.GetHealth();
    }
}
