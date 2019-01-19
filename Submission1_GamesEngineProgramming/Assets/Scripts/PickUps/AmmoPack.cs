using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    public int AmmoAmount;

    public string[] AmmoTypes;

    public GameObject Weapon;

    void Start()
    {
        int i = Random.Range(0, AmmoTypes.Length);

        Weapon = GameObject.FindGameObjectWithTag(AmmoTypes[i]);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("PlayerMesh"))
        {
            Weapon.GetComponent<Gun>().currentAmmoPouchAmount += AmmoAmount;
            Destroy(gameObject);
        }
    }
}
