using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{
    [Header("TimeLine Settings")]
    public PlayableDirector playableDirector;
    public bool playTimelineOnlyOnce;

    [Header("Trigger Zone Settings")]
    public GameObject triggerZoneObject;
    public KeyCode key;

    [Header("UI Interact Settings")]
    public bool displayUI;
    public GameObject interactDisplay;

    private bool playerInZone;
    private bool timeLinePlaying;
    private float timelineDuration;
    // Start is called before the first frame update
    void Start()
    {
        ToggleInteractUI(false);
    }

    public void OnPlayerEnterZone()
    {
        playerInZone = true;
        ToggleInteractUI(playerInZone);
    }

    public void OnPlayerExitZone()
    {
        playerInZone = false;
        ToggleInteractUI(playerInZone);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && !timeLinePlaying)
        {
            var activateTimelineInput = Input.GetKey(key);
            if (key == KeyCode.None)
            {
                PlayTimeLine();
            }
            else if (activateTimelineInput)
            {
                PlayTimeLine();
                ToggleInteractUI(false);
            }
        }
    }

    private void PlayTimeLine()
    {
        if (playableDirector)
        {
            playableDirector.Play();
        }
        triggerZoneObject.SetActive(false);

        timeLinePlaying = true;

        StartCoroutine(WaitForTimelineToFinish());
    }

    IEnumerator WaitForTimelineToFinish()
    {
        timelineDuration = (float)playableDirector.duration;
        yield return new WaitForSeconds(timelineDuration);
        if (!playTimelineOnlyOnce)
        {
            triggerZoneObject.SetActive(true);
        }
        else if (playTimelineOnlyOnce)
        {
            playerInZone = false;
        }

        timeLinePlaying = false;
    }

    void ToggleInteractUI(bool newState)
    {
        if (displayUI)
        {
            interactDisplay.SetActive(newState);
        }
    }
}
