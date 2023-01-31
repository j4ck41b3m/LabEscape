using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float mouseSensitivity = 2000f;
    public Transform playerBody;
    float xRotation = 0;
    float yRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(8.09f,transform.localRotation.y,transform.localRotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);

        /*/ yRotation = Mathf.Clamp(yRotation, -100f, 100f);
         transform.localRotation = Quaternion.Euler(0, -yRotation, 0);
         playerBody.Rotate(Vector3.right * -mouseY);*/


    }
}
