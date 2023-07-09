
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
    public bool IsDoingStuff { get; protected set; }

    [SerializeField] protected FishingUI fishingUI;


    protected Catchable fish;
    protected bool canFish;
    public void SetCanFish(bool _value, Catchable _fish)
    {
        canFish = _value;
        fish = _fish;
    }


    protected virtual void Update()
    {

        if (canFish && Input.GetKeyDown(KeyCode.Space) && !IsDoingStuff && PlayerState.Instance.GetState() != State.Dying)
        {
            DoStuff();
        }

    }



    public abstract void DoStuff();
    public abstract void RightTiming();
}

