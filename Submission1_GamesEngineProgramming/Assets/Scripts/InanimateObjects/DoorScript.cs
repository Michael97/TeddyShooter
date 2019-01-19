using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //The closed position of the door
    public Vector3 closedPosition;

    //The gameobject for the open door
    public GameObject openTransform;

    //The player gameobject
    public GameObject playerGameObject;

    public GameObject SwitchBoxGameObject;

    //The range of the door, if the player is within this range, the door will open
    private float range = 5.0f;

    //The speed of the door opening
    private float speed = 21;

    //The step of the door to translate every frame
    private float step;


	// Use this for initialization
	void Start ()
	{
        GetPlayer();
	    closedPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    step = speed * Time.deltaTime;
        CheckPlayerPosition();
	}

    void OpenDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, openTransform.transform.position, step);
    }

    void CloseDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, closedPosition, step);
    }

    void CheckPlayerPosition()
    {
        if (playerGameObject == null)
        {
            return;
        }

        //if the player is not within the range of the door than shut it
        if (Vector3.Distance(playerGameObject.transform.position, closedPosition) > range || !SwitchBoxGameObject.GetComponentInChildren<SwitchBoxScript>().isUnlocked)
        {
            CloseDoor();
        }

        //else open it!
        else
        {
            OpenDoor();
        }
    }

    void GetPlayer()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }
}
