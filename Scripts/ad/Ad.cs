using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ad : MonoBehaviour, IUnityAdsListener
{

    string GooglePlay_ID = "4141947";
    string myRewardBoxId = "rewardAd";
    bool GameMode = false;


    [Space]
    [SerializeField] RewardBox rewardBox;

   


    public static Ad instance;
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
    }

    public void DisplayRewardedAd()
    {

        Advertisement.Show(myRewardBoxId);
    }

    // Update is called once per frame


    public void OnUnityAdsDidFinish(string myPlacementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            rewardBox.isAdWatched = true;


            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {

            rewardBox.AdClose();
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
