using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AnimalBuy : MonoBehaviour
{
    public void OnClickBuyChickenButton()
    {
        EventManager<UIEvents>.TriggerEvent(UIEvents.OnClickBuyChickenButton);
    }
}
