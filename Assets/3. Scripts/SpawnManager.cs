using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SpawnManager : MonoBehaviour
{
    [FoldoutGroup("Animal Prefab")] [SerializeField] private GameObject chickenPrefab;
    [FoldoutGroup("Animal Prefab")][SerializeField] private GameObject pigPrefab;
    [FoldoutGroup("Animal Prefab")][SerializeField] private GameObject sheepPrefab;
    [FoldoutGroup("Animal Prefab")][SerializeField] private GameObject cowPrefab;
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
        EventManager<SpawnEvents>.StartListening(SpawnEvents.SpawnChicken, SpawnChicken);
        EventManager<UIEvents>.StartListening(UIEvents.OnClickBuyPigButton, SpawnPigMethodTrigger);
        EventManager<SpawnEvents>.StartListening(SpawnEvents.SpawnPig, SpawnPig);
        EventManager<UIEvents>.StartListening(UIEvents.OnClickBuySheepButton, SpawnSheepMethodTrigger);
        EventManager<SpawnEvents>.StartListening(SpawnEvents.SpawnSheep, SpawnSheep);
        EventManager<UIEvents>.StartListening(UIEvents.OnClickBuyCowButton, SpawnCowMethodTrigger);
        EventManager<SpawnEvents>.StartListening(SpawnEvents.SpawnCow, SpawnCow);
    }

    private void RandomSpawn()
    {
        //랜덤하게 스폰 위치 선택
        randomIndex = Random.Range(0, spawnPoints.Length);
        chosenSpawnPoint = spawnPoints[randomIndex];   
    }
    public void SpawnChickenMethodTrigger()
    {
        EventManager<SpawnEvents>.TriggerEvent(SpawnEvents.SpawnChicken);
    }

    public void SpawnPigMethodTrigger()
    {
        EventManager<SpawnEvents>.TriggerEvent(SpawnEvents.SpawnPig);
    }

    public void SpawnSheepMethodTrigger()
    {
        EventManager<SpawnEvents>.TriggerEvent(SpawnEvents.SpawnSheep);
    }

    public void SpawnCowMethodTrigger()
    {
        EventManager<SpawnEvents>.TriggerEvent(SpawnEvents.SpawnCow);
    }



    public void SpawnChicken()
    {
        RandomSpawn();
        GameObject newChicken = Instantiate(chickenPrefab, chosenSpawnPoint.position, Quaternion.identity);
    }

    public void SpawnPig()
    {
        RandomSpawn();
        GameObject newPig = Instantiate(pigPrefab, chosenSpawnPoint.position, Quaternion.identity);
    }

    public void SpawnSheep()
    {
        RandomSpawn();
        GameObject newSheep = Instantiate(sheepPrefab, chosenSpawnPoint.position, Quaternion.identity);
    }
    public void SpawnCow()
    {
        RandomSpawn();
        GameObject newCow = Instantiate(cowPrefab, chosenSpawnPoint.position, Quaternion.identity);
    }
}
