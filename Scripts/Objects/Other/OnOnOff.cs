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

    private void FixedUpdate()
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
    }
}
