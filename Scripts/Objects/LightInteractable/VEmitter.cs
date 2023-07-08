using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VEmitter : MonoBehaviour, ILightInteractable
{
    public GameObject emitter;
    bool isLit = true;

    private void FixedUpdate()
    {
        if(!isLit && emitter.activeInHierarchy)
        {
            emitter.SetActive(false);
        }
        isLit = false;   
    }

    public void onLit()
    {
        emitter.SetActive(true);
        isLit = true;
    }

    public void onUnlit()
    {

    }
}
