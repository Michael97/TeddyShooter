using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunStatistics : MonoBehaviour
{
    //The effective range of the weapon, if the projectile has traveled longer than this distance, its damage is greatly reduced
    public float EffectiveRange;

    //The Fire rate of the weapon
    public float FireRate;
    
    //The Reload Rate of the weapon
    public float ReloadRate;

    public float currentReloadRate;

    public bool isReloading;

    //The cost of the weapon
    public int Cost;


    //The capacity of the ammo amount
    public int AmmoPouchCapacity;
    //The amount of total ammo in the player/weapon
    public int currentAmmoPouchAmount;


    //The amount of ammo in its magazine
    public int MagCapacity;
    //The current size of the magazine
    public int currentMagAmount;


    //The Speed of the projectile
    public float ProjectileSpeed;

    //The projectile gameobject
    public GameObject Projectile;

    //The muzzleflash for weapon
    public ParticleSystem MuzzleFlash;

    public Transform Emitter;

    public Image GunImage;

    public AudioClip GunShotAudio;

    public AudioClip GunReloadAudio;

    public AudioSource AudioSource;

    //The state of the weapon
    private GunState.EGunState eGunState;


    void Start()
    {
        isReloading = false;
        Emitter = transform.Find("BulletEmitter").GetComponent<Transform>();
        currentMagAmount = MagCapacity;
        currentAmmoPouchAmount = AmmoPouchCapacity;
        currentReloadRate = ReloadRate;
    }

    void FixedUpdate()
    {
        //if we reload hasnt finished yet and we are reloading
        if (isReloading)
        {
            if (currentReloadRate > 0.0f)
            {
                currentReloadRate -= Time.deltaTime;
            }
            else
            {
                isReloading = false;
                currentReloadRate = ReloadRate;
            }
        }
    }

    //Returns the cost of the weapon
    public int GetCurrentAmmoPouchAmount()
    {
        return currentAmmoPouchAmount;
    }

    //returns if there is still ammo
    public bool HasAmmoInPouch()
    {
        return currentAmmoPouchAmount > 0;
    }

    //Returns if the magazine has ammo in it
    public bool HasAmmoInMag()
    {
        return currentMagAmount > 0;
    }

    //Returns the cost of the weapon
    public int GetCurrentMagAmount()
    {
        return currentMagAmount;
    }

    public void FiredProjectile()
    {
        //Subtract 1 from the amount in the mag
        currentMagAmount -= 1;
    }

    public bool GetIsReloading()
    {
        return isReloading;
    }

    //Reloads the current magazine
    public void ReloadMagazine()
    {
        if (HasAmmoInPouch() == false)
            return;

        //Calculates the amount of ammo needed to complete the magazine
        int ammoToAdd = MagCapacity - currentMagAmount;

        isReloading = true;

        //if the ammoToAdd is lessthan or equal to the currentAmmo
        if (ammoToAdd <= currentAmmoPouchAmount)
        {
            //Take away the amount of ammo we are adding onto the magazine
            currentAmmoPouchAmount -= ammoToAdd;

            //add ammoToAdd to the currentMagAmount
            currentMagAmount += ammoToAdd;
        }
        //else the ammoToAdd is larger than the remaining ammoPouch, then we just add the rest of the ammoPouch into the mag and empty it.
        else
        {
            currentMagAmount += currentAmmoPouchAmount;
            currentAmmoPouchAmount -= currentAmmoPouchAmount;
        }
    }

    //Gets the current Gun State
    public GunState.EGunState GetGunState()
    {
        return eGunState;
    }

    //Sets the current Gun State
    public void SetGunState(GunState.EGunState _gunState)
    {
        eGunState = _gunState;
    }
}
