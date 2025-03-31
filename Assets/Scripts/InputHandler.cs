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
    public GameObject player;

    void Start() {
        account = "Checking";
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
                account = "Checking";
                AccountDisplay.text = "Checking";
                break;
            case 1:
                account = "Savings";
                AccountDisplay.text = "Savings";
                break;
            case 2:
                account = "Emergency";
                AccountDisplay.text = "Emergency";
                break;
            case 3:
                account = "Rainy Day";
                AccountDisplay.text = "Rain Day";
                break;
        }
    }

    public void LockPlayerMovement() {
        player.GetComponent<PlayerMovement>().enabled = false;
    }
    public void UnlockPlayerMovement() {
        player.GetComponent<PlayerMovement>().enabled = true;
    }

}
