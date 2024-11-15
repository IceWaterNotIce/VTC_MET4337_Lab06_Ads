using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.unity3d.mediation;

public class BannerAdsManager : MonoBehaviour
{

    [SerializeField]
    private string bannerADUnitId = "";

    [SerializeField]
    private string placementId = "";

    private LevelPlayBannerAd bannerAd;

    LevelPlayAdSize adSize = LevelPlayAdSize.BANNER;
    private LevelPlayBannerPosition AdPos = LevelPlayBannerPosition.BottomCenter;

    // Start is called before the first frame update
    void Start()
    {
        // Test Integration success or not
        IronSource.Agent.validateIntegration();

        bannerAd = new LevelPlayBannerAd(
            bannerADUnitId,
            adSize,
            AdPos,
            placementId
        );

        bannerAd.OnAdLoaded += BannerOnAdLoadedEvent;
        bannerAd.OnAdLoadFailed += BannerOnAdLoadFailedEvent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BannerOnAdLoadedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log("Banner On Ad Loaded : " + adInfo);
        bannerAd.ShowAd();
    }

    private void BannerOnAdLoadFailedEvent(LevelPlayAdError error)
    {
        Debug.LogError("Banner On Ad LoadFailed : " + error.ErrorMessage);
    }
}
