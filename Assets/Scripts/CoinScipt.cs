using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CoinScipt : MonoBehaviour
{
    public int value;
    [SerializeField] private float c_timer;
    public float seconds;
    public bool ticking;
    private bool flinging;
    private float fling_seconds;
    private float fling_speed;
    private float horizontal_vec;
    private float vertical_vec;
    private float min_vec;

    // Start is called before the first frame update
    void Start()
    {
        
        c_timer = seconds;
        flinging = false;
        GetComponent<Collider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ticking) {
            c_timer -= Time.deltaTime;
        }
        if(c_timer < 0 && ticking == true && flinging == false) {
            ticking = false;
            GetComponent<Rigidbody>().isKinematic = true;
        } 
        if(flinging == true && c_timer > 0) {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().velocity = Vector3.up * fling_speed;
        } else if(flinging == true && c_timer < 0) {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f) * horizontal_vec, vertical_vec, Random.Range(-1f, 1f) * horizontal_vec), ForceMode.VelocityChange);
            Destroy(gameObject, 20f);
            flinging = false;
            ticking = false;
        }
    }

    public void fling(float fseconds, float speed, float h_vec, float v_vec, float m_vec) {
        flinging = true;
        fling_speed = speed;
        fling_seconds = fseconds;
        horizontal_vec = h_vec;
        vertical_vec = v_vec;
        min_vec = m_vec;
        c_timer = fseconds;
        GetComponent<Collider>().enabled = false;
        ticking = true;
        Debug.Log("FLUNG");
    }

    /*void OnCollisionEnter(Collision other) {
        if(GetComponent<Rigidbody>().isKinematic == true) {
            //GetComponent<Rigidbody>().isKinematic = false;
            timer = seconds;
        }
    }*/

    void OnCollisionStay(Collision other) {
        
    }
 }
