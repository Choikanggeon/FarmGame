using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // 싱글톤 패턴을 유지하기 위해 중복된 GameManager를 삭제
        }

        DontDestroyOnLoad(gameObject); // 다른 씬으로 이동해도 GameManager가 유지되도록 설정
    }

    public Player player;
}
