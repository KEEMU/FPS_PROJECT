using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    public int Damage { get; set; }

    [Range(1, 10)]
    [Tooltip("After how long time should the bullet prefab be destroyed?")]
    public float destroyAfter = 5;

    private void Start()
    {
        //Start destroy timer
        StartCoroutine(DestroyAfter());
        player = GameObject.FindGameObjectWithTag("Player");
        Damage = 36;
    }

    //If the bullet collides with anything
    private void OnCollisionEnter(Collision collision)
    {
        var s = collision.collider.GetComponent<Damageable>();
        if (s != null)
        {
            s.Damage(Damage);
            player.GetComponent<Crosshair>().hit.Invoke();
        }
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfter()
    {
        //Wait for set amount of time
        yield return new WaitForSeconds(destroyAfter);
        //Destroy bullet object
        Destroy(gameObject);
    }
}
