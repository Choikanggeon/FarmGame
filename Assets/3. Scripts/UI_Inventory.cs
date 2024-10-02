using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Resource와 Sprite의 매핑을 위한 클래스
public class UI_Inventory : MonoBehaviour
{
    public GameObject UIResourcePrefab;

    private List<GameObject> inventory = new List<GameObject>();
    

    private void Awake()
    {
        // EA 변경 이벤트 구독
        EventManager<UIEvents>.StartListening<Resource>(UIEvents.OnEAChanged,OnEAChanged);
    }

    private void OnDestroy()
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
        
        for (int i = 1; i <= resource.UI_EA - resource.LastEA; i++)
        {
            AddImage(resource);
        }
        Debug.Log("Before Update -> UI_EA: " + resource.UI_EA + ", LastEA: " + resource.LastEA);
        resource.LastEA = Mathf.FloorToInt(resource.UI_EA);
        Debug.Log("After Update -> UI_EA: " + resource.UI_EA + ", LastEA: " + resource.LastEA);
    }

    private void AddImage(Resource resource)
    {
        GameObject newImage = Instantiate(UIResourcePrefab, transform);
        DataManager.Instance.LoadResourceFromXM(resource);
        newImage.GetComponent<Image>().sprite = GetResourceSprite(resource);
        inventory.Add(newImage);
    }

    private Sprite GetResourceSprite(Resource resource)
    {
        if (DataManager.Instance.ResourceSpriteDic == null)
        {
            Debug.LogError("ResourceSpriteDic is not initialized!");
            return null;
        }
        if (DataManager.Instance.ResourceSpriteDic.TryGetValue(resource, out var sprite))
        {
            return sprite;
        }
        else
        {
            Debug.LogWarning("No sprite found for resource: " + resource.Name);
            return null;
        }
    }
    
        
    


}
