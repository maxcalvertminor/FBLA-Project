using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionButton : InteractScript
{
    public VaultScript vault_script;
    public TransactionType t;
    public int amount;

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
        Transaction t1 = new Transaction(t, amount, DateTime.Now);
        vault_script.transact(t1);
    }
}
