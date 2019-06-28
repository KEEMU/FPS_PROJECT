using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageablePlayer : Damageable
{
    PlayerProperties properties;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        properties = GetComponent<PlayerProperties>();
        Hitpoint = 300;
        properties.updateHP.Invoke(Hitpoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Damage(int d)
    {
        base.Damage(d);
        properties.updateHP.Invoke(Hitpoint);
    }

    protected override void Disable()
    {
        //player specific
        print("disable");
    }
}
