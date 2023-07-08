using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


class Fishing : TimeAttack
{

    [SerializeField] int fishCapacity = 10;
    int fishCount;
    public int FishCount { get { return fishCount; } private set { SetFishCount(value);  } }

    int fishCaught = 0;

    [SerializeField]
    int[] mutationFished = new int[3];



    public void SetFishCount(int _value)
    {
        fishCount = (int)Mathf.Clamp(_value, 0, fishCapacity);
        PlayerState.Instance.FishCount = (fishCount / (float)fishCapacity);
    }


    public override void RightTiming()
    {
        fishCaught += 1;
        if (fishCaught >= mutationFished[GameManager.Instance.Phase])
        {
            //mutaattikala
            GameManager.Instance.ChangePhase();
            fishCaught = 0;
            FishCount = 0;
        }
        else
        {
            FishCount += 1;
        }
        return;
    }
}

