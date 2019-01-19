using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrenadeThrower : MonoBehaviour
{
    public float ThrowForce;

    public GameObject GrenadePrefab;

    public int GrenadeCount;

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("g") && GrenadeCount > 0)
	    {
	        ThrowGrenade();
	    }
	}

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(GrenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        Physics.IgnoreCollision(grenade.GetComponent<Collider>(), GetComponentInChildren<Collider>());
        rb.AddForce(transform.forward * ThrowForce, ForceMode.VelocityChange);
        GrenadeCount -= 1;
    }
}
