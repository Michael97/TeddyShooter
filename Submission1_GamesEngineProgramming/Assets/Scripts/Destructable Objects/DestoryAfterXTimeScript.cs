using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAfterXTimeScript : MonoBehaviour
{

    public float time;

    void FixedUpdate()
    {
        time -= Time.deltaTime;

        if (time <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
