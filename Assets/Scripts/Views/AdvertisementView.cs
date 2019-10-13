using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementView : BoxClickerElement
{
    public void Initialization()
    {
        StartCoroutine(ShowBannerWhenReady());
    }

    internal void ClickListener()
    {

    }

    IEnumerator ShowBannerWhenReady()
    {
        string placementBannerId = app.model.advertisementModel.GetPlacementBannerId();

        while (!Advertisement.IsReady(placementBannerId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementBannerId);
    }
}
