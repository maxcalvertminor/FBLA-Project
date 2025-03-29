using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownMenu : MonoBehaviour
{
  public int typeChosen;
    [SerializeField] private TMP_Text Selection;
    public int ChosenAction;
    public TransactionType type;
  
  public void DropdownSample(int index){
    switch (index){
        case 0: Selection.text = "Select Action"; ChosenAction=0; break;
        case 1: Selection.text = "Deposit To:";  ChosenAction=1;break;
        case 2: Selection.text = "Withdraw From:";  ChosenAction=2;break;
        case 3: Selection.text = "Take From:"; ChosenAction=3;break;
    }
    switch (index){
        case 0: break;
        case 1: type = TransactionType.Deposit; break;
        case 2: type = TransactionType.Withdrawal; break;
        case 3: type = TransactionType.Transfer; break;
    }
  }
    //...
}

