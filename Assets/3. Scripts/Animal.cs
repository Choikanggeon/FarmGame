using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Animal
{
    public string animalName;
    public string resourceType;
    public float produceTime; //자원 생산 주기
    private float timer = 0.0f;

    public Animal(string name , string resource , float time)
    {
        animalName = name;
        resourceType = resource;
        produceTime = time;
    }

    public void ProduceResource(List<Resource> resources)
    {
        timer += Time.deltaTime;

        if (timer >= produceTime)
        {
            resources.Add(new Resource(resourceType));
        }
    }
}
