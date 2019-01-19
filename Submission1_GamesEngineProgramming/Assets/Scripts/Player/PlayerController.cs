using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{

    public Collider InteractableObject;

    public Animator animation;

    void Awake()
    {
        SetUpHealthStats();
        animation = GetComponentInChildren<Animator>();
        //In 1 second start calling "CheckForIterations" every 0.3 seconds forever
        InvokeRepeating("CheckForInteractions", 1.0f, 0.3f);
    }

    void Update()
    {
        if (InteractableObject != null && Input.GetKeyDown("e"))
        {
            InteractableObject.GetComponent<InteractableObjectScript>().Interaction();
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        //transform.Translate(GetMovementSpeed() * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, GetMovementSpeed() * Input.GetAxis("Vertical") * Time.deltaTime);
        

        //Since we get a weird ice effect when using add force, we just reset the velocity to 0 when we call update again so we can freely move around with no trouble
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical > 0.0f || moveHorizontal > 0.0f)
        {
            animation.SetFloat("Speed", 1.0f);
        }
        else if (moveVertical < 0.0f || moveHorizontal < 0.0f)
        {
            animation.SetFloat("Speed", 0.5f);
        }
        else
        {
            animation.SetFloat("Speed", 0.0f);
        }

        Vector3 movementVector3 = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movementVector3 * movementSpeed);

        if (eEntityState == EntityState.EEntityState.DEAD)
	        Dead();
    }

    //Checks for colliders within a certain distance
    //currently returns the array in a completely random order, this should be changed to ascending distance order so the closest object will be the interactable one. (shortest to longest)
    //so when we hit an interactable object we can just exit the foreach  loop as we dont need to check further ones.
    void CheckForInteractions()
    {
        //Grabs all colliders within 5 units
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5.0f);

        //iterator to test if we need to clear the interactableobject
        int i = 0;

        
        foreach (Collider collider in hitColliders)
        {
            //Grabs the script from the colliders
            InteractableObjectScript script = collider.GetComponent<InteractableObjectScript>();

            //if there is no script
            if (script == null)
            {
                //increment iterator by one
                i++;

                //if i is not equal to the length than continue
                if (i != hitColliders.Length)
                    continue;

                //else if it is equal to the length clear the interactableobject
                InteractableObject = null;

                continue;
            }

            //if there is a script this is the new interactable object
            InteractableObject = collider;
        }
    }


}
