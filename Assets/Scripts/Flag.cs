using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Deplacment playerCapture;
    public bool isCapture;
    
    private float delay = 1f;
    public float delayNotCapture = 0.5f;
    public float delayCapture = 1f;
    public SO_Midlemen midlemen;


    private void Start()
    {
        SetDelay();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Set player isCapturing to true
        if (other.CompareTag("Player"))
        {
            if (playerCapture != other.GetComponent<Deplacment>())
            {
                other.GetComponent<Deplacment>().isCapturing = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerCapture != other.GetComponent<Deplacment>())
            {
                playerCapture = other.GetComponent<Deplacment>();
                StartCoroutine(DelayAddScore(playerCapture));
            }
        }
    }
    
    //Set delay depending on isCapture
    void SetDelay()
    {
        if (isCapture)
        {
            delay = delayCapture;
        }
        else
        {
            delay = delayNotCapture;
        }
    }
    
    IEnumerator DelayAddScore(Deplacment player)
    {
        yield return new WaitForSeconds(delay);
        //add score to player 1
        midlemen.AddScore(player.idPlayer);
        
        //Set isCapture to true
        isCapture = true;
        
        //Set player isCapturing to false
        player.isCapturing = false;
        
        playerCapture.arbre = transform.position;
        playerCapture.InitSpline(transform.position);
        
        //Set delay
        SetDelay();
        
        //Change material of flag
        GetComponent<MeshRenderer>().material = midlemen.GetMaterial(player.idPlayer);
    }
}
