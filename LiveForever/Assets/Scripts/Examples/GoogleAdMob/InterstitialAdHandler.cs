using GoogleMobileAds.Api;
using UnityEngine;

public class InterstitialAdHandler : MonoBehaviour
{
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    private string _adUnitId = "unused";
#endif

    private InterstitialAd _interstitialAd;

    public void LoadAd()
    {
        // 전면 광고는 일회용, 로드할 경우 항상 새로운 객체를 생성 해줘야 한다.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        var adRequest = new AdRequest();
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                    return;

                _interstitialAd = ad;
            });
    }

    public void ShowAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
            _interstitialAd.Show();
        else
            Debug.LogError("Interstitial ad is not ready yet.");
    }
}
