using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SortingMenuScript : MonoBehaviour
{
    public TMP_Text text;
    public int rank_criteria;

    // Start is called before the first frame update
    void Start()
    {
        rank_criteria = 0;
    }

    // Update is called once per frame
    void Update() {
        switch(rank_criteria) {
            case 0:
                text.text = "Date: high to low"; 
                break;
            case 1:
                text.text = "Date: low to high";
                break;
            case 2:
                text.text = "Amount: high to low";
                break;
            case 4:
                text.text = "Amount: low to high";
                break;
        }
    }

    public void SetRankCriteria(int index) {
        rank_criteria = index;
    }
}
