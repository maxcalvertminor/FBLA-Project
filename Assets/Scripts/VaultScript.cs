using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultScript : MonoBehaviour
{
    public GameObject vault;
    private int amount;
    public List<Transaction> list;
    public List<GameObject> sack_o_coins;
    public GameObject gold_coin;
    public GameObject bronze_coin;
    public GameObject silver_coin;
    public Vector3 coin_drop_pos;
    public float randomness;
    private float timer;
    private bool ticking;
    public float start_timer;
    // Start is called before the first frame update
    void Start()
    {
        sack_o_coins = new List<GameObject>();
        timer = start_timer;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(ticking) {
            timer -= Time.deltaTime;
        }
        if(timer < 0) {
            ticking = false;
            timer = start_timer;
            for(int i = 0; i < sack_o_coins.Count; i++) {
                sack_o_coins[i].GetComponent<Rigidbody>().isKinematic = true;
                Debug.Log("YUH");
            }
        }*/
    }

    public void transact(Transaction t) {
        //list.add(t);
        if(t.type == TransactionType.Deposit) {
            amount += t.amount;
            for(int i = 0; i < t.amount; i++) {
                float random = Random.Range(0f, 6f);
                if(random < 3) {
                    sack_o_coins.Add(Instantiate(gold_coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), new Quaternion(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1), 0)));
                } else if(random < 5) {
                    sack_o_coins.Add(Instantiate(bronze_coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), new Quaternion(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1), 0)));
                } else {
                    sack_o_coins.Add(Instantiate(silver_coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), new Quaternion(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1), 0)));
                }
            }
        } else {
            amount -= t.amount;
        }
    }
}
