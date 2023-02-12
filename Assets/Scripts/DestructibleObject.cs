using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [SerializeField] private float hpInitial = 100;
    [SerializeField] private float hpCurrent = 100;

    public void ReceiveDamage()
    {
        hpCurrent -= 1;

        if (hpCurrent < 0f)
        {
            Destroy(gameObject);
        }
    }
}
