using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string resourceType; //가축이 생산하는 자원의 종류

    public Resource(string type)
    {
        resourceType = type;
    }
}
