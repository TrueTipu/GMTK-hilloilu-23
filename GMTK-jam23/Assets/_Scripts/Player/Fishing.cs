using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


class Fishing : MonoBehaviour
{
    bool canFish;
    bool isFishing;

    public bool IsFishing { get; private set; }

    [SerializeField] FishingUI fishingUI;

    Fish fish;
    public void SetCanFish(bool _value, Fish _fish)
    {
        canFish = _value;
        fish = _fish;
    }

    private void Update()
    {
        if(canFish && Input.GetKeyDown(KeyCode.Space) && !IsFishing)
        {
            StartCoroutine(StartFishing());
        }
    }

    IEnumerator StartFishing()
    {
        IsFishing = true;
        canFish = false;
        Fish.FishData _fishData = fish.GetData();
        float _timer = 0;
        float _length = _fishData.CatchMoment + _fishData.CatchTime;

        fishingUI.Init(_length, _fishData.CatchMoment);

        yield return null;

        while (_timer <= _length)
        {
            if (Input.GetKeyDown(KeyCode.Space)){
                if(_fishData.CatchMoment - _fishData.CatchTime <= _timer)
                {
                    Debug.Log("WOO");
                    break;
                }
                else
                {
                    break;
                }
            }
            _timer += Time.deltaTime;

            yield return null;
        }
        fishingUI.DeActivate();
        IsFishing = false;
        Debug.Log("myöhässä");
    }
}

