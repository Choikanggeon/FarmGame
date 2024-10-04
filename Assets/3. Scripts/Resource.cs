using EnumTypes;
using EventLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    public ResourceData Data { get; protected set; } = new ResourceData();

    // 자원 클릭 시 호출될 메서드
    public abstract void OnMouseDown();
}


public class ResourceData
{
    protected string _name;
    protected float _uiEA;
    protected float _ea;
    protected int _price;
    protected int _lastIntegerEA; //이전의 정수형 EA값을 추적


    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public float EA
    {
        get { return _ea; }
        set { _ea = value; }
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

}