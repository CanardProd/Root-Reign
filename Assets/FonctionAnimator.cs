using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonctionAnimator : MonoBehaviour
{
    public SO_Midlemen midlemen;
    
    public void SetPauseOn()
    {
        midlemen.isPaused = true;
    }
    
    public void SetPauseOff()
    {
        midlemen.isPaused = false;
    }
}
