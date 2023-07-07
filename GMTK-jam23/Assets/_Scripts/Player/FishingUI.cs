using UnityEngine;
using System.Collections;
using System;

public class FishingUI : MonoBehaviour
{
    [SerializeField] GameObject fishUI;
    [SerializeField] RectTransform circle;
    Vector3 defaultSize;
    [SerializeField] RectTransform targetSize;

    float speed;

    private void Start()
    {
        this.GetComponent<Canvas>().worldCamera = Camera.main;
        defaultSize = circle.sizeDelta;
        fishUI.SetActive(false);
    }

    public void Init(float _length, float _catchMoment)
    {
        circle.sizeDelta = defaultSize;
        speed = ( (circle.sizeDelta.x - targetSize.sizeDelta.x) / _catchMoment);
        fishUI.SetActive(true);
    }
    public void DeActivate()
    {
        fishUI.SetActive(false);
    }

    private void Update()
    {
        if (fishUI.activeSelf)
        {
            circle.sizeDelta -= Vector2.one * speed * Time.deltaTime;
        }
    }
}
