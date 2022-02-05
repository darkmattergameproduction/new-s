using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class SecondLife : MonoBehaviour, IUnityAdsListener
{

    string GooglePlay_ID = "4141947";
    string myRewardBoxId = "rewardAd";
    bool GameMode = false;

    [SerializeField] private GameObject continuePanel;
    [SerializeField] private Button WatchOverButton;
    [SerializeField] private Button gameOverButton;
     

    






  
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(GooglePlay_ID, GameMode);
        Advertisement.AddListener(this);
    }

    public void DisplayAdForSecondChance()
    {
        WatchOverButton.interactable = false;
        gameOverButton.interactable = false;

        Advertisement.Show(myRewardBoxId);
    }

    // Update is called once per frame


    public void OnUnityAdsDidFinish(string myPlacementId, ShowResult showResult)
    {
        gameOverButton.interactable = true;
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            PlayerManager.numberOfCoins += 50;
            PlayerPrefs.SetInt("numberOfCoins", PlayerManager.numberOfCoins);


            continuePanel.SetActive(false);
            Time.timeScale = 1;
            PlayerController.instance.SecondChance();





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
        if (placementId == myRewardBoxId)
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




    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
