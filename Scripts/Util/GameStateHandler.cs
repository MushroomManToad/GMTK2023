using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : CustomSingleton<GameStateHandler>
{
    bool onOffOff = false;

    protected GameStateHandler() { }

    public bool getOnOff()
    {
        return onOffOff;
    }

    public void setOnOff(bool onOff)
    {
        onOffOff = onOff;
    }
}
