using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class VaultScript : MonoBehaviour
{
    public GameObject vault;
    public int amount;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public int checking_account;
    public int savings_account;
    public int account1;
    public int account2;
    public int deposits;
    public int withdrawals;
    public int transfers;
    public int total_transactions;
    public List<Transaction> transaction_list;
=======
=======
>>>>>>> Stashed changes
    public List<Transaction> list;
>>>>>>> Stashed changes
    public List<GameObject> sack_o_coins;
    public GameObject gold_coin;
    public GameObject bronze_coin;
    public GameObject silver_coin;
    public GameObject[] gem_list;
    public List<GameObject> drop_list;
    public Vector3 coin_drop_pos;
    public float randomness;
    private bool dropping;
    public float proportion_constant;
    private float coin_rate_of_fire;
    private float v_timer;

    public float fling_seconds;
    public float fling_speed;
    public Vector3 fling_vector;

    // Start is called before the first frame update
    void Start()
    {
        sack_o_coins = new List<GameObject>();
        drop_list = new List<GameObject>();
        transaction_list = new List<Transaction>();
        v_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(drop_list.Count != 0) {
            v_timer += Time.deltaTime;
            if(v_timer > coin_rate_of_fire) {
                v_timer = 0;
                GameObject c_coin = Instantiate(drop_list[0], coin_drop_pos, Random.rotation);
                c_coin.GetComponent<CoinScipt>().ticking = true;
                sack_o_coins.Add(c_coin);
                drop_list.RemoveAt(0);
            }
        }
    }

    public void transact(Transaction t) {
        transaction_list.Add(t);
        if(t.type == TransactionType.Deposit) {
            amount += t.amount;
            int gems = t.amount / 1000;
            int gold = t.amount % 1000 / 100;
            int silver = t.amount % 1000 % 100 / 10;
            int bronze = t.amount % 1000 % 100 % 10;

            for(int i = 0; i < gems; gems--) {
                drop_list.Add(gem_list[Random.Range(0, gem_list.Length)]);
            }
            for(int i = 0; i < gold; gold--) {
                drop_list.Add(gold_coin);
            }
            for(int i = 0; i < silver; silver--) {
                drop_list.Add(silver_coin);
            }  
            for(int i = 0; i < bronze; bronze--) {
                drop_list.Add(bronze_coin);
            }

            deposits++;
            total_transactions++;

            switch(t.account) {
                case "Checking":
                    checking_account += t.amount;
                    break;
                case "Savings":
                    savings_account += t.amount;
                    break;
                case "Emergency":
                    account1 += t.amount;
                    break;
                case "Rainy Day":
                    account2 += t.amount;
                    break;
            }
        } else {
            amount -= t.amount;
            float value = 0;
            for(float i = 0; i < t.amount; i += value){
                if(sack_o_coins.Count == 0) {
                    i = t.amount + 1;
                }
                sack_o_coins[sack_o_coins.Count - 1].GetComponent<CoinScipt>().fling(fling_seconds, fling_speed, fling_vector.x, fling_vector.y, fling_vector.z);
                value = sack_o_coins[sack_o_coins.Count - 1].GetComponent<CoinScipt>().value;
                sack_o_coins.RemoveAt(sack_o_coins.Count - 1);
            }

            if(t.type == TransactionType.Withdrawal) {
                withdrawals++;
            } else {
                transfers++;
            }
            total_transactions++;

            switch(t.account) {
                case "Checking":
                    checking_account -= t.amount;
                    break;
                case "Savings":
                    savings_account -= t.amount;
                    break;
                case "Account 1":
                    account1 -= t.amount;
                    break;
                case "Account 2":
                    account2 -= t.amount;
                    break;
            }
        }
        if(drop_list.Count > 27) {
            coin_rate_of_fire = proportion_constant / drop_list.Count;
        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(coin_drop_pos, Vector3.one);
    }
}
