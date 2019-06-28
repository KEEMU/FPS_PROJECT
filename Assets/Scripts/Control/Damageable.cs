using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    Canvas healthBarPrefab;
    Canvas canvas;
    Slider healthBar;
    public string Name { get; protected set; }
    public int Hitpoint { get; protected set; }
    public int MaxHitpoint { get; protected set; }
    
    // Start is called before the first frame update
    void Start()
    {
        //healthBarPrefab = Resources.Load("Assets/Resources/HealthBar.prefab") as Canvas;

        canvas = Instantiate(healthBarPrefab, gameObject.transform);
        healthBar = FindObjectOfType<Slider>();
        Name = "01";
        MaxHitpoint = 100;
        Hitpoint = MaxHitpoint;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.enabled = false;
    }

    public virtual void Damage(int d)
    {
        Hitpoint -= d;
        if (Hitpoint <= 0)
        {
            Disable();
        }
    }

    public void ShowHealthBar()
    {
        Vector3 wPos = transform.position + new Vector3(0, GetComponent<Collider>().bounds.extents.y, 0) + Vector3.up;
        Vector3 sPos = Camera.main.WorldToScreenPoint(wPos);
        healthBar.transform.position = sPos;
        healthBar.maxValue = MaxHitpoint;
        healthBar.value = Hitpoint;
        canvas.enabled = true;
    }

    protected virtual void Disable()
    {
        Destroy(gameObject);
    }
}
