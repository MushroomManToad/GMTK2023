using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.UI.Image;

public class FastBullet : MonoBehaviour, ILightInteractable
{
    [SerializeField]
    private Vector2 dir;
    [SerializeField]
    private int damage;
    [SerializeField]
    private LayerMask playerLayer, groundLayer, crabLayer;

    private bool hasBeenDeflected = false;

    [SerializeField]
    private bool canBeDeflected;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Vector3.Magnitude(dir), playerLayer);
        if (hit && !hasBeenDeflected)
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
            bool flag = false;
            if(hasBeenDeflected)
            {
                RaycastHit2D hit3 = Physics2D.Raycast(transform.position, dir, Vector3.Magnitude(dir), crabLayer);
                if (hit3)
                {
                    CrabHurtbox chb = hit3.collider.gameObject.GetComponent<CrabHurtbox>();
                    if (chb != null)
                    {
                        chb.damage(damage);
                        Destroy(gameObject);
                        flag = true;
                    }
                }
            }
            if(!flag)
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

    }

    public void setDirection(Vector2 dir)
    {
        this.dir = dir;
    }

    public void setDeflected()
    {
        hasBeenDeflected = true;
    }

    public bool isDeflected()
    {
        return hasBeenDeflected;
    }

    public bool canDeflect()
    {
        return canBeDeflected;
    }

    private void deflect()
    {
        setDeflected();
        setDirection(Vector2.up * Vector3.Magnitude(dir));
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
    }

    public void onLit()
    {
        if(!isDeflected() && canBeDeflected)
        {
            deflect();
        }
    }

    public void onUnlit()
    {

    }
}
