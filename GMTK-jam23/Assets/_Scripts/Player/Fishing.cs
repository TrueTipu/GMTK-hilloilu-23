using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;

class Fishing : TimeAttack
{
    [MenuItem("Dev/Fishing")]
    public static void CatchFishTest()
    {
        FindObjectOfType<Fishing>().SetFishCount(4);
    }
    [SerializeField] int fishCapacity = 10;
    int fishCount;
    public int FishCount { get { return fishCount; } private set { SetFishCount(value);  } }

    int fishCaught = 0;

    [SerializeField]
    int[] mutationFished = new int[3];

    [SerializeField] SpriteRenderer fishPile;
    [SerializeField] Sprite[] sprites;



    public void SetFishCount(int _value)
    {
        fishCount = (int)Mathf.Clamp(_value, 0, fishCapacity);
        fishPile.sprite = sprites[fishCount];
        // PlayerState.Instance.FishCount = (fishCount / (float)fishCapacity);
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

        AudioManager.Instance.Play("OnkiSplash");

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

    public override void RightTiming()
    {
        AudioManager.Instance.Play("OnkiSplash");
        AudioManager.Instance.Play("KalaMumina");
        fishCaught += 1;
        if (fishCaught >= mutationFished[GameManager.Instance.Phase])
        {
            //mutaattikala
            AudioManager.Instance.Play("Kala");
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

    public override void DoStuff()
    {
        StartCoroutine(StartFishing());
    }
}

