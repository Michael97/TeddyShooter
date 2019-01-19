using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplosionScript : MonoBehaviour
{
    public ParticleSystem ExplosionParticleSystem;

    public float Radius;

    public float Force;

    public float Damage;

    public float BleedDamage;

    public int BleedCount;

    public bool ShouldDestoryItself;

    public void Explode()
    {
        Vector3 position = new Vector3(transform.position.x, 1.0f, transform.position.z);

        Instantiate(ExplosionParticleSystem, position, Quaternion.Euler(90.0f, transform.rotation.y, transform.rotation.z));

        Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            NavMeshAgent navMesh = nearbyObject.GetComponent<NavMeshAgent>();
            
            if (rb != null && navMesh != null)
            {
                navMesh.enabled = false;
                rb.AddExplosionForce(Force, transform.position, Radius);
            }

            HealthScript healthScript = nearbyObject.GetComponent<HealthScript>();

            if (healthScript != null)
            {
                healthScript.TakeDamage(Damage, BleedDamage, BleedCount);
            }

        }
        if (ShouldDestoryItself)
        {
            Destroy(gameObject);
        }
    }
}
