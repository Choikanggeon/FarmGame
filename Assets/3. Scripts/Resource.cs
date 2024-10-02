using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    protected string _name;
    protected float _uiEA;
    protected float _ea;
    protected int _price;
    protected int _lastIntegerEA; //이전의 정수형 EA값을 추적


    public string Name
    {
        get {  return _name; }
        set { _name = value; }
    }

    public float EA
    {
        get { return _ea; }
        set { _ea = value; }
    }
    public float UI_EA
    {
        get { return _uiEA; }
        set 
        {
            _uiEA = value;
        }
    }

    public int LastEA
    {
        get { return _lastIntegerEA; }
        set { _lastIntegerEA = value; }
    }


    public int Price
    {
        get { return _price; }
        set { _price = value; }
    }

    // 자원 클릭 시 호출될 메서드
    private void OnMouseDown()
    {
        // 클릭하면 자원이 인벤토리에 추가됨
        EventManager<UIEvents>.TriggerEvent(UIEvents.OnClickRestoreResource, this);
        this.gameObject.SetActive(false);
    }
}
