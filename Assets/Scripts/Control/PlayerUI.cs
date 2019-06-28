using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public UnityEvent updateAmmo;
    public UnityEvent updateHP;
    public GameObject player;
    public Text totalAmmoText;
    public Text currentAmmoText;
    public Text HitPointText;
    private PlayerProperties properties;

    private void Awake()
    {
        properties = player.GetComponent<PlayerProperties>();
        updateAmmo.AddListener(()=>
        {
            totalAmmoText.text = properties.MaxAmmo.ToString();
            currentAmmoText.text = properties.CurrentAmmo.ToString();
        });
        updateHP.AddListener(() =>
        {
            HitPointText.text = properties.Hitpoint.ToString();
        });
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

}
