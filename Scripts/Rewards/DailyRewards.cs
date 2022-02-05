using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;


namespace DailyRewardSystem
{
    public enum RewardType
    {
        Metals,
        Coins,
        Gems,
    }
        

    [Serializable] public struct Reward
    {
        public RewardType Type;
        public int Amount;
    }

    public class DailyRewards : MonoBehaviour
    {
        [Header("Main Menu UI")]
        [SerializeField]
        Text coinsText;
        [SerializeField]
        Text metalsText;
        [SerializeField]
        Text gemsText;

        [Space]
        [Header("Reward UI")]
        [SerializeField]
        GameObject rewardCanvas;
        [SerializeField]
        Button openButton;
        [SerializeField]
        Button closeButton;
        [SerializeField]
        Image rewardImage;
        [SerializeField]
        Text rewardAmountText;
        [SerializeField]
        Button claimButton;
        [SerializeField]
        GameObject rewardNotification;
        [SerializeField]
        GameObject noMoreRewardsPanel;

        [Space]
        [Header("Rewards Images")]
        [SerializeField]
        Sprite iconMetalsSprite;
        [SerializeField]
        Sprite iconCoinsSprite;
        [SerializeField]
        Sprite iconGemsSprite;



        

        [Space]
        [Header("Rewards Database")]
        [SerializeField]
        RewardsDatabase rewardsDB;
        private int nextRewardIndex;

        [Space]
        [Header("FX")]
        [SerializeField]
        ParticleSystem fxMetals;
        [SerializeField]
        ParticleSystem fxCoins;
        [SerializeField]
        ParticleSystem fxGems;


        [Space]
        [Header("Timing")]
        [SerializeField]
        double nextRewardDelay = 86400f;

        [SerializeField]
        float checkforRewardDelay = 5f;

        
        private bool isRewardReady = false;
      

        



        void Start()
        {
            Initialize ();
            StopAllCoroutines();
            StartCoroutine(CheckForRewards());
            


        }



       void Initialize ()
        {
            nextRewardIndex = PlayerPrefs.GetInt("Next_Reward_Index", 0);

            UpdateMetalsTextUI();
            UpdateCoinsTextUI ();
            UpdateGemsTextUI  ();
            //------------------------------------------------------------
            openButton.onClick.RemoveAllListeners();
            openButton.onClick.AddListener(OnOpenButtonClick);

            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(OnCloseButtonClick);

            claimButton.onClick.RemoveAllListeners();
            claimButton.onClick.AddListener(OnClaimButtonClick);

            //-----checking the game open for the first time-----
            if (string.IsNullOrEmpty(PlayerPrefs.GetString("Reward_Claim_Datetime")))
                PlayerPrefs.SetString("Reward_Claim_Datetime", DateTime.Now.ToString());



        }
      IEnumerator CheckForRewards()
        {
            while (true)
            {
                if (!isRewardReady)
                {

                    DateTime currentDateTime = DateTime.Now;
                    DateTime rewardClaimDatetime = DateTime.Parse(PlayerPrefs.GetString("Reward_Claim_Datetime", currentDateTime.ToString()));

                    //get total second between this 2 dates 
                    double elapsedSeconds = (currentDateTime - rewardClaimDatetime).TotalSeconds;

                    if (elapsedSeconds >= nextRewardDelay)
                        ActivateReward();
                    else
                        DesactivateReward();
                }
                yield return new WaitForSeconds(checkforRewardDelay);
            }
        }
       
        void ActivateReward()
        {
            isRewardReady = true;
            noMoreRewardsPanel.SetActive(false);
            rewardNotification.SetActive(true);
            //---------update reward ui --------------------
            Reward reward = rewardsDB.GetRewards(nextRewardIndex);
            if (reward.Type == RewardType.Metals)
                rewardImage.sprite = iconMetalsSprite;
            else if (reward.Type == RewardType.Coins)
                rewardImage.sprite = iconCoinsSprite;
            else 
                rewardImage.sprite = iconGemsSprite;
            rewardAmountText.text = string.Format("+{0}", reward.Amount);



        }
        void DesactivateReward()
        {
            isRewardReady = false;
            noMoreRewardsPanel.SetActive(true);
            rewardNotification.SetActive(false);
        }


        void OnClaimButtonClick ()
        {
            Reward reward  = rewardsDB.GetRewards(nextRewardIndex);
            //check reward type 
            if (reward.Type == RewardType.Metals)
            {
                Debug.Log("<clolor=White>" + reward.Type.ToString() + " Claimed : </color>+" + reward.Amount);
                GameData.Metals += reward.Amount;
                UpdateMetalsTextUI();
                fxMetals.Play();
            }
            else if (reward.Type == RewardType.Coins)
            {
                Debug.Log("<clolor=Yello>" + reward.Type.ToString() + " Claimed : </color>+" + reward.Amount);
                


                PlayerManager.numberOfCoins += reward.Amount;
                PlayerPrefs.SetInt("numberOfCoins", PlayerManager.numberOfCoins);



                UpdateCoinsTextUI();
                fxCoins.Play();

            }
            else 
            {
                Debug.Log("<clolor=Green>" + reward.Type.ToString() + " Claimed : </color>+" + reward.Amount);
                GameData.Gems += reward.Amount;
                UpdateGemsTextUI();
                fxGems.Play();

                isRewardReady = false;
            }

            //---------------------------------------------------------

            nextRewardIndex++;
            if (nextRewardIndex >= rewardsDB.rewardsCount)
                nextRewardIndex = 0;
            PlayerPrefs.SetInt("Next_Reward_Index", nextRewardIndex);


            //----------save date and time------------
            PlayerPrefs.SetString("Reward_Claim_Datetime", DateTime.Now.ToString());


            DesactivateReward();
        }

       void UpdateMetalsTextUI ()
        {
            metalsText.text = GameData.Metals.ToString();

        }
        void UpdateCoinsTextUI ()
        {
            coinsText.text = PlayerManager.numberOfCoins.ToString();
        }
        void UpdateGemsTextUI()
        {
            gemsText.text = GameData.Gems.ToString();
        }
        //------------------------------------------------------------------------------------
        void OnOpenButtonClick ()
        {
            rewardCanvas.SetActive(true);

        }
        void OnCloseButtonClick()
        {
            rewardCanvas.SetActive(false);

        }
    }

}
