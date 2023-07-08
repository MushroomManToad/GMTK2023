using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField]
    private Image hpSlider;

    public void setFill(float percentage)
    {
        hpSlider.fillAmount = percentage;
    }
}
