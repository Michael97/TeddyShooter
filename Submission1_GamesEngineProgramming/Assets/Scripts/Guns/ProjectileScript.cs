using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    private float lifeTime = 3.0f;

    public float Damage;
    public float BleedDamage;
    public int BleedCount;
	
	// Update is called once per frame
	void Update ()
	{
	    lifeTime -= Time.deltaTime;


	    if (lifeTime <= 0.0f)
	    {
	        Destroy(gameObject);
	    }
	}

    void OnTriggerEnter(Collider col)
    {
        ImpactEffectScript impactScript = col.gameObject.transform.GetComponent<ImpactEffectScript>();

        if (impactScript == null)
        {
            return;
        }

        ParticleSystem impactEffect = impactScript.ImpactEffect;

        if (impactEffect == null)
        {
            return;
        }
        
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
