using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public GameObject player;
    public Text totalAmmoText;
    public Text currentAmmoText;

    private AutomaticGunScriptLPFP LPFP;

    private void Awake()
    {
        LPFP = player.GetComponent<AutomaticGunScriptLPFP>();
        Init();
    }

    private void OnEnable()
    {
        EventManager.StartListening("Fire", OnFire);
        EventManager.StartListening("Change", Init);
    }
    private void OnDisable()
    {
        EventManager.StopListening("Fire", OnFire);
        EventManager.StopListening("Change", Init);
    }
    private void Init()
    {
        totalAmmoText.text = LPFP.ammo.ToString();
        currentAmmoText.text = LPFP.ammo.ToString();
    }

    private void OnFire()
    {
        totalAmmoText.text = LPFP.ammo.ToString();
        currentAmmoText.text = LPFP.currentAmmo.ToString();
    }

}
