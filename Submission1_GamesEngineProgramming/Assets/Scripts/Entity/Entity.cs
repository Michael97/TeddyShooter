using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : HealthScript {

    public float movementSpeed;

    //Getters and setters for movement speed

    public void SetMovementSpeed(float _movementSpeed)
    {
        movementSpeed = _movementSpeed;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }
}
