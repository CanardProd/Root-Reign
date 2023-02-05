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
    private Image FirstBtn, SecondBtn, ThirdBtn, FourthBtn, FirstBtn1, SecondBtn1, ThirdBtn1, FourthBtn1;

    private Image BackFirstBtn,
        BackSecondBtn,
        BackThirdBtn,
        BackFourthBtn,
        BackFirstBtn1,
        BackSecondBtn1,
        BackThirdBtn1,
        BackFourthBtn1;

    private List<Image> QTEOrderList;

    private List<Image> imagesBackground;
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
        imagesBackground = new List<Image>();

        increment = 0;
        
        blue = Resources.Load("Materials/Bluez", typeof(Material)) as Material;
        red = Resources.Load("Materials/Redz", typeof(Material)) as Material;

        X_Btn = Resources.Load("UI/X_Btn", typeof(Sprite)) as Sprite;
        Y_Btn = Resources.Load("UI/Y_Btn", typeof(Sprite)) as Sprite;
        B_Btn = Resources.Load("UI/B_Btn", typeof(Sprite)) as Sprite;
        A_Btn = Resources.Load("UI/A_Btn", typeof(Sprite)) as Sprite;

        FirstBtn = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        BackFirstBtn = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        FirstBtn.CrossFadeAlpha(0,0, false);
        SecondBtn = gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
        BackSecondBtn = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        SecondBtn.CrossFadeAlpha(0,0, false);
        ThirdBtn = gameObject.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
        BackThirdBtn = gameObject.transform.GetChild(0).GetChild(2).GetComponent<Image>();
        ThirdBtn.CrossFadeAlpha(0, 0, false);
        FourthBtn = gameObject.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>();
        BackFourthBtn = gameObject.transform.GetChild(0).GetChild(3).GetComponent<Image>();
        FourthBtn.CrossFadeAlpha(0,0, false);
        FirstBtn1 = gameObject.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>();
        BackFirstBtn1 = gameObject.transform.GetChild(0).GetChild(4).GetComponent<Image>();
        FirstBtn1.CrossFadeAlpha(0,0, false);
        SecondBtn1 = gameObject.transform.GetChild(0).GetChild(5).GetChild(0).GetComponent<Image>();
        BackSecondBtn1 = gameObject.transform.GetChild(0).GetChild(5).GetComponent<Image>();
        SecondBtn1.CrossFadeAlpha(0,0, false);
        ThirdBtn1 = gameObject.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<Image>();
        BackThirdBtn1 = gameObject.transform.GetChild(0).GetChild(6).GetComponent<Image>();
        ThirdBtn1.CrossFadeAlpha(0,0, false);
        FourthBtn1 = gameObject.transform.GetChild(0).GetChild(7).GetChild(0).GetComponent<Image>();
        BackFourthBtn1 = gameObject.transform.GetChild(0).GetChild(7).GetComponent<Image>();
        FourthBtn1.CrossFadeAlpha(0,0, false);
        
        imagesBackground.Add(BackFirstBtn);
        imagesBackground.Add(BackSecondBtn);
        imagesBackground.Add(BackThirdBtn);
        imagesBackground.Add(BackFourthBtn);
        imagesBackground.Add(BackFirstBtn1);
        imagesBackground.Add(BackSecondBtn1);
        imagesBackground.Add(BackThirdBtn1);
        imagesBackground.Add(BackFourthBtn1);

        foreach (Image image in imagesBackground)
        { 
            image.CrossFadeAlpha(0,0,false);
        }

        
        
        GetComponent<Renderer>().material = red;

        CreateList(indexPlayer);
        RecreateBackList(indexPlayer);
        /////////////////////////////////////////////
        //GenerateSequence();
    }
    
    void CreateList(int index)
    {
        if (index == 0)
        {
            QTEOrderList.Add(FirstBtn);
            QTEOrderList.Add(SecondBtn);
            QTEOrderList.Add(ThirdBtn);
            QTEOrderList.Add(FourthBtn);
        }
        else if (index == 1)
        {
            QTEOrderList.Add(FirstBtn1);
            QTEOrderList.Add(SecondBtn1);
            QTEOrderList.Add(ThirdBtn1);
            QTEOrderList.Add(FourthBtn1);
        }
    }
    
    void RecreateBackList(int index)
    {
        imagesBackground.Clear();
        if (index == 0)
        {
            imagesBackground.Add(BackFirstBtn);
            imagesBackground.Add(BackSecondBtn);
            imagesBackground.Add(BackThirdBtn);
            imagesBackground.Add(BackFourthBtn);
        }
        else if (index == 1)
        {
            imagesBackground.Add(BackFirstBtn1);
            imagesBackground.Add(BackSecondBtn1);
            imagesBackground.Add(BackThirdBtn1);
            imagesBackground.Add(BackFourthBtn1);
        }
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
            //QTEOrderList[i].GameObject().SetActive(true);
            QTEOrderList[i].CrossFadeAlpha(255, 0.1f, false);
            imagesBackground[i].CrossFadeAlpha(255, 0.1f, false);
            QTEOrderList[i].sprite = GenerateInput();
        }
    }

    public void ResetFlag()
    {
        QTEGenList.Clear();
        increment = 0;
        hasSucceeded = false;
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
                QTEOrderList[increment].CrossFadeAlpha(0,0,false);
                imagesBackground[increment].CrossFadeAlpha(0,0,false);
                //QTEOrderList[increment].SetActive(false);
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

