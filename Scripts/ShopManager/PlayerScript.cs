using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public int currentModelIndex;

    public GameObject[] model;
    void Start()
    {
        currentModelIndex = PlayerPrefs.GetInt("SelectedModel", 0);
        foreach (GameObject model in model)
            model.SetActive(false);
        model[currentModelIndex].SetActive(true);
    }

}
