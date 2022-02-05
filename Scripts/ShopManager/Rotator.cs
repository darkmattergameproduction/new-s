using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float raotaionSpeed = 50;
    void Update()
    {
       
        transform.Rotate(0, raotaionSpeed * Time.deltaTime , 0);
    }
}
