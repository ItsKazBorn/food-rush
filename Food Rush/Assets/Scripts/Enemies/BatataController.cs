using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatataController : Enemy
{
    private GameObject player;
    [SerializeField] private GameObject sprite;

    [Header("Explosion")]
    [SerializeField] private float explosionRadius = 10f;
    [SerializeField] private float force = 10f;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject explosionEffect2;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_transform.position, explosionRadius);
    }

    protected override void ChangeDirection()
    {
        direction = (player.transform.position - transform.position).normalized;
    }

    protected override void Die()
    {
        Explode();
    }

    void Explode()
    {
        GameObject explosion1 = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(explosion1, 2f);
        GameObject explosion2 = Instantiate(explosionEffect2, transform.position, transform.rotation);
        Destroy(explosion2, 2f);
        
        Collider[] collidersToDamage = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in collidersToDamage)
        {
            if (nearbyObject.CompareTag("Player"))
            {
                nearbyObject.GetComponent<PlayerController>().TakeDamage(force);
                Debug.Log("Player Damaged by " + force);
            }
            /*
            else if (nearbyObject.CompareTag("Enemy"))
            {
                nearbyObject.GetComponent<Enemy>().TakeDamage(force);
            }
            */
        }


        Destroy(gameObject);
        
    }
}
