using System.Collections;
using System.Collections.Generic;
using DailyRewardSystem;
using UnityEngine;

[CreateAssetMenu(fileName ="RewardDB" , menuName ="Daily Rewards System/Rewards Database")]
public class RewardsDatabase : ScriptableObject
{
    public Reward[] rewards;

    public int rewardsCount
    {
        get { return rewards.Length; }
    }

    public Reward GetRewards(int index)
    {
        return rewards[index];

    }
}
 

