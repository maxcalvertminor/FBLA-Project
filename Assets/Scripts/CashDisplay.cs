using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashDisplay : MonoBehaviour
{
    private int displaycash = 0;
    public Text cashText;

   // public int FinalTransAmount;

    //public GameObject InputHandlerHandler;
   // private InputHandler inputs;

    void Start()
    {
        // Debug.Log(InputHandlerHandler);
        // FinalTransAmount = InputHandlerHandler.GetComponent<InputHandler>().TransAmount;
        
    }
    void Update()
    {
        
        
       // cashText.text = "Net Worth = $" + displaycash;
        if(Input.GetKeyDown(KeyCode.Space)){
        displaycash++;
        cashText.text = "Net Worth = $" + displaycash;
        }
    }

}
