using UnityEngine;


public class BoxClickerApplication : MonoBehaviour
{
    public BoxClickerModel model;
    public BoxClickerView view;
    public BoxClickerController controller;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 2);
        //Screen.SetResolution(600, 1024, true);

        controller.advertisementController.Initialization();
        controller.coinController.Initialization();
        controller.pointController.Initialization();
        controller.boxController.Initialization();
        controller.gunController.Initialization();
        controller.skillController.Initialization();
        controller.achievementController.Initialization();
        controller.sceneController.Initialization();
    }

    void Update()
    {
        controller.gunController.UpdateGunCells();
        controller.skillController.UpdateSkillCells();
        controller.gunController.UpdateUpgradeButton();
    }
}
