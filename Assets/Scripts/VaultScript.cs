using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultScript : MonoBehaviour
{
    public GameObject vault;
    private int amount;
    public List<Transaction> list;
    public GameObject coin;
    public Vector3 coin_drop_pos;
    public float randomness;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transact(Transaction t) {
        //list.add(t);
        if(t.type == TransactionType.Deposit) {
            amount += t.amount;
            for(int i = 0; i < t.amount; i++) {
                Instantiate(coin, coin_drop_pos + new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), Random.Range(-randomness, randomness)), new Quaternion(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1), 0));
            }
        } else {
            amount -= t.amount;
        }
    }
}
