using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementView : BoxClickerElement, IUnityAdsListener
{
    public void Initialization()
    {
        Advertisement.AddListener(this);
        StartCoroutine(ShowBannerWhenReady());
    }

    internal void ClickListener()
    {
        StartCoroutine(ShowVideoWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        print("ShowBannerWhenReady");
        string placementBannerId = app.model.advertisementModel.GetPlacementBannerId();

        while (!Advertisement.IsReady(placementBannerId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementBannerId);
    }


    IEnumerator ShowVideoWhenReady()
    {
        string placemenVideoId = app.model.advertisementModel.GetPlacemenVideoId();

        while (!Advertisement.IsReady(placemenVideoId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Show(placemenVideoId);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            print("Ad Finished");
        }
        else if (showResult == ShowResult.Skipped)
        {
            print("Ad Skipped");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogWarning("OnUnityAdsDidError");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.LogWarning("OnUnityAdsDidStart");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.LogWarning("Ad Ready " + placementId);
    }
}
