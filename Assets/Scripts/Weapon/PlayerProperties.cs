using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerProperties : MonoBehaviour
{
    public class UpdateAmmoEvent:UnityEvent<int,int>
    {

    }
    public UpdateAmmoEvent updateAmmo;
    public class UpdateHPEvent:UnityEvent<int>
    {

    }
    public UpdateHPEvent updateHP;
    public int Hitpoint { get; private set; }
    public int CurrentAmmo { get; private set; }
    public int MaxAmmo { get; private set; }

    public PlayerUI playerUI;

    private void Awake()
    {
        updateAmmo = new UpdateAmmoEvent();
        updateHP = new UpdateHPEvent();
        updateAmmo.AddListener((cur,max) =>
        {
            CurrentAmmo = cur;
            MaxAmmo = max;
            playerUI.updateAmmo.Invoke();
        });
        updateHP.AddListener(hp =>
        {
            Hitpoint = hp;
            playerUI.updateHP.Invoke();
        });
    }
}
