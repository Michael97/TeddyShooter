using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : GunStatistics
{

    private float nextTimeToFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && GetCurrentMagAmount() < MagCapacity)
        {
            ReloadMagazine();
            AudioSource.PlayOneShot(GunReloadAudio);
        }
        
        else if (Input.GetButton("Fire1") && HasAmmoInMag() && Time.time >= nextTimeToFire && !GetIsReloading())
        {
            nextTimeToFire = Time.time + 1f / FireRate;
            Fire();
            AudioSource.PlayOneShot(GunShotAudio, 0.2f);
        }
    }

    void Fire()
    {
        ParticleSystem muzzleFlash = Instantiate(MuzzleFlash, Emitter.position, Quaternion.Euler(0.0f, transform.parent.gameObject.transform.eulerAngles.y, 0.0f));
        muzzleFlash.Play();

        GameObject projectile = Instantiate(Projectile, Emitter.position, Quaternion.Euler(90.0f, transform.parent.gameObject.transform.eulerAngles.y, 0.0f));

        projectile.GetComponent<Rigidbody>().velocity = ProjectileSpeed * Emitter.forward;

        FiredProjectile();
    }
}
