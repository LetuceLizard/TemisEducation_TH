﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class index : MonoBehaviour
{
    public Text build;

    void Start()
    {
        build.text = "Index = " + SceneManager.GetActiveScene().buildIndex.ToString(); 
    }
}