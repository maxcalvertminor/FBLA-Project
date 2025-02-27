using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionButton : InteractScript
{
    public VaultScript vault_script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void interact() {
        Transaction t1 = new Transaction(TransactionType.Deposit, 100, new Vector3(0, 0, 0));
        vault_script.transact(t1);
    }
}
