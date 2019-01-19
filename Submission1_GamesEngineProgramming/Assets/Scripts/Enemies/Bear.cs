using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : Entity {

    public float AggroRange;

    public NavMeshAgent NavMeshBear;

    public GameObject PlayerGameObject;

    private NavMeshPath navMeshPath;

    private bool isEngaged;

    public float navMeshTimer;

    private float timer;

    public float Damage;

    public float AttackRange;

    public float AttackRate;

    public Animator animation;

    private float nextTimeToAttack = 0.0f;

    void Awake()
    {
        SetUpHealthStats();
    }

    void Start()
    {
        navMeshPath = new NavMeshPath();

        NavMeshBear.speed = movementSpeed;

        timer = navMeshTimer;
        PlayerGameObject = GameObject.Find("Player");
        NavMeshBear.enabled = false;
    }

    void FixedUpdate()
    {
        if (EnableBear())
            UpdateTarget();
    }

    //Will keep the navmesh disabled on the bear until the player comes within range
    private bool EnableBear()
    {
        if (PlayerGameObject == null)
            return false;

        if (Vector3.Distance(gameObject.transform.position, PlayerGameObject.transform.position) <= 20.0f)
        {
            NavMeshBear.enabled = true;
            return true;
        }
        return false;

    }

    private void TimerCountdown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            NavMeshBear.enabled = true;
            timer = navMeshTimer;
        }
    }

    public void UpdateTarget()
    {
        //Checks to see if we have the player
        if (PlayerGameObject == null)
            return;

        //if the navemeshagent is not enabled
        if (!NavMeshBear.isActiveAndEnabled)
        {
            //start a countdown and stuff
            TimerCountdown();
            return;
        }

        if (!NavMeshBear.isOnNavMesh)
            return;


        float distance = Vector3.Distance(PlayerGameObject.transform.position, NavMeshBear.transform.position);

        //calculates the distance between the player and the bear, if its less than or equal to the aggrorange or if isEngaged equals true
        if (distance <= AggroRange || isEngaged)
        {
            //checks to see if there is a path and stores it in navMeshPath
            if (NavMeshBear.CalculatePath(PlayerGameObject.transform.position, navMeshPath))
            {
                //sets the path to the path created in the previous if statement
                NavMeshBear.SetPath(navMeshPath);

                //if isEngaged is false then set it to true
                if (!isEngaged)
                {
                    isEngaged = true;
                    animation.SetFloat("Speed", 1.0f);
                }
            }
        }

        if (distance <= AttackRange && Time.time >= nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + 1f / AttackRate;
            Attack();
        }
    }

    private void Attack()
    {
        PlayerGameObject.GetComponent<HealthScript>().TakeDamage(Damage, 0, 0);
    }

    public override void Dead()
    {
        PlayerGameObject = null;
        NavMeshBear.enabled = false;
        
        animation.SetBool("isDead", true);
        Destroy(gameObject, 2.5f);
    }
}
