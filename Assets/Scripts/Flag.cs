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

    public GameObject fxCapturePlayer1;
    public GameObject fxCapturePlayer2;
    
    public GameObject tempObject;


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
        }else if (other.CompareTag("Player") && isCapture)
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
                //other.GetComponent<Deplacment>().isCapturing = true;
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
            //GetComponent<MeshRenderer>().material = midlemen.GetMaterial(player.idPlayer);
            if(tempObject != null)
                Destroy(tempObject);

            if (player.idPlayer == 1)
            {
                tempObject = Instantiate(fxCapturePlayer1, transform.position, Quaternion.identity);
            }
            else if (player.idPlayer == 2)
            {
                tempObject = Instantiate(fxCapturePlayer2, transform.position, Quaternion.identity);
            }
            
        }
        
    }
}
