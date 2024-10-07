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

    // 리소스별 이미지 리스트를 관리하는 딕셔너리
    private Dictionary<string, List<GameObject>> resourceImageLists = new Dictionary<string, List<GameObject>>();


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
        float afterCount = ResourceManager.Instance.GetResourceAfterCounts(resource);
        float beforeCount = ResourceManager.Instance.GetResourceBeforeCounts(resource);

        // 자원 수량의 차이를 구하고 소수점 차이는 올림하여 처리
        int difference = Mathf.FloorToInt(afterCount - Mathf.FloorToInt(beforeCount));

        for (int i = 0; i < difference; i++)
        {
            AddImage(resource);
        }

        ResourceManager.Instance.resourceBeforeCounts[resource.Data.Name] = afterCount;
        Debug.Log($"Updated resourceBeforeCounts for {ResourceManager.Instance.resourceBeforeCounts[resource.Data.Name]} to {afterCount}");
    }

    // 리소스별 이미지를 추가하는 메서드
    private void AddImage(Resource resource)
    {
        if (!resourceImageLists.ContainsKey(resource.Data.Name))
        {
            // 리소스 종류에 대한 리스트가 없으면 새로 생성
            resourceImageLists[resource.Data.Name] = new List<GameObject>();
        }

        // 새로운 이미지 생성 및 추가
        GameObject newImage = Instantiate(UIResourcePrefab, transform);
        DataManager.Instance.LoadResourceFromXM(resource);
        newImage.GetComponent<Image>().sprite = GetResourceSprite(resource);

        // 이미지 리스트에 추가
        resourceImageLists[resource.Data.Name].Add(newImage);

        // 리소스별로 이미지를 연속적으로 배치하기 위해 기존 이미지 뒤에 배치
        int lastSiblingIndex = GetLastSiblingIndexForResource(resource.Data.Name);
        newImage.transform.SetSiblingIndex(lastSiblingIndex + 1);
    }

    private int GetLastSiblingIndexForResource(string resourceName)
    {
        if (resourceImageLists.ContainsKey(resourceName) && resourceImageLists[resourceName].Count > 0)
        {
            // 해당 리소스의 마지막 이미지의 SiblingIndex를 반환
            return resourceImageLists[resourceName][resourceImageLists[resourceName].Count - 1].transform.GetSiblingIndex();
        }
        else
        {
            // 해당 리소스가 처음 추가되는 경우, 현재 자식 개수 반환
            return -1;
        }
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
            Debug.LogWarning("No sprite found for resource: " + resource.Data.Name);
            return null;
        }
    }
    
        
    


}
