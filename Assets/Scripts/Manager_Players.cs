using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Players : MonoBehaviour
{
    public SO_Midlemen midlemen;

    private void Start()
    {
        midlemen.Initialize();
    }
}
