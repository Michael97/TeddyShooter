using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBoxScript : InteractableObjectScript
{

    public bool isUnlocked;

    public Light LightSource;

    public GameObject SectorGameObject;

    //The collider that prevents illegal teleportation
    public GameObject ColliderGameObject;

    void Start()
    {
        SwitchColor();
    }
    
    public override void Interaction()
    {
        if (CheckSector())
        {
            isUnlocked = !isUnlocked;
        }

        if (isUnlocked && ColliderGameObject != null)
        {
            Destroy(ColliderGameObject.gameObject);
        }

        SwitchColor();
    }

    //Checks how many components are in the gameobject sectorgameobject
    private bool CheckSector()
    {
        Transform[] bears = SectorGameObject.GetComponentsInChildren<Transform>();

        if (bears.Length > 1)
            return false;

        return true;
    }

    private void SwitchColor()
    {
        if (isUnlocked)
        {
            LightSource.color = Color.green;
        }
        if (!isUnlocked)
        {
            LightSource.color = Color.red;
        }
    }
}
