using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;

using UnityEngine;
using Random = UnityEngine.Random;


public class Deplacment : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody rb;
    public Transform direction;
    public Spline lastSpline;
    
    [Header("Data")]
    public SO_Midlemen midlemen;
    public GameObject colliderPoint;
    public GameObject splinePrefab;
    
    [Header("Variables")]
    public int idPlayer;
    private float speed = 10f;
    public float speedMax = 10f;
    [Range(0f,1f)]
    public float speedReduction;
    public float rotationSpeed = 10f;
    public bool isCapturing;

    public Vector3 arbre;
    private Vector3 rando;
    
    public float maxDelay = 1f;
    private float tempMaxDelay = 1f;
    public float delay = 1f;

    public int indexPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        delay = maxDelay;
        tempMaxDelay = maxDelay;
        speed = speedMax;
        
        
        if (idPlayer == 1)
        {
            arbre = midlemen.Arbre1;
            
        }
        else if (idPlayer == 2)
        {
            arbre = midlemen.Arbre2;
        }
        InitSpline(arbre);
    }

    public void InitSpline(Vector3 startPos)
    {
        //Instantiate a spline
        
        GameObject obj = Instantiate(splinePrefab, startPos, Quaternion.identity);
        lastSpline = obj.GetComponent<Spline>();
        obj.transform.GetChild(0).tag = "Player" + idPlayer;
        rando = Random.insideUnitSphere * 0.5f;
        SplineNode node = new SplineNode(Vector3.zero, transform.position - arbre);
        
        SplineNode node1 = new SplineNode(transform.position- (arbre + rando), transform.position- (arbre + rando));
        lastSpline.nodes[0] = node;
        lastSpline.nodes[1] = node1;
    }

    private void AddSplineNode()
    {
        rando = Random.insideUnitSphere * 0.3f;
        SplineNode node = new SplineNode(transform.position- (arbre + rando), transform.position- (arbre + rando));
        lastSpline.AddNode(node);
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
            tempMaxDelay = maxDelay;
            delay = tempMaxDelay;
            InstantiateColliderPoint();
            if (rb.velocity.magnitude > 0.1f && !isCapturing)
            {
                speed = speed * speedReduction;
                if(speed < 0.5f)
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
        if (!isCapturing && !midlemen.isPaused)
        {
            rb.velocity = direction.right * speed;
        }
        else
        {
            Debug.Log("IS CAPTURING");
            rb.velocity = Vector3.zero;
        }
    }

    void SetDirection()
    {
        //Rotate transformDirection from input controller
        direction.Rotate(0, Hinput.gamepad[indexPlayer].leftStick.horizontal * rotationSpeed, 0);
    }

    void InstantiateColliderPoint()
    {
        AddSplineNode();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player2") || collision.transform.CompareTag("Player1"))
        {
            transform.GetComponent<SphereCollider>().isTrigger = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        transform.GetComponent<SphereCollider>().isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Set the player position to arbre 1 or 2
        if (other.transform.CompareTag("Player2") && idPlayer == 1)
        {
            
            if (idPlayer == 1)
            {
                arbre = midlemen.Arbre1;
            
            }
            else if (idPlayer == 2)
            {
                arbre = midlemen.Arbre2;
            }
            //InstantiateColliderPoint();
            ResetPositionToArbre();
        }
        else if (other.transform.CompareTag("Player1") && idPlayer == 2)
        {
            
            if (idPlayer == 1)
            {
                arbre = midlemen.Arbre1;
            
            }
            else if (idPlayer == 2)
            {
                arbre = midlemen.Arbre2;
            }
            //InstantiateColliderPoint();
            ResetPositionToArbre();
        }
        
    }
    
    public void ResetPositionToArbre()
    {
        if (idPlayer == 1)
        {
            transform.position = midlemen.Arbre1;
            
        }
        else if (idPlayer == 2)
        {
            transform.position = midlemen.Arbre2;
        }
        speed = speedMax;
        InitSpline(arbre);
    }
    
    
}
