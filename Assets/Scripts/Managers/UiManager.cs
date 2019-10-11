using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager use = null;

    void Awake()
    {
        use = this;
    }
    //----------------------------------

    public GameObject GunList;
    public GameObject GunPanel;
    public GameObject SkillList;
    public GameObject SettingsList;
    public GameObject AchievementList;

    private bool uiOpen;
    public bool IsUiOpen() { return uiOpen; }

    private bool uiCoolDown;
    public bool IsCoolDown() { return uiCoolDown; }

    public void ShowGunListPanel()
    {
        GunList.SetActive(true);
        uiOpen = true;
        uiCoolDown = true;
        StartCoroutine(CoolDownDisable());
    }
    public void HideGunListPanel()
    {
        GunList.SetActive(false);
        uiOpen = false;
    }

    public void ShowGunPanel()
    {
        GunPanel.SetActive(true);
        uiOpen = true;
        uiCoolDown = true;
        StartCoroutine(CoolDownDisable());
    }
    public void HideGunPanel()
    {
        GunPanel.SetActive(false);
        uiOpen = false;
    }

    public void ShowSkillListPanel()
    {
        SkillList.SetActive(true);
        uiOpen = true;
        uiCoolDown = true;
        StartCoroutine(CoolDownDisable());
    }
    public void HideSkillListPanel()
    {
        SkillList.SetActive(false);
        uiOpen = false;
        //Save
        SaveManager.use.SaveSkills();
    }

    public void ShowSettingsListPanel()
    {
        SettingsList.SetActive(true);
        uiOpen = true;
        uiCoolDown = true;
        StartCoroutine(CoolDownDisable());
    }
    public void HideSettingsListPanel()
    {
        SettingsList.SetActive(false);
        uiOpen = false;
    }

    public void ShowAchievementListPanel()
    {
        AchievementList.SetActive(true);
        uiOpen = true;
        uiCoolDown = true;
        StartCoroutine(CoolDownDisable());
    }
    public void HideAchievementListPanel()
    {
        AchievementList.SetActive(false);
        uiOpen = false;
    }

    IEnumerator CoolDownDisable()
    {
        yield return new WaitForSeconds(0.2f);
        uiCoolDown = false;
    }
}
