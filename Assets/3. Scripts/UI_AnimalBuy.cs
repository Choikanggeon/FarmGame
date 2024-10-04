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

    public void OnClickBuyPigButton()
    {
        EventManager<UIEvents>.TriggerEvent(UIEvents.OnClickBuyPigButton);
    }

    public void OnClickBuySheepButton()
    {
        EventManager<UIEvents>.TriggerEvent(UIEvents.OnClickBuySheepButton);
    }

    public void OnClickBuyCowButton()
    {
        EventManager<UIEvents>.TriggerEvent(UIEvents.OnClickBuyCowButton);
    }
}
