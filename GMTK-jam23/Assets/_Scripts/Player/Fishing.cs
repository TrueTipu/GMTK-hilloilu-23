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

    [SerializeField] int fishCapacity = 10;
    int fishCount;
    public int FishCount { get { return fishCount; } private set { SetFishCount(value);  } }

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
    public void SetFishCount(int _value)
    {
        fishCount = (int)Mathf.Clamp(_value, 0, fishCapacity);
        PlayerState.Instance.FishCount = (fishCount / (float)fishCapacity);
    }

    IEnumerator StartFishing()
    {
        PlayerState.Instance.SetState(State.Fishing);
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
                    FishCount += 1;
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
    }
}

