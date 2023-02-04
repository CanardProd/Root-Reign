using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacment : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody rb;
    public Transform direction;
    
    [Header("Data")]
    public SO_Midlemen midlemen;
    public GameObject colliderPoint;
    
    [Header("Variables")]
    public int idPlayer;
    private float speed = 10f;
    public float speedMax = 10f;
    [Range(0f,1f)]
    public float speedReduction;
    public float rotationSpeed = 10f;
    public bool isCapturing;
    
    public float maxDelay = 1f;
    private float tempMaxDelay = 1f;
    public float delay = 1f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        delay = maxDelay;
        tempMaxDelay = maxDelay;
        speed = speedMax;
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
        //CoolDown instanciate colliderPoint
        if (delay > 0 && !isCapturing)
        {
            delay -= Time.deltaTime;
        }
        if(delay <= 0)
        {
            tempMaxDelay *= 1+ (1-speedReduction);
            delay = tempMaxDelay;
            InstantiateColliderPoint();
            if (rb.velocity.magnitude > 0.1f && !isCapturing)
            {
                speed = speed * speedReduction;
                if(speed < 0.1f)
                {
                    ResetPositionToArbre();
                }
            }
        }
    }
    
    
    
    private void FixedUpdate()
    {
        Deplacement();
        if (isCapturing)
        {
            speed = speedMax;
            tempMaxDelay = maxDelay;
        }
    }
    
    
    void Deplacement()
    {
        //add velocity to rigidbody
        if (!isCapturing)
        {
            rb.velocity = direction.right * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void SetDirection()
    {
        //Rotate transformDirection from input controller
        direction.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
    }

    void InstantiateColliderPoint()
    {
        //instanciate with a delay of 1 second a colliderPoint
        GameObject obj = Instantiate(colliderPoint, transform.position, Quaternion.identity);
        
        //Set the tag of obj of player 1or 2
        if (idPlayer == 1)
        {
            obj.tag = "Player1";
        }
        else if (idPlayer == 2)
        {
            obj.tag = "Player2";
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Set the player position to arbre 1 or 2
        if (other.transform.CompareTag("Player2") )
        {
            ResetPositionToArbre();
            //InstantiateColliderPoint();
        }
        else if (other.transform.CompareTag("Player1"))
        {
            ResetPositionToArbre();
            //InstantiateColliderPoint();
        }
    }
    
    private void ResetPositionToArbre()
    {
        if (idPlayer == 1)
        {
            transform.position = midlemen.Arbre1.position;
            
        }
        else if (idPlayer == 2)
        {
            transform.position = midlemen.Arbre2.position;
        }
        speed = speedMax;
    }
}
