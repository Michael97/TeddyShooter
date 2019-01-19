using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public Text TextGunClip;
    public Text TextGunAmmoPouch;

    public Image GunImage;

    public Text TextGroundSmashTimer;
    public Text TextMeleeTimer;

    public Text TextTeleportTimer;

    public Text TextGrenadeCount;


    //Scripts
    public GameObject playerGameObject;

    public Gun playerCurrentGun;
    public CloseRangeAttacks playerCloseRangeAttacks;
    public PlayerController playerController;
    public Teleportation playerTeleportation;
    public WeaponSwitcher playerWeaponSwitcher;
    public GrenadeThrower PlayerGrenadeThrower;

    void Awake()
    {
        //Limit fps
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        SortUI();
    }

    void FixedUpdate()
    {
        UpdateAllVariables();
    }

    //Grabbing and setting scripts

    public void SortUI()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");

        GrabNecessaryScripts();

        UpdateAllVariables();
    }

    private void UpdateAllVariables()
    {
        GrabCurrentGun();
        UpdateGunClip();
        UpdateGunPouch();
        UpdateImageGun();
        UpdateGroundSmashTimer();
        UpdateMeleeTimer();
        UpdateTeleportationTimer();
        UpdateGrenadeCount();
    }


    private void UpdateGunClip()
    {
        TextGunClip.text = playerCurrentGun.currentMagAmount.ToString();
    }

    private void UpdateGunPouch()
    {
        TextGunAmmoPouch.text = playerCurrentGun.currentAmmoPouchAmount.ToString();
    }

    private void UpdateImageGun()
    {
        GunImage.sprite = playerCurrentGun.GunImage.sprite;
    }


    private void UpdateGroundSmashTimer()
    {
        TextGroundSmashTimer.text = playerCloseRangeAttacks.CurrentSmashAttackRate.ToString("F");
    }

    private void UpdateMeleeTimer()
    {
        TextMeleeTimer.text = playerCloseRangeAttacks.CurrentMeleeAttackRate.ToString("F");
    }

    private void UpdateTeleportationTimer()
    {
        TextTeleportTimer.text = playerTeleportation.CurrentTeleportTimer.ToString("F");
    }

    private void UpdateGrenadeCount()
    {
        TextGrenadeCount.text = PlayerGrenadeThrower.GrenadeCount.ToString();
    }

    private void GrabNecessaryScripts()
    {
        GrabWeaponSwitcher();
        GrabPlayerController();
        GrabCloseRangeAttacks();
        GrabTeleportation();
        GrabGrenadeThrower();
    }

    private void GrabGrenadeThrower()
    {
        PlayerGrenadeThrower = playerGameObject.GetComponentInChildren<GrenadeThrower>();
    }

    private void GrabWeaponSwitcher()
    {
        playerWeaponSwitcher = playerGameObject.GetComponentInChildren<WeaponSwitcher>();
    }

    private void GrabCurrentGun()
    {
        playerCurrentGun = playerGameObject.GetComponentInChildren<WeaponSwitcher>().transform
            .GetChild(playerWeaponSwitcher.selectedWeapon).GetComponent<Gun>();
    }

    private void GrabPlayerController()
    {
        playerController = playerGameObject.GetComponent<PlayerController>();
    }

    private void GrabCloseRangeAttacks()
    {
        playerCloseRangeAttacks = playerGameObject.GetComponent<CloseRangeAttacks>();
    }

    private void GrabTeleportation()
    {
        playerTeleportation = playerGameObject.GetComponent<Teleportation>();
    }


}
