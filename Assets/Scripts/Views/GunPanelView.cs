using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPanelView : BoxClickerElement
{
    [SerializeField] private GameObject gunPanelView;
    [SerializeField] private Text titleText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text damageNumberText;
    [SerializeField] private Text coolDownNumberText;
    [SerializeField] private Text damageNumberUpgradeText;
    [SerializeField] private Text coolDownNumberUpgradeText;
    [SerializeField] private Text priceSellText;
    [SerializeField] private Text priceUpgradeText;
    [SerializeField] private Button sellButton;
    [SerializeField] private Button upgradeButton;

    [SerializeField] private Sprite activeButton;
    [SerializeField] private Sprite deActiveButton;

    [SerializeField] private Sprite activeCoin;
    [SerializeField] private Sprite deActiveCoin;

    //Tech
    private string levelPrefix = "Level ";

    void Start()
    {
        sellButton.onClick.AddListener(SellButtonListener);
        upgradeButton.onClick.AddListener(UpgradeButtonListener);

        activeButton = Resources.Load<Sprite>("Sprites/Buttons_Blue");
        deActiveButton = Resources.Load<Sprite>("Sprites/Buttons_Gray");

        activeCoin = Resources.Load<Sprite>("Sprites/Coin");
        deActiveCoin = Resources.Load<Sprite>("Sprites/Coin_Gray");
    }

    public void SetPanel(PointData point)
    {
        titleText.text = point.name;
        levelText.text = levelPrefix + point.level;

        damageNumberText.text = Math.Round(Convert.ToDecimal(point.damage), 2).ToString();
        coolDownNumberText.text = Math.Round(Convert.ToDecimal(point.coolDown), 2).ToString();

        damageNumberUpgradeText.text = Math.Round(Convert.ToDecimal(point.upgradeDamage), 2).ToString();
        coolDownNumberUpgradeText.text = Math.Round(Convert.ToDecimal(point.upgradeCoolDown), 2).ToString();

        priceSellText.text = (point.price / 2).ToString();
        priceUpgradeText.text = point.upgradePrice.ToString();
        UiManager.use.ShowGunPanel();
    }

    void SellButtonListener()
    {
        if (UiManager.use.IsCoolDown()) return;
        app.controller.gunController.Sell();
    }

    void UpgradeButtonListener()
    {
        if (UiManager.use.IsCoolDown()) return;
        app.controller.gunController.Upgrade();
    }

    public void UpdateUpgradeButton()
    {
        PointData currentPoint = app.model.pointModel.GetCurrentPointData();

        if (currentPoint == null) return;

        if (currentPoint.upgradePrice <= GameManager.use.GetCoins())
        {
            upgradeButton.GetComponent<Image>().sprite = activeButton;
            upgradeButton.transform.GetChild(2).GetComponent<Image>().sprite = activeCoin;
        }
        else
        {
            upgradeButton.GetComponent<Image>().sprite = deActiveButton;
            upgradeButton.transform.GetChild(2).GetComponent<Image>().sprite = deActiveCoin;
        }
    }
}
