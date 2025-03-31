using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionButton : InteractScript
{
    public VaultScript vault_script;
    public TransactionType t;
    public int amount;
    public string category;
    public string account;

    public InputHandler InputHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void interact() {
        t = InputHandler.ActionSelect.GetComponent<DropdownMenu>().type;
        amount = InputHandler.TransAmount;
        if(InputHandler.category.Equals("") || InputHandler.category == null) {
            category = "Unspecified";
        } else {
            category = InputHandler.category;
        }
        account = InputHandler.account;
        Transaction t1 = new Transaction(t, amount, DateTime.Now, category, account);
        vault_script.transact(t1);
    }
}
