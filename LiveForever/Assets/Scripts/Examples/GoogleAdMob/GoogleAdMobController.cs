using GoogleMobileAds.Api;
using UnityEngine;

public class GoogleAdMobController : MonoBehaviour
{
    private BannerAdHandler _bannerHandler;
    private InterstitialAdHandler _interstitialHandler;
    private RewardAdHandler _rewardHandler;

    public void Init()
    {
        MobileAds.Initialize((InitializationStatus initStatus) => { });
    }

    public void InitBannerHandler()
    {
        _bannerHandler = gameObject.AddComponent<BannerAdHandler>();
        _bannerHandler.GenerateBannerView();
    }

    public void InitInterstitialHandler()
    {
        _interstitialHandler = gameObject.AddComponent<InterstitialAdHandler>();
        _bannerHandler.GenerateBannerView();
    }

    public void InitRewardHandler()
    {
        _rewardHandler = gameObject.AddComponent<RewardAdHandler>();
    }

    public void ShowBannerAd()
    {
        _bannerHandler.ShowAd();
    }

    public void ShowInterstitialAd()
    {
        _interstitialHandler.LoadAd();
        _interstitialHandler.ShowAd();
    }

    public void ShowRewardAd()
    {
        _rewardHandler.LoadAd();
        _rewardHandler.ShowAd();
    }

}
