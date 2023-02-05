using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (other.CompareTag("Player") && !isCapture)
        {
            if (playerCapture != other.GetComponent<Deplacment>())
            {
                other.GetComponent<Deplacment>().isCapturing = true;
                transform.GetComponent<QTE>().indexPlayer = other.GetComponent<Deplacment>().indexPlayer;
                transform.GetComponent<QTE>().GenerateSequence();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in trigger");
            if (transform.GetComponent<QTE>().hasSucceeded)
            {
                if(playerCapture != other.GetComponent<Deplacment>())
                {
                    other.GetComponent<Deplacment>().isCapturing = false;
                    Debug.Log("Player is capturing");
                    playerCapture = other.GetComponent<Deplacment>();
                    AddScore(playerCapture);
                    transform.GetComponent<QTE>().ResetFlag();
                }
            }
            else
            {
                other.GetComponent<Deplacment>().isCapturing = true;
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
    
    public void AddScore(Deplacment player)
    {
        if (transform.GetComponent<QTE>().hasSucceeded)
        {
            Debug.Log("Capture");
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
}
