using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLock : MonoBehaviour
{
    public Door[] doors;
    public KeyColor myColor = KeyColor.Red;

    private Lock myLock;

    // Start is called before the first frame update
    void Start()
    {
        myLock = GetComponentInChildren<Lock>();
        myLock.doors = doors;
        myLock.myColor = myColor;
    }
}
