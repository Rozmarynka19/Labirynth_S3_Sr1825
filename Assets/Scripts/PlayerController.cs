using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 12f;
    CharacterController characterController;

    [SerializeField]
    Transform groundChecker;
    [SerializeField]
    LayerMask groundMask;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CheckTheGround();
        PlayerMove();
    }

    private void CheckTheGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundChecker.position, transform.up * (-1), out hit, 0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;
            switch(terrainType)
            {
                case "Low":
                    speed = 3f;
                    break;
                case "High":
                    speed = 20f;
                    break;
                default:
                    speed = 12f;
                    break;
            }
        }
    }

    private void PlayerMove()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        // Vector3.right
        // transform.right
        // Vector3 move = Vector3.right * moveX + Vector3.forward * moveZ;
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
