using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour
{
    [SerializeField] private float force = 4f;
    [SerializeField] private GameObject impactPrefab;
    [SerializeField] private Transform shootPoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
            {
                print(hit.transform.gameObject.name);

                Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));

                var rigidbody = hit.transform.GetComponent<Rigidbody>();
                if (rigidbody == null)
                {
                    //hit.transform.gameObject.SetActive(false);
                    return;
                }
                rigidbody.AddForce(shootPoint.forward * force, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawRay(shootPoint.position, shootPoint.forward * 9999);
    }
}
