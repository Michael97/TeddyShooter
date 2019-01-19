using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePack : MonoBehaviour {

    public int GrenadeCount;

    public GameObject PlayerRenderer;

    void Start()
    {
        PlayerRenderer = GameObject.FindGameObjectWithTag("PlayerRenderer");
    }

    void OnTriggerEnter(Collider col)
    { 
        if (col.transform.CompareTag("PlayerMesh"))
        {
            PlayerRenderer.GetComponent<GrenadeThrower>().GrenadeCount += GrenadeCount;
            Destroy(gameObject);
        }
    }
}
