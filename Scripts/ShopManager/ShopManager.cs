using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    public int currentModelIndex;

    public GameObject[] playerModels;
    

    public Text chararcterName;
    public Text characterDiscription;
    public Text characterPrice;
    public Text donthavecoinText;
    

    public ModelBlueprint[] models;
    public Button buyButton;


    void Start()
    {
        foreach (ModelBlueprint model in models)
        {
            if (model.price == 0)
                model.isUnlocked = true;
            else
                model.isUnlocked = PlayerPrefs.GetInt(model.name, 0) == 0 ? false : true;


        }
        currentModelIndex = PlayerPrefs.GetInt("SelectedModel", 0);
        foreach (GameObject model in playerModels)
            model.SetActive(false);
        playerModels[currentModelIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
    public void changeNext()
    {
        playerModels[currentModelIndex].SetActive(false);
        currentModelIndex++;
        if (currentModelIndex == playerModels.Length)
            currentModelIndex = 0;
        playerModels[currentModelIndex].SetActive(true);

        ModelBlueprint m = models[currentModelIndex];


        if (!m.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedModel", currentModelIndex);
    }
    public void changePrevious()
    {
        playerModels[currentModelIndex].SetActive(false);
        currentModelIndex--;
        if (currentModelIndex == -1)
            currentModelIndex = playerModels.Length - 1;
        playerModels[currentModelIndex].SetActive(true);

        ModelBlueprint m = models[currentModelIndex];


        if (!m.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedModel", currentModelIndex);
    }


    public void UnlockModel()
    {
        ModelBlueprint m = models[currentModelIndex];
        PlayerPrefs.SetInt(m.name, 1);
        PlayerPrefs.SetInt("SelectedModel", currentModelIndex);
        m.isUnlocked = true;
        PlayerPrefs.SetInt("numberOfCoins", PlayerPrefs.GetInt("numberOfCoins", 0) - m.price);


    }


    private void UpdateUI()
    {
        ModelBlueprint m = models[currentModelIndex];
        chararcterName.text = "Name: " + m.name;
        characterDiscription.text = "Ability:" + m.CharcterDiscription;
        characterPrice.text = "Price: " + m.price;

        if (m.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            donthavecoinText.text = "congratulation!  you have bought the Character ";

        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<Text>().text = "Buy-" + m.price;
           
            if (m.price <= PlayerPrefs.GetInt("numberOfCoins", 0))
            {
                buyButton.interactable = true;
               
                donthavecoinText.text = "You can Buy This";
            }
            else
            {
                buyButton.interactable = false;
               
                donthavecoinText.text = "SORRY ! YOU DON'T HAVE COINS,PLEASE CHEACK OUT";
            }
        }
    }
}
