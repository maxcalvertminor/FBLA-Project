using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction
{
    public TransactionType type;
    public int amount;
    public DateTime date;
    public string reason;
    public Transaction(TransactionType t, int a, DateTime d, string r = "Unspecified") {
        type = t;
        amount = a;
        date = d;
        reason = r;
    }

}
