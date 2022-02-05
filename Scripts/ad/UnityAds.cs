using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;





public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    string GooglePlay_ID = "4141947";
    string myPlacementId = "rewardedVideo";
    string myInteristialId = "Interstitial";

    bool GameMode = false;

    public GameObject RewardPanel;
    int coin = PlayerManager.numberOfCoins;



    public static UnityAds instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(GooglePlay_ID, GameMode);
        Advertisement.AddListener(this);

        int coin = PlayerManager.numberOfCoins;
        PlayerManager.numberOfCoins = PlayerPrefs.GetInt("numberOfCoins");
    }


    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {


            Advertisement.Show(myInteristialId);




        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
    public void DisplayRewardedAd()
    {

        Advertisement.Show(myPlacementId);

    }


    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string myPlacementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {

            PlayerManager.numberOfCoins += 50;
            PlayerPrefs.SetInt("numberOfCoins", PlayerManager.numberOfCoins);
            RewardPanel.SetActive(true);
            SceneManager.LoadScene("Level");
            StartCoroutine(loadLevel());
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
    private IEnumerator loadLevel()
    {
        yield return new WaitForSeconds(3f);
        

    }
}

