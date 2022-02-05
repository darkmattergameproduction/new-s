using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    private Transform target;
    public Vector3 offset;
    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

   


}
