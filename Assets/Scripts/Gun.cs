using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public int damage = 10;
    public float range = 100f;
    public Transform muzzle;
    public ParticleSystem shootParticle;

    private Camera playerCamera;

    public enum GUN_TYPE
    {
        Revolver,
        AK47
    }

    private void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        shootParticle.Play();

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {

            ITakeDamage damagable = hit.collider.GetComponent<ITakeDamage>();
            if (damagable != null)
            {
                Rigidbody damagablerb = hit.collider.GetComponent<Rigidbody>();
                Vector3 newVector = hit.point - playerCamera.transform.position;
                damagablerb.AddForce(newVector* 100);
                damagable.TakeDamage(damage);

            }
        }
    }
}
