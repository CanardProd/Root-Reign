using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Players : MonoBehaviour
{
    public SO_Midlemen midlemen;

    private void Awake()
    {
        midlemen.Initialize();
    }

    private void Update()
    {
        ResetScene();
    }

    private void ResetScene()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
