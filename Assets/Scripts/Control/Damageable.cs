using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    public Image healthBar;
    public string Name { get; private set; }
    private int hitpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Name = "01";
        hitpoint = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int d)
    {
        hitpoint -= d;
        if (hitpoint <= 0)
        {
            Disable();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    var s = collision.collider.GetComponent<BulletScript>();
    //    if (s!=null)
    //    {
    //        Damage(s.Damage);
    //    }
        
    //}

    public void ShowHealthBar()
    {
        print("debug.shb");
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}
