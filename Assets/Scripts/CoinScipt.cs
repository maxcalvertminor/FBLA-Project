using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CoinScipt : MonoBehaviour
{
    public float timer;
    public float seconds;
    private bool ticking;
    // Start is called before the first frame update
    void Start()
    {
        timer = seconds;
        ticking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Rigidbody>().isKinematic == false) {
            ticking = true;
        }
        if(ticking) {
            timer -= Time.deltaTime;
        }
        if(timer < 0) {
            ticking = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision other) {
        if(GetComponent<Rigidbody>().isKinematic == true) {
            //GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnCollisionStay(Collision other) {
        
    }
 }
