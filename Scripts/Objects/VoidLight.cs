using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidLight : MonoBehaviour
{
    private float radius = 0f;

    private void FixedUpdate()
    {
        // Get all objects
        Collider2D[] overlaps = Physics2D.OverlapCircleAll(transform.position, radius);
        // Update all objects
        foreach (Collider2D collider in overlaps)
        {
            ILightInteractable ili = collider.gameObject.GetComponent<ILightInteractable>();
            if(ili != null)
            {
                ili.onLit();
            }
        }
    }

    public void setRadius(float radius)
    {
        this.radius = radius;
        transform.localScale = new Vector3(radius * 2.0f, radius * 2.0f, 1.0f);
    }
}
