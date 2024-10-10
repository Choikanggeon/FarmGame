using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : SingletonMono<ResourceManager>
{
    // 각 자원의 수량과 가격을 저장하는 딕셔너리
    public Dictionary<string, float> resourceAfterCounts = new Dictionary<string, float>(); //자원 수량을 더한 후 개수
    public Dictionary<string, float> resourceBeforeCounts = new Dictionary<string, float>(); //자원 수량을 더하기 전 개수
    private Dictionary<string, int> resourceCosts = new Dictionary<string, int>(); // 자원의 총 가격
    public Resource[] Resources;

    private void Awake()
    {
        EventManager<UIEvents>.StartListening<Resource>(UIEvents.OnClickRestoreResource, AddResource);
    }

    private void OnDestroy()
    {
        EventManager<UIEvents>.StopListening<Resource>(UIEvents.OnClickRestoreResource, AddResource);
    }

    private void Start()
    {
        InitializeResourceDic();
    }

    private void InitializeResourceDic()
    {
        foreach (var Resource in Resources)
        {
            string name = Resource.GetType().Name;

            if (!resourceAfterCounts.ContainsKey(name))
            {
                resourceAfterCounts.Add(name, 0);
                resourceBeforeCounts.Add(name, 0);
                resourceCosts.Add(name, 0);
            }
        }
    }

    public void AddResource(Resource resource)
    {
        //자원의 이름을 키로 사용하여 수량과 가격을 업데이트
        if(!resourceAfterCounts.ContainsKey(resource.Data.Name))
        {
            // 만약 자원 키가 딕셔너리에 없으면 초기화
            resourceAfterCounts[resource.Data.Name] = 0;
            resourceBeforeCounts[resource.Data.Name] = 0;
            resourceCosts[resource.Data.Name] = 0;
        }
        
        resourceAfterCounts[resource.Data.Name] += resource.Data.EA;
        resourceCosts[resource.Data.Name] += resource.Data.Price;
        EventManager<UIEvents>.TriggerEvent<Resource>(UIEvents.OnEAChanged, resource);
    }

    // 자원의 수량과 가격을 외부에서 조회하는 메서드
    public float GetResourceAfterCounts(Resource resource)
    {
        return resourceAfterCounts.ContainsKey(resource.Data.Name) ? resourceAfterCounts[resource.Data.Name] : 0;
    }
    public float GetResourceBeforeCounts(Resource resource)
    {
        return resourceBeforeCounts.ContainsKey(resource.Data.Name) ? resourceBeforeCounts[resource.Data.Name] : 0;
    }

    public int GetResourceCosts(Resource resource)
    {
        return resourceCosts.ContainsKey(resource.Data.Name) ? resourceCosts[resource.Data.Name] : 0;
    }
}
