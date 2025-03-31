using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Transaction
{
    public TransactionType type;
    public int amount;
    public DateTime date;
    public string reason;
    public string account;
    public Transaction(TransactionType t, int a, DateTime d, string r = "Unspecified", string ac = "Checking") {
        type = t;
        amount = a;
        date = d;
        reason = r;
        account = ac;
    }

    public string Write() {
        return "" + account + ": " + type + " of " + amount + ". \n" + reason + " at " + date + ".";
    }

}
