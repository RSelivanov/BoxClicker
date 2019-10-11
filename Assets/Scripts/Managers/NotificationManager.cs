using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : BoxClickerElement
{
    public static NotificationManager use = null;

    public GameObject notificationContainer;

    Dictionary<string, string> mesages = new Dictionary<string, string>();

    private IEnumerator destroNotificationCoolDown;

    void Awake()
    {
        use = this;

        mesages.Add("no_coins", "You don't have enough coins!");
    }
    //-----------------------------------------
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void ShowMessage(string key)
    {
        destroNotificationCoolDown = DestroyNotification();

        if (notificationContainer.transform.childCount > 0) Destroy(notificationContainer.transform.GetChild(0).transform.gameObject);
        StopCoroutine(destroNotificationCoolDown);

        GameObject notificationPrefab = Resources.Load("Prefabs/Bit4/Notification2") as GameObject;
        GameObject notificationInstantiate = Instantiate(notificationPrefab, new Vector3(0f, 0f, 0f), transform.rotation) as GameObject;

        notificationInstantiate.transform.GetChild(0).GetComponent<Text>().text = mesages[key];

        notificationInstantiate.transform.SetParent(notificationContainer.transform);
        notificationInstantiate.transform.localScale = new Vector3(1f, 1f, 1f);
        notificationInstantiate.transform.localPosition = new Vector3(-400f, -100f, 0f);

        StartCoroutine(destroNotificationCoolDown);
    }

    public void ShowAchievement(int id)
    {
        destroNotificationCoolDown = DestroyNotification();

        if (notificationContainer.transform.childCount > 0) Destroy(notificationContainer.transform.GetChild(0).transform.gameObject);
        StopCoroutine(destroNotificationCoolDown);

        GameObject notificationPrefab = Resources.Load("Prefabs/Bit4/AchievementCell_01") as GameObject;
        GameObject notificationInstantiate = Instantiate(notificationPrefab, new Vector3(0f, 0f, 0f), transform.rotation) as GameObject;

        AchievementData currentAchievement = app.model.achievementModel.GetAchievementDataById(id);

        notificationInstantiate.transform.GetChild(0).GetComponent<Text>().text = currentAchievement.title; // Description
        notificationInstantiate.transform.GetChild(1).GetComponent<Text>().text = currentAchievement.coins.ToString(); // Coins      

        notificationInstantiate.transform.SetParent(notificationContainer.transform);
        notificationInstantiate.transform.localScale = new Vector3(1f, 1f, 1f);
        notificationInstantiate.transform.localPosition = new Vector3(-400f, -100f, 0f);

        StartCoroutine(destroNotificationCoolDown);
    }

    IEnumerator DestroyNotification()
    {
        print("DestroyNotification");
        yield return new WaitForSeconds(3f);
        Destroy(notificationContainer.transform.GetChild(0).transform.gameObject);
    }

}
