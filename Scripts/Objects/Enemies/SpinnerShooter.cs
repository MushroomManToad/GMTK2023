using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerShooter : MonoBehaviour
{
    [SerializeField]
    private Vector2 initialDir;
    [SerializeField]
    private float range;

    private Vector2 facing;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private int bulletFrequency;
    private int bulletTime;

    [SerializeField]
    private float offsetPerShot;

    private void Start()
    {
        facing = initialDir;
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(facing.y, facing.x) * (180.0f / Mathf.PI));
    }

    private void FixedUpdate()
    {
        if (bulletTime > bulletFrequency)
        {
            bulletTime = 0;
            shoot();
        }

        bulletTime++;
    }

    public void shoot()
    {
        float rad = offsetPerShot * (Mathf.PI / 180.0f);

        transform.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + offsetPerShot);

        facing = transform.right;

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
