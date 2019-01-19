using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupContainer : HealthScript
{

    public GameObject[] PrefabPickupGameObjects;

	// Use this for initialization
	void Start () {
	    SetUpHealthStats();
    }

    public override void Dead()
    {
        int i = Random.Range(0, PrefabPickupGameObjects.Length);

        Instantiate(PrefabPickupGameObjects[i], transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
