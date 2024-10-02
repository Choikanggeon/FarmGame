using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Resource
{
    private void OnEnable()
    {
        Name = "달걀";
        EA = 1.5f;
        Price = 10;
    }
}
