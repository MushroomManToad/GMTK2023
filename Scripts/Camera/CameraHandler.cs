using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject toCenter;

    public float worldMin, worldMax, worldLeft, worldRight;
    public bool lockX, lockY;

    public float lerpSpeed;

    public float lerpOffset;

    public float snapDistance;

    private bool shouldLerp = false;

    // Update is called once per frame
    void Update()
    {
        if(toCenter != null)
        {
            PlayerMovementController pmc = toCenter.GetComponent<PlayerMovementController>();
            if (pmc != null)
            {
                if (!pmc.getIsClicking())
                {
                    if (!shouldLerp)
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
                                float px = playerTransform.position.x + pmc.getMoveVector().x * lerpOffset;
                                newX = (px - xos < worldLeft) ? worldLeft + xos : (px + xos > worldRight) ? worldRight - xos : px;
                            }
                            if (!lockY)
                            {
                                float yos = GetComponentInChildren<UnityEngine.Camera>().orthographicSize / 2;
                                float py = playerTransform.position.y + pmc.getMoveVector().y * lerpOffset;
                                float cy = GetComponentInChildren<UnityEngine.Camera>().transform.position.y;
                                newY = (py - yos < worldMin) ? worldMin + yos : (py + yos > worldMax) ? worldMax - yos : py;
                            }

                            Vector3 targetPos = new Vector3(newX, newY, transform.position.z);

                            float blend = lerpSpeed;

                            transform.position = Vector3.Lerp(targetPos, transform.position, blend);

                            if(Vector3.Distance(transform.position, targetPos) < snapDistance)
                            {
                                shouldLerp = false;
                            }
                        }
                    }
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
    }

    public void setToCenter(GameObject tC)
    {
        toCenter = tC;
    }

    public void setLerp()
    {
        shouldLerp = true;
    }
}
