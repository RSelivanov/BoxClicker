using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxView : BoxClickerElement
{
    //Tech
    private float thrust = 500.0f;
    private int clickDamage;
    private bool kickCoolDown;

    public void ClickListener(GameObject box)
    {
        //SoundManager.use.Play("Click_02", 1.0f);

        BoxData boxData = app.model.boxModel.GetBox();
        SoundManager.use.PlaySound("Click" + boxData.spriteName);
        
        app.controller.achievementController.AddLevel(3, 1); // 10 clicks
        app.controller.achievementController.AddLevel(7, 1); // 50 clicks
        app.controller.achievementController.AddLevel(11, 1); // 100 clicks
        app.controller.achievementController.AddLevel(15, 1); // 1000 clicks
        app.controller.achievementController.AddLevel(19, 1); // 10 000 clicks
        app.controller.achievementController.AddLevel(23, 1); // 100 000 clicks
        app.controller.achievementController.AddLevel(27, 1); // 1 000 000 clicks
        app.controller.achievementController.AddLevel(31, 1); // 10 000 000 clicks
        app.controller.achievementController.AddLevel(35, 1); // 100 000 000 clicks

        app.controller.boxController.Click(clickDamage);
    }

    public void UpdateClickDamage()
    {
        this.clickDamage = app.model.clickModel.GetClickDamage();
    }

    public void UpdateBoxView(BoxData box)
    {
        GameObject boxContainer = app.model.boxModel.GetBoxContainer();
        if (boxContainer.transform.childCount == 0) return;
        //boxContainerObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = box.color;

        Vector3 currentPossition = boxContainer.transform.position;

        BoxData boxData = app.model.boxModel.GetBox();

        Destroy(boxContainer.transform.GetChild(0).transform.gameObject);

        GameObject boxPrefab = Resources.Load("Prefabs/" + boxData.spriteName) as GameObject;
        GameObject boxInstantiate = Instantiate(boxPrefab, currentPossition, boxContainer.transform.rotation) as GameObject;
        boxInstantiate.name = "Box";
        boxInstantiate.transform.SetParent(boxContainer.transform);

    }

    public void InstantiateBox()
    {
        GameObject boxContainer = app.model.boxModel.GetBoxContainer();
        BoxData boxData = app.model.boxModel.GetBox();

        if (boxContainer.transform.childCount > 0) return;
        GameObject boxPrefab = Resources.Load("Prefabs/" + boxData.spriteName) as GameObject;
        Vector3 newPosition = new Vector3(boxContainer.transform.position.x, boxContainer.transform.position.y + 6, boxContainer.transform.position.z);
        GameObject boxInstantiate = Instantiate(boxPrefab, newPosition, boxContainer.transform.rotation) as GameObject;
        boxInstantiate.name = "Box";
        boxInstantiate.transform.SetParent(boxContainer.transform);
    }

    public void InstantiateBoxParts()
    {
        GameObject boxContainer = app.model.boxModel.GetBoxContainer();

        BoxData boxData = app.model.boxModel.GetBox();
        SoundManager.use.PlaySound("Break" + boxData.spriteName);

        GameObject boxPartsPrefab = Resources.Load("Prefabs/"+ boxData.spriteName + "_Destructible") as GameObject;
        GameObject boxPartsInstantiate = Instantiate(boxPartsPrefab, boxContainer.transform.position, boxContainer.transform.rotation) as GameObject;

        float force = Random.Range(100.0f, 200.0f);

        for (int i = 0; i < boxPartsInstantiate.transform.childCount; i++)
        {
            float xRange = Random.Range(-1.5f, 1.5f);
            float yRange = Random.Range(1.3f, 1.8f);
            boxPartsInstantiate.transform.GetChild(i).GetComponent<Rigidbody2D>().AddForce(new Vector2(xRange, yRange) * force);
        }
    }

    public void RemoveBox()
    {
        GameObject boxContainer = app.model.boxModel.GetBoxContainer();
        Destroy(boxContainer.transform.GetChild(0).transform.gameObject);
    }

    public void DrawCois(long amount)
    {
        float force = Random.Range(550.0f, 600.0f);

        for (int i = 0; i < Random.Range(3, 5); i++)
        {
            float xRange = Random.Range(-0.2f, 0.2f);
            float yRange = Random.Range(0.3f, 0.6f);
            GameObject CoinPrefab = Resources.Load("Prefabs/Coin") as GameObject;
            GameObject CoinInstantiate = Instantiate(CoinPrefab, transform.position, transform.rotation) as GameObject;
            CoinInstantiate.GetComponent<Rigidbody2D>().AddForce(new Vector2(xRange, yRange) * force);
        }
    }

    public void DrawText(long amount)
    {
        GameObject TextPrefab = Resources.Load("Prefabs/Text") as GameObject;
        GameObject TextInstantiate = Instantiate(TextPrefab) as GameObject;
        TextInstantiate.GetComponent<TextMeshPro>().SetText("+" + amount.ToString());
        TextInstantiate.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.3f, 0.3f), 1) * thrust);
    }

    public void KickBox()
    {
        if (kickCoolDown) return;
        kickCoolDown = true;

        GameObject boxContainer = app.model.boxModel.GetBoxContainer();

        float force = Random.Range(100.0f, 150.0f);
        boxContainer.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * force);

        StartCoroutine(kickReload());
    }

    IEnumerator kickReload()
    {
        yield return new WaitForSeconds(0.1f);
        kickCoolDown = false;
    }
}
