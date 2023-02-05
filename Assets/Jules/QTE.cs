using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using HinputClasses;
using Random = UnityEngine.Random;

public class QTE : MonoBehaviour
{
    private Material red;
    private Material blue;

    private Gamepad myGp;

    private float vibrationLength;
    
    private bool hasPressedA;

    private Sprite currentGeneratedInput;
    private Sprite X_Btn, Y_Btn, B_Btn, A_Btn;
    private Image FirstBtn, SecondBtn, ThirdBtn, FourthBtn;
    private List<Image> QTEOrderList;
    //public GameObject DisplayBox;
    //public GameObject PassBox;
    public int indexPlayer;

    private int QTEGen;
    private List<int> QTEGenList;
    private int CorrectKey;
    private int increment;
    private string gamepadName;

    public bool hasSucceeded;

    // Start is called before the first frame update
    void Start()
    {
        vibrationLength = 0.2f;
       //Debug.Log("player index : " + indexPlayer + " connected : "+ Hinput.gamepad[indexPlayer].isConnected);
       //Debug.Log("player index : " + indexPlayer + " enabled : "+ Hinput.gamepad[indexPlayer].isEnabled);
       myGp = Hinput.gamepad[indexPlayer];
       gamepadName = myGp.name;
       //Debug.Log(gamepadName);


       hasSucceeded = false;

        QTEGenList = new List<int>();
        QTEOrderList = new List<Image>();

        increment = 0;
        
        blue = Resources.Load("Materials/Bluez", typeof(Material)) as Material;
        red = Resources.Load("Materials/Redz", typeof(Material)) as Material;

        X_Btn = Resources.Load("UI/X_Btn", typeof(Sprite)) as Sprite;
        Y_Btn = Resources.Load("UI/Y_Btn", typeof(Sprite)) as Sprite;
        B_Btn = Resources.Load("UI/B_Btn", typeof(Sprite)) as Sprite;
        A_Btn = Resources.Load("UI/A_Btn", typeof(Sprite)) as Sprite;

        FirstBtn = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        SecondBtn = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        ThirdBtn = gameObject.transform.GetChild(0).GetChild(2).GetComponent<Image>();
        FourthBtn = gameObject.transform.GetChild(0).GetChild(3).GetComponent<Image>();
        
        GetComponent<Renderer>().material = red;

        CreateList();
        /////////////////////////////////////////////
        //GenerateSequence();
    }
    
    void CreateList()
    {
        QTEOrderList.Add(FirstBtn);
        QTEOrderList.Add(SecondBtn);
        QTEOrderList.Add(ThirdBtn);
        QTEOrderList.Add(FourthBtn);
    }
    
    private Sprite GenerateInput()
    {
        QTEGen = Random.Range(1, 5);
        switch (QTEGen)
        {
            case 1:
                currentGeneratedInput = X_Btn;
                //DisplayBox.GetComponent<TextMeshProUGUI>().text = "E/B";
                QTEGenList.Add(1);
                break;

            case 2:
                currentGeneratedInput = Y_Btn;
                //DisplayBox.GetComponent<TextMeshProUGUI>().text = "R/Y";
                QTEGenList.Add(2);
                break;

            case 3:
                currentGeneratedInput = B_Btn;
                //DisplayBox.GetComponent<TextMeshProUGUI>().text = "T/A";
                QTEGenList.Add(3);
                break;
            case 4 :
                currentGeneratedInput = A_Btn;
                //DisplayBox.GetComponent<TextMeshProUGUI>().text = "T/A";
                QTEGenList.Add(4);
                break;
        }
        return currentGeneratedInput;
    }

    public void GenerateSequence()
    {
        QTEGenList.Clear();
        for (int i = 0; i < 4; i++)
        {
            QTEOrderList[i].GameObject().SetActive(true);
            QTEOrderList[i].sprite = GenerateInput();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GenerateSequence();
            increment = 0;
            hasSucceeded = false;
        }
        Debug.Log("player index : " + indexPlayer + " has touched : "+ Hinput.gamepad[indexPlayer].X.justReleased);
        if (hasSucceeded == false && QTEGenList.Count > 0)
        {
            switch (QTEGenList[increment])
            {
                case 1:
                    if (Hinput.gamepad[indexPlayer].anyInput.justReleased)
                    {
                        if (Hinput.gamepad[indexPlayer].X.justReleased)
                        {
                            Hinput.gamepad[indexPlayer].Vibrate(vibrationLength);
                            CorrectKey = 1;
                            KeyPressing();
                        }
                        else
                        {
                            Hinput.gamepad[indexPlayer].Vibrate(vibrationLength);
                            CorrectKey = 2;
                            KeyPressing();
                        }
                    }

                    break;

                case 2:
                    if (Hinput.gamepad[indexPlayer].anyInput.justReleased)
                    {
                        if (Hinput.gamepad[indexPlayer].Y.justReleased)
                        {
                            Hinput.gamepad[indexPlayer].Vibrate(vibrationLength);
                            CorrectKey = 1;
                            KeyPressing();
                        }
                        else
                        {
                            Hinput.gamepad[indexPlayer].Vibrate(vibrationLength);
                            CorrectKey = 2;
                            KeyPressing();
                        }
                    }

                    break;

                case 3:
                    if (Hinput.gamepad[indexPlayer].anyInput.justReleased)
                    {
                        if (Hinput.gamepad[indexPlayer].B.justReleased)
                        {
                            Hinput.gamepad[indexPlayer].Vibrate(vibrationLength);
                            CorrectKey = 1;
                            KeyPressing();
                        }
                        else
                        {
                            Hinput.gamepad[indexPlayer].Vibrate(vibrationLength);
                            CorrectKey = 2;
                            KeyPressing();
                        }
                    }

                    break;
                case 4:
                    if (Hinput.gamepad[indexPlayer].anyInput.justReleased)
                    {
                        if (Hinput.gamepad[indexPlayer].A.justReleased)
                        {
                            Hinput.gamepad[indexPlayer].Vibrate(vibrationLength);
                            CorrectKey = 1;
                            KeyPressing();
                        }
                        else
                        {
                            Hinput.gamepad[indexPlayer].Vibrate(vibrationLength);
                            CorrectKey = 2;
                            KeyPressing();
                        }
                    }

                    break;

                default:
                    Debug.Log("Default");
                    break;
            }
        }

    }
    void KeyPressing()
    {
        QTEGen = 5;
        switch (CorrectKey)
        {
            case 1 :
                QTEOrderList[increment].GameObject().SetActive(false);
                CorrectKey = 0;
                // !!!!!! Son Click
                increment += 1;
                if (increment >= 4)
                {
                    hasSucceeded = true;
                    // !!!!!! Son item collect~~~~~~~~
                }
                break;
                
            case 2 :
                // !!!!!! Son erreur
                CorrectKey = 0;
                GenerateSequence();
                increment = 0;
                break;
        }
    }
}

