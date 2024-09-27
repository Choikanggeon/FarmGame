using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public GameObject UIResourcePrefab;
    public Dictionary<Resource, Sprite> ResourceSpriteDic;

    private List<GameObject> inventory = new List<GameObject>();
    

    private void OnEnable()
    {
        // EA 변경 이벤트 구독
        EventManager<UIEvents>.StartListening<Resource>(UIEvents.OnEAChanged,OnEAChanged);
    }

    private void OnDisable()
    {
        // EA 변경 이벤트 해제
        EventManager<UIEvents>.StopListening<Resource>(UIEvents.OnEAChanged, OnEAChanged);
    }

    // EA 변경시 실행될 콜백 함수
    private void OnEAChanged(Resource resource)
    {
        AddImages(resource);
    }

    private void AddImages(Resource resource)
    {
        for (int i = 0; i < resource.EA; i++)
        {
            AddImage(resource);
        }
    }

    private void AddImage(Resource resource)
    {
        GameObject newImage = Instantiate(UIResourcePrefab, transform);
        newImage.GetComponent<Image>().sprite = GetResourceSprite(resource);
        inventory.Add(newImage);
    }

    private Sprite GetResourceSprite(Resource resource)
    {
        return ResourceSpriteDic[resource];
    }


}
