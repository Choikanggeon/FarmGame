using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class SellingProduct : MonoBehaviour
{
    [SerializeField] private Sprite productSprite;
    [SerializeField] private TMP_Text productEA;

    private Resource _resource;

    private void Start()
    {
        productSprite = DataManager.Instance.LoadSpriteFromResources(_resource.Data.Name);
        //productEA = ResourceManager.Instance.GetResourceAfterCounts(_resource).ToString();
    }

    public void SetResource(Resource resource)
    {
        _resource = resource;
    }



}
