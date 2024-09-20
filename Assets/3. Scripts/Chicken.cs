using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    [SerializeField] private GameObject eggPrefab;

    private void Start()
    {
        productionInterval = 5.0f;
        if (eggPrefab != null)
        {
            resourcePrefab = eggPrefab;
        }

        // Animal 클래스의 초기 상태를 Idle로 설정
        SetState(new IdleState());
    }
}
    


    
