using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerHPBar hpBar;
    public PlayerStaminaBar staminaBar;
    public PlayerMovementController pMC;

    public void updateHP(int currHP, int maxHP)
    {
        hpBar.setFill((float)(currHP) / (float)(maxHP));
    }

    public void updateStamina(float currStamina, float maxStamina)
    {
        staminaBar.setFill(currStamina / maxStamina);
    }

    public void setOverheated(bool val)
    {
        staminaBar.setOverheated(val);
        // Sound?
    }
}
