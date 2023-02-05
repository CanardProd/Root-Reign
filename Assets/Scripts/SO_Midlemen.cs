using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "New Midlemen", menuName = "Midlemen")]
public class SO_Midlemen : ScriptableObject
{
    public Vector3 Arbre1;
    public Vector3 Arbre2;

    public float scorePlayer1;
    public float scorePlayer2;

    public bool isPaused = false;
    public float timer;
    
    public Material Player1;
    public Material Player2;
    
    //Return Material of player 1 or 2
    public Material GetMaterial(int player)
    {
        if (player == 1)
        {
            return Player1;
        }
        else if (player == 2)
        {
            return Player2;
        }
        else
        {
            return null;
        }
    }
    
    //Initialize midlmen
    public void Initialize()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        
        Arbre1 = GameObject.Find("Arbre1").transform.position;
        Arbre2 = GameObject.Find("Arbre2").transform.position;
    }
    
    //Add Score to player 1 or 2
    public void AddScore(int player)
    {
        if (player == 1)
        {
            scorePlayer1++;
        }
        else if (player == 2)
        {
            scorePlayer2++;
        }
    }
    
    public void RemoveScore(int player)
    {
        if (player == 1)
        {
            scorePlayer1--;
        }
        else if (player == 2)
        {
            scorePlayer2--;
        }
    }
}
