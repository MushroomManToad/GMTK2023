using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOnOff : MonoBehaviour, ILightInteractable
{
    bool isOn = true;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Collider2D blockCollider;

    int waitFrames = 0;

    private void FixedUpdate()
    {
        if(waitFrames > 3)
        {
            if (isOn && GameStateHandler.Instance.getOnOff())
            {
                turnOff();
            }
            if (!isOn && !GameStateHandler.Instance.getOnOff())
            {
                turnOn();
            }
        }
        waitFrames++;
    }

    private void turnOff()
    {
        isOn = false;
        blockCollider.enabled = false;
        animator.SetBool("On", false);
    }

    private void turnOn() 
    {
        isOn = true;
        blockCollider.enabled = true;
        animator.SetBool("On", true);
    }

    public void onLit()
    {
        GameStateHandler.Instance.setOnOff(!GameStateHandler.Instance.getOnOff());
        GameStateHandler.Instance.setLock();
    }

    public void onUnlit()
    {

    }
}
