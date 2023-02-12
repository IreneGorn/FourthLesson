using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject handgun;
    [SerializeField] private GameObject autoRifle;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !handgun.activeInHierarchy)
        {
            handgun.SetActive(true);
            autoRifle.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && !autoRifle.activeInHierarchy)
        {
            autoRifle.SetActive(true);
            handgun.SetActive(false);
        }
    }
}
