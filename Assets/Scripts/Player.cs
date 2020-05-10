using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour {

    PlayerController controller;
    GunController gunController;
    public float moveSpeed = 12f;
    public float mouseSensitivy = 100f;

    bool isPickUpRange;
    Pickup_weapon pickupWeapon;

    void Start()
    {
        pickupWeapon = null;
        isPickUpRange = false;
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveVelocity = (transform.right * x + transform.forward * z)*moveSpeed;
        controller.Move(moveVelocity);

        // Rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivy * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivy * Time.deltaTime;
        controller.Rotate(mouseX, mouseY);

        if (Input.GetKeyDown(KeyCode.E) && isPickUpRange)
        {
            Debug.Log("Pressed E");
            Debug.Log(pickupWeapon.GetGun());
            gunController.EquipGun(pickupWeapon.GetGun());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(pickupWeapon == null)
        {
            pickupWeapon = other.GetComponentInParent<Pickup_weapon>();
        }
        Debug.Log(pickupWeapon);
        pickupWeapon.EnablePickUpText();
        isPickUpRange = true;

    }

    private void OnTriggerExit(Collider other)
    {
        pickupWeapon.DisablePickUpText();
        pickupWeapon = null;
        isPickUpRange = false;
    }
}
