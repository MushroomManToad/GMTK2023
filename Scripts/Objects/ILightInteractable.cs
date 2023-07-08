using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILightInteractable
{
    abstract void onLit();

    abstract void onUnlit();
}
