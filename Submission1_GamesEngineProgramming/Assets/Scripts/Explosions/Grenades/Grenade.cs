using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float Delay;
    public float Radius;
    public float Force;

    public float Damage;
    public float BleedDamage;
    public int BleedCount;

    public GameObject ExplosionParticleSystem;

    private float countDown;

    private bool hasExploded;

    public ExplosionScript ExplosionScript;

    

	// Use this for initialization
	void Start ()
	{
	    countDown = Delay;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    countDown -= Time.deltaTime;

	    if (countDown <= 0.0f && !hasExploded)
	    {
	        ExplosionScript.Explode();
	        hasExploded = true;
	    }
	}
}
