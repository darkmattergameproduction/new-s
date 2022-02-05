
using UnityEngine;

public class Inapp : MonoBehaviour
{




    public void PurchasingCoinPack5000()
    {
        if (PlayerPrefs.HasKey("numberOfCoins"))
        {
            int coins = PlayerPrefs.GetInt("numberOfCoins");
            PlayerPrefs.SetInt("numberOfCoins", coins + 5000);

        }

        else
        {
            PlayerPrefs.SetInt("numberOfCoins", 5000);

        }
 
    }


    public void PurchasingCoinPack10000()
    {
        if (PlayerPrefs.HasKey("numberOfCoins"))
        {
            int coins = PlayerPrefs.GetInt("numberOfCoins");
            PlayerPrefs.SetInt("numberOfCoins", coins + 10000);

        }

        else
        {
            PlayerPrefs.SetInt("numberOfCoins", 10000);

        }

    }

    public void PurchasingCoinPack20000()
    {
        if (PlayerPrefs.HasKey("numberOfCoins"))
        {
            int coins = PlayerPrefs.GetInt("numberOfCoins");
            PlayerPrefs.SetInt("numberOfCoins", coins + 20000);

        }

        else
        {
            PlayerPrefs.SetInt("numberOfCoins", 20000);

        }

    }

    public void PurchasingCoinPack50000()
    {
        if (PlayerPrefs.HasKey("numberOfCoins"))
        {
            int coins = PlayerPrefs.GetInt("numberOfCoins");
            PlayerPrefs.SetInt("numberOfCoins", coins + 50000);

        }

        else
        {
            PlayerPrefs.SetInt("numberOfCoins", 50000);

        }

    }

    public void PurchasingCoinPack100000()
    {
        if (PlayerPrefs.HasKey("numberOfCoins"))
        {
            int coins = PlayerPrefs.GetInt("numberOfCoins");
            PlayerPrefs.SetInt("numberOfCoins", coins + 100000);

        }

        else
        {
            PlayerPrefs.SetInt("numberOfCoins", 100000);

        }

    }

   
}
