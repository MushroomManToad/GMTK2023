using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.UI.Image;

public class FastBullet : MonoBehaviour
{
    [SerializeField]
    private Vector2 dir;
    [SerializeField]
    private int damage;
    [SerializeField]
    private LayerMask playerLayer, groundLayer;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Vector3.Magnitude(dir), playerLayer);
        if (hit)
        {
            PlayerMovementController pmc = hit.collider.gameObject.GetComponent<PlayerMovementController>();
            if (pmc != null)
            {
                pmc.addHealth(-damage);
                Destroy(gameObject);
            }
        }
        else
        {
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, dir, Vector3.Magnitude(dir), groundLayer);
            if (hit2)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + dir.x, transform.position.y + dir.y, 0.0f);
            }
        }

    }

    public void setDirection(Vector2 dir)
    {
        this.dir = dir;
    }
}
