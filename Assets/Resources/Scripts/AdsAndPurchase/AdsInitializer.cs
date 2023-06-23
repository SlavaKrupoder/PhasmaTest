using UnityEngine;
using UnityEngine.Advertisements;
using SF = UnityEngine.SerializeField;

namespace AdsAndPurchase
{
    public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SF] string _androidGameId;
        [SF] string _iOSGameId;
        [SF] bool _testMode = true;
        [SF] RewardedAdsButton _rewardedAdsButton;
        private string _gameId;

        void Awake()
        {
            InitializeAds();
        }

        public void InitializeAds()
        {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
            _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(_gameId, _testMode, this);
            }
        }


        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
            _rewardedAdsButton.LoadAd();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }
    }
}