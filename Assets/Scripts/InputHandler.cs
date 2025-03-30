using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    // public TMP_Text _wordText;
    // public TMP_InputField _wordInputField;

    public TMP_Text RelayText;
    public TMP_InputField AmountInput;
    public int TransAmount;
    public TMP_Text AmountDisplay;
    private int amounttran;

    public GameObject ActionSelect;
    public GameObject AccountSelect;

    // Update is called once per frame
    void Update()
    {
    //  _wordText.text = _wordInputField.text;

     //RelayText.text = "You are " + amounttran.ToString();   
     TransAmount = amounttran;
     AmountDisplay.text = amounttran.ToString();
    }
    public void numImput(){
        int.TryParse(AmountInput.text, out amounttran);
    }
   

}
