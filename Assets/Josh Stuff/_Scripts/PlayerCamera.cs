using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;

    float xRot;
    float yRot;

    [Header("Object References")]
    public Camera playerCam;
    public Transform orientation;

    [Header("Mouse Parameters")]
    public float sensX;
    public float sensY;

    [Header("Camera Parameters")]
    public float camFOV;

    private void Awake()
    {
        playerCam.fieldOfView = camFOV;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        yRot += mouseX;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        playerCam.transform.localRotation = Quaternion.Euler(xRot, yRot, playerCam.transform.rotation.z);
        orientation.localRotation = Quaternion.Euler(0, yRot, 0);
    }
}
