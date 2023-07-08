using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffOnOff : MonoBehaviour, ILightInteractable
{
    bool isOn = false;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Collider2D blockCollider;

    private void FixedUpdate()
    {

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
        if (!isOn && GameStateHandler.Instance.getOnOff())
        {
            turnOn();
        }
        if (isOn && !GameStateHandler.Instance.getOnOff())
        {
            turnOff();
        }
    }

    public void onUnlit()
    {

    }
}
