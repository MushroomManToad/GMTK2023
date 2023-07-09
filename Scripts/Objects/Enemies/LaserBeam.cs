using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sr;
    [SerializeField]
    BoxCollider2D col;

    [SerializeField]
    private float moveSpeed;

    int lifeTimer = 0;

    private void FixedUpdate()
    {
        lifeTimer++;
        if (lifeTimer <= 10)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (float) lifeTimer / 10.0f);
        }
        else if (lifeTimer == 11) 
        {
            col.enabled = true;
        }
        else if (lifeTimer > 59 && lifeTimer < 200)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed, transform.position.z);
        }
        else if (lifeTimer > 200 && lifeTimer < 205)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (float)(205 - lifeTimer) / 5.0f);
            col.enabled = false;
        }
        else if(lifeTimer > 205)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerMovementController>() != null)
        {
            collider.GetComponent<PlayerMovementController>().addHealth(-1);
        }
    }
}
