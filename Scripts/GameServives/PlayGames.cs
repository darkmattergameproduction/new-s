using UnityEngine;
using System;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public   class PlayGames : MonoBehaviour
{
    public Text playerScore;
    string leaderboardIDCoins = "CgkI9NnnxoQHEAIQDA";
    string leaderboardIDScore = "CgkI9NnnxoQHEAIQAQ";
    string Academy_Sprite = "CgkI9NnnxoQHEAIQBQ";
    string Average_Sprite = "CgkI9NnnxoQHEAIQBg";
    string Elite_Sprite = "CgkI9NnnxoQHEAIQBw";
    public static PlayGamesPlatform platform;



    public static PlayGames instance;
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


    void Start()
    {
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Logged in successfully");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });
        UnlockAchievement();
    }

    public  void AddScoreToLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(int.Parse(playerScore.text), leaderboardIDCoins, success => { });
          

        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }

    public void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowAchievementsUI();
        }
    }

    public void UnlockAchievement()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(Academy_Sprite, 100f, success => { });
        }
    }
}