using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActualizer : MonoBehaviour
{
    AutomaticGunScriptLPFP scriptLPFP;
    private void Awake()
    {
        scriptLPFP = GetComponent<AutomaticGunScriptLPFP>();
    }
    private void Start()
    {

    }
    //public Weapon weapon;
    //LineRenderer lineRenderer;
    //float cooldown;
    //GameObject bullet;


    //void Start()
    //{
    //    lineRenderer = GetComponent<LineRenderer>();
    //    cooldown = weapon.RateOfFire;
    //    bullet = Resources.Load<GameObject>("Bullet");
    //}

    //private void FixedUpdate()
    //{
    //    if (cooldown>0)
    //    {
    //        cooldown -= Time.fixedDeltaTime;
    //    }
    //    else
    //    {
    //        cooldown = 0;
    //    }

    //    if (Input.GetMouseButton(0))
    //    {
    //        if (cooldown <= 0)
    //        {
    //            cooldown += weapon.RateOfFire;
    //            for (int i = 0; i < weapon.BulletCount; i++)
    //            {
    //            GameObject generatedBullet = Instantiate(bullet, transform);
    //            generatedBullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * weapon.BulletSpeed, ForceMode.VelocityChange);
    //            }
    //        }
    //    }

    //}

    /*void Update()
    {

        {
            if (staticFire)
            {
                transform.LookAt(target, Vector3.back);
            }
            else
            {
                transform.LookAt(player.transform, Vector3.back);
            }
            transform.Rotate(0, -90, 0);
            coolDown -= Time.deltaTime;
            if (transform.localEulerAngles.z < 360 && transform.localEulerAngles.z > 90)
            {
                Vector3 rot = transform.localEulerAngles;
                rot.z = 0;
                transform.localEulerAngles = rot;
                return;
            }
            if (coolDown < 0)
            {
                coolDown = 0.3f;
                RaycastHit hit;
                lineRenderer.SetPosition(0, transform.position);
                Vector3 dir;
                if (staticFire)
                {
                    dir = target - transform.position;
                }
                else
                {
                    dir = player.transform.position + new Vector3(0, 0.8f, 0) - transform.position;
                }
                dir.Normalize();
                dir += Random.insideUnitSphere * 0.03f / Time.timeScale;
                if (Physics.Raycast(transform.position, dir, out hit))
                {
                    lineRenderer.SetPosition(1, hit.point);
                    if (hit.collider.CompareTag("Player"))
                    {
                        GameManager.getInstance().Damage(damage);
                    }
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * hitForce, ForceMode.Impulse);
                    }
                }
                else
                {
                    lineRenderer.SetPosition(1, transform.position + (transform.right * 40f));
                }
                StartCoroutine(DrawLine());
            }
        }
    }*/

    //IEnumerator DrawLine()
    //{
    //    lineRenderer.enabled = true;
    //    yield return new WaitForSeconds(0.07f);
    //    lineRenderer.enabled = false;
    //}
}
