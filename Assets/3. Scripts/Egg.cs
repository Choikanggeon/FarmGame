using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Resource
{
    private void OnEnable()
    {
        Name = "달걀";
        EA = 2;
        ImageIndex = 1;
        Price = 10;
    }
}
