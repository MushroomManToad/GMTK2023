using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabHurtbox : MonoBehaviour
{
    [SerializeField]
    private CrabAI crab;

    public void damage(int amount)
    {
        if (crab != null)
        {
            crab.takeDamage();
        }
    }
}
