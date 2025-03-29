using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class UITransactType : InteractScript
{
public TextMeshProUGUI output;
public void HandleInputData(int select){
    if (select == 0){
        Debug.Log("DEPO");
    }
    if (select ==1){
        Debug.Log("WITH");
    }
    if (select ==2){
        Debug.Log("TRANS");

    }
}

  
}
