using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Components
    protected Transform _transform;
    
    // Health
    [SerializeField] private float health = 10f;

    // Movement
    [SerializeField] private float speed = 3;
    protected float xBounds = 16;
    protected float yBounds = 6;
    protected Vector3 direction;

    protected virtual void Start()
    {
        _transform = transform;
    }
    
    protected virtual void Update()
    {
        ChangeDirection();
        _transform.Translate(direction * (speed * Time.deltaTime));
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void ChangeDirection() { }


}
