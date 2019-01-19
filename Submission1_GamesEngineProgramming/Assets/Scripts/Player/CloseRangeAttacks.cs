using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRangeAttacks : MonoBehaviour
{
    public ExplosionScript ExplosionScript;

    public float nextTimeToMelee = 0.0f;
    public float nextTimeToGroundSmash = 0.0f;

    //Attack rates ever x second
    public float MeleeAttackRate;
    public float SmashAttackRate;

    //Attack rates ever x second
    public float CurrentMeleeAttackRate;
    public float CurrentSmashAttackRate;

    public CloseRangeStatistics MeleeRangeStatistics;
    public CloseRangeStatistics SmashRangeStatistics;

    void FixedUpdate()
    {
        CurrentMeleeAttackRate -= Time.deltaTime;
        CurrentSmashAttackRate -= Time.deltaTime;

        if (CurrentMeleeAttackRate <= 0.0f)
            CurrentMeleeAttackRate = 0.0f;

        if (CurrentSmashAttackRate <= 0.0f)
            CurrentSmashAttackRate = 0.0f;
    }

    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyDown("f") && CurrentMeleeAttackRate <= 0.0f)
	    {
	        MeleeAttack();
	        CurrentMeleeAttackRate = MeleeAttackRate;

	    }

        if (Input.GetKeyDown("q") && CurrentSmashAttackRate <= 0.0f)
        {
            GroundSmash();
            CurrentSmashAttackRate = SmashAttackRate;
        }
    }

    private void GroundSmash()
    {
        ExplosionScript.BleedCount = SmashRangeStatistics.BleedCount;
        ExplosionScript.BleedDamage = SmashRangeStatistics.BleedDamage;
        ExplosionScript.Damage = SmashRangeStatistics.Damage;
        ExplosionScript.Force = SmashRangeStatistics.Force;
        ExplosionScript.Radius = SmashRangeStatistics.Radius;
        
        ExplosionScript.Explode();
    }

    private void MeleeAttack()
    {
        ExplosionScript.BleedCount = MeleeRangeStatistics.BleedCount;
        ExplosionScript.BleedDamage = MeleeRangeStatistics.BleedDamage;
        ExplosionScript.Damage = MeleeRangeStatistics.Damage;
        ExplosionScript.Force = MeleeRangeStatistics.Force;
        ExplosionScript.Radius = MeleeRangeStatistics.Radius;

        ExplosionScript.Explode();
    }
}
