using UnityEditor;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //하이어라키에서 T타입 객체를 찾아봄
                instance = FindAnyObjectByType<T>();

                //만약 존재하지 않으면 새로 생성
                if (instance == null)
                {
                    var obj = new GameObject(nameof(T));//T타입 이름으로 오브젝트 새로생성
                    instance = obj.AddComponent<T>();

                    DontDestroyOnLoad(obj);// 씬 전환시 파괴되지 않도록 설정
                }
            }
            return instance;
        }
    }
}
