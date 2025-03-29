using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AccountSelectCode : MonoBehaviour
{
   
    [SerializeField] private TMP_Text Selection2;

  
  public void DropdownSamples(int index){
    switch (index){
        case 0: Selection2.text = "Select Action2";  break;
        case 1: Selection2.text = "Deposit To2:";  break;
        case 2: Selection2.text = "Withdrawl From2:";  break;
        case 3: Selection2.text = "Take From2:"; break;
    }
  }
    //...
}


