using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownMenu2 : MonoBehaviour
{
  public int typeChosen;
    [SerializeField] private TMP_Text Selection;
    public int ChosenAction;
  
  public void DropdownSample(int index){
    switch (index){
        case 0: Selection.text = "Select Action"; ChosenAction=0; break;
        case 1: Selection.text = "Deposit To:";  ChosenAction=1;break;
        case 2: Selection.text = "Withdrawl From:";  ChosenAction=2;break;
        case 3: Selection.text = "Take From:"; ChosenAction=3;break;
    }
  }
    //...
}

