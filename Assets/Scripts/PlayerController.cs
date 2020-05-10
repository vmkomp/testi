using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    Vector3 moveVelocity;

    float mouseX;
    float mouseY;
    Transform playerCamera;
    float xRotation = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main.transform;
        
    }

    public void Move(Vector3 moveVelocity) {
        this.moveVelocity = moveVelocity;
    }

    public void Rotate(float mouseX, float mouseY)
    {
        this.mouseX = mouseX;
        this.mouseY = mouseY;
    }

    public void FixedUpdate()
    {
        characterController.Move(moveVelocity * Time.fixedDeltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
