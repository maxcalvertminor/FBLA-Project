using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : InteractScript
{

    public GameObject textbox;

    // Start is called before the first frame update
    void Start()
    {
        textbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact() {
        textbox.SetActive(true);
    }
}
