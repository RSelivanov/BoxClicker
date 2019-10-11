using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementModel : BoxClickerElement
{
    private static string gameId = "3296162";
    private static string placementBannerId = "BoxClickerDownBanner";
    private static string placemenVideoId = "rewardedVideo";

    private bool testMode = true;

    public string GetGameId(){ return gameId; }
    public string GetPlacementBannerId() { return placementBannerId; }
    public string GetPlacemenVideoId() { return placemenVideoId; }

    public void Initialization()
    {
        Advertisement.Initialize(gameId, testMode);
    }
}
