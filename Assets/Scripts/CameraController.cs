using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity = 100f;
    Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;

    private void Start()
    {
        playerBody = transform.parent;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        yRotation += mouseX;
        playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        //playerBody.Rotate(Vector3.up * mouseX);
        //Vector3.up == new Vector3(0f, 1f, 0f);
    }
}
