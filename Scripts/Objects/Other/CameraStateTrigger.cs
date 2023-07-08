using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateTrigger : MonoBehaviour
{
    [SerializeField]
    private CameraHandler mainCamera;
    [SerializeField]
    private bool lockToPlayer, lockToPlayerWithOffset, lockToPos;
    [SerializeField]
    private Vector2 targetPos, playerOffset;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovementController pmc = collider.gameObject.GetComponent<PlayerMovementController>();
        if (pmc != null)
        {
            if(lockToPlayer)
            {
                mainCamera.setCameraMode(0);
            }
            else if (lockToPlayerWithOffset)
            {
                mainCamera.setCameraMode(2);
                mainCamera.setPlayerOffset(playerOffset);
            }
            else if(lockToPos)
            {
                mainCamera.setCameraMode(1);
                mainCamera.setTargetPos(targetPos);
            }
        }
    }
}
