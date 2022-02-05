using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Achivement : MonoBehaviour
{
  

    void Awake()
    {
        if (!RuntimeManager.IsInitialized())
            RuntimeManager.Init();


    }


        void Start()
    {
        if (!GameServices.IsInitialized())
        {
            GameServices.Init ();
        }
    }


    public void ShowLeaderboard()
    {
        if(GameServices.IsInitialized())
        {
            GameServices.ShowLeaderboardUI();
        }
    }


    public void ShowAchievement()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.ShowAchievementsUI();
        }
    }

    public void SumitScoreToLeaderboard()
    {
        if(GameServices.IsInitialized())
        {
            GameServices.ReportScore(PlayerManager.numberOfCoins, EM_GameServicesConstants.Leaderboard_Leaderboard);
        }
    }

    public void LoadLocalScoreLeaderboard()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.LoadLocalUserScore(EM_GameServicesConstants.Leaderboard_Leaderboard, OnLocalUserScoreLoaded);

        }
    }

    void OnLocalUserScoreLoaded(string leaderboardName, IScore score)
    {
        if (score != null)
        {
           
        }
        else
        {
            
        }
    }

    public void UnlockedAchievment()
    {
        if (GameServices.IsInitialized())
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_Achievement);
            
        }
    }

}
