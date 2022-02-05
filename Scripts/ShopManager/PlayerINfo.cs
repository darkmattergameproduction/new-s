using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerINfo : MonoBehaviour
{
    public GameObject info;
    public ModelBlueprint[] models;
    public Text infotext;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ModelBlueprint model in models)
        {
            infotext.text = "" + model.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
