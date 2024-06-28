using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAdHandler : MonoBehaviour
{
#if UNITY_ANDROID
    public const string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
    public const string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
    public const string _adUnitId = "unused";
#endif

    private BannerView _bannerView;

    public void GenerateBannerView()
    {
        if (_bannerView != null)
            return;

        // 적응형 배너 크기
        // var adSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);
        ListenToAdEvents();
    }

    public void ShowAd()
    {
        if (_bannerView == null)
            GenerateBannerView();

        var adRequest = new AdRequest();
        _bannerView.LoadAd(adRequest);
    }

    public void DestroyAd()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    private void ListenToAdEvents()
    {
        _bannerView.OnBannerAdLoaded += () =>
        {
        };
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
        };
        _bannerView.OnAdPaid += (AdValue adValue) =>
        {
        };
        _bannerView.OnAdImpressionRecorded += () =>
        {
        };
        _bannerView.OnAdClicked += () =>
        {
        };
        _bannerView.OnAdFullScreenContentOpened += () =>
        {
        };
        _bannerView.OnAdFullScreenContentClosed += () =>
        {
        };
    }
}
