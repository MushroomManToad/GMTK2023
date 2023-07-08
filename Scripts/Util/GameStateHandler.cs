using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : CustomSingleton<GameStateHandler>
{
    bool locked = false;

    bool onOffOff = false;

    protected GameStateHandler() { }

    public bool getOnOff()
    {
        return onOffOff;
    }

    public void setOnOff(bool onOff)
    {
        if( !locked )
        {
            onOffOff = onOff;
        }
    }

    public void setLock()
    {
        locked = true;
    }

    public void releaseLock()
    {
        locked = false;
    }
}
