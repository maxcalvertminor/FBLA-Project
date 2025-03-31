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
    public TMP_Text CategoryDisplay;
    public TMP_Text AccountDisplay;
    private int amounttran;
    public string account;
    public string category;

    public GameObject ActionSelect;
    public GameObject AccountSelect;

    void Start() {
        account = "Checkings";
    }
    // Update is called once per frame
    void Update()
    {
    //  _wordText.text = _wordInputField.text;

     //RelayText.text = "You are " + amounttran.ToString();   
     TransAmount = amounttran;
     AmountDisplay.text = amounttran.ToString();
    }
    public void numImput() {
        int.TryParse(AmountInput.text, out amounttran);
    }

    public void catInput(string cat) {
        category = cat;
        CategoryDisplay.text = cat;
    }
    
    public void setAccount(int index) {
        switch(index) {
            case 0:
                account = "Checkings";
                AccountDisplay.text = "Checkings";
                break;
            case 1:
                account = "Savings";
                AccountDisplay.text = "Savings";
                break;
            case 2:
                account = "Untitled 1";
                AccountDisplay.text = "Untitled 1";
                break;
            case 3:
                account = "Untitled 2";
                AccountDisplay.text = "Untitled 2";
                break;
        }
    }

}
