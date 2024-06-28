using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class RewardAdHandler : MonoBehaviour
{
#if UNITY_ANDROID
  private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
    private string _adUnitId = "unused";
#endif

    private RewardedAd _rewardedAd;

    public void LoadAd()
    {
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        var adRequest = new AdRequest();

        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                    return;

                _rewardedAd = ad;
                RegisterEventHandlers(ad);
            });
    }

    public void ShowAd()
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                Debug.Log(string.Format("사용자에게 보상 제공"));
            });
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("광고 수익 창출 완료");
        };
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("광고 개재 완료");
        };
        ad.OnAdClicked += () =>
        {
            Debug.Log("광고 클릭");
        };
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("전체 화면 광고 시작");
        };
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("전체 화면 광고 종료");
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("전체 화면 광고 오류 : " + error);
        };
    }
}