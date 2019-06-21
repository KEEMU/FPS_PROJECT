using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Sprite crosshair;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        size = Camera.main.pixelHeight / 20;
    }

    // Update is called once per frame
    void Update()
    {
        //Pointer();
    }
    private void OnGUI()
    {
        Color color = Color.green;
        if (Input.GetMouseButton(0))
        {
            color = Color.red;
        }
        if (!Input.GetMouseButton(1))
        {
            Rect rect = new Rect((Camera.main.pixelWidth - size) / 2, (Camera.main.pixelHeight - size) / 2, size, size);
            GUI.DrawTexture(rect, crosshair.texture, ScaleMode.ScaleAndCrop, true, 0, color, 0, 0);
        }
    }

    void Pointer()
    {
        float dist = 100;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Physics.Raycast(ray, out hit, dist);
        if (hit.collider!=null)
        {
            var s = hit.collider.GetComponent<Damageable>();
            if (s!=null)
            {
                s.ShowHealthBar();
            }
        }
    }
}
