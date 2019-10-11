using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementModel : BoxClickerElement
{
    private static string gameId = "3296162";
    private static string placementBannerId = "BoxClickerDownBanner";

    private bool testMode = true;

    public string GetGameId(){ return gameId; }
    public string GetPlacementBannerId() { return placementBannerId; }

    public void Initialization()
    {
        Advertisement.Initialize(gameId, testMode);
    }
}
