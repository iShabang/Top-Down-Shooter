using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private GameObject pfParticle;
    void OnCollisionEnter(Collision other)
    {
        GameObject particles = Instantiate(pfParticle, transform.position, Quaternion.identity); 
        Destroy(gameObject);
        Destroy(particles, 1f);
    }
}
