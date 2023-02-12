using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]  private float delay = 3f;
    [SerializeField]  private float radius = 5f;
    [SerializeField]  private float force = 700f;
    [SerializeField]  private float damage = 80f;
    [SerializeField]  private GameObject explosionEffect;

    private float countdown;
    private bool hasExploded = false;

    void Start()
    {
        countdown = delay;
    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToDestroy)
        {
            DestructibleObject destObj = nearbyObject.GetComponent<DestructibleObject>();
            if (destObj != null)
            {
                destObj.ReceiveDamage(damage);
            }
        }
        
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
