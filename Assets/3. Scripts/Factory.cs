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
        // �ڿ��� �����Ͽ� ���ο� ��ǰ ����
        if (resources.Count > 0)
        {
            Resource resource = resources[0];
            resources.RemoveAt(0);
            Debug.Log("Processed " + resource.resourceType + " into " + productType);
        }
    }
}
