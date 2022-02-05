using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitmanager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnityAds.instance.ShowInterstitialAd();
            if (SceneManager.GetActiveScene().buildIndex == 5) 

            Application.Quit();
            else
            {
                SceneManager.LoadScene(5);
            }

        }
    }
}
