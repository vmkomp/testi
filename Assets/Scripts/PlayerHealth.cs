using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    private float currentHealth;
    public float maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
        SetHealthBar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20f);
            Debug.Log(currentHealth);
        }
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        healthBar.fillAmount = fillAmount;
    }
}
