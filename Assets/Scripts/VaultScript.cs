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
    public GameObject[] gem_list;
    public List<GameObject> drop_list;
    public Vector3 coin_drop_pos;
    public float randomness;
    private bool dropping;
    public float useful_y_constant;
    public float coin_rate_of_fire;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        sack_o_coins = new List<GameObject>();
        drop_list = new List<GameObject>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(drop_list.Count != 0) {
            timer += Time.deltaTime;
            if(timer > coin_rate_of_fire) {
                timer = 0;
                Instantiate(drop_list[0], coin_drop_pos, Random.rotation);
                drop_list.RemoveAt(0);
            }
        }
    }

    public void transact(Transaction t) {
        //list.add(t);
        if(t.type == TransactionType.Deposit) {
            amount += t.amount;
            int gems = amount / 1000;
            int gold = amount % 1000 / 100;
            int silver = amount % 1000 % 100 / 10;
            int bronze = amount % 1000 % 100 % 10;

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
        } else {
            amount -= t.amount;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(coin_drop_pos, Vector3.one);
    }
}
