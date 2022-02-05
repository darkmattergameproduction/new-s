using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dance : MonoBehaviour
{

    private bool isDance1 = false;

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (SwipeManager.swipeLeft)
        {

            isDance1 = true;
            animator.SetBool("isDance1", true);
        }
        else
        {

        }
       
        

        
      }

   
}
