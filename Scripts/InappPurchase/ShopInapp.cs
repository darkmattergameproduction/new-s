using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ShopInapp : MonoBehaviour
{
    [SerializeField]
    private Text CoinsText;

    int coin = PlayerManager.numberOfCoins;

    void Awake()
    {
        if (!RuntimeManager.IsInitialized())
            RuntimeManager.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        bool isInitialized = InAppPurchasing.IsInitialized();
        int coin = PlayerManager.numberOfCoins;
        PlayerManager.numberOfCoins = PlayerPrefs.GetInt("numberOfCoins");
    }

    // Update is called once per frame
    void Update()
    {
        
        CoinsText.text = PlayerManager.numberOfCoins.ToString();
    }

    private void OnEnable()
    {
        InAppPurchasing.PurchaseCompleted += PurchasingCompleteHandle;
        InAppPurchasing.PurchaseFailed += PurchasingFailedHandle;
    }
    private void OnDisable()
    {
        InAppPurchasing.PurchaseCompleted -= PurchasingCompleteHandle;
        InAppPurchasing.PurchaseFailed -= PurchasingFailedHandle;
    }


    private void PurchasingFailedHandle(IAPProduct arg1, string arg2)
    {
        throw new NotImplementedException();

    }
    

    private void PurchasingCompleteHandle(IAPProduct product )
    {
       switch(product.Name)
        {
            case EM_IAPConstants.Product_coins1000:
                PlayerManager.numberOfCoins += 1000;
                PlayerPrefs.SetInt("numberOfCoins", PlayerManager.numberOfCoins);

                break;
            case EM_IAPConstants.Product__coins3000:
                PlayerManager.numberOfCoins += 3000;
                PlayerPrefs.SetInt("numberOfCoins", PlayerManager.numberOfCoins);
                break;
            case EM_IAPConstants.Product__coins400000:
                PlayerManager.numberOfCoins += 400000;
                PlayerPrefs.SetInt("numberOfCoins", PlayerManager.numberOfCoins);
                break;
            default:
                break;
        }
    }

    public void PurchasingCoinPack1000()
    {
        InAppPurchasing.Purchase(EM_IAPConstants.Product_coins1000);
    }


    public void PurchasingCoinPack3000()
    {
        InAppPurchasing.Purchase(EM_IAPConstants.Product__coins3000);
    }


    public void PurchasingCoinPack400000()
    {
        InAppPurchasing.Purchase(EM_IAPConstants.Product__coins400000);
    }
}
