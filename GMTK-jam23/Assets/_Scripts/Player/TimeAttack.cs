
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public interface Catchable
{
    FishData GetData();
}
public struct FishData
{
    public static FishData Normal => new FishData(0, 0);
    public FishData(float _catchTime, float _catchMoment)
    {
        CatchTime = _catchTime;
        CatchMoment = _catchMoment;
    }

    public float CatchTime { get; private set; }
    public float CatchMoment { get; private set; }
}
abstract class TimeAttack : MonoBehaviour
{
    public bool IsDoingStuff { get; private set; }

    [SerializeField] FishingUI fishingUI;


    Catchable fish;
    bool canFish;
    public void SetCanFish(bool _value, Catchable _fish)
    {
        canFish = _value;
        fish = _fish;
    }


    private void Update()
    {

        if (canFish && Input.GetKeyDown(KeyCode.Space) && !IsDoingStuff)
        {
            StartCoroutine(StartFishing());
        }

    }


    protected IEnumerator StartFishing()
    {
        PlayerState.Instance.SetState(State.Fishing);
        IsDoingStuff = true;
        canFish = false;
        FishData _fishData = fish.GetData();
        float _timer = 0;
        float _length = _fishData.CatchMoment + _fishData.CatchTime;

        fishingUI.Init(_length, _fishData.CatchMoment);

        yield return null;

        while (_timer <= _length)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_fishData.CatchMoment - _fishData.CatchTime <= _timer)
                {

                    RightTiming();
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
        IsDoingStuff = false;
    }

    public abstract void RightTiming();
}

