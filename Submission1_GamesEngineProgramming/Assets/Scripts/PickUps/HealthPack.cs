using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int HealthAmount;

    public GameObject PlayerGameObject;

    void Start()
    {
        PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("PlayerMesh"))
        {
            PlayerGameObject.GetComponent<PlayerController>().currentHealth += HealthAmount;
            Destroy(gameObject);
        }
    }
}
