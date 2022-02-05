using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
  public void ReplayGame()
    {
        SceneManager.LoadScene("Level");

    }

    public void LoadPopUP()
    {
        SceneManager.LoadScene("PopUp");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void LoadSetting()
    {
        SceneManager.LoadScene("SettingsWindow");
    }
    public void LoadDaiyReward()
    {
        SceneManager.LoadScene("Crossplatform_leaderboard");
    }
    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
        Time.timeScale = 1f;
    }
    public void LoadSoialmedia()
    {
        SceneManager.LoadScene("SocialAccount");
    }

    public void LoadMultipleReward()
    {
        SceneManager.LoadScene("Reward box");
        UnityAds.instance.ShowInterstitialAd();
    }

    public void QuiteGame()
    {
        Application.Quit();

    }
}
