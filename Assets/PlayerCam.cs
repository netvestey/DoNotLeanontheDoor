using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public float smooth = 1f;

    private Quaternion targetRotation;

    public int Speed = 50;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


       // if(Input.GetKeyDown(KeyCode.Z))
       // { transform.Rotate(new Vector​3(0.0f, 10.0f, 0.0f)); }

       // if (Input.GetKeyDown(KeyCode.S))
       // { transform.Rotate(new Vector​3(0.0f, -10.0f, 0.0f)); }

        //if (Input.GetKeyDown(KeyCode.R)) // some condition
        //targetRotation = Quaternion.LookRotation(-transform.forward, Vector3.up);

        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smooth * Time.deltaTime);

    }
}
