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
    public int Hitpoint { get; private set; }
    public int CurrentAmmo { get; private set; }
    public int MaxAmmo { get; private set; }

    public AmmoUI ammoUI;

    private void Awake()
    {
        if (updateAmmo == null)
        {
            updateAmmo = new UpdateAmmoEvent();
        }
        updateAmmo.AddListener(UpdateAmmo);
    }

    void UpdateAmmo(int cur,int max)
    {
        CurrentAmmo = cur;
        MaxAmmo = max;
        ammoUI.updateAmmo.Invoke();
    }
}
