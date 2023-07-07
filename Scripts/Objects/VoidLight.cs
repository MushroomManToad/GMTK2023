using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidLight : MonoBehaviour
{
    private float radius = 0f;

    private void FixedUpdate()
    {
        Debug.Log(transform.position + " : " + radius);
        // Get all objects
        Collider2D[] overlaps = Physics2D.OverlapCircleAll(transform.position, radius);
        // Update all objects
        foreach (Collider2D collider in overlaps)
        {
            Debug.Log(collider);
            ILightInteractable ili = collider.gameObject.GetComponent<ILightInteractable>();
            Debug.Log(ili);
            if(ili != null)
            {
                ili.onLit();
            }
        }
    }

    public void setRadius(float radius)
    {
        this.radius = radius;
    }
}
