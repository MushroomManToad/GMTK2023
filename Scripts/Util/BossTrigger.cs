using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField]
    CrabAI ai;

    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    DoorSlam doorSlam;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovementController pmc = collider.gameObject.GetComponent<PlayerMovementController>();
        if(pmc != null)
        {
            ai.startBattle();
            doorSlam.slamDoor();
        }
    }
}
