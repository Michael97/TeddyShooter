using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    protected EntityState.EEntityState eEntityState;

    //This is the starting health value
    public float Health;

    //This is the current health of the entity
    public float currentHealth;

    //Bleed variables

        //will need an array of bleeddamage adn bleedcount cause if the bleedDamage changes, it will effect all other bleeds damage
    //The bleed damage
    private float bleedDamage;

    //The bleed interval value, deal damage every bleedInterval
    private float bleedInterval;

    //The start time to bleed when called
    private float bleedStartTime;

    //The bleed count, amount of times to bleed
    private int bleedCount;

    private bool isDead;

    public bool InfiniteBleed;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            ProjectileScript projectileScript = col.gameObject.GetComponent<ProjectileScript>();
            TakeDamage(projectileScript.Damage, projectileScript.BleedDamage, projectileScript.BleedCount);
            Destroy(col.gameObject);
        }
    }

    public void SetUpHealthStats()
    {
        //Setting inital values for the private variables
        bleedInterval = 1.0f;
        bleedStartTime = 0.5f;
        isDead = false;

        eEntityState = EntityState.EEntityState.ALIVE;

        //Setting the currentHealth to the Health of the entity
        currentHealth = Health;
    }

    //Set the Health of the entity, usually used for shop purchases for increased health
    public void SetHealth(float _health)
    {
        Health = _health;
    }

    //Inrease the currentHealth amount of the entity, usually used for bandaging and stuff
    public void IncreaseHealth(float _health)
    {
        currentHealth += _health;

        //If the currentHealth is greater than the Health, then reset it to Health value
        if (currentHealth > Health)
        {
            currentHealth = Health;
        }
    }

    //Returns if currentHealth of less than Health
    public bool CanHeal()
    {
        return currentHealth < Health;
    }

    //Returns isDead boolean
    public bool GetIsDead()
    {
        return isDead;
    }

    //Function to take damage with 2 parameters
    //_damage - The damage to be dealt
    //_bleedDamage - The bleedDamage to be dealt
    public void TakeDamage(float _damage, float _bleedDamage, int _bleedCount)
    {
        //subtract the damage
        currentHealth -= _damage;

        CheckIsDead();

        //if there is a _bleedDamage value
        if (_bleedDamage > 0.0f)
        {
            //Set the scripts bleedDamage varaible to _bleedDamage
            bleedDamage = _bleedDamage;

            //Set bleedCount to _bleedCount
            bleedCount += _bleedCount;

            //Call "BleedEffect" after bleedStartTime calling every bleedInterval indefinetly until canceled
            InvokeRepeating("BleedEffect", bleedStartTime, bleedInterval);
        }
    }

    public void CheckForInfiniteBleed()
    {
        if (currentHealth <= Health / 2)
        {
            InfiniteBleed = true;
            bleedCount += 1000;
            bleedDamage = 2.0f;
            InvokeRepeating("BleedEffect", 0.0f, 0.3f);
        }
    }

    //Bleed effect function, meant to be called when the entity is bleeding
    private void BleedEffect()
    {
        //if we still need to bleed
        if (bleedCount > 0)
        {
            //minus the bleedDamage from currentHealth
            currentHealth -= bleedDamage;

            //subtract one from bleedCount
            bleedCount--;

            CheckIsDead();
        }
        //else we dont need to bleed anymore
        else
        {
            //Cancel all invokes in the script
            CancelInvoke("BleedEffect");
        }
    }

    //Function to check if the entity is dead
    private void CheckIsDead()
    {
        //if currentHealth is equal to or less than 0
        if (currentHealth <= 0)
        {
            //Set isDead to true
            isDead = true;
            eEntityState = EntityState.EEntityState.DEAD;
            Dead();
        }
    }

    public virtual void Dead()
    {
        
    }
}
