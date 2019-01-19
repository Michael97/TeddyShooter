using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades")]
public class Upgrade : ScriptableObject
{
    public string ItemName;
    public string Description;

    public UpgradeState.UpgradeEffect UpgradeState;

    public int Price;
    public int Modifier;

    public Sprite Image;
}
