using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public KeyColor color;
    public Material red;
    public Material green;
    public Material gold;

    void Start()
    {
        SetMyColor();
    }
    
    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddKey(color);
    }

    private void SetMyColor()
    {
        switch (color)
        {
            case KeyColor.Red:
                GetComponent<Renderer>().material = red;
                break;
            case KeyColor.Green:
                GetComponent<Renderer>().material = green;
                break;
            case KeyColor.Gold:
                GetComponent<Renderer>().material = gold;
                break;
        }
    }
}
