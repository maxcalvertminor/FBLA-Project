using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultScript : MonoBehaviour
{
    public GameObject vault;
    public int amount;
    public List<Transaction> list;
    public List<GameObject> sack_o_coins;
    public GameObject gold_coin;
    public GameObject bronze_coin;
    public GameObject silver_coin;
    public Vector3 coin_drop_pos;
    public float randomness;
    private bool dropping;
    public float useful_y_constant;
    public float coin_rate_of_fire;
    private int coins_to_drop;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        sack_o_coins = new List<GameObject>();
        coins_to_drop = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(coins_to_drop > 0) {
            timer += Time.deltaTime;
            if(timer > coin_rate_of_fire) {
                timer = 0;
                float random = Random.Range(0f, 6f);
                if(Random.Range(0f, 6f) < 3) {
                    sack_o_coins.Add(Instantiate(gold_coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), Random.rotation));
                } else if(random < 5) {
                    sack_o_coins.Add(Instantiate(bronze_coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), Random.rotation));
                } else {
                    sack_o_coins.Add(Instantiate(silver_coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), Random.rotation));
                }
                coins_to_drop--;
            }
        }
    }

    public void transact(Transaction t) {
        //list.add(t);
        if(t.type == TransactionType.Deposit) {
            amount += t.amount;
            coins_to_drop += t.amount;
            /* for(int i = 0; i < t.amount; i++) {
                float random = Random.Range(0f, 6f);
                if(random < 3) {
                    sack_o_coins.Add(Instantiate(gold_coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), useful_y_constant * Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), Random.rotation));
                } else if(random < 5) {
                    sack_o_coins.Add(Instantiate(bronze_coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), Random.rotation));
                } else {
                    sack_o_coins.Add(Instantiate(silver_coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), Random.rotation));
                }
            } */
        } else {
            amount -= t.amount;
        }
    }
}
