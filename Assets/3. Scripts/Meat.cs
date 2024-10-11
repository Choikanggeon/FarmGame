using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Resource
{
    private void OnEnable()
    {
        Data.Name = "Meat";
        Data.EA = 3f;
        Data.Price = 50;
    }

    public override void OnMouseDown()
    {
        // 클릭하면 자원이 인벤토리에 추가됨
        EventManager<UIEvents>.TriggerEvent<Resource>(UIEvents.OnMouseDownRestoreUIInventory, this);
        EventManager<UIEvents>.TriggerEvent<Resource>(UIEvents.OnMouseDownSetProductContent, this);
        this.gameObject.SetActive(false);
    }
}
