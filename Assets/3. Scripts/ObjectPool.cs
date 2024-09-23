using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab; // 풀에서 사용할 프리팹
    public int initialPoolSize; // 초기 풀 크기

    private List<GameObject> pool = new List<GameObject>();

    private void Start()
    {
        for(int i =0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    //풀에서 비활성화된 오브젝트를 가져옴
    public GameObject GetObject()
    {
        foreach(GameObject obj in pool)
        {
            if(!obj.activeInHierarchy)// 비활성화된 오브젝트를 찾아 반환
            {
                obj.SetActive(true);
                return obj;
            }
        }
        // pool에 있는 루프를 돌때까지 비활성화 되있는 오브젝트를 발견하지 못하면 새로운 오브젝트를 생성하고 반환
        GameObject newobj = Instantiate(objectPrefab);
        newobj.SetActive(true);
        return newobj;
    }

    //오브젝트를 다시 풀로 반환(비활성화)
    public void ReuturnObj(GameObject obj)
    {
        obj.SetActive(false);
    }
}
