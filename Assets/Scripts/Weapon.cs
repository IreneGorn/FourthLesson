using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float force = 4f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private GameObject impactPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float spreadConfig = 0.1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var randomX = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var randomY = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var spread = new Vector3(randomX, randomY, 0);
            Vector3 direction = shootPoint.forward + spread;
            //Random.Range(0, 10);
            
            if (Physics.Raycast(shootPoint.position, direction, out var hit))
            {
                print(hit.transform.gameObject.name);

                Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));

                var destructible = hit.transform.GetComponent<DestructibleObject>();
                if (destructible != null)
                {
                    destructible.ReceiveDamage(damage);
                }
                
                var rigidbody = hit.transform.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    rigidbody.AddForce(shootPoint.forward * force, ForceMode.Impulse);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawRay(shootPoint.position, shootPoint.forward * 9999);
    }
}
