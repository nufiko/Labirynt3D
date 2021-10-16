using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public int time = 5;

    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddTime(time);
    }
}
