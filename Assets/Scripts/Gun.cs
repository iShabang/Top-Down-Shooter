using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, iWeapon
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float force;

    public void fire()
    {
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * force, ForceMode.Impulse);
    }
}
