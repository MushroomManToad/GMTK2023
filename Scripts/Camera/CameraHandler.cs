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

    // 0 --> Lock to player, 1 --> Lock to pos, 2 --> Lock to player with offset
    private int camera_mode = 0;

    private Vector2 playerOffset, target_Pos;

    // Update is called once per frame
    void Update()
    {
        if (camera_mode == 0)
        {
            playerTrack();
        }
        else if (camera_mode == 1)
        {
            posTrack();
        }
        else if (camera_mode == 2)
        {
            playerTrackWithOffset();
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

    public void setCameraMode(int mode)
    {
        this.camera_mode = mode;
    }

    public void setPlayerOffset(Vector2 offset)
    {
        this.playerOffset = offset;
    }

    public void setTargetPos(Vector2 pos)
    {
        this.target_Pos = pos;
    }

    private void posTrack()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;

        if (!lockX)
        {
            float yos = GetComponentInChildren<UnityEngine.Camera>().orthographicSize / 2;
            float height = Screen.currentResolution.height;
            float width = Screen.currentResolution.width;
            float xos = (yos * 2 * width) / height;
            float px = target_Pos.x;
            newX = (px - xos < worldLeft) ? worldLeft + xos : (px + xos > worldRight) ? worldRight - xos : px;
        }
        if (!lockY)
        {
            float yos = GetComponentInChildren<UnityEngine.Camera>().orthographicSize / 2;
            float py = target_Pos.y;
            float cy = GetComponentInChildren<UnityEngine.Camera>().transform.position.y;
            newY = (py - yos < worldMin) ? worldMin + yos : (py + yos > worldMax) ? worldMax - yos : py;
        }

        Vector3 targetPos = new Vector3(newX, newY, transform.position.z);

        float blend = 0.95f;

        transform.position = Vector3.Lerp(targetPos, transform.position, blend);

        Vector2 camPos = new Vector2(transform.position.x, transform.position.y);

        if (Vector3.Distance(camPos, target_Pos) < snapDistance)
        {
            transform.position = new Vector3(target_Pos.x, target_Pos.y, transform.position.z);
        }
    }

    private void playerTrackWithOffset()
    {
        if (toCenter != null)
        {
            PlayerMovementController pmc = toCenter.GetComponent<PlayerMovementController>();
            if (pmc != null)
            {
                if (!pmc.getIsClicking())
                {
                    if (!shouldLerp)
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

                        transform.position = new Vector3(newX + playerOffset.x, newY + playerOffset.y, transform.position.z);
                    }
                    else
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

                        Vector3 targetPos = new Vector3(newX + playerOffset.x, newY + playerOffset.y, transform.position.z);

                        float blend = lerpSpeed;

                        transform.position = Vector3.Lerp(targetPos, transform.position, blend);

                        if (Vector3.Distance(transform.position, targetPos) < snapDistance)
                        {
                            shouldLerp = false;
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

                    transform.position = new Vector3(newX + playerOffset.x, newY + playerOffset.y, transform.position.z);
                }
            }
        }
    }

    private void playerTrack()
    {
        if (toCenter != null)
        {
            PlayerMovementController pmc = toCenter.GetComponent<PlayerMovementController>();
            if (pmc != null)
            {
                if (!pmc.getIsClicking())
                {
                    if (!shouldLerp)
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
                    else
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

                        if (Vector3.Distance(transform.position, targetPos) < snapDistance)
                        {
                            shouldLerp = false;
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
}
