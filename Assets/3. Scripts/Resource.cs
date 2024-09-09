using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string resourceType;

    public Resource(string type)
    {
        resourceType = type;
    }
}
