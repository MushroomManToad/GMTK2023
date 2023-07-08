using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaBar : MonoBehaviour
{
    [SerializeField]
    private Image staminaSlider;

    public void setFill(float percentage)
    {
        staminaSlider.fillAmount = percentage;
    }

    public void setOverheated(bool val)
    {
        if (!val)
        {
            staminaSlider.color = Color.white;
        }
        else
        {
            staminaSlider.color = new Color(1.0f, 0.5f, 0.5f);
        }
    }
}
