using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpsIndex;
    public float waitTime = 2f;



    
    void Update() 
    {
       for(int i = 0; i< popUps.Length; i++)
        {
            if(i == popUpsIndex)
            {
                popUps[popUpsIndex].SetActive(true);
            }else
            {
                popUps[popUpsIndex].SetActive(false);
            }
        }  

        if(popUpsIndex == 0)
        {
            if(SwipeManager.swipeLeft || SwipeManager.swipeRight)
                {
                popUpsIndex++;
                }

            
        } else if (popUpsIndex == 1)
        {
            if (SwipeManager.swipeUp)
            {
                popUpsIndex++;
            }
        }else if(popUpsIndex == 2)
        {

        }
        
    }
}
