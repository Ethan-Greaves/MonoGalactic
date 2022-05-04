using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool m_testMode = true;
    public static AdManager m_AdMangerInstance;
    private GameOverHandler m_gameOverHandler;

#if UNITY_ANDROID
    private string gameId = "4734773";
#elif UNITY_IOS
    private string gameId = "4734772";
#endif

    private void Awake()
    {
        if (m_AdMangerInstance != null && m_AdMangerInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            m_AdMangerInstance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, m_testMode);
        }
    }

    public void ShowAd(GameOverHandler gameOverHandler)
    {
        this.m_gameOverHandler = gameOverHandler;
        SoundManager.m_SoundManagerInstance.StopMusic();
        Advertisement.Show("rewardedVideo");
    }


    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                m_gameOverHandler.ContinueGame();
                break;
            case ShowResult.Skipped:
                // Ad was skipped
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad Failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready");
    }
}
