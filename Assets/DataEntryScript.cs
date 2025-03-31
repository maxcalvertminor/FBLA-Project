using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataEntryScript : MonoBehaviour
{
    public int value;
    public GameObject value_holder;
    public TMP_Text display_obj;
    public int data_type;
    public string opt_text;

    // Start is called before the first frame update
    void Start()
    {
        opt_text = "";
    }

    // Update is called once per frame
    void Update()
    {
        switch(data_type) {
            case 0:
                value = value_holder.GetComponent<VaultScript>().amount;
                break;
            case 1:
                value = value_holder.GetComponent<VaultScript>().checking_account;
                break;
            case 2:
                value = value_holder.GetComponent<VaultScript>().savings_account;
                break;
            case 3:
                value = value_holder.GetComponent<VaultScript>().account1;
                break;
            case 4:
                value = value_holder.GetComponent<VaultScript>().account2;
                break;
            case 5:
                value = value_holder.GetComponent<VaultScript>().deposits;
                opt_text = " deposits";
                break;
            case 6:
                value = value_holder.GetComponent<VaultScript>().withdrawals;
                opt_text = " withdrawals";
                break;
            case 7:
                value = value_holder.GetComponent<VaultScript>().transfers;
                opt_text = " transfers";
                break;
            case 8:
                value = value_holder.GetComponent<VaultScript>().total_transactions;
                opt_text = " total transactions";
                break;
        } 

        display_obj.text = "" + value + opt_text;
    }
}
