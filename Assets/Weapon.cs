using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    //commit for test by kim
    public enum WeaponType
    {
        Pistol, SMG, Rifle, Shotgun, Sniper
    }
    public enum BulletType
    {
        Ballistic, Laser
    }
    public enum FireMode
    {
        Automatic, Manual, Burst
    }
    public enum Rarity
    {
        Common, Uncommon, Rare, Unusual
    }
    public WeaponType WType;
    public BulletType BType;
    public FireMode FMode;
    public Rarity Quality;

    public int Damage;
    public int BulletCount;
    public float BulletSpeed;
    public float Accuracy;
    public float RateOfFire;
    public float ReloadTime;
    public int MagazineSize;
    public float SwapTime;
    public int CritDmgMul;
    public float InitialRecoil;
    public float RecoilInc;
    public float RecoilDec;
    public float SightMul;

    public float DPS;

}
