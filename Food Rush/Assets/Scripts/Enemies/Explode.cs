using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public float radius = 3f;
    public ParticleSystem explosionEffect;
    public float force = 10f;

    public void ExplodeObject()
    {
        Collider[] collidersToDamage = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToDamage)
        {
            if (nearbyObject.CompareTag("Player"))
            {
                nearbyObject.GetComponent<PlayerController>().TakeDamage(force);
            }
            else if (nearbyObject.CompareTag("Enemy"))
            {
                nearbyObject.GetComponent<Enemy>().TakeDamage(force);
            }
        }
        
        // Instantiate Particle /  Explosion Effect
    }
}
