using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour, ITakeDamage
{
    public int health = 30;
    public ParticleSystem destroyParticle;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        destroyParticle.Play();

        if (health<= 0)
        {
            ParticleSystem p = Instantiate(destroyParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
