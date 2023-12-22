using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string androidGameID = "5506952";
    [SerializeField] string iOSGameID = "5506953";
    [SerializeField] bool testMode;
    private string gameID;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSGameID : androidGameID;
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization failed: {error.ToString()} - {message}");
    }
}
