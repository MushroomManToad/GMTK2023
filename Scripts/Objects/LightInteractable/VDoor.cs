using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VDoor : MonoBehaviour, ILightInteractable
{
    bool isClosed = true;
    bool isLit = true;
    int timer = 0;
    [SerializeField]
    int closeTime;

    [SerializeField]
    Collider2D groundCollider;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float sizeX, sizeY;

    private void FixedUpdate()
    {
        if(!isClosed && timer > closeTime)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(sizeX, sizeY), transform.eulerAngles.z);
            if(colliders.Length <= 2)
            {
                closeDoor();
            }
        }
        timer++;
        isLit = false;
    }

    public void onLit()
    {
        if (isClosed)
        {
            openDoor();
        }
        timer = 0;
        isLit = true;
    }

    private void openDoor()
    {
        groundCollider.enabled = false;
        animator.SetTrigger("Open");
        // Sound
        isClosed = false;
    }

    private void closeDoor()
    {
        groundCollider.enabled = true;
        animator.SetTrigger("Close");
        // Sound
        isClosed = true;
    }

    public void onUnlit()
    {

    }
}
