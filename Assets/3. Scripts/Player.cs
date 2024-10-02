using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{

    private void Awake()
    {
        EventManager<UIEvents>.StartListening<Resource>(UIEvents.OnClickRestoreResource, AddResource);
    }

    public void AddResource(Resource resource)
    {
        resource.UI_EA += resource.EA;
        EventManager<UIEvents>.TriggerEvent(UIEvents.OnEAChanged, resource);
    } 
}
