using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public int FillAmount;

    public Image ContentImage;

    public PlayerController PlayerController;
	// Update is called once per frame
	void Update ()
	{
	    HandleBar();
	}

    private void HandleBar()
    {
        ContentImage.fillAmount = Map(PlayerController.currentHealth, 0, PlayerController.Health, 0, 1);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //(80 - 0) * (1 - 0) / (100 - 0) + 0 = 0.8
    }
}
