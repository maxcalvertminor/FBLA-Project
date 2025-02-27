using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    public Rigidbody body;
    public GameObject mainCamera;
    public float speed;
    private Vector3 direction;
    public float interactDistance;
    private GameObject[] inv;
    //public int invSize;
    //private int invIterator;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, 0, 0);
        //inv = new GameObject[invSize];
        //invIterator = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        direction = new Vector3(xInput, 0, yInput).normalized;
        direction *= speed;
        direction.y = body.velocity.y;
        body.velocity = transform.TransformDirection(direction);

        if(Input.GetButtonDown("Interact")) {
            LayerMask mask = LayerMask.GetMask("Interactable", "Pickupable");
            RaycastHit hit;
            if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactDistance, mask)) {
                Debug.Log("Hit!");
                hit.collider.gameObject.GetComponent<InteractScript>().interact();
                /*if(hit.rigidbody.gameObject.layer == 9) {
                    hit.rigidbody.gameObject.GetComponent<InteractScript>().interact();
                } else if(hit.rigidbody.gameObject.layer == 10) {
                    inv[invIterator] = hit.rigidbody.gameObject;
                    invIterator++;
                }*/
                
            
            }
        }
    }
}
