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

    // 자원 클릭 시 호출될 메서드
    private void OnMouseDown()
    {
       // 클릭하면 자원이 인벤토리에 추가됨
       GameManager.Instance.player.AddResource(this);
        Destroy(gameObject);
    }
}
