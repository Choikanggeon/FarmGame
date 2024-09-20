using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SpawnManager : MonoBehaviour
{
    [FoldoutGroup("Animal Prefab")] [SerializeField] private GameObject chickenPrefab;
    [FoldoutGroup("Spawn Points")][SerializeField] private Transform[] spawnPoints; //여러곳의 스폰위치

    private Transform chosenSpawnPoint;
    private int randomIndex;

    private void Awake()
    {
        AddEvent();
    }

    private void AddEvent()
    {
        EventManager<UIEvents>.StartListening(UIEvents.OnClickBuyChickenButton, SpawnChickenMethodTrigger);
        EventManager<SpawnEvents>.StartListening(SpawnEvents.BuyChickenButton_SpawnChicken, SpawnChicken);
    }

    private void RandomSpawn()
    {
        //랜덤하게 스폰 위치 선택
        randomIndex = Random.Range(0, spawnPoints.Length);
        chosenSpawnPoint = spawnPoints[randomIndex];   
    }
    public void SpawnChickenMethodTrigger()
    {
        EventManager<SpawnEvents>.TriggerEvent(SpawnEvents.BuyChickenButton_SpawnChicken);
    }



    public void SpawnChicken()
    {
        RandomSpawn();
        GameObject newChicken = Instantiate(chickenPrefab, chosenSpawnPoint.position, Quaternion.identity);

        Chicken chickenComponent = newChicken.GetComponent<Chicken>();
        if (chickenComponent != null)
        {
            chickenComponent.animalName = "Chicken";
            chickenComponent.resourceType = "Egg";
            chickenComponent.produceTime = 5.0f;
        }
    }
}
