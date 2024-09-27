using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory
{
    public string productType;

    public Factory(string product)
    {
        productType = product;
    }

    public void ProcessResources(List<Resource> resources)
    {
        // 자원을 가공하여 새로운 제품 생산
        if (resources.Count > 0)
        {
            Resource resource = resources[0];
            resources.RemoveAt(0);
        }
    }
}
