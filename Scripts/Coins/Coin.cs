using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject vfx;
    public Transform coinPostion;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,80 * Time.deltaTime,  0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numberOfCoins += 1;
            PlayerManager.point += 1;
            PlayerPrefs.SetInt("pointcoin", PlayerManager.point);
            PlayerPrefs.SetInt("numberOfCoins", PlayerManager.numberOfCoins);

            Destroy(gameObject);
            FindObjectOfType<AudioManger>().PlaySound("PickUpCoin");
            GameObject ball2 = Instantiate(vfx, coinPostion.position, Quaternion.identity);
        }

    }
}
