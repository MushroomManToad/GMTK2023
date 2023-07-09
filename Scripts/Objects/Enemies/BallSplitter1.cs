using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSplitter1 : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    int lifeLeft = 150;
    int tick = 1000;

    public bool isSplitter;
    public int tickTime;
    private void FixedUpdate()
    {
        if(tick >= tickTime)
        {

            {
                GameObject ball = Instantiate(ballPrefab);
                ball.transform.position = transform.position;
                FastBullet fb = ball.GetComponent<FastBullet>();
                if (fb != null)
                {
                    fb.setDirection(new Vector2(0.0f, -0.2f));
                }
            }
            if (isSplitter) 
            {
                {
                    GameObject ball = Instantiate(ballPrefab);
                    ball.transform.position = transform.position;
                    FastBullet fb = ball.GetComponent<FastBullet>();
                    if (fb != null)
                    {
                        fb.setDirection(new Vector2(0.2f, -0.2f));
                    }
                }
                {
                    GameObject ball = Instantiate(ballPrefab);
                    ball.transform.position = transform.position;
                    FastBullet fb = ball.GetComponent<FastBullet>();
                    if (fb != null)
                    {
                        fb.setDirection(new Vector2(-0.2f, -0.2f));
                    }
                }
            }
            tick = 0;
        }
        tick++;

        lifeLeft--;
        if(lifeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
