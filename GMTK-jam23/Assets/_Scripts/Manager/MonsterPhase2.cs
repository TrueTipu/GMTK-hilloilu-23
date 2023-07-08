using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

class MonsterPhase2 : MonoBehaviour
{
    [SerializeField] float spawnHeight;

    [SerializeField] float reactTime;

    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    [SerializeField] float minLifeTime;
    [SerializeField] float maxLifeTime;

    [SerializeField] Lonkero longerPrefab;

    List<Lonkero> fishes = new List<Lonkero>();

    void KillFish(Lonkero _fish)
    {
        fishes.Remove(_fish);
        Destroy(_fish.gameObject);
    }
    void SpawnFish()
    {
        Vector2 _pos = new Vector2(UnityEngine.Random.Range(Borders.leftX + 2, Borders.rightX - 2), spawnHeight);
        Lonkero _newFish = Instantiate(longerPrefab, _pos, Quaternion.Euler(0, 0, -90), this.transform);
        _newFish.Init(UnityEngine.Random.Range(minTime, maxTime), reactTime,
            UnityEngine.Random.Range(minLifeTime, maxLifeTime), KillFish);
        fishes.Add(_newFish);
    }

    private void Update()
    {
        if(fishes.Count < 1)
        {
            SpawnFish();
        }
    }


}

