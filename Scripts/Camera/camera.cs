using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Transform target;
    
    
    public float smoothSpeed = 0.15f;


    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("CameraPos").transform;
       

    }

    // Update is called once per frame

    private void Update()
    {
       
         target = GameObject.FindGameObjectWithTag("CameraPos").transform;

        Vector3 desiredPositon = target.position;
        transform.position = Vector3.Lerp(transform.position, desiredPositon, smoothSpeed); 
    }
}
