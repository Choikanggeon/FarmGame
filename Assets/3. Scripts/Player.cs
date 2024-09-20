using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Resource> inventory = new List<Resource>();

    public void AddResource(Resource resource)
    {
        inventory.Add(resource);
    }
}
