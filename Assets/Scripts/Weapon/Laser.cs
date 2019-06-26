using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    int damage = 7;
    LineRenderer line;
    float lineWidth = 0.1f;
    float delay = 1.5f;
    float duration = 0.5f;
    float range = 50f;

    GameObject player;
    Vector3 target;

    public Material prepMat;
    public Material damageOnMat;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Test());
    }

    void Update()
    {

    }

    public void Fire()
    {
        target = player.transform.position;
        transform.LookAt(target);
        RaycastHit hit;
        line.SetPosition(0, transform.position);
        Vector3 dir;
        dir = player.transform.position - transform.position;
        dir.Normalize();
        Ray ray = new Ray(transform.position, dir);
        if (Physics.Raycast(ray, out hit, range))
        {
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(1, transform.position + (transform.forward * range));
        }
        StartCoroutine(DrawLaser(ray));
    }

    IEnumerator DrawLaser(Ray ray)
    {
        line.material = prepMat;
        line.enabled = true;
        yield return new WaitForSeconds(delay);
        line.material = damageOnMat;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            var d = hit.collider.GetComponent<Damageable>();
            if (d != null)
            {
                d.Damage(100);
            }
        }
        yield return new WaitForSeconds(duration);
        line.enabled = false;
    }

    IEnumerator Test()
    {
        Fire();
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(Test());
    }

}
