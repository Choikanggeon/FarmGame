using System.Collections.Generic;
using System.Xml.Linq; //XML 파싱에 필요한 네임스페이스
using UnityEngine;

public class DataManager : SingletonMono<DataManager>
{
    public Dictionary<Resource, Sprite> ResourceSpriteDic { get; private set; }

    private string xmlFilePath = $"{Application.dataPath}/Resources/Resource.xml"; //XML 파일 경로

    private void Awake()
    {
        // 딕셔너리 초기화
        ResourceSpriteDic = new Dictionary<Resource, Sprite>();
    }

    //XML에서 자원과 스프라이트 정보를 불러오는 메서드
    public void LoadResourceFromXM(Resource resource)
    {
        if (ResourceSpriteDic.ContainsKey(resource))
        {
            return;
        }

        // XML 파일 로드
        XDocument doc = XDocument.Load(xmlFilePath);

        // XML에서 <data> 태그를 가진 모든 요소를 가져옴
        var dataElements = doc.Descendants("data");

        foreach (var data in dataElements)
        {
            // XML에서 Name 속성을 읽고, resource.Data.Name과 비교
            if (resource.Data.Name != data.Attribute("Name").Value)
            {
                continue;
            }

            // XML 데이터에서 속성 값들을 가져와서 resource.Data에 저장
            resource.Data.Name = data.Attribute("Name").Value;
            resource.Data.EA = float.Parse(data.Attribute("EA").Value);
            resource.Data.Price = int.Parse(data.Attribute("Price").Value);

            Debug.Log("Resource Name: " + resource.Data.Name);

            // 스프라이트 로드
            Sprite resourceSprite = LoadSpriteFromResources(resource.Data.Name);

            if (resourceSprite != null)
            {
                Debug.Log("Sprite loaded successfully for resource: " + resource.Data.Name);
                ResourceSpriteDic.TryAdd(resource, resourceSprite);
                break;
            }
            else
            {
                Debug.LogWarning("Failed to load sprite for resource: " + resource.Data.Name);
            }
            break; // 해당 리소스를 찾았으므로 반복문 종료
        }
    }

    private Sprite LoadSpriteFromResources(string spriteName)
    {
        return Resources.Load<Sprite>(spriteName);
    }
}
