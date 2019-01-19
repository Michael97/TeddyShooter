using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {

    public float TeleportTimer;

    public float CurrentTeleportTimer;

    public ParticleSystem TeleportParticleSystem;

    void Update()
    {
        if (Input.GetKeyDown("t") && CurrentTeleportTimer <= 0.0f)
        {
            TeleportLocation();
            //Reset timer
            CurrentTeleportTimer = TeleportTimer;
        }
    }

    void FixedUpdate()
    {
        CurrentTeleportTimer -= Time.deltaTime;

        if (CurrentTeleportTimer <= 0.0f)
            CurrentTeleportTimer = 0.0f;
    }

    Vector3 TeleportLocation()
    {
        Vector3 newPosition;

        //Lets create a ray ready to cast from the mouses cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Creating a RaycastHit that will hold all the information of the object/entity hit
        RaycastHit hit;

        //If the ray we cast hit something
        if (Physics.Raycast(ray, out hit, 2000))
        {
            //if the hit collider is the ground then we can teleport there!
            if (hit.collider.tag == "Ground")
            {
                //What we hit we set as the newPosition
                newPosition = hit.point;

                //Since we the NewWorldPosition is now directly on the terrain, we will be moving our player in the terrain. This is bad m9
                //Since the transform is in the center of the object we take half of its size to bring it back on top of the terrain.
             //   newPosition.y = gameObject.transform.Find("PlayerRenderer").GetComponent<Collider>().bounds.size.y / 2;

                newPosition.y = 0.5f;

                //Setting the new position of the objects transform as NewWorldPosition
                transform.position = newPosition;
                TeleportEffect();
                //Return the newPosition
                return newPosition;
          
            }
        }

        //Return default vector3
        return new Vector3(0,0,0);
    }

    private void TeleportEffect()
    {
        Instantiate(TeleportParticleSystem, transform.position, TeleportParticleSystem.GetComponent<Transform>().rotation);
    }

}
