using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextFader : MonoBehaviour
{
    public TextMeshProUGUI text;

    bool startFade = false;

    int inFrames = 50;
    int frames = 100;
    int outFrames = 50;

    int inTimer = 0;
    int outTimer = 0;
    int framesTimer = 0;

    private void FixedUpdate()
    {
        if (startFade)
        {
            if(inTimer < inFrames)
            {
                inTimer++;
                text.color = new Color(text.color.r, text.color.g, text.color.b, ((float) inTimer) / ((float)inFrames));
            }
            else if(framesTimer < frames) 
            {
                framesTimer++;
                
            }
            else if (outTimer < outFrames)
            {
                outTimer++;
                text.color = new Color(text.color.r, text.color.g, text.color.b, ((float)(outFrames - outTimer)) / ((float)outFrames));
            }
            else
            {
                text.enabled = false;
            }
        }
    }

    public void fadeText()
    {
        startFade = true;
    }
}
