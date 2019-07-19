using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineTrigger : MonoBehaviour
{
    public TimeLineController controller;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        controller.OnPlayerEnterZone();
    }

    private void OnTriggerExit(Collider other)
    {
        controller.OnPlayerExitZone();
    }
}
