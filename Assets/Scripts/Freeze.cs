using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : PickUp
{
    public int freezeTime = 5;

    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.FreezeTime(freezeTime);
    }
}
