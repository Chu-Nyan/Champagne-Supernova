using UnityEngine;

public class TestSceneTrigger : MonoBehaviour
{
    [Header("Google AdMob")]
    [SerializeField] private bool _testBannerAD;
    [SerializeField] private bool _testInterstitialAD;
    [SerializeField] private bool _testRewardAD;

    private GoogleAdMobController _googleAdMob;

    private void Awake()
    {
        TestGoogleAdmob();
    }

    private void TestGoogleAdmob()
    {
        _googleAdMob = gameObject.AddComponent<GoogleAdMobController>();
        _googleAdMob.Init();

        if (_testBannerAD == true)
        {
            _googleAdMob.InitBannerHandler();
            _googleAdMob.ShowBannerAd();
        }
        if (_testInterstitialAD == true)
        {
            _googleAdMob.InitInterstitialHandler();
            _googleAdMob.ShowInterstitialAd();
        }
        if (_testRewardAD == true)
        {
            _googleAdMob.InitRewardHandler();
            _googleAdMob.ShowRewardAd();
        }
    }
}
