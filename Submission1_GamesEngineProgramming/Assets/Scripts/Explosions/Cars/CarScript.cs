using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CarScript : Entity
{

    public GameObject Fire;

    public ExplosionScript ExplosionScript;

    // Use this for initialization
    void Start () {
		SetUpHealthStats();
	}
	
	// Update is called once per frame
	void Update () {
        if (!InfiniteBleed)
		    CheckForInfiniteBleed();
        else if (InfiniteBleed && Fire.activeInHierarchy == false)
	    {
	        Fire.SetActive(true);
	    }
	}

    public override void Dead()
    {
        gameObject.GetComponent<Collider>().enabled = false;

        ExplosionScript.Explode();

        Destroy(Fire);

        Destroy(gameObject);
    }
}
