using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    private int gold = 0;

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }
}
