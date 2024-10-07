using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Animal
{

    private void Start()
    {
        //자원 생산 시간
        productionInterval = 5.0f;

        // Animal 클래스의 초기 상태를 Idle로 설정
        SetState(new IdleState());
    }

}
