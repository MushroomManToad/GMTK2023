using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject toCenter;

    public float worldMin, worldMax, worldLeft, worldRight;
    public bool lockX, lockY;

    public float lerpSpeed;

    // Update is called once per frame
    void Update()
    {
        PlayerMovementController pmc = toCenter.GetComponent<PlayerMovementController>();
        if(pmc != null)
        {
            if (!pmc.getIsClicking())
            {
                float blend = Mathf.Pow(0.5f, Time.deltaTime * lerpSpeed);
                transform.position = Vector3.Lerp(new Vector3(toCenter.transform.position.x, toCenter.transform.position.y, transform.position.z), transform.position, blend);
            }
        }
        else
        {
            if (toCenter != null)
            {
                float newX = transform.position.x;
                float newY = transform.position.y;

                Transform playerTransform = toCenter.transform;

                if (!lockX)
                {
                    float yos = GetComponentInChildren<UnityEngine.Camera>().orthographicSize / 2;
                    float height = Screen.currentResolution.height;
                    float width = Screen.currentResolution.width;
                    float xos = (yos * 2 * width) / height;
                    float px = playerTransform.position.x;
                    newX = (px - xos < worldLeft) ? worldLeft + xos : (px + xos > worldRight) ? worldRight - xos : px;
                }
                if (!lockY)
                {
                    float yos = GetComponentInChildren<UnityEngine.Camera>().orthographicSize / 2;
                    float py = playerTransform.position.y;
                    float cy = GetComponentInChildren<UnityEngine.Camera>().transform.position.y;
                    newY = (py - yos < worldMin) ? worldMin + yos : (py + yos > worldMax) ? worldMax - yos : py;
                }

                transform.position = new Vector3(newX, newY, transform.position.z);
            }
        }
    }

    public void setToCenter(GameObject tC)
    {
        toCenter = tC;
    }
}
