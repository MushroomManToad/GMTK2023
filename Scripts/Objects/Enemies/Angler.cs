using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angler : MonoBehaviour
{
    [SerializeField]
    private Vector2 initialDir;
    [SerializeField]
    private float range;

    private Vector2 facing;

    private int playerScanTimer;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private int bulletFrequency;
    private int bulletTime;

    private void Start()
    {
        facing = initialDir;
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(facing.y, facing.x) * (180.0f / Mathf.PI));
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < range)
        {
            facing = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(facing.y, facing.x) * (180.0f / Mathf.PI));

            if(bulletTime > bulletFrequency)
            {
                bulletTime = 0;
                shoot();
            }

            bulletTime++;
        }
    }

    public void shoot()
    {
        GameObject fastBullet = Instantiate(bullet);
        FastBullet fastBulletScript = fastBullet.GetComponent<FastBullet>();
        Vector2 normVec = facing.normalized;
        if (fastBulletScript != null)
        {
            Vector2 normScaledVec = normVec * bulletSpeed;
            fastBulletScript.setDirection(normScaledVec);
        }
        fastBullet.transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(facing.y, facing.x) * (180.0f / Mathf.PI));
        fastBullet.transform.position = new Vector3(transform.position.x + normVec.x, transform.position.y + normVec.y, 0.0f);
    }
}
