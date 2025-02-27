using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;
    public float sensitivity;
    private float yRotate;
    private float xRotate;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yRotate += -mouseY * sensitivity * Time.deltaTime;
        yRotate = Mathf.Clamp(yRotate, -90, 90);
        xRotate += mouseX  * sensitivity * Time.deltaTime;
        cam.transform.localEulerAngles = (new Vector3(yRotate, 0, 0));
        player.transform.eulerAngles = (new Vector3(0, xRotate, 0));
        //player.transform.eulerAngles += (new Vector3(0, mouseX, 0) * sensitivity);
    }
}
