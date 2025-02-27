using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction
{
    public TransactionType type;
    public int amount;
    public Vector3 date;
    public string reason;
    public Transaction(TransactionType t, int a, Vector3 d, string r = "Unspecified") {
        type = t;
        amount = a;
        date = d;
        reason = r;
    }

}
