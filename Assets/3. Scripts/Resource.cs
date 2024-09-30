using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private string _name;
    private int _ea;
    private int _imageIndex;
    private int _price;
    private int _lastIntegerEA; //이전의 정수형 EA값을 추적


    public string Name
    {
        get {  return _name; }
        set { _name = value; }
    }

    public int EA
    {
        get { return _ea; }
        set 
        {
            int newIntegerEA = Mathf.FloorToInt(value); // 새로운 정수값 계산

            if (newIntegerEA != _lastIntegerEA) //정수값이 변경되었을때만 이벤트 발생
            {
                _ea = value;
                _lastIntegerEA = newIntegerEA;
                EventManager<UIEvents>.TriggerEvent(UIEvents.OnEAChanged, this);
            }
        }
    }
    
    public int ImageIndex
    {
        get { return _imageIndex; }
        set { _imageIndex = value; }
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
