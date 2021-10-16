using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{
    public int points = 5;
    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddPoints(points);
    }
}
