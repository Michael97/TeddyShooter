using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndColliderScript : MonoBehaviour
{

    public bool EndGameText;

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("PlayerMesh"))
        {
            EndGameText = true;
        }
    }

    void OnGUI()
    {
        //End of Demo
        if (EndGameText)
        {
            GUI.TextField(new Rect(Screen.width / 3, Screen.height / 3, 300, 20),
                "Thanks for playing the demo!");
        }
    }
}
