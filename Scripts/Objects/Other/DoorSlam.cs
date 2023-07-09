using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlam : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D col;

    [SerializeField]
    Animator animator;

    public void slamDoor()
    {
        col.enabled = true;
        animator.SetTrigger("Slam");
    }
}
