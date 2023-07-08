using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

class FishManager : MonoBehaviour
{
    [SerializeField] float spawnHeight;

    [SerializeField] float reactTime;

    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    [SerializeField] float minLifeTime;
    [SerializeField] float maxLifeTime;

    [SerializeField] float minSize;
    [SerializeField] float maxSize;

    [SerializeField] Fish fishPrefab;

    List<Fish> fishes = new List<Fish>();

    void KillFish(Fish _fish)
    {
        fishes.Remove(_fish);
        Destroy(_fish.gameObject);
    }
    void SpawnFish()
    {
        Vector2 _pos = new Vector2(UnityEngine.Random.Range(Borders.leftX + 2, Borders.rightX - 2), spawnHeight);
        Fish _newFish = Instantiate(fishPrefab, _pos, Quaternion.identity, this.transform);
        _newFish.Init(UnityEngine.Random.Range(minSize, maxSize), UnityEngine.Random.Range(minTime, maxTime), reactTime,
            UnityEngine.Random.Range(minLifeTime, maxLifeTime), KillFish);
        fishes.Add(_newFish);
    }

    private void Update()
    {
        if(fishes.Count < 3)
        {
            SpawnFish();
        }
    }


}

