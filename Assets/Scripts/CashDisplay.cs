using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashDisplay : MonoBehaviour
{
    private int displaycash = 0;
    public Text cashText;

    // Opt1: reference to vault - set in inspector 
    public GameObject vault;

    // Opt2: access value TransAmount through Input Handler Script in InputHandlerHandler obj
    public InputHandler input_handler;


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

        // Opt1: use GetComponent<> to get access to vault script, which has access to the net amount of money variable
        cashText.text = "Net Worth = $" + vault.GetComponent<VaultScript>().amount;

        //Opt2: use InputHandler script to get access to TransAmount (Or any other public variable in InputHandler)
        cashText.text = "Net Worth = $" + input_handler.TransAmount;
        
    }

}
