using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private PlayerHealth playerHealth;
    public float checkRate = 0.01f;
    public ParticleSystem deathParticle;
    float nextCheck;
    UnityEngine.AI.NavMeshAgent myNavMesh;

    void Start()
    {
        myNavMesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.position);
        if(distance < 2)
        {
            ParticleSystem explosion = Instantiate(deathParticle);
            explosion.transform.position = gameObject.transform.position;
            explosion.Play();
            playerHealth.TakeDamage(20f);
            Debug.Log(playerHealth.GetHealth());
            Destroy(gameObject);
        }
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            FollowPlayer();
        }
    }
    
    void FollowPlayer()
    {
        myNavMesh.transform.LookAt(player);
        myNavMesh.destination = player.position;
    }
}
