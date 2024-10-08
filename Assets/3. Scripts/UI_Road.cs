using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class UI_Road : MonoBehaviour
{
    [SerializeField] private GameObject truck;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private Sprite truckSprite;
    private Image truckImage; 
    private RectTransform truckRect;
    private float totalTime = 5f;
    private float halfTime;

    private void Awake()
    {
        truckRect = truck.GetComponent<RectTransform>();
        truckImage = truck.GetComponent<Image>();
        halfTime = totalTime / 2;
    }

    private void Start()
    {
        StartCoroutine(MoveTruck());
    }


    private IEnumerator MoveTruck()
    {
        // startPos에서 endPos로 이동
        yield return MoveTruckBetweenPoints(startPos, endPos, halfTime);

        // 트럭 스프라이트 변경
        truckImage.sprite = truckSprite;

        // endPos에서 startPos로 이동
        yield return MoveTruckBetweenPoints(endPos, startPos, halfTime);
    }

    private IEnumerator MoveTruckBetweenPoints(Vector2 start, Vector2 end, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            truckRect.anchoredPosition = Vector2.Lerp(start, end, t);
            yield return null;
        }

        // 마지막 위치를 정확하게 설정
        truckRect.anchoredPosition = end;
    }
}
