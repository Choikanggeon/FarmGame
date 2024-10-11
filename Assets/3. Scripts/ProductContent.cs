using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStruct;
using EventLibrary;
using EnumTypes;
using TMPro;

public class ProductContent : MonoBehaviour
{
    [SerializeField] private GameObject productPrefab;
    private TMP_Text _tmpText;

    private Dictionary<string, Resource> productDic;
    private void Awake()
    {
        EventManager<UIEvents>.StartListening<Resource>(UIEvents.OnMouseDownSetProductContent, SetProductContent);
    }

    private void OnDestroy()
    {
        EventManager<UIEvents>.StopListening<Resource>(UIEvents.OnMouseDownSetProductContent, SetProductContent);
    }

    public void SetProductContent(Resource resource)
    {
        if(!productDic.ContainsKey(resource.Data.Name))
        {
            productDic.Add(resource.Data.Name, resource);
            // 자원리스트를 동적 생성
            GameObject product = Instantiate(productPrefab);
            product.GetComponent<SellingProduct>().SetResource(resource);
            
        }
    }
}
