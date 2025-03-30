using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SearchFunctions : MonoBehaviour
{
    public bool deposits_shown;
    public bool withdrawals_shown;
    public bool transfers_shown;
    public string category;

    // 0 is Date high to low, 1 is Date low to high, 2 is Amount high to low, 3 is Amount low to high
    public int rank_criteria;
    public float scroll_distance;


    public List<Transaction> unfiltered_data;
    public List<Transaction> unorganized_data;
    public List<Transaction> filtered_organized_data;
    public List<GameObject> displayed_data;

    public GameObject vault;
    public GameObject rank_type_obj;
    public GameObject category_obj;
    public GameObject display_area;
    public GameObject single_item_prefab;

    public Vector2 starting_pos;
    public Vector2 starting_pos_reset;
    public Vector2 single_item_dimensions;
    public Vector2 distance_between_items;

    // Start is called before the first frame update
    void Start()
    {
        unfiltered_data = new List<Transaction>();
        unorganized_data = new List<Transaction>();
        filtered_organized_data = new List<Transaction>();
        displayed_data = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        unfiltered_data = vault.GetComponent<VaultScript>().transaction_list;
        rank_criteria = rank_type_obj.GetComponent<SortingMenuScript>().rank_criteria;
        
    }

    public void Search() {

        filtered_organized_data.Clear();

        // filtering
        for(int i = 0; i < unfiltered_data.Count; i++) {
            Transaction c = unfiltered_data[i];
            if(c.reason.Equals(category) || category.Equals("Show all")) {
                switch(c.type) {
                    case TransactionType.Deposit:
                        if(deposits_shown == true) {unorganized_data.Add(c);}
                        break;
                    case TransactionType.Withdrawal:
                        if(withdrawals_shown == true) {unorganized_data.Add(c);}
                        break;
                    case TransactionType.Transfer:
                        if(transfers_shown == true) {unorganized_data.Add(c);}
                        break;
                }
            }
        }

        // organizing
        int best_index = 0;
        while(unorganized_data.Count > 0) {
            best_index = 0;
            for(int i = 0; i < unorganized_data.Count; i++) {
                Debug.Log("Index: " + i);
                Debug.Log("Count: " + unorganized_data.Count);
                switch(rank_criteria) {
                    case 0:
                        if(DateTime.Compare(unorganized_data[best_index].date, unorganized_data[i].date) < 0) {best_index = i;}
                        break;
                    case 1:
                        if(DateTime.Compare(unorganized_data[best_index].date, unorganized_data[i].date) > 0) {best_index = i;}
                        break;
                    case 2:
                        if(unorganized_data[i].amount > unorganized_data[best_index].amount) {best_index = i;}
                        break;
                    case 3:
                        if(unorganized_data[i].amount < unorganized_data[best_index].amount) {best_index = i;}
                        break;
                }
            }
            filtered_organized_data.Add(unorganized_data[best_index]);
            unorganized_data.RemoveAt(best_index);
        }
    }

    public void Generate_Display() {
        for(int i = 0; i < displayed_data.Count; i++) {
            Destroy(displayed_data[i]);
        }
        displayed_data.Clear();

        Search();
        for(int i = 0; i < filtered_organized_data.Count; i++) {
            GameObject c = Instantiate(single_item_prefab, display_area.transform);
            c.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, single_item_dimensions.x);
            c.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, single_item_dimensions.y);
            c.GetComponent<RectTransform>().localPosition = starting_pos - distance_between_items * i;
            c.transform.GetChild(0).GetComponent<TMP_Text>().text = "" + filtered_organized_data[i].Write();
            displayed_data.Add(c);
        }
        if(displayed_data.Count == 0) {
            GameObject c = Instantiate(single_item_prefab, display_area.transform);
            c.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, single_item_dimensions.x);
            c.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, single_item_dimensions.y);
            c.GetComponent<RectTransform>().localPosition = starting_pos;
            c.transform.GetChild(0).GetComponent<TMP_Text>().text = "No results found.";
            displayed_data.Add(c);
        }
    }

    public void ScrollUp() {
        starting_pos += new Vector2(0, scroll_distance);
        Generate_Display();
    }
    public void ScrollDown() {
        starting_pos -= new Vector2(0, scroll_distance);
        Generate_Display();
    }

    public void Toggle_deposits_shown() {
        deposits_shown = !deposits_shown;
    }
    public void Toggle_withdrawals_shown() {
        withdrawals_shown = !withdrawals_shown;
    }
    public void Toggle_transfers_shown() {
        transfers_shown = !transfers_shown;
    }

    public void SearchButtonMethod() {
        starting_pos = starting_pos_reset;
        Generate_Display();
    }
}
