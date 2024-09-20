using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public interface IAnimalState
{
    void Execute(Animal animal);
}

public class IdleState : IAnimalState
{
    public void Execute(Animal animal)
    {
        if (animal.CanProduce())
        {
            animal.SetState(new ProducingState());
        }
    }
}

public class ProducingState : IAnimalState
{
    public void Execute(Animal animal)
    {
        // 자원 생성 위치
        Transform spawnLocation = animal.transform;
        animal.ProduceResource(spawnLocation); // 프리팹 생성

        // 상태를 다시 Idle로 변경
        animal.SetState(new IdleState());
    }
}

public class Animal : MonoBehaviour
{
    protected float productionInterval = 5.0f;
    private float timer = 0.0f;
    private IAnimalState currentState;

    public GameObject resourcePrefab;

    public void SetState(IAnimalState newState)
    {
        currentState = newState;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        currentState?.Execute(this); // 현재 상태에서 실행
    }

    public bool CanProduce()
    {
        return timer >= productionInterval;
    }
    public void ProduceResource(Transform spawnLocation)
    {
        if (CanProduce())
        {
            Instantiate(resourcePrefab, spawnLocation.position, Quaternion.identity);
            timer = 0.0f; //생산후 타이머 초기화
        }
    }


}
