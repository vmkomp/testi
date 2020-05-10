using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup_weapon : MonoBehaviour
{
    GameObject gunModel;
    public Text pickUpText;
    bool isPickUpRange;

    public Gun gun;

    void Start()
    {
        isPickUpRange = false;
        DisablePickUpText();
        gunModel = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        RotateModel();
    }

    private void RotateModel()
    {
        gunModel.transform.Rotate(0.0f, 0.0f, 1.5f, Space.Self);
    }

    public void EnablePickUpText()
    {
        pickUpText.gameObject.SetActive(true);
        pickUpText.text = "Press E to pick up " + gunModel.name.ToString();
        isPickUpRange = true;
    }

    public void DisablePickUpText()
    {
        pickUpText.gameObject.SetActive(false);
        isPickUpRange = false;
    }

    public Gun GetGun()
    {
        return gun;
    }
}
