using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public UnityEvent updateAmmo;
    public GameObject player;
    public Text totalAmmoText;
    public Text currentAmmoText;

    //private AutomaticGunScriptLPFP LPFP;
    private PlayerProperties properties;

    private void Awake()
    {
        //LPFP = player.GetComponent<AutomaticGunScriptLPFP>();
        properties = player.GetComponent<PlayerProperties>();
        updateAmmo.AddListener(UpdateAmmo);
    }

    //private void OnEnable()
    //{
    //    EventManager.StartListening("Fire", OnFire);
    //    EventManager.StartListening("Change", Init);
    //}
    //private void OnDisable()
    //{
    //    EventManager.StopListening("Fire", OnFire);
    //    EventManager.StopListening("Change", Init);
    //}
    //private void Init()
    //{
    //    totalAmmoText.text = LPFP.ammo.ToString();
    //    currentAmmoText.text = LPFP.ammo.ToString();
    //}

    private void UpdateAmmo()
    {
        totalAmmoText.text = properties.MaxAmmo.ToString();
        currentAmmoText.text = properties.CurrentAmmo.ToString();
    }

}
