using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenImageFade : MonoBehaviour
{
    [SerializeField]
    private int maxFrames;
    private int frames = 0;

    [SerializeField]
    private Image target;

    bool fadeInFlag = false;

    private void FixedUpdate()
    {
        if(fadeInFlag && frames < maxFrames)
        {
            frames++;
            target.color = new Color(target.color.r, target.color.g, target.color.b, (float) frames / (float) maxFrames);
        }
    }

    public void fadeIn()
    {
        fadeInFlag = true;
    }
}
